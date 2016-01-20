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

namespace GameClient
{
    public partial class EndGameForm : Form
    {

        Callbacks c;
        private string clientname;
        public EndGameForm(Callbacks call,string Clientname)
        {
            InitializeComponent();
            clientname = Clientname;
            c = call;
            
        }

        private void btLeave_Click(object sender, EventArgs e)
        {

        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            TriviaForm t = new TriviaForm(ref c);
            t.clientname = clientname;
            c.SetTriviaForm(t);
            c.proxy.StartGame(clientname);
           
        }

        public void Result(string m)
        {
            lblFinish.Text = m;
        }

        private void EndGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
