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
        public TriviaForm()
        {
            InitializeComponent();
            InstanceContext cont = new InstanceContext(this);
            gsr = new GamePlayClient(cont);
            gsr.Open();

            gsr.AssignClient();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void TriviaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
