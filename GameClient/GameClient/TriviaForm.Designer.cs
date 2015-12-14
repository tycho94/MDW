namespace GameClient
{
    partial class TriviaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAns1 = new System.Windows.Forms.Button();
            this.btnAns2 = new System.Windows.Forms.Button();
            this.btnAns3 = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lb_game_score = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupQuestion = new System.Windows.Forms.GroupBox();
            this.groupAnswers = new System.Windows.Forms.GroupBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lb_chat = new System.Windows.Forms.ListBox();
            this.groupQuestion.SuspendLayout();
            this.groupAnswers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAns1
            // 
            this.btnAns1.Location = new System.Drawing.Point(11, 38);
            this.btnAns1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAns1.Name = "btnAns1";
            this.btnAns1.Size = new System.Drawing.Size(248, 57);
            this.btnAns1.TabIndex = 0;
            this.btnAns1.Text = "button1";
            this.btnAns1.UseVisualStyleBackColor = true;
            this.btnAns1.Click += new System.EventHandler(this.btnAns1_Click);
            // 
            // btnAns2
            // 
            this.btnAns2.Location = new System.Drawing.Point(352, 38);
            this.btnAns2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAns2.Name = "btnAns2";
            this.btnAns2.Size = new System.Drawing.Size(248, 57);
            this.btnAns2.TabIndex = 1;
            this.btnAns2.Text = "button2";
            this.btnAns2.UseVisualStyleBackColor = true;
            this.btnAns2.Click += new System.EventHandler(this.btnAns2_Click);
            // 
            // btnAns3
            // 
            this.btnAns3.Location = new System.Drawing.Point(677, 38);
            this.btnAns3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAns3.Name = "btnAns3";
            this.btnAns3.Size = new System.Drawing.Size(248, 57);
            this.btnAns3.TabIndex = 2;
            this.btnAns3.Text = "button3";
            this.btnAns3.UseVisualStyleBackColor = true;
            this.btnAns3.Click += new System.EventHandler(this.btnAns3_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(28, 52);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(80, 17);
            this.lblQuestion.TabIndex = 3;
            this.lblQuestion.Text = "QUESTION";
            // 
            // lb_game_score
            // 
            this.lb_game_score.FormattingEnabled = true;
            this.lb_game_score.ItemHeight = 16;
            this.lb_game_score.Location = new System.Drawing.Point(897, 17);
            this.lb_game_score.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_game_score.Name = "lb_game_score";
            this.lb_game_score.Size = new System.Drawing.Size(159, 116);
            this.lb_game_score.TabIndex = 13;
            // 
            // groupQuestion
            // 
            this.groupQuestion.Controls.Add(this.lblQuestion);
            this.groupQuestion.Location = new System.Drawing.Point(133, 14);
            this.groupQuestion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupQuestion.Name = "groupQuestion";
            this.groupQuestion.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupQuestion.Size = new System.Drawing.Size(756, 123);
            this.groupQuestion.TabIndex = 21;
            this.groupQuestion.TabStop = false;
            this.groupQuestion.Text = "Question";
            // 
            // groupAnswers
            // 
            this.groupAnswers.Controls.Add(this.btnAns1);
            this.groupAnswers.Controls.Add(this.btnAns2);
            this.groupAnswers.Controls.Add(this.btnAns3);
            this.groupAnswers.Location = new System.Drawing.Point(72, 142);
            this.groupAnswers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupAnswers.Name = "groupAnswers";
            this.groupAnswers.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupAnswers.Size = new System.Drawing.Size(985, 150);
            this.groupAnswers.TabIndex = 20;
            this.groupAnswers.TabStop = false;
            this.groupAnswers.Text = "Answers";
            this.groupAnswers.Enter += new System.EventHandler(this.groupAnswers_Enter);
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(367, 437);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(248, 57);
            this.btnSendMsg.TabIndex = 19;
            this.btnSendMsg.Text = "Send Message";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(897, 327);
            this.btnLeave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(100, 80);
            this.btnLeave.TabIndex = 18;
            this.btnLeave.Text = "Leave Game";
            this.btnLeave.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(696, 327);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(97, 76);
            this.btnPause.TabIndex = 17;
            this.btnPause.Text = "Pause game";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // lb_chat
            // 
            this.lb_chat.FormattingEnabled = true;
            this.lb_chat.ItemHeight = 16;
            this.lb_chat.Location = new System.Drawing.Point(72, 299);
            this.lb_chat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lb_chat.Name = "lb_chat";
            this.lb_chat.Size = new System.Drawing.Size(541, 116);
            this.lb_chat.TabIndex = 16;
            // 
            // TriviaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 508);
            this.Controls.Add(this.lb_game_score);
            this.Controls.Add(this.groupQuestion);
            this.Controls.Add(this.groupAnswers);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lb_chat);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TriviaForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TriviaForm_Load);
            this.groupQuestion.ResumeLayout(false);
            this.groupQuestion.PerformLayout();
            this.groupAnswers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAns1;
        private System.Windows.Forms.Button btnAns2;
        private System.Windows.Forms.Button btnAns3;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.ListBox lb_game_score;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupQuestion;
        private System.Windows.Forms.GroupBox groupAnswers;
        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ListBox lb_chat;
    }
}

