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
        private Callbacks c;
        public TriviaForm(ref Callbacks call)
        {
            InitializeComponent();
            c = call;
        }

        private void btnAns1_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns1.Text);
            btnDisable();
        }

        private void btnAns2_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns2.Text);
            btnDisable();
        }

        private void btnAns3_Click(object sender, EventArgs e)
        { 
            c.proxy.AnswerQuestion(clientname, btnAns3.Text);
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
        }
        public void Warning(string w)
        {
            lb_chat.Items.Add(w);
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

    }
}
