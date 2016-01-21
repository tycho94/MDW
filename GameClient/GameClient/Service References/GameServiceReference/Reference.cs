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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="GameService", ConfigurationName="GameServiceReference.IGamePlay", CallbackContract=typeof(GameClient.GameServiceReference.IGamePlayCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IGamePlay {
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/Connect", ReplyAction="GameService/IGamePlay/ConnectResponse")]
        bool Connect(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/Connect", ReplyAction="GameService/IGamePlay/ConnectResponse")]
        System.Threading.Tasks.Task<bool> ConnectAsync(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/StartGame")]
        void StartGame(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/StartGame")]
        System.Threading.Tasks.Task StartGameAsync(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/PauseGame", ReplyAction="GameService/IGamePlay/PauseGameResponse")]
        void PauseGame(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/PauseGame", ReplyAction="GameService/IGamePlay/PauseGameResponse")]
        System.Threading.Tasks.Task PauseGameAsync(string clientname);
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/FinishGame", ReplyAction="GameService/IGamePlay/FinishGameResponse")]
        void FinishGame();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/FinishGame", ReplyAction="GameService/IGamePlay/FinishGameResponse")]
        System.Threading.Tasks.Task FinishGameAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/AnswerQuestion")]
        void AnswerQuestion(string clientname, string answer);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/AnswerQuestion")]
        System.Threading.Tasks.Task AnswerQuestionAsync(string clientname, string answer);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/SendMessage")]
        void SendMessage(string clientname, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string clientname, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/AskClientQuestion")]
        void AskClientQuestion();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/AskClientQuestion")]
        System.Threading.Tasks.Task AskClientQuestionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGamePlayCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/StartNotify", ReplyAction="GameService/IGamePlay/StartNotifyResponse")]
        void StartNotify();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/PauseNotify", ReplyAction="GameService/IGamePlay/PauseNotifyResponse")]
        void PauseNotify();
        
        [System.ServiceModel.OperationContractAttribute(Action="GameService/IGamePlay/LeaveNotify", ReplyAction="GameService/IGamePlay/LeaveNotifyResponse")]
        void LeaveNotify();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/AskQuestion")]
        void AskQuestion(string q, System.Collections.Generic.List<string> ans);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/ReceiveMessage")]
        void ReceiveMessage(string m);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/StartClients")]
        void StartClients();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/FinishNotify")]
        void FinishNotify(int result, int yourpoints, int theirpoints);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="GameService/IGamePlay/Score")]
        void Score(string s);
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
        
        public bool Connect(string clientname) {
            return base.Channel.Connect(clientname);
        }
        
        public System.Threading.Tasks.Task<bool> ConnectAsync(string clientname) {
            return base.Channel.ConnectAsync(clientname);
        }
        
        public void StartGame(string clientname) {
            base.Channel.StartGame(clientname);
        }
        
        public System.Threading.Tasks.Task StartGameAsync(string clientname) {
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
        
        public void AnswerQuestion(string clientname, string answer) {
            base.Channel.AnswerQuestion(clientname, answer);
        }
        
        public System.Threading.Tasks.Task AnswerQuestionAsync(string clientname, string answer) {
            return base.Channel.AnswerQuestionAsync(clientname, answer);
        }
        
        public void SendMessage(string clientname, string message) {
            base.Channel.SendMessage(clientname, message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string clientname, string message) {
            return base.Channel.SendMessageAsync(clientname, message);
        }
        
        public void AskClientQuestion() {
            base.Channel.AskClientQuestion();
        }
        
        public System.Threading.Tasks.Task AskClientQuestionAsync() {
            return base.Channel.AskClientQuestionAsync();
        }
    }
}
