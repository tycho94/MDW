using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(   Namespace = "GameService",
                        CallbackContract = typeof(IGameplayCallback),
                        SessionMode = SessionMode.Required)]
    public interface IGamePlay
    {
        [OperationContract(IsOneWay = true)]
        void Connect(string clientname);
        [OperationContract]
        void StartGame(string clientname);
        [OperationContract]
        void PauseGame(string clientname);
        [OperationContract]
        void FinishGame();
        [OperationContract()]
        Question GetQuestion();
        [OperationContract]
        void AnswerQuestion(string clientname, Question q, string answer);
        [OperationContract]
        void SendMessage(string message);
        void ShuffleQuestions();

        
    }

    public interface IGameplayCallback
    {
        [OperationContract]
        void StartNotify();
        [OperationContract]
        void PauseNotify();
        [OperationContract]
        void LeaveNotify();
        [OperationContract]
        void AskQuestion(Question q);
        [OperationContract]
        void ReceiveMessage(string m);
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
        
    }
    [DataContract]
    public class Question
    {
        public Question(string qst, List<string> answ, string rAnswer)
        {
            question = qst;
            answers = answ;
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
