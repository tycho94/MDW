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
        List<question> Questions;
        client client1;//client2;

        question question1 = new question("where is the capital of Netherlands", "Amsterdam");
        question question2 = new question("where is the capital of France", "Pairs");
        

        public CGamePlay()
        {
            question1.Answers.Add("Pairs");
            question1.Answers.Add("Berlin");
            question1.Answers.Add(question1.Rightanswer);

            question2.Answers.Add("Berlin");
            question2.Answers.Add("Amsterdam");
            question2.Answers.Add(question2.Rightanswer);

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
                client1 = new client(clientname);
                
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




        public bool Answerquestion(question q, string answer)
        {
            if (q.Rightanswer == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AnswerQuestion(string clientname, string answer)
        {
            throw new NotImplementedException();
        }

        public string AssignClient()
        {
            throw new NotImplementedException();
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

        public void StartGame(string clientname)
        {
            throw new NotImplementedException();

        }
     


    }
}
