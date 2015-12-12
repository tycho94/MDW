using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace GameService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CGamePlay : IGamePlay
    {
        Timer t;
        List<Question> questions;
        List<IGameplayCallback> clientsCallback;
        Client client1, client2;
        int questionindex;

        public CGamePlay()
        {
            questions = new List<Question>();
            clientsCallback = new List<IGameplayCallback>();
            List<string> tempans = new List<string>();
            tempans.Add("Wrong");
            tempans.Add("Wrong2");
            questions.Add(new Question( "What is the Capital of Netherlands", tempans, "Amsterdam"));
            tempans.Clear();
            tempans.Add("Wrong");
            tempans.Add("Wrong2");
            questions.Add(new Question( "What is the Capital of France", tempans, "Paris"));
            tempans.Clear();
            tempans.Add("Wrong");
            tempans.Add("Wrong2");
            questions.Add(new Question( "What is the Capital of United Kingdom", tempans, "London"));
            questionindex = 0;
        }

        public void StartGame(string clientname)
        {
            if(client1.name == clientname && client2.ready)
            {

            }
        }

        public void AnswerQuestion(string clientname, Question q, string answer)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();

                if (clientname == "Player 1")
                {
                    if(answer == q.GetRightAnswer())
                    {
                        
                    }
                }

                else if (clientname == "Player 2")
                {
                    if (answer == q.GetRightAnswer())
                    {

                    }
                }
        }

        public void ShuffleQuestions()
        {
            Random random = new Random();
            for(int i = questions.Count-1; i > 1; i--)
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
            throw new NotImplementedException();
        }

        public void PauseGame(string clientname)
        {
            throw new NotImplementedException();
        }

        public void FinishGame()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
