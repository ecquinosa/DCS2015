namespace DCS2015.Forms
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.lbContinue = new System.Windows.Forms.LinkLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbContinue
            // 
            this.lbContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContinue.AutoSize = true;
            this.lbContinue.Location = new System.Drawing.Point(404, 111);
            this.lbContinue.Name = "lbContinue";
            this.lbContinue.Size = new System.Drawing.Size(55, 13);
            this.lbContinue.TabIndex = 14;
            this.lbContinue.TabStop = true;
            this.lbContinue.Text = "Continue?";
            this.lbContinue.Visible = false;
            this.lbContinue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbContinue_LinkClicked);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 111);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Ready";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(9, 54);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 21);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "AFPSLAI";
            // 
            // Version
            // 
            this.Version.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version.ForeColor = System.Drawing.Color.Gray;
            this.Version.Location = new System.Drawing.Point(9, 76);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(338, 20);
            this.Version.TabIndex = 10;
            this.Version.Text = "Version {0}.{1:00}";
            // 
            // bg
            // 
            this.bg.WorkerReportsProgress = true;
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBar1.Location = new System.Drawing.Point(9, 127);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(448, 23);
            this.ProgressBar1.TabIndex = 9;
            // 
            // Panel1
            // 
            this.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel1.BackgroundImage")));
            this.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel1.Controls.Add(this.btnClose);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(465, 49);
            this.Panel1.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(400, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "X Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 157);
            this.Controls.Add(this.lbContinue);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.LinkLabel lbContinue;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Version;
        internal System.ComponentModel.BackgroundWorker bg;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Button btnClose;
    }
}