namespace DCS2015.Forms.UserForms
{
    partial class ucSignatureCapture
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.SigPlusNET1 = new Topaz.SigPlusNET();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chkOverrideSignature = new VIBlend.WinForms.Controls.vCheckBox();
            this.btnDone = new VIBlend.WinForms.Controls.vButton();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnReset = new VIBlend.WinForms.Controls.vButton();
            this.Panel3.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.SigPlusNET1);
            this.Panel3.Location = new System.Drawing.Point(250, 141);
            this.Panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(625, 234);
            this.Panel3.TabIndex = 0;
            // 
            // SigPlusNET1
            // 
            this.SigPlusNET1.BackColor = System.Drawing.Color.White;
            this.SigPlusNET1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SigPlusNET1.ForeColor = System.Drawing.Color.Black;
            this.SigPlusNET1.Location = new System.Drawing.Point(0, 0);
            this.SigPlusNET1.Name = "SigPlusNET1";
            this.SigPlusNET1.Size = new System.Drawing.Size(623, 232);
            this.SigPlusNET1.TabIndex = 107;
            this.SigPlusNET1.Text = "SigPlusNET1";
            this.SigPlusNET1.PenMove += new System.EventHandler(this.SigPlusNET1_PenDown);
            this.SigPlusNET1.PenUp += new System.EventHandler(this.SigPlusNET1_PenUp);
            this.SigPlusNET1.DeviceArrived += new System.EventHandler(this.SigPlusNET1_DeviceArrived);
            this.SigPlusNET1.DeviceRemoved += new System.EventHandler(this.SigPlusNET1_DeviceRemoved);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkOverrideSignature);
            this.pnlMain.Controls.Add(this.btnDone);
            this.pnlMain.Controls.Add(this.txtMsg);
            this.pnlMain.Controls.Add(this.btnReset);
            this.pnlMain.Controls.Add(this.Panel3);
            this.pnlMain.Location = new System.Drawing.Point(1, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1124, 516);
            this.pnlMain.TabIndex = 1;
            // 
            // chkOverrideSignature
            // 
            this.chkOverrideSignature.BackColor = System.Drawing.Color.Transparent;
            this.chkOverrideSignature.Location = new System.Drawing.Point(250, 109);
            this.chkOverrideSignature.Name = "chkOverrideSignature";
            this.chkOverrideSignature.Size = new System.Drawing.Size(115, 26);
            this.chkOverrideSignature.TabIndex = 44;
            this.chkOverrideSignature.Text = "Override Signature";
            this.chkOverrideSignature.UseVisualStyleBackColor = false;
            this.chkOverrideSignature.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.chkOverrideSignature.CheckedChanged += new System.EventHandler(this.chkOverrideSignature_CheckedChanged);
            // 
            // btnDone
            // 
            this.btnDone.AllowAnimations = true;
            this.btnDone.BackColor = System.Drawing.Color.Transparent;
            this.btnDone.Location = new System.Drawing.Point(949, 7);
            this.btnDone.Name = "btnDone";
            this.btnDone.RoundedCornersMask = ((byte)(15));
            this.btnDone.Size = new System.Drawing.Size(77, 32);
            this.btnDone.TabIndex = 8;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Location = new System.Drawing.Point(204, 380);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(717, 34);
            this.txtMsg.TabIndex = 8;
            // 
            // btnReset
            // 
            this.btnReset.AllowAnimations = true;
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(1032, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.RoundedCornersMask = ((byte)(15));
            this.btnReset.Size = new System.Drawing.Size(77, 32);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ucSignatureCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "ucSignatureCapture";
            this.Size = new System.Drawing.Size(1126, 522);
            this.Load += new System.EventHandler(this.ucSignatureCapture_Load);
            this.Resize += new System.EventHandler(this.ucSignatureCapture_Resize);
            this.Panel3.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel3;
        internal Topaz.SigPlusNET SigPlusNET1;
        internal System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Panel pnlMain;
        private VIBlend.WinForms.Controls.vButton btnReset;
        private System.Windows.Forms.TextBox txtMsg;
        private VIBlend.WinForms.Controls.vButton btnDone;
        private VIBlend.WinForms.Controls.vCheckBox chkOverrideSignature;
    }
}
