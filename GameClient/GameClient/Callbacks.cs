using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Media;
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
        private SoundPlayer sp;

        public Callbacks()
        {
            InstanceContext GameClientCallbackInstance = new InstanceContext(this);
            proxy = new GamePlayClient(GameClientCallbackInstance);
        }

        public void SetTriviaForm(TriviaForm form)
        {
            triviaform = form;
            triviaform.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        public void SetStartForm(StartForm form)
        {
            startform = form;
            startform.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        public void SetEndGameForm(EndGameForm form)
        {
            endform = form;
            endform.FormClosed += new FormClosedEventHandler(FormClosed);
        }

        public void StartNotify()
        {
             MessageBox.Show("The other player wants to play a game with you");
        }
        public void PauseNotify()
        {
            triviaform.PauseGame();
        }

        public void LeaveNotify()
        {
            try
            {
                triviaform.Disable();
                endform.Disable();
                endform.Warning("The other player has left the game\nThe game will close now");
                Application.Exit();
            }
            catch
            {
                Application.Exit();
            }
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
            endform.Hide();
        }

        public void FinishNotify(int result, int yourpoints, int theirpoints)
        {
            triviaform.Hide();
            endform.Show();
            if (result == 0)
                endform.Result("You Lost! Score: " + yourpoints + " vs " + theirpoints);
            if (result == 1)
                endform.Result("It's a draw! Score: " + yourpoints + " vs " + theirpoints);
            if (result == 2)
                endform.Result("You win! Score: " + yourpoints + " vs " + theirpoints);
        }
        public void Score(string s)
        {
            triviaform.Score(s);
        }
        public void Restart()
        {
            triviaform.ResetGame();
            triviaform.c.proxy.StartGame(triviaform.clientname);
        }
        void FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                proxy.Close();
            }
            catch (CommunicationException)
            {
                proxy.Abort();
            }
            catch (TimeoutException)
            {
                proxy.Abort();
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }
            Application.Exit();
        }

        public void AnswerNotify(bool correct)
        {
            if (correct)
            {

                sp = new SoundPlayer(@"..\..\resources\answer_right.wav");
            }
            else
            {
                sp = new SoundPlayer(@"..\..\resources\answer_wrong.wav");
            }
            sp.Play();
        }
    }
}
