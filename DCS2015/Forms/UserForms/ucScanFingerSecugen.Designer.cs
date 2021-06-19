namespace DCS2015.Forms.UserForms
{
    partial class ucScanFingerSecugen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucScanFingerSecugen));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCollectedTemplates = new System.Windows.Forms.Panel();
            this.chkFingerType_RP = new System.Windows.Forms.CheckedListBox();
            this.pbRightThumbTemplate = new System.Windows.Forms.PictureBox();
            this.chkFingerType_RB = new System.Windows.Forms.CheckedListBox();
            this.lblRightPrimaryTemplate = new System.Windows.Forms.Label();
            this.chkFingerType_LB = new System.Windows.Forms.CheckedListBox();
            this.lblRightThumbTemplate = new System.Windows.Forms.Label();
            this.chkFingerType_LP = new System.Windows.Forms.CheckedListBox();
            this.lblLeftThumbTemplate = new System.Windows.Forms.Label();
            this.lblLeftPrimaryTemplate = new System.Windows.Forms.Label();
            this.pbRightPrimaryTemplate = new System.Windows.Forms.PictureBox();
            this.pbLeftPrimaryTemplate = new System.Windows.Forms.PictureBox();
            this.pbLeftThumbTemplate = new System.Windows.Forms.PictureBox();
            this.btnSequenceCapture = new VIBlend.WinForms.Controls.vButton();
            this.btnReset = new VIBlend.WinForms.Controls.vButton();
            this.pnlLiveScan = new System.Windows.Forms.Panel();
            this.pbBlinking = new System.Windows.Forms.PictureBox();
            this.lblQuality = new System.Windows.Forms.Label();
            this.vScroll_Quality = new VIBlend.WinForms.Controls.vVScrollBar();
            this.textQuality = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlCollectedTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightThumbTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightPrimaryTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftPrimaryTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftThumbTemplate)).BeginInit();
            this.pnlLiveScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlinking)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtQT);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.pnlCollectedTemplates);
            this.pnlMain.Controls.Add(this.btnSequenceCapture);
            this.pnlMain.Controls.Add(this.btnReset);
            this.pnlMain.Controls.Add(this.pnlLiveScan);
            this.pnlMain.Location = new System.Drawing.Point(1, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1124, 516);
            this.pnlMain.TabIndex = 2;
            // 
            // txtQT
            // 
            this.txtQT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQT.Location = new System.Drawing.Point(154, 15);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(52, 23);
            this.txtQT.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Quality Threshold";
            // 
            // pnlCollectedTemplates
            // 
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RP);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightThumbTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RB);
            this.pnlCollectedTemplates.Controls.Add(this.lblRightPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LB);
            this.pnlCollectedTemplates.Controls.Add(this.lblRightThumbTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LP);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftThumbTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftThumbTemplate);
            this.pnlCollectedTemplates.Location = new System.Drawing.Point(30, 116);
            this.pnlCollectedTemplates.Name = "pnlCollectedTemplates";
            this.pnlCollectedTemplates.Size = new System.Drawing.Size(1065, 240);
            this.pnlCollectedTemplates.TabIndex = 16;
            // 
            // chkFingerType_RP
            // 
            this.chkFingerType_RP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_RP.CheckOnClick = true;
            this.chkFingerType_RP.FormattingEnabled = true;
            this.chkFingerType_RP.Items.AddRange(new object[] {
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RP.Location = new System.Drawing.Point(560, 17);
            this.chkFingerType_RP.Name = "chkFingerType_RP";
            this.chkFingerType_RP.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RP.TabIndex = 20;
            // 
            // pbRightThumbTemplate
            // 
            this.pbRightThumbTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightThumbTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightThumbTemplate.Image")));
            this.pbRightThumbTemplate.Location = new System.Drawing.Point(890, 17);
            this.pbRightThumbTemplate.Name = "pbRightThumbTemplate";
            this.pbRightThumbTemplate.Size = new System.Drawing.Size(154, 179);
            this.pbRightThumbTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightThumbTemplate.TabIndex = 13;
            this.pbRightThumbTemplate.TabStop = false;
            this.pbRightThumbTemplate.DoubleClick += new System.EventHandler(this.pbRightThumbTemplate_DoubleClick);
            // 
            // chkFingerType_RB
            // 
            this.chkFingerType_RB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_RB.CheckOnClick = true;
            this.chkFingerType_RB.FormattingEnabled = true;
            this.chkFingerType_RB.Items.AddRange(new object[] {
            "Right Thumb",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RB.Location = new System.Drawing.Point(805, 17);
            this.chkFingerType_RB.Name = "chkFingerType_RB";
            this.chkFingerType_RB.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RB.TabIndex = 19;
            // 
            // lblRightPrimaryTemplate
            // 
            this.lblRightPrimaryTemplate.AutoSize = true;
            this.lblRightPrimaryTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightPrimaryTemplate.Location = new System.Drawing.Point(647, 199);
            this.lblRightPrimaryTemplate.Name = "lblRightPrimaryTemplate";
            this.lblRightPrimaryTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblRightPrimaryTemplate.TabIndex = 18;
            // 
            // chkFingerType_LB
            // 
            this.chkFingerType_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_LB.CheckOnClick = true;
            this.chkFingerType_LB.FormattingEnabled = true;
            this.chkFingerType_LB.Items.AddRange(new object[] {
            "Left Thumb",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LB.Location = new System.Drawing.Point(261, 17);
            this.chkFingerType_LB.Name = "chkFingerType_LB";
            this.chkFingerType_LB.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LB.TabIndex = 18;
            // 
            // lblRightThumbTemplate
            // 
            this.lblRightThumbTemplate.AutoSize = true;
            this.lblRightThumbTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightThumbTemplate.Location = new System.Drawing.Point(893, 198);
            this.lblRightThumbTemplate.Name = "lblRightThumbTemplate";
            this.lblRightThumbTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblRightThumbTemplate.TabIndex = 17;
            // 
            // chkFingerType_LP
            // 
            this.chkFingerType_LP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_LP.CheckOnClick = true;
            this.chkFingerType_LP.FormattingEnabled = true;
            this.chkFingerType_LP.Items.AddRange(new object[] {
            "Left Index",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LP.Location = new System.Drawing.Point(10, 17);
            this.chkFingerType_LP.Name = "chkFingerType_LP";
            this.chkFingerType_LP.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LP.TabIndex = 17;
            // 
            // lblLeftThumbTemplate
            // 
            this.lblLeftThumbTemplate.AutoSize = true;
            this.lblLeftThumbTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftThumbTemplate.Location = new System.Drawing.Point(352, 199);
            this.lblLeftThumbTemplate.Name = "lblLeftThumbTemplate";
            this.lblLeftThumbTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftThumbTemplate.TabIndex = 16;
            // 
            // lblLeftPrimaryTemplate
            // 
            this.lblLeftPrimaryTemplate.AutoSize = true;
            this.lblLeftPrimaryTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftPrimaryTemplate.Location = new System.Drawing.Point(101, 199);
            this.lblLeftPrimaryTemplate.Name = "lblLeftPrimaryTemplate";
            this.lblLeftPrimaryTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftPrimaryTemplate.TabIndex = 15;
            // 
            // pbRightPrimaryTemplate
            // 
            this.pbRightPrimaryTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightPrimaryTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightPrimaryTemplate.Image")));
            this.pbRightPrimaryTemplate.Location = new System.Drawing.Point(645, 17);
            this.pbRightPrimaryTemplate.Name = "pbRightPrimaryTemplate";
            this.pbRightPrimaryTemplate.Size = new System.Drawing.Size(154, 179);
            this.pbRightPrimaryTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightPrimaryTemplate.TabIndex = 14;
            this.pbRightPrimaryTemplate.TabStop = false;
            this.pbRightPrimaryTemplate.DoubleClick += new System.EventHandler(this.pbRightPrimaryTemplate_DoubleClick);
            // 
            // pbLeftPrimaryTemplate
            // 
            this.pbLeftPrimaryTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftPrimaryTemplate.Image = global::DCS2015.Properties.Resources.doubletap;
            this.pbLeftPrimaryTemplate.Location = new System.Drawing.Point(98, 17);
            this.pbLeftPrimaryTemplate.Name = "pbLeftPrimaryTemplate";
            this.pbLeftPrimaryTemplate.Size = new System.Drawing.Size(154, 179);
            this.pbLeftPrimaryTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftPrimaryTemplate.TabIndex = 11;
            this.pbLeftPrimaryTemplate.TabStop = false;
            this.pbLeftPrimaryTemplate.DoubleClick += new System.EventHandler(this.pbLeftPrimaryTemplate_DoubleClick);
            // 
            // pbLeftThumbTemplate
            // 
            this.pbLeftThumbTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftThumbTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftThumbTemplate.Image")));
            this.pbLeftThumbTemplate.Location = new System.Drawing.Point(349, 17);
            this.pbLeftThumbTemplate.Name = "pbLeftThumbTemplate";
            this.pbLeftThumbTemplate.Size = new System.Drawing.Size(154, 179);
            this.pbLeftThumbTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftThumbTemplate.TabIndex = 12;
            this.pbLeftThumbTemplate.TabStop = false;
            this.pbLeftThumbTemplate.DoubleClick += new System.EventHandler(this.pbLeftThumbTemplate_DoubleClick);
            // 
            // btnSequenceCapture
            // 
            this.btnSequenceCapture.AllowAnimations = true;
            this.btnSequenceCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnSequenceCapture.Location = new System.Drawing.Point(911, 7);
            this.btnSequenceCapture.Name = "btnSequenceCapture";
            this.btnSequenceCapture.RoundedCornersMask = ((byte)(15));
            this.btnSequenceCapture.Size = new System.Drawing.Size(115, 32);
            this.btnSequenceCapture.TabIndex = 12;
            this.btnSequenceCapture.Text = "Sequence Capture";
            this.btnSequenceCapture.UseVisualStyleBackColor = false;
            this.btnSequenceCapture.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnSequenceCapture.Click += new System.EventHandler(this.btnSequenceCapture_Click);
            // 
            // btnReset
            // 
            this.btnReset.AllowAnimations = true;
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(1032, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.RoundedCornersMask = ((byte)(15));
            this.btnReset.Size = new System.Drawing.Size(77, 32);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlLiveScan
            // 
            this.pnlLiveScan.Controls.Add(this.pbBlinking);
            this.pnlLiveScan.Controls.Add(this.lblQuality);
            this.pnlLiveScan.Controls.Add(this.vScroll_Quality);
            this.pnlLiveScan.Controls.Add(this.textQuality);
            this.pnlLiveScan.Controls.Add(this.txtMsg);
            this.pnlLiveScan.Location = new System.Drawing.Point(196, 17);
            this.pnlLiveScan.Name = "pnlLiveScan";
            this.pnlLiveScan.Size = new System.Drawing.Size(732, 286);
            this.pnlLiveScan.TabIndex = 15;
            this.pnlLiveScan.Visible = false;
            // 
            // pbBlinking
            // 
            this.pbBlinking.Image = global::DCS2015.Properties.Resources.left_right_hand4;
            this.pbBlinking.Location = new System.Drawing.Point(286, 1);
            this.pbBlinking.Name = "pbBlinking";
            this.pbBlinking.Size = new System.Drawing.Size(161, 228);
            this.pbBlinking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBlinking.TabIndex = 15;
            this.pbBlinking.TabStop = false;
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(569, 82);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(51, 13);
            this.lblQuality.TabIndex = 14;
            this.lblQuality.Text = "Quality: 0";
            this.lblQuality.Visible = false;
            this.lblQuality.Click += new System.EventHandler(this.lblQuality_Click);
            // 
            // vScroll_Quality
            // 
            this.vScroll_Quality.AllowAnimations = true;
            this.vScroll_Quality.LargeChange = 10;
            this.vScroll_Quality.Location = new System.Drawing.Point(569, 99);
            this.vScroll_Quality.Maximum = 100;
            this.vScroll_Quality.Minimum = 25;
            this.vScroll_Quality.Name = "vScroll_Quality";
            this.vScroll_Quality.ScrollButtonsRoundedCornersRadius = 0;
            this.vScroll_Quality.ScrollButtonsSemiRounded = true;
            this.vScroll_Quality.Size = new System.Drawing.Size(17, 50);
            this.vScroll_Quality.SmallChange = 1;
            this.vScroll_Quality.TabIndex = 13;
            this.vScroll_Quality.Text = "vVScrollBar1";
            this.vScroll_Quality.Value = 25;
            this.vScroll_Quality.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.vScroll_Quality.Visible = false;
            this.vScroll_Quality.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_Quality_Scroll);
            // 
            // textQuality
            // 
            this.textQuality.BackColor = System.Drawing.Color.White;
            this.textQuality.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textQuality.Location = new System.Drawing.Point(567, 34);
            this.textQuality.Name = "textQuality";
            this.textQuality.ReadOnly = true;
            this.textQuality.Size = new System.Drawing.Size(117, 13);
            this.textQuality.TabIndex = 12;
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMsg.Location = new System.Drawing.Point(3, 238);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(726, 45);
            this.txtMsg.TabIndex = 8;
            this.txtMsg.Text = "Initialiazing please wait...";
            this.txtMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucScanFingerSecugen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "ucScanFingerSecugen";
            this.Size = new System.Drawing.Size(1126, 522);
            this.Load += new System.EventHandler(this.ucScanFingerSecugen_Load);
            this.Leave += new System.EventHandler(this.ucScanFingerSecugen_Leave);
            this.Resize += new System.EventHandler(this.ucScanFingerSecugen_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCollectedTemplates.ResumeLayout(false);
            this.pnlCollectedTemplates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightThumbTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightPrimaryTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftPrimaryTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftThumbTemplate)).EndInit();
            this.pnlLiveScan.ResumeLayout(false);
            this.pnlLiveScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlinking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Panel pnlCollectedTemplates;
        private System.Windows.Forms.PictureBox pbRightThumbTemplate;
        private System.Windows.Forms.PictureBox pbRightPrimaryTemplate;
        private System.Windows.Forms.PictureBox pbLeftPrimaryTemplate;
        private System.Windows.Forms.PictureBox pbLeftThumbTemplate;
        private System.Windows.Forms.Panel pnlLiveScan;
        private VIBlend.WinForms.Controls.vButton btnReset;
        private System.Windows.Forms.TextBox textQuality;
        private System.Windows.Forms.Label lblRightPrimaryTemplate;
        private System.Windows.Forms.Label lblRightThumbTemplate;
        private System.Windows.Forms.Label lblLeftThumbTemplate;
        private System.Windows.Forms.Label lblLeftPrimaryTemplate;
        private VIBlend.WinForms.Controls.vButton btnSequenceCapture;
        private System.Windows.Forms.CheckedListBox chkFingerType_RP;
        private System.Windows.Forms.CheckedListBox chkFingerType_RB;
        private System.Windows.Forms.CheckedListBox chkFingerType_LB;
        private System.Windows.Forms.CheckedListBox chkFingerType_LP;
        private VIBlend.WinForms.Controls.vVScrollBar vScroll_Quality;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBlinking;
    }
}
