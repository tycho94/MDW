using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "GameService",
                        CallbackContract = typeof(IGameplayCallback),
                        SessionMode = SessionMode.Required)]
    public interface IGamePlay
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string clientname);
        [OperationContract(IsOneWay = true)]
        void StartGame(string clientname);
        [OperationContract]
        void PauseGame(string clientname);
        [OperationContract]
        void FinishGame();
        [OperationContract(IsOneWay = true)]
        void AnswerQuestion(string clientname, string answer);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string clientname, string message);
        [OperationContract(IsOneWay = true)]
        void AskClientQuestion();

        void ShuffleQuestions();
        Question GetQuestion();
    }

    public interface IGameplayCallback
    {
        [OperationContract]
        void StartNotify();
        [OperationContract]
        void PauseNotify();
        [OperationContract]
        void LeaveNotify();
        [OperationContract(IsOneWay = true)]
        void AskQuestion(string q, List<string> ans);
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string m);
        [OperationContract(IsOneWay = true)]
        void StartClients();
        /// <summary>
        /// Lets the client know who won
        /// </summary>
        /// <param name="result">
        /// 0 = lost
        /// 1 = draw
        /// 2 = win
        /// </param>
        [OperationContract(IsOneWay = true)]
        void FinishNotify(int result, int yourpoints, int theirpoints);
    }

    [DataContract]
    public class Client
    {
        private int points;
        public bool ready;
        [DataMember]
        public string name { get; set; }
        public Client(string name)
        {
            this.name = name;
            points = 0;
        }
        public void incrementpoints()
        {
            points++;
        }
        public int GetPoints()
        {
            return points;
        }
    }
    [DataContract]
    public class Question
    {
        public Question(string qst, List<string> answ, string rAnswer)
        {
            answers = new List<string>();
            foreach (string a in answ)
            {
                answers.Add(a);
            }
            question = qst;
            rightAnswer = rAnswer;
            answers.Add(rightAnswer);
        }
        [DataMember]
        public string question { get; set; }
        [DataMember]
        public List<string> answers { get; set; }
        private string rightAnswer { get; set; }
        public string GetRightAnswer()
        {
            return rightAnswer;
        }
    }
}
