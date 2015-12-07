using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IGameplayCallback))]
    public interface IGamePlay
    {
        [OperationContract]
        void AssignClient();

        [OperationContract]
        void PauseGame();

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
        public string Name { get; set; }

        public Client(string name)
        {
            this.Name = name;
            this.points = 0;
        }
        public void incrementpoints(string c)  //not part of contract
        {
            this.points++;
        }
    }
    [DataContract]
    public class Question
    {
        public Question(int questionno, string quest, string option1, string option2, string option3, string answer)
        {
            Questionno = questionno;
            Quest=quest;
            Option1=option1;
            Option2=option2;
            Option3=option3;
            Answer=answer;
        }

        [DataMember]
        public int Questionno { get; set; }
         [DataMember]
        public string Quest { get; set; }
         [DataMember]
        public string Option1 { get; set; }
         [DataMember]
        public string Option2 { get; set; }
         [DataMember]
        public string Option3 { get; set; }
         [DataMember]
        public string Answer { get; set; }
    }

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
