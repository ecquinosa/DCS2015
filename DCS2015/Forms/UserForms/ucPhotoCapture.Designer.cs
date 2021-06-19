namespace DCS2015.Forms.UserForms
{
    partial class ucPhotoCapture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPhotoCapture));
            this.lvPhotoProperty = new System.Windows.Forms.ListView();
            this.lvField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnConnect = new VIBlend.WinForms.Controls.vButton();
            this.btnDisconnect = new VIBlend.WinForms.Controls.vButton();
            this.btnCapture = new VIBlend.WinForms.Controls.vButton();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.lblSharpness = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.hScrollBarBrightness = new VIBlend.WinForms.Controls.vHScrollBar();
            this.chkOverrideChecking = new VIBlend.WinForms.Controls.vCheckBox();
            this.hScrollBarSharpness = new VIBlend.WinForms.Controls.vHScrollBar();
            this.hScrollBarZoom = new VIBlend.WinForms.Controls.vHScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkManualCapture = new VIBlend.WinForms.Controls.vCheckBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnPreview = new VIBlend.WinForms.Controls.vButton();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkICAO = new VIBlend.WinForms.Controls.vCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new VIBlend.WinForms.Controls.vButton();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lvPhotoProperty
            // 
            this.lvPhotoProperty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvField,
            this.lvValue});
            this.lvPhotoProperty.GridLines = true;
            this.lvPhotoProperty.Location = new System.Drawing.Point(765, 41);
            this.lvPhotoProperty.Name = "lvPhotoProperty";
            this.lvPhotoProperty.Size = new System.Drawing.Size(305, 355);
            this.lvPhotoProperty.TabIndex = 4;
            this.lvPhotoProperty.UseCompatibleStateImageBehavior = false;
            this.lvPhotoProperty.View = System.Windows.Forms.View.Details;
            // 
            // lvField
            // 
            this.lvField.Text = "";
            this.lvField.Width = 136;
            // 
            // lvValue
            // 
            this.lvValue.Text = "";
            this.lvValue.Width = 165;
            // 
            // btnConnect
            // 
            this.btnConnect.AllowAnimations = true;
            this.btnConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(14, 14);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.RoundedCornersMask = ((byte)(15));
            this.btnConnect.Size = new System.Drawing.Size(96, 49);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.AllowAnimations = true;
            this.btnDisconnect.BackColor = System.Drawing.Color.Transparent;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.Image")));
            this.btnDisconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisconnect.Location = new System.Drawing.Point(14, 124);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.RoundedCornersMask = ((byte)(15));
            this.btnDisconnect.Size = new System.Drawing.Size(96, 49);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.AllowAnimations = true;
            this.btnCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnCapture.Enabled = false;
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapture.Location = new System.Drawing.Point(14, 69);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.RoundedCornersMask = ((byte)(15));
            this.btnCapture.Size = new System.Drawing.Size(96, 49);
            this.btnCapture.TabIndex = 7;
            this.btnCapture.Text = "Capture";
            this.btnCapture.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(764, 399);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(76, 13);
            this.lblBrightness.TabIndex = 38;
            this.lblBrightness.Text = "Brightness: {0}";
            // 
            // lblSharpness
            // 
            this.lblSharpness.AutoSize = true;
            this.lblSharpness.Location = new System.Drawing.Point(764, 435);
            this.lblSharpness.Name = "lblSharpness";
            this.lblSharpness.Size = new System.Drawing.Size(77, 13);
            this.lblSharpness.TabIndex = 39;
            this.lblSharpness.Text = "Sharpness: {0}";
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(764, 472);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(54, 13);
            this.lblZoom.TabIndex = 41;
            this.lblZoom.Text = "Zoom: {0}";
            // 
            // hScrollBarBrightness
            // 
            this.hScrollBarBrightness.AllowAnimations = true;
            this.hScrollBarBrightness.Enabled = false;
            this.hScrollBarBrightness.LargeChange = 1;
            this.hScrollBarBrightness.Location = new System.Drawing.Point(765, 415);
            this.hScrollBarBrightness.Maximum = 100;
            this.hScrollBarBrightness.Minimum = 0;
            this.hScrollBarBrightness.Name = "hScrollBarBrightness";
            this.hScrollBarBrightness.ScrollButtonsRoundedCornersRadius = 0;
            this.hScrollBarBrightness.ScrollButtonsSemiRounded = true;
            this.hScrollBarBrightness.Size = new System.Drawing.Size(303, 15);
            this.hScrollBarBrightness.SmallChange = 1;
            this.hScrollBarBrightness.TabIndex = 42;
            this.hScrollBarBrightness.Text = "vHScrollBar1";
            this.hScrollBarBrightness.Value = 0;
            this.hScrollBarBrightness.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.hScrollBarBrightness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarBrightness_Scroll);
            // 
            // chkOverrideChecking
            // 
            this.chkOverrideChecking.BackColor = System.Drawing.Color.Transparent;
            this.chkOverrideChecking.Checked = true;
            this.chkOverrideChecking.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverrideChecking.Location = new System.Drawing.Point(866, 9);
            this.chkOverrideChecking.Name = "chkOverrideChecking";
            this.chkOverrideChecking.Size = new System.Drawing.Size(115, 26);
            this.chkOverrideChecking.TabIndex = 43;
            this.chkOverrideChecking.Text = "Override Checkers";
            this.chkOverrideChecking.UseVisualStyleBackColor = false;
            this.chkOverrideChecking.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.chkOverrideChecking.CheckedChanged += new System.EventHandler(this.chkOverrideChecking_CheckedChanged);
            // 
            // hScrollBarSharpness
            // 
            this.hScrollBarSharpness.AllowAnimations = true;
            this.hScrollBarSharpness.Enabled = false;
            this.hScrollBarSharpness.LargeChange = 10;
            this.hScrollBarSharpness.Location = new System.Drawing.Point(765, 451);
            this.hScrollBarSharpness.Maximum = 100;
            this.hScrollBarSharpness.Minimum = 0;
            this.hScrollBarSharpness.Name = "hScrollBarSharpness";
            this.hScrollBarSharpness.ScrollButtonsRoundedCornersRadius = 0;
            this.hScrollBarSharpness.ScrollButtonsSemiRounded = true;
            this.hScrollBarSharpness.Size = new System.Drawing.Size(303, 15);
            this.hScrollBarSharpness.SmallChange = 1;
            this.hScrollBarSharpness.TabIndex = 43;
            this.hScrollBarSharpness.Text = "vHScrollBar1";
            this.hScrollBarSharpness.Value = 0;
            this.hScrollBarSharpness.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.hScrollBarSharpness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarSharpness_Scroll);
            // 
            // hScrollBarZoom
            // 
            this.hScrollBarZoom.AllowAnimations = true;
            this.hScrollBarZoom.Enabled = false;
            this.hScrollBarZoom.LargeChange = 10;
            this.hScrollBarZoom.Location = new System.Drawing.Point(767, 488);
            this.hScrollBarZoom.Maximum = 100;
            this.hScrollBarZoom.Minimum = 0;
            this.hScrollBarZoom.Name = "hScrollBarZoom";
            this.hScrollBarZoom.ScrollButtonsRoundedCornersRadius = 0;
            this.hScrollBarZoom.ScrollButtonsSemiRounded = true;
            this.hScrollBarZoom.Size = new System.Drawing.Size(303, 15);
            this.hScrollBarZoom.SmallChange = 1;
            this.hScrollBarZoom.TabIndex = 43;
            this.hScrollBarZoom.Text = "vHScrollBar1";
            this.hScrollBarZoom.Value = 0;
            this.hScrollBarZoom.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.hScrollBarZoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarZoom_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // chkManualCapture
            // 
            this.chkManualCapture.BackColor = System.Drawing.Color.Transparent;
            this.chkManualCapture.Checked = true;
            this.chkManualCapture.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManualCapture.Location = new System.Drawing.Point(767, 9);
            this.chkManualCapture.Name = "chkManualCapture";
            this.chkManualCapture.Size = new System.Drawing.Size(99, 26);
            this.chkManualCapture.TabIndex = 44;
            this.chkManualCapture.Text = "Manual Capture";
            this.chkManualCapture.UseVisualStyleBackColor = false;
            this.chkManualCapture.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.chkManualCapture.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnPreview);
            this.pnlMain.Controls.Add(this.button2);
            this.pnlMain.Controls.Add(this.textBox2);
            this.pnlMain.Controls.Add(this.textBox1);
            this.pnlMain.Controls.Add(this.button1);
            this.pnlMain.Controls.Add(this.chkICAO);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.hScrollBarZoom);
            this.pnlMain.Controls.Add(this.chkManualCapture);
            this.pnlMain.Controls.Add(this.hScrollBarSharpness);
            this.pnlMain.Controls.Add(this.btnReset);
            this.pnlMain.Controls.Add(this.hScrollBarBrightness);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lblZoom);
            this.pnlMain.Controls.Add(this.btnConnect);
            this.pnlMain.Controls.Add(this.lblSharpness);
            this.pnlMain.Controls.Add(this.chkOverrideChecking);
            this.pnlMain.Controls.Add(this.lblBrightness);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.btnDisconnect);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.btnCapture);
            this.pnlMain.Controls.Add(this.lvPhotoProperty);
            this.pnlMain.Controls.Add(this.pbPhoto);
            this.pnlMain.Location = new System.Drawing.Point(4, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1124, 516);
            this.pnlMain.TabIndex = 47;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // btnPreview
            // 
            this.btnPreview.AllowAnimations = true;
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(14, 462);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.RoundedCornersMask = ((byte)(15));
            this.btnPreview.Size = new System.Drawing.Size(96, 36);
            this.btnPreview.TabIndex = 53;
            this.btnPreview.Text = "Review";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 263);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 51;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 237);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 50;
            this.textBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkICAO
            // 
            this.chkICAO.BackColor = System.Drawing.Color.Transparent;
            this.chkICAO.Checked = true;
            this.chkICAO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkICAO.Location = new System.Drawing.Point(981, 5);
            this.chkICAO.Name = "chkICAO";
            this.chkICAO.Size = new System.Drawing.Size(51, 34);
            this.chkICAO.TabIndex = 45;
            this.chkICAO.Text = "ICAO";
            this.chkICAO.UseVisualStyleBackColor = false;
            this.chkICAO.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.chkICAO.CheckedChanged += new System.EventHandler(this.chkICAO_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.AllowAnimations = true;
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Location = new System.Drawing.Point(1032, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.RoundedCornersMask = ((byte)(15));
            this.btnReset.Size = new System.Drawing.Size(77, 32);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pbPhoto
            // 
            this.pbPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhoto.Location = new System.Drawing.Point(116, 14);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(643, 484);
            this.pbPhoto.TabIndex = 35;
            this.pbPhoto.TabStop = false;
            // 
            // ucPhotoCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "ucPhotoCapture";
            this.Size = new System.Drawing.Size(1130, 522);
            this.Load += new System.EventHandler(this.ucPhotoCapture_Load);
            this.Leave += new System.EventHandler(this.ucPhotoCapture_Leave);
            this.Resize += new System.EventHandler(this.ucPhotoCaptureCapture_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPhotoProperty;
        private VIBlend.WinForms.Controls.vButton btnConnect;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.ColumnHeader lvField;
        private System.Windows.Forms.ColumnHeader lvValue;
        private VIBlend.WinForms.Controls.vButton btnDisconnect;
        private VIBlend.WinForms.Controls.vButton btnCapture;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.Label lblSharpness;
        private System.Windows.Forms.Label lblZoom;
        private VIBlend.WinForms.Controls.vHScrollBar hScrollBarBrightness;
        private VIBlend.WinForms.Controls.vCheckBox chkOverrideChecking;
        private VIBlend.WinForms.Controls.vHScrollBar hScrollBarSharpness;
        private VIBlend.WinForms.Controls.vHScrollBar hScrollBarZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private VIBlend.WinForms.Controls.vCheckBox chkManualCapture;
        private System.Windows.Forms.Panel pnlMain;
        private VIBlend.WinForms.Controls.vButton btnReset;
        private System.Windows.Forms.Label label4;
        private VIBlend.WinForms.Controls.vCheckBox chkICAO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private VIBlend.WinForms.Controls.vButton btnPreview;
    }
}
