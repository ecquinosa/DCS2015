namespace DCS2015.Forms.UserForms
{
    partial class ucScanFinger_Complete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucScanFinger_Complete));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtFooterMsg = new System.Windows.Forms.TextBox();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCollectedTemplates = new System.Windows.Forms.Panel();
            this.lblRightRingTemplate = new System.Windows.Forms.Label();
            this.lblRightPinkyTemplate = new System.Windows.Forms.Label();
            this.lblRightMiddleTemplate = new System.Windows.Forms.Label();
            this.lblLeftMiddleTemplate = new System.Windows.Forms.Label();
            this.lblLeftRingTemplate = new System.Windows.Forms.Label();
            this.lblLeftPinkyTemplate = new System.Windows.Forms.Label();
            this.chkFingerType_RPink = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_RR = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_RM = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_RP = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_LPink = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_LR = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_LM = new System.Windows.Forms.CheckedListBox();
            this.chkFingerType_LB = new System.Windows.Forms.CheckedListBox();
            this.pbLeftPinkyTemplate = new System.Windows.Forms.PictureBox();
            this.pbLeftRingTemplate = new System.Windows.Forms.PictureBox();
            this.pbRightPinkyTemplate = new System.Windows.Forms.PictureBox();
            this.pbRightRingTemplate = new System.Windows.Forms.PictureBox();
            this.pbRightMiddleTemplate = new System.Windows.Forms.PictureBox();
            this.pbLeftMiddleTemplate = new System.Windows.Forms.PictureBox();
            this.pbRightThumbTemplate = new System.Windows.Forms.PictureBox();
            this.chkFingerType_RB = new System.Windows.Forms.CheckedListBox();
            this.lblRightPrimaryTemplate = new System.Windows.Forms.Label();
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
            this.lblQuality = new System.Windows.Forms.Label();
            this.vScroll_Quality = new VIBlend.WinForms.Controls.vVScrollBar();
            this.textQuality = new System.Windows.Forms.TextBox();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.display = new System.Windows.Forms.PictureBox();
            this.pbBlinking = new System.Windows.Forms.PictureBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            this.pnlCollectedTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftPinkyTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftRingTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightPinkyTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightRingTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightMiddleTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftMiddleTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightThumbTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightPrimaryTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftPrimaryTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftThumbTemplate)).BeginInit();
            this.pnlLiveScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlinking)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtFooterMsg);
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
            // txtFooterMsg
            // 
            this.txtFooterMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFooterMsg.BackColor = System.Drawing.Color.White;
            this.txtFooterMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFooterMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFooterMsg.Location = new System.Drawing.Point(3, 493);
            this.txtFooterMsg.Multiline = true;
            this.txtFooterMsg.Name = "txtFooterMsg";
            this.txtFooterMsg.ReadOnly = true;
            this.txtFooterMsg.Size = new System.Drawing.Size(791, 20);
            this.txtFooterMsg.TabIndex = 20;
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
            this.pnlCollectedTemplates.Controls.Add(this.lblRightRingTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblRightPinkyTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblRightMiddleTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftMiddleTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftRingTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftPinkyTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RPink);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RR);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RM);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RP);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LPink);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LR);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LM);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LB);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftPinkyTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftRingTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightPinkyTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightRingTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightMiddleTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftMiddleTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightThumbTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_RB);
            this.pnlCollectedTemplates.Controls.Add(this.lblRightPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblRightThumbTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.chkFingerType_LP);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftThumbTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.lblLeftPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbRightPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftPrimaryTemplate);
            this.pnlCollectedTemplates.Controls.Add(this.pbLeftThumbTemplate);
            this.pnlCollectedTemplates.Location = new System.Drawing.Point(30, 116);
            this.pnlCollectedTemplates.Name = "pnlCollectedTemplates";
            this.pnlCollectedTemplates.Size = new System.Drawing.Size(1065, 313);
            this.pnlCollectedTemplates.TabIndex = 16;
            // 
            // lblRightRingTemplate
            // 
            this.lblRightRingTemplate.AutoSize = true;
            this.lblRightRingTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightRingTemplate.Location = new System.Drawing.Point(827, 191);
            this.lblRightRingTemplate.Name = "lblRightRingTemplate";
            this.lblRightRingTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblRightRingTemplate.TabIndex = 45;
            // 
            // lblRightPinkyTemplate
            // 
            this.lblRightPinkyTemplate.AutoSize = true;
            this.lblRightPinkyTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightPinkyTemplate.Location = new System.Drawing.Point(911, 191);
            this.lblRightPinkyTemplate.Name = "lblRightPinkyTemplate";
            this.lblRightPinkyTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblRightPinkyTemplate.TabIndex = 44;
            // 
            // lblRightMiddleTemplate
            // 
            this.lblRightMiddleTemplate.AutoSize = true;
            this.lblRightMiddleTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightMiddleTemplate.Location = new System.Drawing.Point(743, 191);
            this.lblRightMiddleTemplate.Name = "lblRightMiddleTemplate";
            this.lblRightMiddleTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblRightMiddleTemplate.TabIndex = 43;
            // 
            // lblLeftMiddleTemplate
            // 
            this.lblLeftMiddleTemplate.AutoSize = true;
            this.lblLeftMiddleTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftMiddleTemplate.Location = new System.Drawing.Point(249, 193);
            this.lblLeftMiddleTemplate.Name = "lblLeftMiddleTemplate";
            this.lblLeftMiddleTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftMiddleTemplate.TabIndex = 42;
            // 
            // lblLeftRingTemplate
            // 
            this.lblLeftRingTemplate.AutoSize = true;
            this.lblLeftRingTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftRingTemplate.Location = new System.Drawing.Point(165, 193);
            this.lblLeftRingTemplate.Name = "lblLeftRingTemplate";
            this.lblLeftRingTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftRingTemplate.TabIndex = 41;
            // 
            // lblLeftPinkyTemplate
            // 
            this.lblLeftPinkyTemplate.AutoSize = true;
            this.lblLeftPinkyTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftPinkyTemplate.Location = new System.Drawing.Point(80, 192);
            this.lblLeftPinkyTemplate.Name = "lblLeftPinkyTemplate";
            this.lblLeftPinkyTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftPinkyTemplate.TabIndex = 40;
            // 
            // chkFingerType_RPink
            // 
            this.chkFingerType_RPink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_RPink.CheckOnClick = true;
            this.chkFingerType_RPink.FormattingEnabled = true;
            this.chkFingerType_RPink.Items.AddRange(new object[] {
            "Right Thumb",
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RPink.Location = new System.Drawing.Point(908, 7);
            this.chkFingerType_RPink.Name = "chkFingerType_RPink";
            this.chkFingerType_RPink.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RPink.TabIndex = 39;
            // 
            // chkFingerType_RR
            // 
            this.chkFingerType_RR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_RR.CheckOnClick = true;
            this.chkFingerType_RR.FormattingEnabled = true;
            this.chkFingerType_RR.Items.AddRange(new object[] {
            "Right Thumb",
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RR.Location = new System.Drawing.Point(823, 7);
            this.chkFingerType_RR.Name = "chkFingerType_RR";
            this.chkFingerType_RR.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RR.TabIndex = 38;
            // 
            // chkFingerType_RM
            // 
            this.chkFingerType_RM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_RM.CheckOnClick = true;
            this.chkFingerType_RM.FormattingEnabled = true;
            this.chkFingerType_RM.Items.AddRange(new object[] {
            "Right Thumb",
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RM.Location = new System.Drawing.Point(740, 7);
            this.chkFingerType_RM.Name = "chkFingerType_RM";
            this.chkFingerType_RM.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RM.TabIndex = 37;
            // 
            // chkFingerType_RP
            // 
            this.chkFingerType_RP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_RP.CheckOnClick = true;
            this.chkFingerType_RP.FormattingEnabled = true;
            this.chkFingerType_RP.Items.AddRange(new object[] {
            "Right Thumb",
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RP.Location = new System.Drawing.Point(657, 7);
            this.chkFingerType_RP.Name = "chkFingerType_RP";
            this.chkFingerType_RP.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RP.TabIndex = 36;
            // 
            // chkFingerType_LPink
            // 
            this.chkFingerType_LPink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_LPink.CheckOnClick = true;
            this.chkFingerType_LPink.FormattingEnabled = true;
            this.chkFingerType_LPink.Items.AddRange(new object[] {
            "Left Thumb",
            "Left Index",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LPink.Location = new System.Drawing.Point(77, 7);
            this.chkFingerType_LPink.Name = "chkFingerType_LPink";
            this.chkFingerType_LPink.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LPink.TabIndex = 35;
            // 
            // chkFingerType_LR
            // 
            this.chkFingerType_LR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_LR.CheckOnClick = true;
            this.chkFingerType_LR.FormattingEnabled = true;
            this.chkFingerType_LR.Items.AddRange(new object[] {
            "Left Thumb",
            "Left Index",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LR.Location = new System.Drawing.Point(161, 7);
            this.chkFingerType_LR.Name = "chkFingerType_LR";
            this.chkFingerType_LR.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LR.TabIndex = 34;
            // 
            // chkFingerType_LM
            // 
            this.chkFingerType_LM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_LM.CheckOnClick = true;
            this.chkFingerType_LM.FormattingEnabled = true;
            this.chkFingerType_LM.Items.AddRange(new object[] {
            "Left Thumb",
            "Left Index",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LM.Location = new System.Drawing.Point(245, 7);
            this.chkFingerType_LM.Name = "chkFingerType_LM";
            this.chkFingerType_LM.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LM.TabIndex = 33;
            // 
            // chkFingerType_LB
            // 
            this.chkFingerType_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkFingerType_LB.CheckOnClick = true;
            this.chkFingerType_LB.FormattingEnabled = true;
            this.chkFingerType_LB.Items.AddRange(new object[] {
            "Left Thumb",
            "Left Index",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LB.Location = new System.Drawing.Point(414, 7);
            this.chkFingerType_LB.Name = "chkFingerType_LB";
            this.chkFingerType_LB.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LB.TabIndex = 32;
            // 
            // pbLeftPinkyTemplate
            // 
            this.pbLeftPinkyTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftPinkyTemplate.Image = global::DCS2015.Properties.Resources.doubletap;
            this.pbLeftPinkyTemplate.Location = new System.Drawing.Point(78, 100);
            this.pbLeftPinkyTemplate.Name = "pbLeftPinkyTemplate";
            this.pbLeftPinkyTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbLeftPinkyTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftPinkyTemplate.TabIndex = 31;
            this.pbLeftPinkyTemplate.TabStop = false;
            this.pbLeftPinkyTemplate.DoubleClick += new System.EventHandler(this.pbLeftPinkyTemplate_DoubleClick);
            // 
            // pbLeftRingTemplate
            // 
            this.pbLeftRingTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftRingTemplate.Image = global::DCS2015.Properties.Resources.doubletap;
            this.pbLeftRingTemplate.Location = new System.Drawing.Point(162, 100);
            this.pbLeftRingTemplate.Name = "pbLeftRingTemplate";
            this.pbLeftRingTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbLeftRingTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftRingTemplate.TabIndex = 29;
            this.pbLeftRingTemplate.TabStop = false;
            this.pbLeftRingTemplate.DoubleClick += new System.EventHandler(this.pbLeftRingTemplate_DoubleClick);
            // 
            // pbRightPinkyTemplate
            // 
            this.pbRightPinkyTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightPinkyTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightPinkyTemplate.Image")));
            this.pbRightPinkyTemplate.Location = new System.Drawing.Point(909, 100);
            this.pbRightPinkyTemplate.Name = "pbRightPinkyTemplate";
            this.pbRightPinkyTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbRightPinkyTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightPinkyTemplate.TabIndex = 27;
            this.pbRightPinkyTemplate.TabStop = false;
            this.pbRightPinkyTemplate.Click += new System.EventHandler(this.pbRightPinkyTemplate_DoubleClick);
            // 
            // pbRightRingTemplate
            // 
            this.pbRightRingTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightRingTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightRingTemplate.Image")));
            this.pbRightRingTemplate.Location = new System.Drawing.Point(825, 100);
            this.pbRightRingTemplate.Name = "pbRightRingTemplate";
            this.pbRightRingTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbRightRingTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightRingTemplate.TabIndex = 25;
            this.pbRightRingTemplate.TabStop = false;
            this.pbRightRingTemplate.Click += new System.EventHandler(this.pbRightRingTemplate_DoubleClick);
            // 
            // pbRightMiddleTemplate
            // 
            this.pbRightMiddleTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightMiddleTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightMiddleTemplate.Image")));
            this.pbRightMiddleTemplate.Location = new System.Drawing.Point(741, 100);
            this.pbRightMiddleTemplate.Name = "pbRightMiddleTemplate";
            this.pbRightMiddleTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbRightMiddleTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightMiddleTemplate.TabIndex = 23;
            this.pbRightMiddleTemplate.TabStop = false;
            this.pbRightMiddleTemplate.Click += new System.EventHandler(this.pbRightMiddleTemplate_DoubleClick);
            // 
            // pbLeftMiddleTemplate
            // 
            this.pbLeftMiddleTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftMiddleTemplate.Image = global::DCS2015.Properties.Resources.doubletap;
            this.pbLeftMiddleTemplate.Location = new System.Drawing.Point(246, 100);
            this.pbLeftMiddleTemplate.Name = "pbLeftMiddleTemplate";
            this.pbLeftMiddleTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbLeftMiddleTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftMiddleTemplate.TabIndex = 21;
            this.pbLeftMiddleTemplate.TabStop = false;
            this.pbLeftMiddleTemplate.Click += new System.EventHandler(this.pbLeftMiddleTemplate_DoubleClick);
            // 
            // pbRightThumbTemplate
            // 
            this.pbRightThumbTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightThumbTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightThumbTemplate.Image")));
            this.pbRightThumbTemplate.Location = new System.Drawing.Point(573, 100);
            this.pbRightThumbTemplate.Name = "pbRightThumbTemplate";
            this.pbRightThumbTemplate.Size = new System.Drawing.Size(78, 90);
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
            "Right Index",
            "Right Middle",
            "Right Ring",
            "Right Pinky",
            "Amputated"});
            this.chkFingerType_RB.Location = new System.Drawing.Point(573, 7);
            this.chkFingerType_RB.Name = "chkFingerType_RB";
            this.chkFingerType_RB.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_RB.TabIndex = 19;
            // 
            // lblRightPrimaryTemplate
            // 
            this.lblRightPrimaryTemplate.AutoSize = true;
            this.lblRightPrimaryTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightPrimaryTemplate.Location = new System.Drawing.Point(661, 191);
            this.lblRightPrimaryTemplate.Name = "lblRightPrimaryTemplate";
            this.lblRightPrimaryTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblRightPrimaryTemplate.TabIndex = 18;
            // 
            // lblRightThumbTemplate
            // 
            this.lblRightThumbTemplate.AutoSize = true;
            this.lblRightThumbTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightThumbTemplate.Location = new System.Drawing.Point(575, 191);
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
            "Left Thumb",
            "Left Index",
            "Left Middle",
            "Left Ring",
            "Left Pinky",
            "Amputated"});
            this.chkFingerType_LP.Location = new System.Drawing.Point(329, 7);
            this.chkFingerType_LP.Name = "chkFingerType_LP";
            this.chkFingerType_LP.Size = new System.Drawing.Size(79, 90);
            this.chkFingerType_LP.TabIndex = 17;
            // 
            // lblLeftThumbTemplate
            // 
            this.lblLeftThumbTemplate.AutoSize = true;
            this.lblLeftThumbTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftThumbTemplate.Location = new System.Drawing.Point(417, 193);
            this.lblLeftThumbTemplate.Name = "lblLeftThumbTemplate";
            this.lblLeftThumbTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftThumbTemplate.TabIndex = 16;
            // 
            // lblLeftPrimaryTemplate
            // 
            this.lblLeftPrimaryTemplate.AutoSize = true;
            this.lblLeftPrimaryTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftPrimaryTemplate.Location = new System.Drawing.Point(333, 193);
            this.lblLeftPrimaryTemplate.Name = "lblLeftPrimaryTemplate";
            this.lblLeftPrimaryTemplate.Size = new System.Drawing.Size(0, 13);
            this.lblLeftPrimaryTemplate.TabIndex = 15;
            // 
            // pbRightPrimaryTemplate
            // 
            this.pbRightPrimaryTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRightPrimaryTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbRightPrimaryTemplate.Image")));
            this.pbRightPrimaryTemplate.Location = new System.Drawing.Point(657, 100);
            this.pbRightPrimaryTemplate.Name = "pbRightPrimaryTemplate";
            this.pbRightPrimaryTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbRightPrimaryTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightPrimaryTemplate.TabIndex = 14;
            this.pbRightPrimaryTemplate.TabStop = false;
            this.pbRightPrimaryTemplate.DoubleClick += new System.EventHandler(this.pbRightPrimaryTemplate_DoubleClick);
            // 
            // pbLeftPrimaryTemplate
            // 
            this.pbLeftPrimaryTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftPrimaryTemplate.Image = global::DCS2015.Properties.Resources.doubletap;
            this.pbLeftPrimaryTemplate.Location = new System.Drawing.Point(330, 100);
            this.pbLeftPrimaryTemplate.Name = "pbLeftPrimaryTemplate";
            this.pbLeftPrimaryTemplate.Size = new System.Drawing.Size(78, 90);
            this.pbLeftPrimaryTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftPrimaryTemplate.TabIndex = 11;
            this.pbLeftPrimaryTemplate.TabStop = false;
            this.pbLeftPrimaryTemplate.DoubleClick += new System.EventHandler(this.pbLeftPrimaryTemplate_DoubleClick);
            // 
            // pbLeftThumbTemplate
            // 
            this.pbLeftThumbTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLeftThumbTemplate.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftThumbTemplate.Image")));
            this.pbLeftThumbTemplate.Location = new System.Drawing.Point(414, 100);
            this.pbLeftThumbTemplate.Name = "pbLeftThumbTemplate";
            this.pbLeftThumbTemplate.Size = new System.Drawing.Size(78, 90);
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
            this.btnSequenceCapture.Visible = false;
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
            this.pnlLiveScan.Controls.Add(this.lblQuality);
            this.pnlLiveScan.Controls.Add(this.vScroll_Quality);
            this.pnlLiveScan.Controls.Add(this.textQuality);
            this.pnlLiveScan.Controls.Add(this.textStatus);
            this.pnlLiveScan.Controls.Add(this.display);
            this.pnlLiveScan.Controls.Add(this.pbBlinking);
            this.pnlLiveScan.Controls.Add(this.txtMsg);
            this.pnlLiveScan.Location = new System.Drawing.Point(196, 17);
            this.pnlLiveScan.Name = "pnlLiveScan";
            this.pnlLiveScan.Size = new System.Drawing.Size(732, 286);
            this.pnlLiveScan.TabIndex = 15;
            this.pnlLiveScan.Visible = false;
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
            // textStatus
            // 
            this.textStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textStatus.BackColor = System.Drawing.Color.White;
            this.textStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textStatus.Location = new System.Drawing.Point(355, 5);
            this.textStatus.Name = "textStatus";
            this.textStatus.ReadOnly = true;
            this.textStatus.Size = new System.Drawing.Size(208, 13);
            this.textStatus.TabIndex = 11;
            this.textStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // display
            // 
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.display.Location = new System.Drawing.Point(355, 21);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(208, 208);
            this.display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.display.TabIndex = 10;
            this.display.TabStop = false;
            // 
            // pbBlinking
            // 
            this.pbBlinking.Image = global::DCS2015.Properties.Resources.left_right_hand4;
            this.pbBlinking.Location = new System.Drawing.Point(170, 1);
            this.pbBlinking.Name = "pbBlinking";
            this.pbBlinking.Size = new System.Drawing.Size(161, 228);
            this.pbBlinking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBlinking.TabIndex = 9;
            this.pbBlinking.TabStop = false;
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
            // ucScanFinger_Complete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "ucScanFinger_Complete";
            this.Size = new System.Drawing.Size(1126, 522);
            this.Load += new System.EventHandler(this.ucScanFinger_Complete_Load);
            this.Leave += new System.EventHandler(this.ucScanFinger_Complete_Leave);
            this.Resize += new System.EventHandler(this.ucScanFinger_Complete_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCollectedTemplates.ResumeLayout(false);
            this.pnlCollectedTemplates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftPinkyTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftRingTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightPinkyTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightRingTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightMiddleTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftMiddleTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightThumbTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightPrimaryTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftPrimaryTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftThumbTemplate)).EndInit();
            this.pnlLiveScan.ResumeLayout(false);
            this.pnlLiveScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlinking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbBlinking;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Panel pnlCollectedTemplates;
        private System.Windows.Forms.PictureBox pbRightThumbTemplate;
        private System.Windows.Forms.PictureBox pbRightPrimaryTemplate;
        private System.Windows.Forms.PictureBox pbLeftPrimaryTemplate;
        private System.Windows.Forms.PictureBox pbLeftThumbTemplate;
        private System.Windows.Forms.Panel pnlLiveScan;
        private VIBlend.WinForms.Controls.vButton btnReset;
        private System.Windows.Forms.TextBox textQuality;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.Label lblRightPrimaryTemplate;
        private System.Windows.Forms.Label lblRightThumbTemplate;
        private System.Windows.Forms.Label lblLeftThumbTemplate;
        private System.Windows.Forms.Label lblLeftPrimaryTemplate;
        private VIBlend.WinForms.Controls.vButton btnSequenceCapture;
        private System.Windows.Forms.CheckedListBox chkFingerType_RB;
        private System.Windows.Forms.CheckedListBox chkFingerType_LP;
        private VIBlend.WinForms.Controls.vVScrollBar vScroll_Quality;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFooterMsg;
        private System.Windows.Forms.PictureBox pbLeftPinkyTemplate;
        private System.Windows.Forms.PictureBox pbLeftRingTemplate;
        private System.Windows.Forms.PictureBox pbRightPinkyTemplate;
        private System.Windows.Forms.PictureBox pbRightRingTemplate;
        private System.Windows.Forms.PictureBox pbRightMiddleTemplate;
        private System.Windows.Forms.PictureBox pbLeftMiddleTemplate;
        private System.Windows.Forms.CheckedListBox chkFingerType_RPink;
        private System.Windows.Forms.CheckedListBox chkFingerType_RR;
        private System.Windows.Forms.CheckedListBox chkFingerType_RM;
        private System.Windows.Forms.CheckedListBox chkFingerType_RP;
        private System.Windows.Forms.CheckedListBox chkFingerType_LPink;
        private System.Windows.Forms.CheckedListBox chkFingerType_LR;
        private System.Windows.Forms.CheckedListBox chkFingerType_LM;
        private System.Windows.Forms.CheckedListBox chkFingerType_LB;
        private System.Windows.Forms.Label lblRightRingTemplate;
        private System.Windows.Forms.Label lblRightPinkyTemplate;
        private System.Windows.Forms.Label lblRightMiddleTemplate;
        private System.Windows.Forms.Label lblLeftMiddleTemplate;
        private System.Windows.Forms.Label lblLeftRingTemplate;
        private System.Windows.Forms.Label lblLeftPinkyTemplate;
    }
}
