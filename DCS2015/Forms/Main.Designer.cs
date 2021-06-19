namespace DCS2015.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContMain = new System.Windows.Forms.SplitContainer();
            this.splitContUpper = new System.Windows.Forms.SplitContainer();
            this.splitContHeader = new System.Windows.Forms.SplitContainer();
            this.pbClientLogo = new System.Windows.Forms.PictureBox();
            this.btnLogout = new VIBlend.WinForms.Controls.vButton();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrieveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturedListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDataCaptureFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreview = new VIBlend.WinForms.Controls.vButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBiometrics = new VIBlend.WinForms.Controls.vButton();
            this.btnSignature = new VIBlend.WinForms.Controls.vButton();
            this.btnPhoto = new VIBlend.WinForms.Controls.vButton();
            this.btnData = new VIBlend.WinForms.Controls.vButton();
            this.splitContLower = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnResetAll = new VIBlend.WinForms.Controls.vButton();
            this.btnPrevious = new VIBlend.WinForms.Controls.vButton();
            this.btnNext = new VIBlend.WinForms.Controls.vButton();
            this.btnSubmit = new VIBlend.WinForms.Controls.vButton();
            this.txtFooterMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTrademark = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).BeginInit();
            this.splitContMain.Panel1.SuspendLayout();
            this.splitContMain.Panel2.SuspendLayout();
            this.splitContMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContUpper)).BeginInit();
            this.splitContUpper.Panel1.SuspendLayout();
            this.splitContUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContHeader)).BeginInit();
            this.splitContHeader.Panel1.SuspendLayout();
            this.splitContHeader.Panel2.SuspendLayout();
            this.splitContHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContLower)).BeginInit();
            this.splitContLower.Panel1.SuspendLayout();
            this.splitContLower.Panel2.SuspendLayout();
            this.splitContLower.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContMain
            // 
            this.splitContMain.BackColor = System.Drawing.Color.White;
            this.splitContMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMain.Location = new System.Drawing.Point(0, 0);
            this.splitContMain.Name = "splitContMain";
            this.splitContMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContMain.Panel1
            // 
            this.splitContMain.Panel1.Controls.Add(this.splitContUpper);
            // 
            // splitContMain.Panel2
            // 
            this.splitContMain.Panel2.Controls.Add(this.splitContLower);
            this.splitContMain.Size = new System.Drawing.Size(1170, 700);
            this.splitContMain.SplitterDistance = 627;
            this.splitContMain.TabIndex = 0;
            // 
            // splitContUpper
            // 
            this.splitContUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContUpper.Location = new System.Drawing.Point(0, 0);
            this.splitContUpper.Name = "splitContUpper";
            this.splitContUpper.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContUpper.Panel1
            // 
            this.splitContUpper.Panel1.Controls.Add(this.splitContHeader);
            // 
            // splitContUpper.Panel2
            // 
            this.splitContUpper.Panel2.AutoScroll = true;
            this.splitContUpper.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContUpper.Size = new System.Drawing.Size(1170, 627);
            this.splitContUpper.SplitterDistance = 121;
            this.splitContUpper.TabIndex = 0;
            // 
            // splitContHeader
            // 
            this.splitContHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContHeader.IsSplitterFixed = true;
            this.splitContHeader.Location = new System.Drawing.Point(0, 0);
            this.splitContHeader.Name = "splitContHeader";
            this.splitContHeader.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContHeader.Panel1
            // 
            this.splitContHeader.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContHeader.Panel1.BackgroundImage")));
            this.splitContHeader.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContHeader.Panel1.Controls.Add(this.pbClientLogo);
            // 
            // splitContHeader.Panel2
            // 
            this.splitContHeader.Panel2.Controls.Add(this.btnLogout);
            this.splitContHeader.Panel2.Controls.Add(this.txtHeight);
            this.splitContHeader.Panel2.Controls.Add(this.txtWidth);
            this.splitContHeader.Panel2.Controls.Add(this.txtY);
            this.splitContHeader.Panel2.Controls.Add(this.txtX);
            this.splitContHeader.Panel2.Controls.Add(this.button1);
            this.splitContHeader.Panel2.Controls.Add(this.menuStrip1);
            this.splitContHeader.Panel2.Controls.Add(this.panel1);
            this.splitContHeader.Panel2.Controls.Add(this.btnPreview);
            this.splitContHeader.Panel2.Controls.Add(this.panel2);
            this.splitContHeader.Panel2.Controls.Add(this.btnBiometrics);
            this.splitContHeader.Panel2.Controls.Add(this.btnSignature);
            this.splitContHeader.Panel2.Controls.Add(this.btnPhoto);
            this.splitContHeader.Panel2.Controls.Add(this.btnData);
            this.splitContHeader.Size = new System.Drawing.Size(1170, 121);
            this.splitContHeader.SplitterDistance = 48;
            this.splitContHeader.SplitterWidth = 1;
            this.splitContHeader.TabIndex = 0;
            // 
            // pbClientLogo
            // 
            this.pbClientLogo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbClientLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClientLogo.Location = new System.Drawing.Point(1064, 2);
            this.pbClientLogo.Name = "pbClientLogo";
            this.pbClientLogo.Size = new System.Drawing.Size(103, 45);
            this.pbClientLogo.TabIndex = 14;
            this.pbClientLogo.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.AllowAnimations = true;
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1085, 3);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RoundedCornersMask = ((byte)(15));
            this.btnLogout.Size = new System.Drawing.Size(81, 28);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(785, 33);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(52, 20);
            this.txtHeight.TabIndex = 18;
            this.txtHeight.Text = "235";
            this.txtHeight.Visible = false;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(785, 11);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(52, 20);
            this.txtWidth.TabIndex = 17;
            this.txtWidth.Text = "240";
            this.txtWidth.Visible = false;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(701, 34);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(52, 20);
            this.txtY.TabIndex = 16;
            this.txtY.Text = "235";
            this.txtY.Visible = false;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(701, 12);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(52, 20);
            this.txtX.TabIndex = 15;
            this.txtX.Text = "12";
            this.txtX.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(602, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemFunctionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(993, 46);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(131, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemFunctionToolStripMenuItem
            // 
            this.systemFunctionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retrieveDataToolStripMenuItem,
            this.capturedListToolStripMenuItem,
            this.systemSettingsToolStripMenuItem,
            this.manageDataCaptureFieldsToolStripMenuItem});
            this.systemFunctionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemFunctionToolStripMenuItem.Image")));
            this.systemFunctionToolStripMenuItem.Name = "systemFunctionToolStripMenuItem";
            this.systemFunctionToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.systemFunctionToolStripMenuItem.Text = "System Function";
            // 
            // retrieveDataToolStripMenuItem
            // 
            this.retrieveDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("retrieveDataToolStripMenuItem.Image")));
            this.retrieveDataToolStripMenuItem.Name = "retrieveDataToolStripMenuItem";
            this.retrieveDataToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.retrieveDataToolStripMenuItem.Text = "Load draft data";
            this.retrieveDataToolStripMenuItem.Click += new System.EventHandler(this.retrieveDataToolStripMenuItem_Click);
            // 
            // capturedListToolStripMenuItem
            // 
            this.capturedListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("capturedListToolStripMenuItem.Image")));
            this.capturedListToolStripMenuItem.Name = "capturedListToolStripMenuItem";
            this.capturedListToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.capturedListToolStripMenuItem.Text = "Captured List";
            this.capturedListToolStripMenuItem.Click += new System.EventHandler(this.capturedListToolStripMenuItem_Click);
            // 
            // systemSettingsToolStripMenuItem
            // 
            this.systemSettingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemSettingsToolStripMenuItem.Image")));
            this.systemSettingsToolStripMenuItem.Name = "systemSettingsToolStripMenuItem";
            this.systemSettingsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.systemSettingsToolStripMenuItem.Text = "System Settings";
            this.systemSettingsToolStripMenuItem.Click += new System.EventHandler(this.systemSettingsToolStripMenuItem_Click);
            // 
            // manageDataCaptureFieldsToolStripMenuItem
            // 
            this.manageDataCaptureFieldsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageDataCaptureFieldsToolStripMenuItem.Image")));
            this.manageDataCaptureFieldsToolStripMenuItem.Name = "manageDataCaptureFieldsToolStripMenuItem";
            this.manageDataCaptureFieldsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.manageDataCaptureFieldsToolStripMenuItem.Text = "Manage Data Capture Fields";
            this.manageDataCaptureFieldsToolStripMenuItem.Click += new System.EventHandler(this.manageDataCaptureFieldsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 11);
            this.panel1.TabIndex = 12;
            // 
            // btnPreview
            // 
            this.btnPreview.AllowAnimations = true;
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.Enabled = false;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(452, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.RoundedCornersMask = ((byte)(15));
            this.btnPreview.RoundedCornersRadius = 6;
            this.btnPreview.Size = new System.Drawing.Size(111, 39);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel2.Location = new System.Drawing.Point(892, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 40);
            this.panel2.TabIndex = 14;
            // 
            // btnBiometrics
            // 
            this.btnBiometrics.AllowAnimations = true;
            this.btnBiometrics.BackColor = System.Drawing.Color.Transparent;
            this.btnBiometrics.Enabled = false;
            this.btnBiometrics.Image = ((System.Drawing.Image)(resources.GetObject("btnBiometrics.Image")));
            this.btnBiometrics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBiometrics.Location = new System.Drawing.Point(228, 6);
            this.btnBiometrics.Name = "btnBiometrics";
            this.btnBiometrics.RoundedCornersMask = ((byte)(15));
            this.btnBiometrics.RoundedCornersRadius = 6;
            this.btnBiometrics.ShowFocusRectangle = false;
            this.btnBiometrics.Size = new System.Drawing.Size(111, 39);
            this.btnBiometrics.TabIndex = 11;
            this.btnBiometrics.Text = "BIOMETRICS";
            this.btnBiometrics.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBiometrics.UseVisualStyleBackColor = false;
            this.btnBiometrics.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnBiometrics.Click += new System.EventHandler(this.btnBiometrics_Click);
            // 
            // btnSignature
            // 
            this.btnSignature.AllowAnimations = true;
            this.btnSignature.BackColor = System.Drawing.Color.Transparent;
            this.btnSignature.Enabled = false;
            this.btnSignature.Image = ((System.Drawing.Image)(resources.GetObject("btnSignature.Image")));
            this.btnSignature.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignature.Location = new System.Drawing.Point(340, 6);
            this.btnSignature.Name = "btnSignature";
            this.btnSignature.RoundedCornersMask = ((byte)(15));
            this.btnSignature.RoundedCornersRadius = 6;
            this.btnSignature.Size = new System.Drawing.Size(111, 39);
            this.btnSignature.TabIndex = 11;
            this.btnSignature.Text = "SIGNATURE";
            this.btnSignature.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSignature.UseVisualStyleBackColor = false;
            this.btnSignature.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnSignature.Click += new System.EventHandler(this.btnSignature_Click);
            // 
            // btnPhoto
            // 
            this.btnPhoto.AllowAnimations = true;
            this.btnPhoto.BackColor = System.Drawing.Color.Transparent;
            this.btnPhoto.Enabled = false;
            this.btnPhoto.Image = ((System.Drawing.Image)(resources.GetObject("btnPhoto.Image")));
            this.btnPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhoto.Location = new System.Drawing.Point(116, 6);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.RoundedCornersMask = ((byte)(15));
            this.btnPhoto.RoundedCornersRadius = 6;
            this.btnPhoto.Size = new System.Drawing.Size(111, 39);
            this.btnPhoto.TabIndex = 10;
            this.btnPhoto.Text = "PHOTO";
            this.btnPhoto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnPhoto.UseVisualStyleBackColor = false;
            this.btnPhoto.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // btnData
            // 
            this.btnData.AllowAnimations = true;
            this.btnData.BackColor = System.Drawing.Color.Transparent;
            this.btnData.Image = ((System.Drawing.Image)(resources.GetObject("btnData.Image")));
            this.btnData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnData.Location = new System.Drawing.Point(4, 6);
            this.btnData.Name = "btnData";
            this.btnData.RoundedCornersMask = ((byte)(15));
            this.btnData.RoundedCornersRadius = 6;
            this.btnData.Size = new System.Drawing.Size(111, 39);
            this.btnData.TabIndex = 9;
            this.btnData.Text = "DATA";
            this.btnData.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnData.UseVisualStyleBackColor = false;
            this.btnData.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // splitContLower
            // 
            this.splitContLower.BackColor = System.Drawing.Color.White;
            this.splitContLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContLower.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContLower.Location = new System.Drawing.Point(0, 0);
            this.splitContLower.Name = "splitContLower";
            this.splitContLower.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContLower.Panel1
            // 
            this.splitContLower.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContLower.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContLower.Panel1.Controls.Add(this.txtFooterMsg);
            // 
            // splitContLower.Panel2
            // 
            this.splitContLower.Panel2.Controls.Add(this.label1);
            this.splitContLower.Panel2.Controls.Add(this.lblTrademark);
            this.splitContLower.Size = new System.Drawing.Size(1170, 69);
            this.splitContLower.SplitterDistance = 40;
            this.splitContLower.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnResetAll);
            this.flowLayoutPanel1.Controls.Add(this.btnPrevious);
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(817, -3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(345, 40);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnResetAll
            // 
            this.btnResetAll.AllowAnimations = true;
            this.btnResetAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetAll.BackColor = System.Drawing.Color.Transparent;
            this.btnResetAll.Location = new System.Drawing.Point(3, 3);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.RoundedCornersMask = ((byte)(15));
            this.btnResetAll.Size = new System.Drawing.Size(99, 34);
            this.btnResetAll.TabIndex = 8;
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.UseVisualStyleBackColor = false;
            this.btnResetAll.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROGREEN;
            this.btnResetAll.Visible = false;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AllowAnimations = true;
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Location = new System.Drawing.Point(108, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.RoundedCornersMask = ((byte)(15));
            this.btnPrevious.Size = new System.Drawing.Size(74, 34);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.AllowAnimations = true;
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Location = new System.Drawing.Point(188, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.RoundedCornersMask = ((byte)(15));
            this.btnNext.Size = new System.Drawing.Size(74, 34);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.AllowAnimations = true;
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.Location = new System.Drawing.Point(268, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.RoundedCornersMask = ((byte)(15));
            this.btnSubmit.Size = new System.Drawing.Size(74, 34);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtFooterMsg
            // 
            this.txtFooterMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFooterMsg.BackColor = System.Drawing.Color.White;
            this.txtFooterMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFooterMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFooterMsg.Location = new System.Drawing.Point(8, 3);
            this.txtFooterMsg.Multiline = true;
            this.txtFooterMsg.Name = "txtFooterMsg";
            this.txtFooterMsg.ReadOnly = true;
            this.txtFooterMsg.Size = new System.Drawing.Size(791, 27);
            this.txtFooterMsg.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User: Operator     |     Station Reference: Station00001-PASIGCITY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTrademark
            // 
            this.lblTrademark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrademark.AutoSize = true;
            this.lblTrademark.Location = new System.Drawing.Point(916, 6);
            this.lblTrademark.Name = "lblTrademark";
            this.lblTrademark.Size = new System.Drawing.Size(251, 13);
            this.lblTrademark.TabIndex = 0;
            this.lblTrademark.Text = "DCS 2015 - Powered by Allcard Technologies Corp.";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1170, 700);
            this.Controls.Add(this.splitContMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALLCARD DCS 2015 v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.splitContMain.Panel1.ResumeLayout(false);
            this.splitContMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMain)).EndInit();
            this.splitContMain.ResumeLayout(false);
            this.splitContUpper.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContUpper)).EndInit();
            this.splitContUpper.ResumeLayout(false);
            this.splitContHeader.Panel1.ResumeLayout(false);
            this.splitContHeader.Panel2.ResumeLayout(false);
            this.splitContHeader.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContHeader)).EndInit();
            this.splitContHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbClientLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContLower.Panel1.ResumeLayout(false);
            this.splitContLower.Panel1.PerformLayout();
            this.splitContLower.Panel2.ResumeLayout(false);
            this.splitContLower.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContLower)).EndInit();
            this.splitContLower.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContMain;
        private System.Windows.Forms.SplitContainer splitContUpper;
        private System.Windows.Forms.SplitContainer splitContLower;
        private System.Windows.Forms.SplitContainer splitContHeader;
        private VIBlend.WinForms.Controls.vButton btnNext;
        private VIBlend.WinForms.Controls.vButton btnPrevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrademark;
        private VIBlend.WinForms.Controls.vButton btnBiometrics;
        private VIBlend.WinForms.Controls.vButton btnSignature;
        private VIBlend.WinForms.Controls.vButton btnPhoto;
        private VIBlend.WinForms.Controls.vButton btnData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private VIBlend.WinForms.Controls.vButton btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private VIBlend.WinForms.Controls.vButton btnResetAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retrieveDataToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbClientLogo;
        private System.Windows.Forms.ToolStripMenuItem systemSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturedListToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFooterMsg;
        private VIBlend.WinForms.Controls.vButton btnPreview;
        private System.Windows.Forms.ToolStripMenuItem manageDataCaptureFieldsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private VIBlend.WinForms.Controls.vButton btnLogout;
    }
}