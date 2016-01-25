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
        [OperationContract(IsOneWay = false)]
        bool Connect(string clientname, out bool succes);
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
        [OperationContract(IsOneWay = true)]
        void AnswerNotify(bool correct);
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
        [OperationContract(IsOneWay = true)]
        void Score(string s);
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
        public void Reset()
        {
            points = 0;
            ready = false;
        }
    }
    [DataContract]
    public class Question
    {
        /// <summary>
        /// Question constructor
        /// </summary>
        /// <param name="qst">question string</param>
        /// <param name="ans1">ans1 string</param>
        /// <param name="ans2">ans2 string</param>
        /// <param name="rAnswer">rightanswer string</param>
        public Question(string qst, string ans1, string ans2, string rAnswer)
        {
            rightAnswer = rAnswer;
            answers = new List<string>();
            answers.Add(ans1);
            answers.Add(ans2);
            answers.Add(rightAnswer);
            question = qst;
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
