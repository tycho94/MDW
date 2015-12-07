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
    }
}
