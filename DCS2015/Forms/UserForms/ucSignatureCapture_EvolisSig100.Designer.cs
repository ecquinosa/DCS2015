namespace DCS2015.Forms.UserForms
{
    partial class ucSignatureCapture_EvolisSig100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSignatureCapture_EvolisSig100));
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPenwidth = new System.Windows.Forms.ComboBox();
            this.axSTPadCapt1 = new AxSTPadCaptLib.AxSTPadCapt();
            this.lbReset3 = new System.Windows.Forms.LinkLabel();
            this.lbReset2 = new System.Windows.Forms.LinkLabel();
            this.lbReset1 = new System.Windows.Forms.LinkLabel();
            this.picSig3 = new System.Windows.Forms.PictureBox();
            this.picSig2 = new System.Windows.Forms.PictureBox();
            this.picSig1 = new System.Windows.Forms.PictureBox();
            this.chkOverrideSignature = new VIBlend.WinForms.Controls.vCheckBox();
            this.btnDone = new VIBlend.WinForms.Controls.vButton();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnReset = new VIBlend.WinForms.Controls.vButton();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSTPadCapt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSig3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSig2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSig1)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.cboPenwidth);
            this.pnlMain.Controls.Add(this.axSTPadCapt1);
            this.pnlMain.Controls.Add(this.lbReset3);
            this.pnlMain.Controls.Add(this.lbReset2);
            this.pnlMain.Controls.Add(this.lbReset1);
            this.pnlMain.Controls.Add(this.picSig3);
            this.pnlMain.Controls.Add(this.picSig2);
            this.pnlMain.Controls.Add(this.picSig1);
            this.pnlMain.Controls.Add(this.chkOverrideSignature);
            this.pnlMain.Controls.Add(this.btnDone);
            this.pnlMain.Controls.Add(this.txtMsg);
            this.pnlMain.Controls.Add(this.btnReset);
            this.pnlMain.Location = new System.Drawing.Point(1, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1124, 516);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Pen width:";
            // 
            // cboPenwidth
            // 
            this.cboPenwidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPenwidth.FormattingEnabled = true;
            this.cboPenwidth.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "20"});
            this.cboPenwidth.Location = new System.Drawing.Point(791, 164);
            this.cboPenwidth.Name = "cboPenwidth";
            this.cboPenwidth.Size = new System.Drawing.Size(54, 21);
            this.cboPenwidth.TabIndex = 52;
            // 
            // axSTPadCapt1
            // 
            this.axSTPadCapt1.Enabled = true;
            this.axSTPadCapt1.Location = new System.Drawing.Point(525, 194);
            this.axSTPadCapt1.Name = "axSTPadCapt1";
            this.axSTPadCapt1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSTPadCapt1.OcxState")));
            this.axSTPadCapt1.Size = new System.Drawing.Size(320, 160);
            this.axSTPadCapt1.TabIndex = 51;
            this.axSTPadCapt1.SensorHotSpotPressed += new AxSTPadCaptLib._DSTPadCaptEvents_SensorHotSpotPressedEventHandler(this.axSTPadCapt1_SensorHotSpotPressed);
            // 
            // lbReset3
            // 
            this.lbReset3.AutoSize = true;
            this.lbReset3.Location = new System.Drawing.Point(464, 417);
            this.lbReset3.Name = "lbReset3";
            this.lbReset3.Size = new System.Drawing.Size(35, 13);
            this.lbReset3.TabIndex = 50;
            this.lbReset3.TabStop = true;
            this.lbReset3.Text = "Reset";
            this.lbReset3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbReset3_LinkClicked);
            // 
            // lbReset2
            // 
            this.lbReset2.AutoSize = true;
            this.lbReset2.Location = new System.Drawing.Point(464, 295);
            this.lbReset2.Name = "lbReset2";
            this.lbReset2.Size = new System.Drawing.Size(35, 13);
            this.lbReset2.TabIndex = 49;
            this.lbReset2.TabStop = true;
            this.lbReset2.Text = "Reset";
            this.lbReset2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbReset2_LinkClicked);
            // 
            // lbReset1
            // 
            this.lbReset1.AutoSize = true;
            this.lbReset1.Location = new System.Drawing.Point(464, 172);
            this.lbReset1.Name = "lbReset1";
            this.lbReset1.Size = new System.Drawing.Size(35, 13);
            this.lbReset1.TabIndex = 48;
            this.lbReset1.TabStop = true;
            this.lbReset1.Text = "Reset";
            this.lbReset1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbReset1_LinkClicked);
            // 
            // picSig3
            // 
            this.picSig3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSig3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSig3.Location = new System.Drawing.Point(169, 329);
            this.picSig3.Name = "picSig3";
            this.picSig3.Size = new System.Drawing.Size(332, 105);
            this.picSig3.TabIndex = 47;
            this.picSig3.TabStop = false;
            // 
            // picSig2
            // 
            this.picSig2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSig2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSig2.Location = new System.Drawing.Point(169, 206);
            this.picSig2.Name = "picSig2";
            this.picSig2.Size = new System.Drawing.Size(332, 105);
            this.picSig2.TabIndex = 46;
            this.picSig2.TabStop = false;
            // 
            // picSig1
            // 
            this.picSig1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSig1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSig1.Location = new System.Drawing.Point(169, 83);
            this.picSig1.Name = "picSig1";
            this.picSig1.Size = new System.Drawing.Size(332, 105);
            this.picSig1.TabIndex = 45;
            this.picSig1.TabStop = false;
            // 
            // chkOverrideSignature
            // 
            this.chkOverrideSignature.BackColor = System.Drawing.Color.Transparent;
            this.chkOverrideSignature.Location = new System.Drawing.Point(525, 162);
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
            this.btnDone.Visible = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(169, 440);
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
            // ucSignatureCapture_EvolisSig100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "ucSignatureCapture_EvolisSig100";
            this.Size = new System.Drawing.Size(1126, 522);
            this.Load += new System.EventHandler(this.ucSignatureCapture_EvolisSig100_Load);
            this.Resize += new System.EventHandler(this.ucSignatureCapture_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSTPadCapt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSig3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSig2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSig1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Panel pnlMain;
        private VIBlend.WinForms.Controls.vButton btnReset;
        private System.Windows.Forms.TextBox txtMsg;
        private VIBlend.WinForms.Controls.vButton btnDone;
        private VIBlend.WinForms.Controls.vCheckBox chkOverrideSignature;
        private System.Windows.Forms.PictureBox picSig3;
        private System.Windows.Forms.PictureBox picSig2;
        private System.Windows.Forms.PictureBox picSig1;
        private System.Windows.Forms.LinkLabel lbReset3;
        private System.Windows.Forms.LinkLabel lbReset2;
        private System.Windows.Forms.LinkLabel lbReset1;
        private AxSTPadCaptLib.AxSTPadCapt axSTPadCapt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPenwidth;
    }
}
