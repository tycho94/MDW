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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndGameForm));
            this.btLeave = new System.Windows.Forms.Button();
            this.btRestart = new System.Windows.Forms.Button();
            this.lblFinish = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btLeave
            // 
            this.btLeave.BackColor = System.Drawing.Color.Crimson;
            this.btLeave.Location = new System.Drawing.Point(223, 193);
            this.btLeave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btLeave.Name = "btLeave";
            this.btLeave.Size = new System.Drawing.Size(140, 94);
            this.btLeave.TabIndex = 5;
            this.btLeave.Text = "Leave Game";
            this.btLeave.UseVisualStyleBackColor = false;
            this.btLeave.Click += new System.EventHandler(this.btLeave_Click);
            // 
            // btRestart
            // 
            this.btRestart.BackColor = System.Drawing.Color.ForestGreen;
            this.btRestart.Location = new System.Drawing.Point(16, 193);
            this.btRestart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(140, 94);
            this.btRestart.TabIndex = 4;
            this.btRestart.Text = "Restart Game";
            this.btRestart.UseVisualStyleBackColor = false;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinish.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblFinish.Location = new System.Drawing.Point(9, 75);
            this.lblFinish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(92, 38);
            this.lblFinish.TabIndex = 6;
            this.lblFinish.Text = "result";
            // 
            // EndGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.lblFinish);
            this.Controls.Add(this.btLeave);
            this.Controls.Add(this.btRestart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EndGameForm";
            this.Text = "EndGameForm";
            this.Load += new System.EventHandler(this.EndGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLeave;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.Label lblFinish;
    }
}