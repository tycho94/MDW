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
        GamePlayClient gsr;
        string clientname;
        Callbacks c;
        public TriviaForm()
        {
            InitializeComponent();
            gsr = new GamePlayClient();
            c = new Callbacks();
        }



        private void TriviaForm_Load(object sender, EventArgs e)
        {

        }

        void Addclient(string c)
        {
            clientname = c;

        }

        public void AddClient(string s)
        {
            throw new NotImplementedException();
        }

        public void Message(string m)
        {
            lb_chat.Items.Add(m);
        }

        public void AskQuestion(Question q)
        {
            throw new NotImplementedException();
        }

        private void btnAns1_Click(object sender, EventArgs e)
        {
            gsr.StartGame();
            label1.Text = gsr.GetQuestion().question;
            btnAns1.Text = gsr.GetQuestion().answers[0];
            btnAns2.Text = gsr.GetQuestion().answers[1];
            btnAns3.Text = gsr.GetQuestion().answers[2];

        }

        private void btnAns2_Click(object sender, EventArgs e)
        {

        }

        private void btnAns3_Click(object sender, EventArgs e)
        {

        }
    }
}
