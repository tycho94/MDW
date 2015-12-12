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
        string clientname;
        static public Callbacks c;
        public TriviaForm()
        {
            InitializeComponent();
            c = new Callbacks();
        }



        private void TriviaForm_Load(object sender, EventArgs e)
        {

        }



        public void AskQuestion(Question q)
        {
            throw new NotImplementedException();
        }

        private void btnAns1_Click(object sender, EventArgs e)
        {
            label1.Text = c.GetProxy().GetQuestion().question;
            btnAns1.Text = c.GetProxy().GetQuestion().answers[0];
            btnAns2.Text = c.GetProxy().GetQuestion().answers[1];
            btnAns3.Text = c.GetProxy().GetQuestion().answers[2];

        }

        private void btnAns2_Click(object sender, EventArgs e)
        {

        }

        private void btnAns3_Click(object sender, EventArgs e)
        {

        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {

        }
    }
}
