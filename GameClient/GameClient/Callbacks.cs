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
        /// <summary>
        /// notification that the other player wants to start
        /// </summary>
        public void StartNotify()
        {
            MessageBox.Show("The other player wants to play a game with you");
        }
        public void PauseNotify()
        {
            triviaform.PauseGame();
        }
        /// <summary>
        /// Happens when the other player left, endform shows
        /// </summary>
        public void LeaveNotify()
        {
            if (triviaform.Visible)
            {
                triviaform.Visible = false;
                endform.Visible = true;
                endform.Result("The other player left.\nYou win!\nWait for another user");
                triviaform.ResetGame();
            }
        }
        /// <summary>
        /// send message to listbox
        /// </summary>
        /// <param name="m">the message of the server</param>
        public void ReceiveMessage(string m)
        {
            triviaform.Warning(m);
        }
        /// <summary>
        /// Send the question to triviaform
        /// </summary>
        /// <param name="q">question</param>
        /// <param name="ans">answer</param>
        public void AskQuestion(string q, List<string> ans)
        {
            triviaform.Question(q, ans);
        }
        /// <summary>
        /// Start the triviaform
        /// </summary>
        public void StartClients()
        {
            startform.Visible = false;
            triviaform.Visible = true;
            triviaform.BringToFront();
            endform.Visible = false;
        }
        /// <summary>
        /// Sends the result to endform and shows endform
        /// </summary>
        /// <param name="result">0 = loss, 1 = draw, 2 = win</param>
        /// <param name="yourpoints">your points of the game</param>
        /// <param name="theirpoints">opponents points of the game</param>
        public void FinishNotify(int result, int yourpoints, int theirpoints)
        {
            triviaform.Visible = false;
            endform.Visible = true;
            endform.BringToFront();
            if (result == 0)
                endform.Result("You Lost! Score: " + yourpoints + " vs " + theirpoints);
            if (result == 1)
                endform.Result("It's a draw! Score: " + yourpoints + " vs " + theirpoints);
            if (result == 2)
                endform.Result("You win! Score: " + yourpoints + " vs " + theirpoints);
        }
        /// <summary>
        /// sends the score to triviaform
        /// </summary>
        /// <param name="s"></param>
        public void Score(string s)
        {
            triviaform.Score(s);
        }
        /// <summary>
        /// restart the game
        /// </summary>
        public void Restart()
        {
            triviaform.ResetGame();
            triviaform.c.proxy.StartGame(triviaform.clientname);
        }
        /// <summary>
        /// Event called when the form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                sp = new SoundPlayer(@"..\..\resources\answer_right.wav");

            else
                sp = new SoundPlayer(@"..\..\resources\answer_wrong.wav");

            sp.Play();
        }
    }
}
