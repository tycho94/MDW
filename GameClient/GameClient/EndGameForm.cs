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

        public Callbacks c;
        private string clientname;
        public EndGameForm(ref Callbacks call, string Clientname)
        {
            InitializeComponent();
            clientname = Clientname;
            c = call;

        }

        private void btLeave_Click(object sender, EventArgs e)
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

        private void btRestart_Click(object sender, EventArgs e)
        {
            c.Restart();
        }

        public void Result(string m)
        {
            lblFinish.Text = m;
        }
        
        public void Disable()
        {
            btRestart.Enabled = false;
        }

        public void Warning(string m)
        {
            MessageBox.Show(m);
        }
    }
}
