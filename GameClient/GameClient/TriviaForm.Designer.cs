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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_game_score = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lb_chat = new System.Windows.Forms.ListBox();
            this.Timer = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(508, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUETION";
            // 
            // lb_game_score
            // 
            this.lb_game_score.FormattingEnabled = true;
            this.lb_game_score.Location = new System.Drawing.Point(673, 14);
            this.lb_game_score.Name = "lb_game_score";
            this.lb_game_score.Size = new System.Drawing.Size(120, 95);
            this.lb_game_score.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(100, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 100);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Question";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(54, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 122);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Answers";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(275, 355);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(186, 46);
            this.button6.TabIndex = 19;
            this.button6.Text = "Send Message";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(673, 266);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 65);
            this.button5.TabIndex = 18;
            this.button5.Text = "Leave Game";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(522, 266);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 62);
            this.button4.TabIndex = 17;
            this.button4.Text = "Pause game";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lb_chat
            // 
            this.lb_chat.FormattingEnabled = true;
            this.lb_chat.Location = new System.Drawing.Point(54, 243);
            this.lb_chat.Name = "lb_chat";
            this.lb_chat.Size = new System.Drawing.Size(407, 95);
            this.lb_chat.TabIndex = 16;
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.Location = new System.Drawing.Point(51, 11);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(33, 13);
            this.Timer.TabIndex = 15;
            this.Timer.Text = "Timer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(42, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 39);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // TriviaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 413);
            this.Controls.Add(this.lb_game_score);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lb_chat);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TriviaForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TriviaForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_game_score;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lb_chat;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

