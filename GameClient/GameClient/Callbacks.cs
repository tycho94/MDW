using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using GameClient.GameServiceReference; 

namespace GameClient
{
    public class Callbacks
    {
        private GamePlayClient proxy;
         

        public Callbacks()
        {
            InstanceContext GameClientCallbackInstance = new InstanceContext(this);
            proxy = new GamePlayClient(GameClientCallbackInstance);
        }

        public GamePlayClient GetProxy() {
            return proxy;
        }
        public void AskQuestion(Question q)
        {
            throw new NotImplementedException();
        }

        public void Message(string m)
        {
            throw new NotImplementedException();
        }
    }
}
