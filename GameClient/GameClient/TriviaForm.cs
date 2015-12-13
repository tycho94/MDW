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
        GameServiceReference.GamePlayClient proxy;
        string clientname;
        static public Callbacks c;
        int nrq;
       
        public TriviaForm()
        {

            nrq = 0;
            InitializeComponent();
            InstanceContext context=new InstanceContext(this);
            proxy=new GamePlayClient(context);
            Question(proxy.GetQuestion(nrq).question, proxy.GetQuestion(nrq).answers);
            

        }



        private void TriviaForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAns1_Click(object sender, EventArgs e)
        {

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




        //FormControl
        public void Question(string q, List<string> ans)
        {
            lblQuestion.Text = q;
            btnAns1.Text = ans[1];
            btnAns2.Text = ans[2];
            btnAns3.Text = ans[3];
        }
        public void Warning(string w)
        {
            lb_chat.Items.Add(w);
        }
    }
}
