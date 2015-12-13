﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameClient.GameServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Question", Namespace="http://schemas.datacontract.org/2004/07/GameService")]
    [System.SerializableAttribute()]
    public partial class Question : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> answersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string questionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> answers {
            get {
                return this.answersField;
            }
            set {
                if ((object.ReferenceEquals(this.answersField, value) != true)) {
                    this.answersField = value;
                    this.RaisePropertyChanged("answers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string question {
            get {
                return this.questionField;
            }
            set {
                if ((object.ReferenceEquals(this.questionField, value) != true)) {
                    this.questionField = value;
                    this.RaisePropertyChanged("question");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="GameService", ConfigurationName="GameServiceReference.IGamePlay", CallbackContract=typeof(GameClient.GameServiceReference.IGamePlayCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IGamePlay {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/Connect")]
        void Connect(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/Connect")]
        System.Threading.Tasks.Task ConnectAsync(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/StartGame", ReplyAction="GameService/IGamePlay/StartGameResponse")]
        bool StartGame(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/StartGame", ReplyAction="GameService/IGamePlay/StartGameResponse")]
        System.Threading.Tasks.Task<bool> StartGameAsync(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/PauseGame", ReplyAction="GameService/IGamePlay/PauseGameResponse")]
        void PauseGame(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/PauseGame", ReplyAction="GameService/IGamePlay/PauseGameResponse")]
        System.Threading.Tasks.Task PauseGameAsync(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/FinishGame", ReplyAction="GameService/IGamePlay/FinishGameResponse")]
        void FinishGame();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/FinishGame", ReplyAction="GameService/IGamePlay/FinishGameResponse")]
        System.Threading.Tasks.Task FinishGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/GetQuestion", ReplyAction="GameService/IGamePlay/GetQuestionResponse")]
        GameClient.GameServiceReference.Question GetQuestion();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/GetQuestion", ReplyAction="GameService/IGamePlay/GetQuestionResponse")]
        System.Threading.Tasks.Task<GameClient.GameServiceReference.Question> GetQuestionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/AnswerQuestion", ReplyAction="GameService/IGamePlay/AnswerQuestionResponse")]
        void AnswerQuestion(string clientname, GameClient.GameServiceReference.Question q, string answer);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/AnswerQuestion", ReplyAction="GameService/IGamePlay/AnswerQuestionResponse")]
        System.Threading.Tasks.Task AnswerQuestionAsync(string clientname, GameClient.GameServiceReference.Question q, string answer);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/SendMessage", ReplyAction="GameService/IGamePlay/SendMessageResponse")]
        void SendMessage(string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/SendMessage", ReplyAction="GameService/IGamePlay/SendMessageResponse")]
        System.Threading.Tasks.Task SendMessageAsync(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGamePlayCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/StartNotify", ReplyAction="GameService/IGamePlay/StartNotifyResponse")]
        void StartNotify();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/PauseNotify", ReplyAction="GameService/IGamePlay/PauseNotifyResponse")]
        void PauseNotify();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/LeaveNotify", ReplyAction="GameService/IGamePlay/LeaveNotifyResponse")]
        void LeaveNotify();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/AskQuestion", ReplyAction="GameService/IGamePlay/AskQuestionResponse")]
        void AskQuestion(string q, System.Collections.Generic.List<string> ans);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/ReceiveMessage", ReplyAction="GameService/IGamePlay/ReceiveMessageResponse")]
        void ReceiveMessage(string m);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGamePlayChannel : GameClient.GameServiceReference.IGamePlay, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GamePlayClient : System.ServiceModel.DuplexClientBase<GameClient.GameServiceReference.IGamePlay>, GameClient.GameServiceReference.IGamePlay {
        
        public GamePlayClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GamePlayClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GamePlayClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GamePlayClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GamePlayClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect(string clientname) {
            base.Channel.Connect(clientname);
        }
        
        public System.Threading.Tasks.Task ConnectAsync(string clientname) {
            return base.Channel.ConnectAsync(clientname);
        }
        
        public bool StartGame(string clientname) {
            return base.Channel.StartGame(clientname);
        }
        
        public System.Threading.Tasks.Task<bool> StartGameAsync(string clientname) {
            return base.Channel.StartGameAsync(clientname);
        }
        
        public void PauseGame(string clientname) {
            base.Channel.PauseGame(clientname);
        }
        
        public System.Threading.Tasks.Task PauseGameAsync(string clientname) {
            return base.Channel.PauseGameAsync(clientname);
        }
        
        public void FinishGame() {
            base.Channel.FinishGame();
        }
        
        public System.Threading.Tasks.Task FinishGameAsync() {
            return base.Channel.FinishGameAsync();
        }
        
        public GameClient.GameServiceReference.Question GetQuestion() {
            return base.Channel.GetQuestion();
        }
        
        public System.Threading.Tasks.Task<GameClient.GameServiceReference.Question> GetQuestionAsync() {
            return base.Channel.GetQuestionAsync();
        }
        
        public void AnswerQuestion(string clientname, GameClient.GameServiceReference.Question q, string answer) {
            base.Channel.AnswerQuestion(clientname, q, answer);
        }
        
        public System.Threading.Tasks.Task AnswerQuestionAsync(string clientname, GameClient.GameServiceReference.Question q, string answer) {
            return base.Channel.AnswerQuestionAsync(clientname, q, answer);
        }
        
        public void SendMessage(string message) {
            base.Channel.SendMessage(message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string message) {
            return base.Channel.SendMessageAsync(message);
        }
    }
}
