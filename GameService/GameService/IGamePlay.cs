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
        client StartGameclient(string clientname);

        [OperationContract]
        void AssignClient();

        [OperationContract]
        void PauseGame();

        [OperationContract]

        void FinishGame();

        [OperationContract]
        void LeaveGame(string clientname);

        [OperationContract]
        bool AnswerQuestion(question q, string answer);



        string AssignClient();
        [OperationContract]
        void StartGame(string clientname);
        [OperationContract]
        void PauseGame(string clientname);
        [OperationContract]
        void FinishGame();
        [OperationContract]
        void LeaveGame(string clientname);
        [OperationContract]
        bool AnswerQuestion(string clientname, string answer);
        [OperationContract]
        void Message(string message);


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "GameService.ContractType".

    [DataContract]

    public class question
    {
        [DataMember]
        public string Rightanswer { get; set; }

        [DataMember]
        public string Question { get; set; }

        [DataMember]
        public List<string> Answers
        {
            get;
            set;
        }


        [DataMember]
        public question(string question, string rightanswer)
        {
            this.Rightanswer = rightanswer;
            this.Question = question;
            this.Answers = new List<string>();
        }


    }


    [DataContract]
    public class client
    {
        private int points;


        [DataMember]
        public string Name { get; set; }




        [DataMember]
        public client(string name)
        {
            this.Name = name;
            this.points = 0;
        }

        public void incrementpoints()  //not part of contract
        {
            this.points++;
        }



        public class Question
        {
            public Question(string ques, string[] ans, string ranswer)
            {
                question = ques;
                answers = ans;
                rightanswer = ranswer;
            }
            public string question { get; set; }
            [DataMember]
            public string[] answers { get; set; }
            [DataMember]
            private string rightanswer { get; set; }
            [OperationContract]
            private void ShuffleAnswers()
            {
                //todo
            }




        }
    }
}
