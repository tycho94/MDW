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
        Client client0, client1;
        int qi;
        List<IGameplayCallback> callbacklist;

        public CGamePlay()
        {
            client0 = null;
            client1 = null;
            questions = new List<Question>();
            CreateQuestions();
            ShuffleQuestions();
            qi = 0;
            callbacklist = new List<IGameplayCallback>();
        }

        public void StartGame(string clientname)
        {
            if (client0.name == clientname)
            {
                client0.ready = true;
                if (client1 != null)
                {
                    if (!client1.ready)
                    {
                        callbacklist[1].StartNotify();
                    }
                    else
                    {
                        foreach (IGameplayCallback c in callbacklist)
                        {
                            c.StartClients();
                        }
                        AskClientQuestion();
                        client0.ready = false;
                        client1.ready = false;
                    }
                }
            }
            if (client1 != null)
            {
                if (client1.name == clientname)
                {
                    client1.ready = true;
                    if (client0 != null)
                    {
                        if (!client0.ready)
                        {
                            callbacklist[0].StartNotify();
                        }
                        else
                        {
                            foreach (IGameplayCallback c in callbacklist)
                            {
                                c.StartClients();

                            }
                            AskClientQuestion();
                            client0.ready = false;
                            client1.ready = false;
                        }
                    }
                }
            }
        }

        public void AnswerQuestion(string clientname, string answer)
        {
            if (client0.name == clientname)
            {
                client0.ready = true;
                if (answer == questions[qi - 1].GetRightAnswer())
                    client0.incrementpoints();
                if (qi <= 4)
                {
                    if (client1.ready == true)
                    {
                        AskClientQuestion();
                        if (client0.ready && client1.ready)
                        {
                            callbacklist[0].ReceiveMessage("Score - You: " + client0.GetPoints() + "\tOpponent: " + client1.GetPoints());
                            callbacklist[1].ReceiveMessage("Score - You: " + client1.GetPoints() + "\tOpponent: " + client0.GetPoints());
                        }
                        client0.ready = false;
                        client1.ready = false;
                    }

                }
            }
            if (client1.name == clientname)
            {
                client1.ready = true;
                if (answer == questions[qi - 1].GetRightAnswer())
                    client1.incrementpoints();
                if (qi <= 4)
                {
                    if (client0.ready == true)
                    {
                        AskClientQuestion();
                        if (client0.ready && client1.ready)
                        {
                            callbacklist[0].ReceiveMessage("Score - You: " + client0.GetPoints() + "\tOpponent: " + client1.GetPoints());
                            callbacklist[1].ReceiveMessage("Score - You: " + client1.GetPoints() + "\tOpponent: " + client0.GetPoints());
                        }
                        client0.ready = false;
                        client1.ready = false;
                    }
                }
            }

            if (qi >= 4 && (client0.ready && client1.ready))
                FinishGame();
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
            return questions[qi];
        }

        public void Connect(string clientname)
        {
            IGameplayCallback callback = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();
            if (client0 == null)
            {
                client0 = new Client(clientname);
                callbacklist.Insert(0, callback);
            }
            else if (client1 == null)
            {
                client1 = new Client(clientname);
                callbacklist.Insert(1, callback);
            }
        }


        public void PauseGame(string clientname)
        {
            if (client0.name == clientname)
            {
                callbacklist[1].PauseNotify();
            }
            else
                if (client1.name == clientname)
            {
                callbacklist[0].PauseNotify();
            }
        }

        public void FinishGame()
        {
            if (client0.GetPoints() == client1.GetPoints())
            {
                foreach (IGameplayCallback c in callbacklist)
                    c.FinishNotify(1, client0.GetPoints(), client1.GetPoints());
            }
            if (client0.GetPoints() > client1.GetPoints())
            {
                callbacklist[0].FinishNotify(2, client0.GetPoints(), client1.GetPoints());
                callbacklist[1].FinishNotify(0, client1.GetPoints(), client0.GetPoints());
            }
            if (client0.GetPoints() < client1.GetPoints())
            {
                callbacklist[0].FinishNotify(0, client0.GetPoints(), client1.GetPoints());
                callbacklist[1].FinishNotify(2, client1.GetPoints(), client0.GetPoints());
            }
        }

        public void SendMessage(string clientname, string message)
        {
            foreach (IGameplayCallback c in callbacklist)
            {
                c.ReceiveMessage(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " " + clientname + ": " + message);
            }
        }



        public void AskClientQuestion()
        {
            List<string> ans = questions[qi].answers;
            Random random = new Random();
            for (int i = ans.Count - 1; i > 1; i--)
            {
                int k = random.Next(i + 1);
                string a = ans[k];
                ans[k] = ans[i];
                ans[i] = a;
            }
            foreach (IGameplayCallback c in callbacklist)
            {
                c.AskQuestion(questions[qi].question, ans);
            }
            qi++;
        }

        public void CreateQuestions()
        {
            List<string> ans = new List<string>();
            ans.Add("London");
            ans.Add("Paris");
            questions.Add(new Question("What is the Capital of Netherlands", ans, "Amsterdam"));
            ans.Clear();
            ans.Add("1");
            ans.Add("3");
            questions.Add(new Question("How much is 1+1", ans, "2"));
            ans.Clear();
            ans.Add("12");
            ans.Add("10");
            questions.Add(new Question("What comes after 1-1-2-3-5-8-?", ans, "13"));
            ans.Clear();
            ans.Add("H3O");
            ans.Add("HO2");
            questions.Add(new Question("Which one is water?", ans, "H2O"));
            ans.Clear();
            ans.Add("Washington DC");
            ans.Add("Chicago");
            questions.Add(new Question("Where is the World Trade Center", ans, "New York City"));
        }
    }
}
