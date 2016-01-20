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
    public class Callbacks : IGamePlayCallback
    {
        public GamePlayClient proxy;
        private TriviaForm triviaform;
        private StartForm startform;
        private EndGameForm endform;

        public Callbacks()
        {
            InstanceContext GameClientCallbackInstance = new InstanceContext(this);
            proxy = new GamePlayClient(GameClientCallbackInstance);
        }

        public void SetTriviaForm(TriviaForm form)
        {
            triviaform = form;
        }

        public void SetStartForm(StartForm form)
        {
            startform = form;
        }
        public void SetEndGameForm(EndGameForm form)
        {
            endform = form;
        }

        public void StartNotify()
        {
            MessageBox.Show("The other player wants to play a game with you");
        }
        public void reStartNotify()
        {
            MessageBox.Show("The other player wants to play a gameagain with you again");
        }
        public void PauseNotify()
        {
            triviaform.Warning("The game will pause briefly between questions");
        }

        public void LeaveNotify()
        {
            triviaform.Warning("The other player has left. You won!");
        }

        public void ReceiveMessage(string m)
        {
            triviaform.Warning(m);
        }

        public void AskQuestion(string q, List<string> ans)
        {
            triviaform.Question(q, ans);
        }

        public void StartClients()
        {
            startform.Hide();
            triviaform.Show();
        }

        public void FinishNotify(int result, int yourpoints, int theirpoints,string thisclient)
        {
            endform = new EndGameForm(triviaform.getcall(),thisclient);
            triviaform.Hide();
            endform.Show();

            if (result == 0)
                endform.Result("You Lost! Score: " +yourpoints+ " vs "+theirpoints);
            if (result == 1)
                endform.Result("It's a draw! Score: " + yourpoints + " vs " + theirpoints);
            if (result == 2)
                endform.Result("You win! Score: " + yourpoints + " vs " + theirpoints);
        }
    }
}
