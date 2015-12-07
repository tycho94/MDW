using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGamePlay
    {
        [OperationContract]
        void AssignClient();
        [OperationContract]
        void PauseGame();
        [OperationContract]
        Question GetQuestion();

        //  [OperationContract]

        //  void FinishGame();

        // [OperationContract]
        //  void LeaveGame(string clientname);
        [OperationContract]
        void AnswerQuestion(string clientname, Question q, string answer);
        [OperationContract]
        Question ShuffleQuestion();
        [OperationContract]
        void StartGame();

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "GameService.ContractType".

    [DataContract]
    public class Client
    {
        private int points;
        [DataMember]
        public string name { get; set; }
        public Client(string name)
        {
            this.name = name;
            points = 0;
        }
        public void incrementpoints(string c)  //not part of contract
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
        [DataMember]
        private string rightAnswer { get; set; }
        [OperationContract]
        public string GetRightAnswer()
        {
            return rightAnswer;
        }
    }
    /*
    [DataContract]
    public class Answer
    {
        public Answer(int questionno, string player1, string player2)
        {
            Questionno = questionno;
            Player1 = player1;
            Player2 = player2;
        }
        [DataMember]
        public int Questionno { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
    }
    */
    public interface IGameplayCallback
    {
        [OperationContract]
        void AddClient(string s);

        [OperationContract]
        void Message(string m);

        [OperationContract]
        void AskQuestion(Question q);
    }
}
