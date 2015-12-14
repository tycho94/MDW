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
        }

        private void btnAns2_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns2.Text);
        }

        private void btnAns3_Click(object sender, EventArgs e)
        {
            c.proxy.AnswerQuestion(clientname, btnAns3.Text);
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {

        }




        //FormControl
        public void Question(string q, List<string> ans)
        {
            lblQuestion.Text = q;
            btnAns1.Text = ans[0];
            btnAns2.Text = ans[1];
            btnAns3.Text = ans[2];
        }
        public void Warning(string w)
        {
            lb_chat.Items.Add(w);
        }
    }
}
