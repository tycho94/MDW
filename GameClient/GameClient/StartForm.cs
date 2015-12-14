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
    public partial class StartForm : Form
    {
        Callbacks c;
        public StartForm(ref Callbacks c)
        {
            InitializeComponent();
            this.c = c;
            btnStart.Visible = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            c.proxy.Connect(tbClientName.Text);
            btnConnect.Visible = false;
            btnStart.Visible = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (c.proxy.CheckStart(tbClientName.Text)){
                TriviaForm t = new TriviaForm(ref c);
                t.clientname = tbClientName.Text;
                c.SetTriviaForm(ref t);
                t.Show();
                Hide();
                c.proxy.StartGame();
            }
        }
    }
}
