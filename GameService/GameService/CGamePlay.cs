using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.IO;

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
            CreateQuestions(@"..\..\resources\question.txt");
            ShuffleQuestions();
            qi = 0;
            callbacklist = new List<IGameplayCallback>();
        }

        /// <summary>
        /// Starts the game if both clients are ready
        /// </summary>
        /// <param name="clientname">name of client application</param>
        public void StartGame(string clientname)
        {
            if (client0 != null)
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
        /// <summary>
        /// Called by the client to answer the question, then checks answer and awards points
        /// </summary>
        /// <param name="clientname">clientname of your client</param>
        /// <param name="answer">the answer you chose</param>
        public void AnswerQuestion(string clientname, string answer)
        {
            int clientcallback;
            Client c, c2;
            if (client0.name == clientname)
            {
                c = client0;
                c2 = client1;
                clientcallback = 0;
            }
            else
            {
                c = client1;
                c2 = client0;
                clientcallback = 1;
            }

            if (c.name == clientname)
            {
                c.ready = true;
                if (answer == questions[qi - 1].GetRightAnswer())
                {
                    c.incrementpoints();
                    callbacklist[clientcallback].AnswerNotify(true);
                }
                else
                    callbacklist[clientcallback].AnswerNotify(false);

                if (qi < questions.Count)
                {
                    if (c2.ready == true)
                    {
                        AskClientQuestion();

                        callbacklist[0].Score("You: " + c.GetPoints() + " Opponent: " + c2.GetPoints());
                        callbacklist[1].Score("You: " + c2.GetPoints() + " Opponent: " + c.GetPoints());

                        c.ready = false;
                        c2.ready = false;
                    }
                }
            }
            if (qi >= questions.Count && (c.ready && c2.ready))
                FinishGame();
        }
        /// <summary>
        /// Shuffles the questionlist
        /// </summary>
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

        /// <summary>
        /// returns current question
        /// </summary>
        /// <returns></returns>
        public Question GetQuestion()
        {
            return questions[qi];
        }

        /// <summary>
        /// Creates the clients and creates the callback
        /// </summary>
        /// <param name="clientname">name of the new client</param>
        /// <param name="succes">is true if clientcreation is succes</param>
        /// <returns></returns>
        public bool Connect(string clientname, out bool succes)
        {
            succes = false;
            bool returnvalue = false;
            IGameplayCallback callback = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();
            if (client0 == null)
            {
                if (client1 != null)
                    if (client1.name == clientname)
                    {
                        clientname = clientname + "-1";
                        returnvalue = true;
                    }
                client0 = new Client(clientname);
                callbacklist.Insert(0, callback);
                OperationContext.Current.Channel.Faulted += new EventHandler(Channel_Faulted);
                OperationContext.Current.Channel.Closed += new EventHandler(Channel_Faulted);
                succes = true;
            }
            else if (client1 == null)
            {
                if (client0.name == clientname)
                {
                    clientname = clientname + "-1";
                    returnvalue = true;
                }
                client1 = new Client(clientname);
                callbacklist.Insert(1, callback);
                OperationContext.Current.Channel.Faulted += new EventHandler(Channel_Faulted);
                OperationContext.Current.Channel.Closed += new EventHandler(Channel_Faulted);
                succes = true;
            }
            return returnvalue;
        }

        /// <summary>
        /// PauseNotify called back to right client
        /// </summary>
        /// <param name="clientname"></param>
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

        /// <summary>
        /// Identifies if it is a win/lose/draw for both clients & resets the game
        /// </summary>
        public void FinishGame()
        {
            if (client0.GetPoints() == client1.GetPoints())
            {
                callbacklist[0].FinishNotify(2, client0.GetPoints(), client1.GetPoints());
                callbacklist[1].FinishNotify(0, client1.GetPoints(), client0.GetPoints());
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
            qi = 0;
            client0.Reset();
            client1.Reset();
        }
        /// <summary>
        /// sends message to both clients
        /// </summary>
        /// <param name="clientname">The name of the messager</param>
        /// <param name="message">The message</param>
        public void SendMessage(string clientname, string message)
        {
            foreach (IGameplayCallback c in callbacklist)
            {
                c.ReceiveMessage(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " " + clientname + ": " + message);
            }
        }

        /// <summary>
        /// Sends the question to both client callbacks after randomizing answer list
        /// </summary>
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

        /// <summary>
        /// Create the questions from a file
        /// </summary>
        /// <param name="filepath">the path to the file</param>
        public void CreateQuestions(string filepath)
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line;
            while ((line = sr.ReadLine()) != "EXIT")
            {
                List<string> s = line.Split(',').ToList();
                questions.Add(new Question(s[0], s[1], s[2], s[3]));
            }
            sr.Close();
            fs.Close();
        }
        /// <summary>
        /// Method runs when a client disconnect, callback & client reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Channel_Faulted(object sender, EventArgs e)
        {
            try
            {
                callbacklist[0].LeaveNotify();
                callbacklist.RemoveAt(1);
                client1 = null;
                client0.Reset();
            }
            catch
            {
                try
                {
                    callbacklist[1].LeaveNotify();
                    callbacklist.RemoveAt(0);
                    client0 = null;
                    client1.Reset();
                }
                catch
                {
                    callbacklist.Clear();
                    client0 = null;
                    client1 = null;
                }
            }
            qi = 0;
        }
    }
}
