namespace Splash
{
    partial class Splash
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelLogout = new System.Windows.Forms.Label();
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(322, 429);
            this.label1.MinimumSize = new System.Drawing.Size(163, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 14);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(322, 457);
            this.label2.MinimumSize = new System.Drawing.Size(163, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 14);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(322, 483);
            this.label3.MinimumSize = new System.Drawing.Size(163, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 14);
            this.label3.TabIndex = 2;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLogout
            // 
            this.labelLogout.AutoSize = true;
            this.labelLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLogout.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelLogout.Location = new System.Drawing.Point(721, 23);
            this.labelLogout.Name = "labelLogout";
            this.labelLogout.Size = new System.Drawing.Size(47, 14);
            this.labelLogout.TabIndex = 3;
            this.labelLogout.Text = "LogOut";
            this.labelLogout.Click += new System.EventHandler(this.label4_Click);
            // 
            // timerSplash
            // 
            this.timerSplash.Enabled = true;
            this.timerSplash.Interval = 3000;
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(194)))), ((int)(((byte)(115)))));
            this.BackgroundImage = global::Splash.Properties.Resources.logo_green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.labelLogout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelLogout;
        private System.Windows.Forms.Timer timerSplash;
    }
}