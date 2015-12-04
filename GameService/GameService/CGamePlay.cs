using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CGamePlay : IGamePlay
    {
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
