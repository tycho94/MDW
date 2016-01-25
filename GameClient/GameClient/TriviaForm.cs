using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using GameClient.GameServiceReference;

namespace GameClient
{
    public partial class TriviaForm : Form
    {
        public string clientname;
        public Callbacks c;
        public int timeleft, pauseleft;
        string q, a1, a2, a3;
        public bool pause = false;
        public TriviaForm(ref Callbacks call)
        {
            InitializeComponent();
            this.
            c = call;
        }

        private void btnAns1_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns1.Text);
            TimerGame.Stop();
            btnDisable();
        }

        private void btnAns2_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns2.Text);
            TimerGame.Stop();
            btnDisable();
        }

        private void btnAns3_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns3.Text);
            TimerGame.Stop();
            btnDisable();
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            c.proxy.SendMessage(clientname, tbMessage.Text);
        }

        //FormControl
        public void Question(string q, List<string> ans)
        {
            lblQuestion.Text = q;
            btnAns1.Text = ans[0];
            btnAns2.Text = ans[1];
            btnAns3.Text = ans[2];
            btnEnable();
            timeleft = 10;
            lblTime.Text = timeleft.ToString();
            TimerGame.Start();
        }
        public void Warning(string w)
        {
            lb_chat.Items.Add(w);
        }
        public void Score(string s)
        {
            lb_game_score.Items.Add(s);
        }

        private void btnDisable()
        {
            btnAns1.Enabled = false;
            btnAns2.Enabled = false;
            btnAns3.Enabled = false;
        }

        private void btnEnable()
        {
            btnAns1.Enabled = true;
            btnAns2.Enabled = true;
            btnAns3.Enabled = true;
        }

        public void ResetGame()
        {
            lblQuestion.Text = "";
            lb_chat.Items.Clear();
            lb_game_score.Items.Clear();
            btnAns1.Text = "";
            btnAns2.Text = "";
            btnAns3.Text = "";
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            try
            {
                c.proxy.Close();
            }
            catch (CommunicationException)
            {
                c.proxy.Abort();
            }
            catch (TimeoutException)
            {
                c.proxy.Abort();
            }
            catch (Exception)
            {
                c.proxy.Abort();
                throw;
            }
            Application.Exit();
        }

        public void Disable()
        {
            btnDisable();
            btnPause.Enabled = false;
            btnSendMsg.Enabled = false;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            PauseGame();
            c.proxy.PauseGame(clientname);
        }

        public void PauseGame()
        {
            q = lblQuestion.Text;
            a1 = btnAns1.Text;
            a2 = btnAns2.Text;
            a3 = btnAns3.Text;
            lblQuestion.Text = "Paused for 5 seconds";
            btnAns1.Text = "";
            btnAns2.Text = "";
            btnAns3.Text = "";
            btnDisable();
            btnPause.Enabled = false;
            TimerGame.Stop();
            
            pauseleft = 5;
            lblTime.Text = pauseleft.ToString();
            t.Start();
        }
        private void t_Tick(object sender, EventArgs e)
        {
            pauseleft--;
            lblTime.Text = pauseleft.ToString();
            if (pauseleft == 0)
            {
                lblTime.Text = timeleft.ToString();
                lblQuestion.Text = q;
                btnAns1.Text = a1;
                btnAns2.Text = a2;
                btnAns3.Text = a3;
                TimerGame.Start();
                t.Stop();
                btnEnable();
                btnPause.Enabled = true;
            }
        }

        private void TimerGame_Tick(object sender, EventArgs e)
        {
            timeleft--;
            lblTime.Text = timeleft.ToString();
            if (timeleft == 0)
                c.proxy.AnswerQuestion(clientname, "");
        }

        private void TriviaForm_Load(object sender, EventArgs e)
        {

        }


    }
}
