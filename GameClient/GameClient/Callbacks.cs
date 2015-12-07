using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameClient.GameServiceReference; 

namespace GameClient
{
    class Callbacks : IGamePlayCallback
    {
        public void AddClient(string s)
        {
            throw new NotImplementedException();
        }

        public void AskQuestion(Question q)
        {
            throw new NotImplementedException();
        }

        public string Message(string m)
        {
            throw new NotImplementedException();
        }
    }
}
