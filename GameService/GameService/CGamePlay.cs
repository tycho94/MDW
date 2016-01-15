using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace GameService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CGamePlay : IGamePlay
    {
        //Timer t;
        List<Question> questions;
        Client client1, client2;
        int questionindex;
        List<IGameplayCallback> callbacklist;
        int userCouter=0;

        public CGamePlay()
        {
            client1 = null;
            client2 = null;
            questions = new List<Question>();
            CreateQuestions();
            ShuffleQuestions();
            questionindex = 0;
            callbacklist = new List<IGameplayCallback>();
        }

        public void StartGame(string clientname)
        {
            if (client1.name == clientname)
            {
                client1.ready = true;
                if (client2 != null)
                {
                    if (!client2.ready)
                    {
                        callbacklist[1].StartNotify();
                    }
                    else
                    {
                        foreach (IGameplayCallback c in callbacklist)
                        {
                            c.StartClients();
                            c.AskQuestion(questions[questionindex].question, questions[questionindex].answers);
                        }
                        client1.ready = false;
                        client2.ready = false;
                    }
                }
            }
            if (client2 != null)
            {
                if (client2.name == clientname)
                {
                    client2.ready = true;
                    if (client1 != null)
                    {
                        if (!client1.ready)
                        {
                            callbacklist[0].StartNotify();
                        }
                        else
                        {
                            foreach (IGameplayCallback c in callbacklist)
                            {
                                c.StartClients();
                                c.AskQuestion(questions[questionindex].question, questions[questionindex].answers);
                                
                            }
                            client1.ready = false;
                            client2.ready = false;
                           
                        }
                    }
                }
            }
        }

        public void AnswerQuestion(string clientname, string answer)
        {
            if (client1.name==clientname)
            {
                client1.ready=true;
                if(client2.ready==true)
                {
                    questionindex++;
                    AskClientQuestion();
                    client1.ready=false;
                    client2.ready=false;
                }

            }
            if (client2.name == clientname)
            {
                client2.ready = true;
                if (client1.ready ==true)
                {
                    questionindex++;
                    AskClientQuestion();
                    client1.ready = false;
                    client2.ready = false;
                }
            }
            MessageBox.Show(questionindex.ToString());
            
               
        
          
        }

        public void ShuffleQuestions()
        {
            Random random = new Random();
            for (int i = questions.Count - 1; i > 1; i--)
            {
                int k = random.Next(i + 1);
                Question q = questions[k];
                questions[k] = questions[i];
                questions[i] = q;
            }
        }

        public Question GetQuestion()
        {
            return questions[questionindex];
        }

        public void Connect(string clientname)
        {
            IGameplayCallback callback = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();
            if (client1 == null)
            {
                client1 = new Client(clientname);
                callbacklist.Insert(0, callback);
            }
            else if (client2 == null)
            {
                client2 = new Client(clientname);
                callbacklist.Insert(1, callback);
            }
        }


        public void PauseGame(string clientname)
        {
            if (client1.name == clientname)
            {
                callbacklist[1].PauseNotify();
            }
            else
                if (client2.name == clientname)
            {
                callbacklist[0].PauseNotify();
            }
        }

        public void FinishGame()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string clientname, string message)
        {
            foreach (IGameplayCallback c in callbacklist)
            {
                c.ReceiveMessage(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " " + clientname + ": " + message);
            }
        }

        public void CreateQuestions()
        {
            List<string> ansA = new List<string>();
            ansA.Add("Wrong1");
            ansA.Add("Wrong2");
            questions.Add(new Question("What is the Capital of Netherlands", ansA, "Amsterdam"));
            List<string> ansB = new List<string>();
            ansB.Add("Wrong1");
            ansB.Add("Wrong2");
            questions.Add(new Question("What is the Capital of France", ansB, "Paris"));
            List<string> ansC = new List<string>();
            ansC.Add("Wrong1");
            ansC.Add("Wrong2");
            questions.Add(new Question("What is the Capital of United Kingdom", ansC, "London"));
        }

        public void AskClientQuestion()
        {
            foreach (IGameplayCallback c in callbacklist)
                c.AskQuestion(questions[questionindex].question, questions[questionindex].answers);
        }
    }
}
