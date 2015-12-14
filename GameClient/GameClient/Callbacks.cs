using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameClient.GameServiceReference;

namespace GameClient
{
    public class Callbacks : TriviaForm, IGamePlayCallback
    {
        private GamePlayClient proxy;

        public Callbacks(TriviaForm form)
        {
            InstanceContext GameClientCallbackInstance = new InstanceContext(this);
            proxy = new GamePlayClient(GameClientCallbackInstance);
        }

        public GamePlayClient GetProxy()
        {
            return proxy;
        }

        public void StartNotify()
        {
            MessageBox.Show("The other player wants to play a game with you");
        }

        public void PauseNotify()
        {
            Warning("The game will pause briefly between questions");
        }

        public void LeaveNotify()
        {
            Warning("The other player has left. You won!");
        }

        public void ReceiveMessage(string m)
        {
            Warning(m);
        }

        public void AskQuestion(string q, List<string> ans)
        {
            Question(q, ans);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Callbacks
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Callbacks";
            this.Load += new System.EventHandler(this.Callbacks_Load);
            this.ResumeLayout(false);

        }

        private void Callbacks_Load(object sender, EventArgs e)
        {

        }
    }
}
