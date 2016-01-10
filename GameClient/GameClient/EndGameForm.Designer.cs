namespace GameClient
{
    partial class EndGameForm
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
            this.btLeave = new System.Windows.Forms.Button();
            this.btRestart = new System.Windows.Forms.Button();
            this.pbWinLose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWinLose)).BeginInit();
            this.SuspendLayout();
            // 
            // btLeave
            // 
            this.btLeave.Location = new System.Drawing.Point(167, 157);
            this.btLeave.Name = "btLeave";
            this.btLeave.Size = new System.Drawing.Size(105, 76);
            this.btLeave.TabIndex = 5;
            this.btLeave.Text = "Leave Game";
            this.btLeave.UseVisualStyleBackColor = true;
            this.btLeave.Click += new System.EventHandler(this.btLeave_Click);
            // 
            // btRestart
            // 
            this.btRestart.Location = new System.Drawing.Point(12, 157);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(105, 76);
            this.btRestart.TabIndex = 4;
            this.btRestart.Text = "Restart Game";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // pbWinLose
            // 
            this.pbWinLose.Location = new System.Drawing.Point(60, 28);
            this.pbWinLose.Name = "pbWinLose";
            this.pbWinLose.Size = new System.Drawing.Size(145, 98);
            this.pbWinLose.TabIndex = 3;
            this.pbWinLose.TabStop = false;
            // 
            // EndGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btLeave);
            this.Controls.Add(this.btRestart);
            this.Controls.Add(this.pbWinLose);
            this.Name = "EndGameForm";
            this.Text = "EndGameForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbWinLose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btLeave;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.PictureBox pbWinLose;
    }
}