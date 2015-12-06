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
        public TriviaForm()
        {
            InitializeComponent();
            InstanceContext cont = new InstanceContext(this);
            gsr = new GamePlayClient(cont);
           

            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
        private void TriviaForm_Load(object sender, EventArgs e)
        {
            gsr.StartGame();
            label1.Text=gsr.ShuffleQuestion().Quest;

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        void Addclient(string c)
        {
            clientname = c;

        }
    }
}
