using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CGamePlay : IGamePlay
    {

        Timer countTimer;
        List<Question> Questions;
        Client client1;//client2;

        Question question1, question2;


        public CGamePlay()
        {
            List<string> Answers = new List<string>();
            Answers.Add("Pairs");
            Answers.Add("Berlin");
            question1 = new Question("where is the capital of Netherlands", Answers, "Amsterdam");
            question1.answers.Add(question1.rightAnswer);

            Answers.Clear();
            Answers.Add("Berlin");
            Answers.Add("Amsterdam");
            question2 = new Question("where is the capital of France", Answers, "Pairs");


            countTimer = new Timer();
            countTimer.Interval = 10000;

            Questions.Add(question1);
            Questions.Add(question2);

            client1 = null;
            // client2 = null;
        }


        public void StartGame(string clientname)
        {
            if (client1 == null)
            {
                client1 = new Client(clientname);

            }
            //else
            //{
            // client2 = new client(clientname);


            //}
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

        public bool AnswerQuestion(string clientname, Question q, string answer)
        {
            if (q.rightAnswer == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void FinishGame()
        {
            throw new NotImplementedException();
        }

        public void LeaveGame(string clientname)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
            throw new NotImplementedException();
        }

        public void PauseGame(string clientname)
        {
            throw new NotImplementedException();
        }



    }
}
