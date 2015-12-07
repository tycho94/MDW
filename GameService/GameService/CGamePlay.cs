using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace GameService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CGamePlay : IGamePlay
    {

       // Timer countTimer;
        List<Question> Questions;
        List<IGameplayCallback> clientsCallback;
       // List<Question> RemainingQuestions;
        List<Client> clients;
        List<Answer> answers;

        
        public CGamePlay()
        {
            Questions = new List<Question>();
            clientsCallback = new List<IGameplayCallback>();
            answers = new List<Answer>();
            clients = new List<Client>();
            Questions.Add(new Question(1, "What is the Capital of Netherlands", "Amsterdam", "Eindhoven", "Den Haag","Amsterdam"));
            Questions.Add(new Question(2, "What is the Capital of France", "Nice", "Paris", "Lyon", "Paris"));
            Questions.Add(new Question(3, "What is the Capital of United Kingdom", "Bristol", "Kent", "Llondon", "London"));
        }
        
        public void StartGame()
        {
            var connection = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();

            if (clientsCallback.Count == 0)
            {
                clientsCallback.Add(OperationContext.Current.GetCallbackChannel<IGameplayCallback>());
                connection.Message("You are Player 1");
                connection.AddClient("Player 1");
                clients.Add(new Client("Player 1"));
            }
            else if (clientsCallback.Count == 1)
            {
                clientsCallback.Add(OperationContext.Current.GetCallbackChannel<IGameplayCallback>());
                connection.Message("You are Player 2");
                connection.AddClient("Player 2");
                clients.Add(new Client("Player 2"));
                
            }
            else
            {
                connection.AddClient("full");
            }
        }

        public void AssignClient() // not sure about does it very nescessary to have this fucntion
        {

        }

        public void PauseGame()
        {

        }

        public void finishGame()
        {

        }

        public void LeaveGame()
        {
        }

        public void AnswerQuestion(string clientname, Question q, string answer)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();
          
           //add player answer to list
            
            foreach (Answer a in answers)

            if (clientname=="Player 1" && a.Player1 == null)
            {
              answers.Add(new Answer(q.Questionno, "Y", ""));
            }

            else if (clientname == "Player 2" && a.Player2 == null)
            {
                answers.Add(new Answer(q.Questionno, "", "Y"));
            }

            // check if second player has played. if not send a message to everybody to notify that someone has not played.
           foreach (Answer a in answers)
            {
                if (a.Questionno == q.Questionno && a.Player1 == clientname && a.Player2==null)
                {
                    connection.Message("Player 2 has not played.");
                }

                else if (a.Questionno == q.Questionno && a.Player2 == clientname && a.Player1 == null)
                {
                    connection.Message("Player 1 has not played.");
                }
                
                else check(clientname,  q,  answer);
            }
        }
        

            public void check(string clientname, Question q, string answer)
            {

            foreach (Question ques in Questions)
            {
                if (ques.Answer == answer)
                {
                    foreach (Client players in clients)
                    {
                        players.incrementpoints(clientname);
                        foreach( IGameplayCallback igc in clientsCallback)
                        {
                            igc.AskQuestion(ShuffleQuestion());
                        }
                    }

                }

            }


        }

         
        public Question ShuffleQuestion()
            {

                Random random = new Random();
                int nextquestion = random.Next() % Questions.Count;
                Question c = Questions.ElementAt<Question>(nextquestion);
                //Qs.Remove(c);
                return c;
                
               
           }
        



    }
}
