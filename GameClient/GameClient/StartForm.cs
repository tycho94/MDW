﻿using System;
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
        public Callbacks c;
        public StartForm(ref Callbacks c)
        {
            InitializeComponent();
            this.c = c;
            btnStart.Visible = false;
            c.SetStartForm(this);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool execute;
            if (c.proxy.Connect(tbClientName.Text, out execute))
                tbClientName.Text = tbClientName.Text + "-1";
            if (execute)
            {
                tbClientName.Enabled = false;
                btnConnect.Visible = false;
                btnStart.Visible = true;
            }
            else
            {
                MessageBox.Show("2 clients already connected");
                tbClientName.Enabled = false;
                btnConnect.Visible = false;
                btnStart.Visible = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            EndGameForm z = new EndGameForm(ref c, tbClientName.Text);
            TriviaForm t = new TriviaForm(ref c);
            t.clientname = tbClientName.Text;
            c.SetEndGameForm(z);
            c.SetTriviaForm(t);
            c.proxy.StartGame(tbClientName.Text);
            btnStart.Enabled = false;
        }
    }
}
