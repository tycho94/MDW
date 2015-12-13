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
        Client client1, client2;
        int questionindex;

        public CGamePlay()
        {
            client1 = null;
            client2 = null;
            questions = new List<Question>();
            CreateQuestions();
            questionindex = 0;
        }

        public bool StartGame(string clientname)
        {
            if (client1.name == clientname && client2.ready)
            {
                return true;
            }
            else
            if (client2.name == clientname && client1.ready)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AnswerQuestion(string clientname, Question q, string answer)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IGameplayCallback>();

            if (clientname == "Player 1")
            {
                if (answer == q.GetRightAnswer())
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
            return questions[0];
        }

        public void Connect(string clientname)
        {
            if (client1 == null)
            {
                client2 = new Client(clientname);
            }
            else
                client1 = new Client(clientname);
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
    }
}
