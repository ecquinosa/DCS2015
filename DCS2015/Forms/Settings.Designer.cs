namespace DCS2015.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTerminal = new System.Windows.Forms.TabPage();
            this.gbSignatureTablet = new System.Windows.Forms.GroupBox();
            this.rbEvolisSig = new System.Windows.Forms.RadioButton();
            this.rbTopaz = new System.Windows.Forms.RadioButton();
            this.gbOutputPath = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutputPath = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.gbModule = new System.Windows.Forms.GroupBox();
            this.chkModulePreview = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkModuleSignature = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkModuleBiometric = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkModulePhoto = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkModuleDataCapture = new VIBlend.WinForms.Controls.vCheckBox();
            this.gbFingerscanner = new System.Windows.Forms.GroupBox();
            this.rbSecugen = new System.Windows.Forms.RadioButton();
            this.rbSagem = new System.Windows.Forms.RadioButton();
            this.gbOutputFile = new System.Windows.Forms.GroupBox();
            this.chkCompressFinalFolder_tabTerminal = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkDeleteFinalFolder_tabTerminal = new VIBlend.WinForms.Controls.vCheckBox();
            this.txtAdminPass_tabTerminal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStationReference_tabTerminal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOperator_tabTerminal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPhoto = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.rbNone_OCP = new System.Windows.Forms.RadioButton();
            this.rbAccumulated_OCP = new System.Windows.Forms.RadioButton();
            this.rbByCapturedDate_OCP = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDefaultZoom_tabPhoto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDefaultSharpness_tabPhoto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDefaultBrightness_tabPhoto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFaceDistance_Max = new System.Windows.Forms.TextBox();
            this.txtFaceDistance_Min = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhotoGlobalScore_tabPhoto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGrayscaleDensityMax_tabPhoto = new System.Windows.Forms.TextBox();
            this.txtGrayscaleDensityMin_tabPhoto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSharpnessMax_tabPhoto = new System.Windows.Forms.TextBox();
            this.txtSharpnessMin_tabPhoto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBGUniformityMax_tabPhoto = new System.Windows.Forms.TextBox();
            this.txtBGUniformityMin_tabPhoto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSagem = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBitmapVResolution_tabSagem = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBitmapHResolution_tabSagem = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTimeout_tabSagem = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQualityThreshold_tabSagem = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboSagemDevice_tabSagem = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkJPG_tabSagem = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkWSQ_tabSagem = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkANSI_tabSagem = new VIBlend.WinForms.Controls.vCheckBox();
            this.tabSecugen = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtImageHeight_tabSecugen = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtImageWidth_tabSecugen = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTimeout_tabSecugen = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtQualityThreshold_tabSecugen = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cboSecugenDevice_tabSecugen = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkJPG_tabSecugen = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkWSQ_tabSecugen = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkANSI_tabSecugen = new VIBlend.WinForms.Controls.vCheckBox();
            this.tabSignature = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rbNone_OCS = new System.Windows.Forms.RadioButton();
            this.rbAccumulated_OCS = new System.Windows.Forms.RadioButton();
            this.rbByCapturedDate_OCS = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkTIFF_tabSignature = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkBMP_tabSignature = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkJPG_tabSignature = new VIBlend.WinForms.Controls.vCheckBox();
            this.tabSplashProcess = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkSignatureTablet_tabSP = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkBiometric_tabSP = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkCamera_tabSP = new VIBlend.WinForms.Controls.vCheckBox();
            this.chkMegamatcherLicense_tabSP = new VIBlend.WinForms.Controls.vCheckBox();
            this.btnSave = new VIBlend.WinForms.Controls.vButton();
            this.tabControl1.SuspendLayout();
            this.tabTerminal.SuspendLayout();
            this.gbSignatureTablet.SuspendLayout();
            this.gbOutputPath.SuspendLayout();
            this.gbModule.SuspendLayout();
            this.gbFingerscanner.SuspendLayout();
            this.gbOutputFile.SuspendLayout();
            this.tabPhoto.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSagem.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabSecugen.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabSignature.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabSplashProcess.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTerminal);
            this.tabControl1.Controls.Add(this.tabPhoto);
            this.tabControl1.Controls.Add(this.tabSagem);
            this.tabControl1.Controls.Add(this.tabSecugen);
            this.tabControl1.Controls.Add(this.tabSignature);
            this.tabControl1.Controls.Add(this.tabSplashProcess);
            this.tabControl1.Location = new System.Drawing.Point(16, 57);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 449);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTerminal
            // 
            this.tabTerminal.Controls.Add(this.gbSignatureTablet);
            this.tabTerminal.Controls.Add(this.gbOutputPath);
            this.tabTerminal.Controls.Add(this.gbModule);
            this.tabTerminal.Controls.Add(this.gbFingerscanner);
            this.tabTerminal.Controls.Add(this.gbOutputFile);
            this.tabTerminal.Controls.Add(this.txtAdminPass_tabTerminal);
            this.tabTerminal.Controls.Add(this.label10);
            this.tabTerminal.Controls.Add(this.txtStationReference_tabTerminal);
            this.tabTerminal.Controls.Add(this.label9);
            this.tabTerminal.Controls.Add(this.txtOperator_tabTerminal);
            this.tabTerminal.Controls.Add(this.label8);
            this.tabTerminal.Location = new System.Drawing.Point(4, 25);
            this.tabTerminal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTerminal.Name = "tabTerminal";
            this.tabTerminal.Size = new System.Drawing.Size(688, 420);
            this.tabTerminal.TabIndex = 2;
            this.tabTerminal.Text = "Terminal";
            this.tabTerminal.UseVisualStyleBackColor = true;
            // 
            // gbSignatureTablet
            // 
            this.gbSignatureTablet.Controls.Add(this.rbEvolisSig);
            this.gbSignatureTablet.Controls.Add(this.rbTopaz);
            this.gbSignatureTablet.Location = new System.Drawing.Point(324, 272);
            this.gbSignatureTablet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSignatureTablet.Name = "gbSignatureTablet";
            this.gbSignatureTablet.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSignatureTablet.Size = new System.Drawing.Size(353, 65);
            this.gbSignatureTablet.TabIndex = 36;
            this.gbSignatureTablet.TabStop = false;
            this.gbSignatureTablet.Text = "Signature Tablet";
            // 
            // rbEvolisSig
            // 
            this.rbEvolisSig.AutoSize = true;
            this.rbEvolisSig.Checked = true;
            this.rbEvolisSig.Location = new System.Drawing.Point(188, 26);
            this.rbEvolisSig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbEvolisSig.Name = "rbEvolisSig";
            this.rbEvolisSig.Size = new System.Drawing.Size(99, 21);
            this.rbEvolisSig.TabIndex = 1;
            this.rbEvolisSig.TabStop = true;
            this.rbEvolisSig.Text = "Evolis SigX";
            this.rbEvolisSig.UseVisualStyleBackColor = true;
            // 
            // rbTopaz
            // 
            this.rbTopaz.AutoSize = true;
            this.rbTopaz.Location = new System.Drawing.Point(61, 26);
            this.rbTopaz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTopaz.Name = "rbTopaz";
            this.rbTopaz.Size = new System.Drawing.Size(111, 21);
            this.rbTopaz.TabIndex = 0;
            this.rbTopaz.Text = "Topaz Siglite";
            this.rbTopaz.UseVisualStyleBackColor = true;
            // 
            // gbOutputPath
            // 
            this.gbOutputPath.Controls.Add(this.btnBrowseOutputPath);
            this.gbOutputPath.Controls.Add(this.txtOutputPath);
            this.gbOutputPath.Location = new System.Drawing.Point(4, 345);
            this.gbOutputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutputPath.Name = "gbOutputPath";
            this.gbOutputPath.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutputPath.Size = new System.Drawing.Size(673, 65);
            this.gbOutputPath.TabIndex = 36;
            this.gbOutputPath.TabStop = false;
            this.gbOutputPath.Text = "Captured Output Path";
            // 
            // btnBrowseOutputPath
            // 
            this.btnBrowseOutputPath.Location = new System.Drawing.Point(561, 21);
            this.btnBrowseOutputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseOutputPath.Name = "btnBrowseOutputPath";
            this.btnBrowseOutputPath.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseOutputPath.TabIndex = 38;
            this.btnBrowseOutputPath.Text = "Browse";
            this.btnBrowseOutputPath.UseVisualStyleBackColor = true;
            this.btnBrowseOutputPath.Click += new System.EventHandler(this.btnBrowseOutputPath_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(11, 23);
            this.txtOutputPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(543, 22);
            this.txtOutputPath.TabIndex = 37;
            // 
            // gbModule
            // 
            this.gbModule.Controls.Add(this.chkModulePreview);
            this.gbModule.Controls.Add(this.chkModuleSignature);
            this.gbModule.Controls.Add(this.chkModuleBiometric);
            this.gbModule.Controls.Add(this.chkModulePhoto);
            this.gbModule.Controls.Add(this.chkModuleDataCapture);
            this.gbModule.Location = new System.Drawing.Point(4, 117);
            this.gbModule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbModule.Name = "gbModule";
            this.gbModule.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbModule.Size = new System.Drawing.Size(673, 74);
            this.gbModule.TabIndex = 35;
            this.gbModule.TabStop = false;
            this.gbModule.Text = "Module";
            // 
            // chkModulePreview
            // 
            this.chkModulePreview.BackColor = System.Drawing.Color.Transparent;
            this.chkModulePreview.Location = new System.Drawing.Point(523, 25);
            this.chkModulePreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModulePreview.Name = "chkModulePreview";
            this.chkModulePreview.Size = new System.Drawing.Size(81, 30);
            this.chkModulePreview.TabIndex = 4;
            this.chkModulePreview.Text = "Preview";
            this.chkModulePreview.UseVisualStyleBackColor = false;
            this.chkModulePreview.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkModuleSignature
            // 
            this.chkModuleSignature.BackColor = System.Drawing.Color.Transparent;
            this.chkModuleSignature.Location = new System.Drawing.Point(400, 25);
            this.chkModuleSignature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModuleSignature.Name = "chkModuleSignature";
            this.chkModuleSignature.Size = new System.Drawing.Size(95, 30);
            this.chkModuleSignature.TabIndex = 3;
            this.chkModuleSignature.Text = "Signature";
            this.chkModuleSignature.UseVisualStyleBackColor = false;
            this.chkModuleSignature.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.chkModuleSignature.CheckedChanged += new System.EventHandler(this.chkModuleSignature_CheckedChanged);
            // 
            // chkModuleBiometric
            // 
            this.chkModuleBiometric.BackColor = System.Drawing.Color.Transparent;
            this.chkModuleBiometric.Location = new System.Drawing.Point(277, 25);
            this.chkModuleBiometric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModuleBiometric.Name = "chkModuleBiometric";
            this.chkModuleBiometric.Size = new System.Drawing.Size(95, 30);
            this.chkModuleBiometric.TabIndex = 3;
            this.chkModuleBiometric.Text = "Biometric";
            this.chkModuleBiometric.UseVisualStyleBackColor = false;
            this.chkModuleBiometric.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.chkModuleBiometric.CheckedChanged += new System.EventHandler(this.chkModuleBiometric_CheckedChanged);
            // 
            // chkModulePhoto
            // 
            this.chkModulePhoto.BackColor = System.Drawing.Color.Transparent;
            this.chkModulePhoto.Checked = true;
            this.chkModulePhoto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModulePhoto.Location = new System.Drawing.Point(181, 25);
            this.chkModulePhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModulePhoto.Name = "chkModulePhoto";
            this.chkModulePhoto.Size = new System.Drawing.Size(68, 30);
            this.chkModulePhoto.TabIndex = 3;
            this.chkModulePhoto.Text = "Photo";
            this.chkModulePhoto.UseVisualStyleBackColor = false;
            this.chkModulePhoto.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.chkModulePhoto.CheckedChanged += new System.EventHandler(this.chkModulePhoto_CheckedChanged);
            // 
            // chkModuleDataCapture
            // 
            this.chkModuleDataCapture.BackColor = System.Drawing.Color.Transparent;
            this.chkModuleDataCapture.Location = new System.Drawing.Point(32, 25);
            this.chkModuleDataCapture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModuleDataCapture.Name = "chkModuleDataCapture";
            this.chkModuleDataCapture.Size = new System.Drawing.Size(121, 30);
            this.chkModuleDataCapture.TabIndex = 2;
            this.chkModuleDataCapture.Text = "Data Capture";
            this.chkModuleDataCapture.UseVisualStyleBackColor = false;
            this.chkModuleDataCapture.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // gbFingerscanner
            // 
            this.gbFingerscanner.Controls.Add(this.rbSecugen);
            this.gbFingerscanner.Controls.Add(this.rbSagem);
            this.gbFingerscanner.Location = new System.Drawing.Point(4, 274);
            this.gbFingerscanner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFingerscanner.Name = "gbFingerscanner";
            this.gbFingerscanner.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFingerscanner.Size = new System.Drawing.Size(312, 65);
            this.gbFingerscanner.TabIndex = 35;
            this.gbFingerscanner.TabStop = false;
            this.gbFingerscanner.Text = "Finger Scanner";
            // 
            // rbSecugen
            // 
            this.rbSecugen.AutoSize = true;
            this.rbSecugen.Checked = true;
            this.rbSecugen.Location = new System.Drawing.Point(167, 26);
            this.rbSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSecugen.Name = "rbSecugen";
            this.rbSecugen.Size = new System.Drawing.Size(85, 21);
            this.rbSecugen.TabIndex = 1;
            this.rbSecugen.TabStop = true;
            this.rbSecugen.Text = "Secugen";
            this.rbSecugen.UseVisualStyleBackColor = true;
            this.rbSecugen.CheckedChanged += new System.EventHandler(this.rbSecugen_CheckedChanged);
            // 
            // rbSagem
            // 
            this.rbSagem.AutoSize = true;
            this.rbSagem.Location = new System.Drawing.Point(56, 26);
            this.rbSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSagem.Name = "rbSagem";
            this.rbSagem.Size = new System.Drawing.Size(73, 21);
            this.rbSagem.TabIndex = 0;
            this.rbSagem.Text = "Sagem";
            this.rbSagem.UseVisualStyleBackColor = true;
            this.rbSagem.CheckedChanged += new System.EventHandler(this.rbSagem_CheckedChanged);
            // 
            // gbOutputFile
            // 
            this.gbOutputFile.Controls.Add(this.chkCompressFinalFolder_tabTerminal);
            this.gbOutputFile.Controls.Add(this.chkDeleteFinalFolder_tabTerminal);
            this.gbOutputFile.Location = new System.Drawing.Point(4, 196);
            this.gbOutputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutputFile.Name = "gbOutputFile";
            this.gbOutputFile.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutputFile.Size = new System.Drawing.Size(673, 74);
            this.gbOutputFile.TabIndex = 34;
            this.gbOutputFile.TabStop = false;
            this.gbOutputFile.Text = "Output File";
            // 
            // chkCompressFinalFolder_tabTerminal
            // 
            this.chkCompressFinalFolder_tabTerminal.BackColor = System.Drawing.Color.Transparent;
            this.chkCompressFinalFolder_tabTerminal.Location = new System.Drawing.Point(32, 23);
            this.chkCompressFinalFolder_tabTerminal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCompressFinalFolder_tabTerminal.Name = "chkCompressFinalFolder_tabTerminal";
            this.chkCompressFinalFolder_tabTerminal.Size = new System.Drawing.Size(185, 30);
            this.chkCompressFinalFolder_tabTerminal.TabIndex = 2;
            this.chkCompressFinalFolder_tabTerminal.Text = "Compress final folder";
            this.chkCompressFinalFolder_tabTerminal.UseVisualStyleBackColor = false;
            this.chkCompressFinalFolder_tabTerminal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.chkCompressFinalFolder_tabTerminal.CheckedChanged += new System.EventHandler(this.chkCompressFinalFolder_tabTerminal_CheckedChanged);
            // 
            // chkDeleteFinalFolder_tabTerminal
            // 
            this.chkDeleteFinalFolder_tabTerminal.BackColor = System.Drawing.Color.Transparent;
            this.chkDeleteFinalFolder_tabTerminal.Location = new System.Drawing.Point(251, 23);
            this.chkDeleteFinalFolder_tabTerminal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDeleteFinalFolder_tabTerminal.Name = "chkDeleteFinalFolder_tabTerminal";
            this.chkDeleteFinalFolder_tabTerminal.Size = new System.Drawing.Size(396, 30);
            this.chkDeleteFinalFolder_tabTerminal.TabIndex = 1;
            this.chkDeleteFinalFolder_tabTerminal.Text = "Delete final folder (applicable if Compress is checked)";
            this.chkDeleteFinalFolder_tabTerminal.UseVisualStyleBackColor = false;
            this.chkDeleteFinalFolder_tabTerminal.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // txtAdminPass_tabTerminal
            // 
            this.txtAdminPass_tabTerminal.Location = new System.Drawing.Point(216, 84);
            this.txtAdminPass_tabTerminal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdminPass_tabTerminal.Name = "txtAdminPass_tabTerminal";
            this.txtAdminPass_tabTerminal.PasswordChar = '*';
            this.txtAdminPass_tabTerminal.Size = new System.Drawing.Size(368, 22);
            this.txtAdminPass_tabTerminal.TabIndex = 33;
            this.txtAdminPass_tabTerminal.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 87);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Administrator Password";
            this.label10.Visible = false;
            // 
            // txtStationReference_tabTerminal
            // 
            this.txtStationReference_tabTerminal.Location = new System.Drawing.Point(216, 52);
            this.txtStationReference_tabTerminal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStationReference_tabTerminal.Name = "txtStationReference_tabTerminal";
            this.txtStationReference_tabTerminal.Size = new System.Drawing.Size(368, 22);
            this.txtStationReference_tabTerminal.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 55);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "Station Reference";
            // 
            // txtOperator_tabTerminal
            // 
            this.txtOperator_tabTerminal.Enabled = false;
            this.txtOperator_tabTerminal.Location = new System.Drawing.Point(216, 20);
            this.txtOperator_tabTerminal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOperator_tabTerminal.Name = "txtOperator_tabTerminal";
            this.txtOperator_tabTerminal.Size = new System.Drawing.Size(368, 22);
            this.txtOperator_tabTerminal.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Operator";
            // 
            // tabPhoto
            // 
            this.tabPhoto.Controls.Add(this.groupBox12);
            this.tabPhoto.Controls.Add(this.groupBox2);
            this.tabPhoto.Controls.Add(this.comboBoxCameras);
            this.tabPhoto.Controls.Add(this.groupBox1);
            this.tabPhoto.Controls.Add(this.label1);
            this.tabPhoto.Location = new System.Drawing.Point(4, 25);
            this.tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPhoto.Name = "tabPhoto";
            this.tabPhoto.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPhoto.Size = new System.Drawing.Size(688, 420);
            this.tabPhoto.TabIndex = 0;
            this.tabPhoto.Text = "Photo";
            this.tabPhoto.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.rbNone_OCP);
            this.groupBox12.Controls.Add(this.rbAccumulated_OCP);
            this.groupBox12.Controls.Add(this.rbByCapturedDate_OCP);
            this.groupBox12.Location = new System.Drawing.Point(8, 334);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox12.Size = new System.Drawing.Size(669, 74);
            this.groupBox12.TabIndex = 29;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Output Consolidated Photo";
            // 
            // rbNone_OCP
            // 
            this.rbNone_OCP.AutoSize = true;
            this.rbNone_OCP.Checked = true;
            this.rbNone_OCP.Location = new System.Drawing.Point(469, 30);
            this.rbNone_OCP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbNone_OCP.Name = "rbNone_OCP";
            this.rbNone_OCP.Size = new System.Drawing.Size(63, 21);
            this.rbNone_OCP.TabIndex = 5;
            this.rbNone_OCP.TabStop = true;
            this.rbNone_OCP.Text = "None";
            this.rbNone_OCP.UseVisualStyleBackColor = true;
            // 
            // rbAccumulated_OCP
            // 
            this.rbAccumulated_OCP.AutoSize = true;
            this.rbAccumulated_OCP.Location = new System.Drawing.Point(264, 30);
            this.rbAccumulated_OCP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAccumulated_OCP.Name = "rbAccumulated_OCP";
            this.rbAccumulated_OCP.Size = new System.Drawing.Size(110, 21);
            this.rbAccumulated_OCP.TabIndex = 4;
            this.rbAccumulated_OCP.Text = "Accumulated";
            this.rbAccumulated_OCP.UseVisualStyleBackColor = true;
            // 
            // rbByCapturedDate_OCP
            // 
            this.rbByCapturedDate_OCP.AutoSize = true;
            this.rbByCapturedDate_OCP.Location = new System.Drawing.Point(29, 30);
            this.rbByCapturedDate_OCP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbByCapturedDate_OCP.Name = "rbByCapturedDate_OCP";
            this.rbByCapturedDate_OCP.Size = new System.Drawing.Size(141, 21);
            this.rbByCapturedDate_OCP.TabIndex = 3;
            this.rbByCapturedDate_OCP.Text = "By Captured Date";
            this.rbByCapturedDate_OCP.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDefaultZoom_tabPhoto);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtDefaultSharpness_tabPhoto);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDefaultBrightness_tabPhoto);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(8, 268);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(669, 58);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Default Values";
            // 
            // txtDefaultZoom_tabPhoto
            // 
            this.txtDefaultZoom_tabPhoto.Location = new System.Drawing.Point(513, 21);
            this.txtDefaultZoom_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDefaultZoom_tabPhoto.Name = "txtDefaultZoom_tabPhoto";
            this.txtDefaultZoom_tabPhoto.Size = new System.Drawing.Size(71, 22);
            this.txtDefaultZoom_tabPhoto.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(457, 23);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "Zoom";
            // 
            // txtDefaultSharpness_tabPhoto
            // 
            this.txtDefaultSharpness_tabPhoto.Location = new System.Drawing.Point(317, 21);
            this.txtDefaultSharpness_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDefaultSharpness_tabPhoto.Name = "txtDefaultSharpness_tabPhoto";
            this.txtDefaultSharpness_tabPhoto.Size = new System.Drawing.Size(71, 22);
            this.txtDefaultSharpness_tabPhoto.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(232, 23);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Sharpness";
            // 
            // txtDefaultBrightness_tabPhoto
            // 
            this.txtDefaultBrightness_tabPhoto.Location = new System.Drawing.Point(121, 21);
            this.txtDefaultBrightness_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDefaultBrightness_tabPhoto.Name = "txtDefaultBrightness_tabPhoto";
            this.txtDefaultBrightness_tabPhoto.Size = new System.Drawing.Size(71, 22);
            this.txtDefaultBrightness_tabPhoto.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Brightness";
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(129, 27);
            this.comboBoxCameras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(500, 24);
            this.comboBoxCameras.TabIndex = 27;            
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFaceDistance_Max);
            this.groupBox1.Controls.Add(this.txtFaceDistance_Min);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPhotoGlobalScore_tabPhoto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGrayscaleDensityMax_tabPhoto);
            this.groupBox1.Controls.Add(this.txtGrayscaleDensityMin_tabPhoto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSharpnessMax_tabPhoto);
            this.groupBox1.Controls.Add(this.txtSharpnessMin_tabPhoto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBGUniformityMax_tabPhoto);
            this.groupBox1.Controls.Add(this.txtBGUniformityMin_tabPhoto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(669, 204);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // txtFaceDistance_Max
            // 
            this.txtFaceDistance_Max.Location = new System.Drawing.Point(332, 134);
            this.txtFaceDistance_Max.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFaceDistance_Max.Name = "txtFaceDistance_Max";
            this.txtFaceDistance_Max.Size = new System.Drawing.Size(87, 22);
            this.txtFaceDistance_Max.TabIndex = 16;
            // 
            // txtFaceDistance_Min
            // 
            this.txtFaceDistance_Min.Location = new System.Drawing.Point(209, 134);
            this.txtFaceDistance_Min.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFaceDistance_Min.Name = "txtFaceDistance_Min";
            this.txtFaceDistance_Min.Size = new System.Drawing.Size(87, 22);
            this.txtFaceDistance_Min.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 138);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 17);
            this.label19.TabIndex = 14;
            this.label19.Text = "Face Distance";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Maximum";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Minimum";
            // 
            // txtPhotoGlobalScore_tabPhoto
            // 
            this.txtPhotoGlobalScore_tabPhoto.Location = new System.Drawing.Point(209, 165);
            this.txtPhotoGlobalScore_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhotoGlobalScore_tabPhoto.Name = "txtPhotoGlobalScore_tabPhoto";
            this.txtPhotoGlobalScore_tabPhoto.Size = new System.Drawing.Size(209, 22);
            this.txtPhotoGlobalScore_tabPhoto.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Photo Global Score";
            // 
            // txtGrayscaleDensityMax_tabPhoto
            // 
            this.txtGrayscaleDensityMax_tabPhoto.Location = new System.Drawing.Point(332, 103);
            this.txtGrayscaleDensityMax_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrayscaleDensityMax_tabPhoto.Name = "txtGrayscaleDensityMax_tabPhoto";
            this.txtGrayscaleDensityMax_tabPhoto.Size = new System.Drawing.Size(87, 22);
            this.txtGrayscaleDensityMax_tabPhoto.TabIndex = 8;
            // 
            // txtGrayscaleDensityMin_tabPhoto
            // 
            this.txtGrayscaleDensityMin_tabPhoto.Location = new System.Drawing.Point(209, 103);
            this.txtGrayscaleDensityMin_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGrayscaleDensityMin_tabPhoto.Name = "txtGrayscaleDensityMin_tabPhoto";
            this.txtGrayscaleDensityMin_tabPhoto.Size = new System.Drawing.Size(87, 22);
            this.txtGrayscaleDensityMin_tabPhoto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grayscale Density";
            // 
            // txtSharpnessMax_tabPhoto
            // 
            this.txtSharpnessMax_tabPhoto.Location = new System.Drawing.Point(332, 73);
            this.txtSharpnessMax_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSharpnessMax_tabPhoto.Name = "txtSharpnessMax_tabPhoto";
            this.txtSharpnessMax_tabPhoto.Size = new System.Drawing.Size(87, 22);
            this.txtSharpnessMax_tabPhoto.TabIndex = 5;
            // 
            // txtSharpnessMin_tabPhoto
            // 
            this.txtSharpnessMin_tabPhoto.Location = new System.Drawing.Point(209, 73);
            this.txtSharpnessMin_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSharpnessMin_tabPhoto.Name = "txtSharpnessMin_tabPhoto";
            this.txtSharpnessMin_tabPhoto.Size = new System.Drawing.Size(87, 22);
            this.txtSharpnessMin_tabPhoto.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sharpness";
            // 
            // txtBGUniformityMax_tabPhoto
            // 
            this.txtBGUniformityMax_tabPhoto.Location = new System.Drawing.Point(332, 42);
            this.txtBGUniformityMax_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBGUniformityMax_tabPhoto.Name = "txtBGUniformityMax_tabPhoto";
            this.txtBGUniformityMax_tabPhoto.Size = new System.Drawing.Size(87, 22);
            this.txtBGUniformityMax_tabPhoto.TabIndex = 2;
            // 
            // txtBGUniformityMin_tabPhoto
            // 
            this.txtBGUniformityMin_tabPhoto.Location = new System.Drawing.Point(209, 42);
            this.txtBGUniformityMin_tabPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBGUniformityMin_tabPhoto.Name = "txtBGUniformityMin_tabPhoto";
            this.txtBGUniformityMin_tabPhoto.Size = new System.Drawing.Size(87, 22);
            this.txtBGUniformityMin_tabPhoto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Background Uniformity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera";
            // 
            // tabSagem
            // 
            this.tabSagem.Controls.Add(this.groupBox4);
            this.tabSagem.Controls.Add(this.cboSagemDevice_tabSagem);
            this.tabSagem.Controls.Add(this.label14);
            this.tabSagem.Controls.Add(this.groupBox3);
            this.tabSagem.Location = new System.Drawing.Point(4, 25);
            this.tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSagem.Name = "tabSagem";
            this.tabSagem.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSagem.Size = new System.Drawing.Size(688, 420);
            this.tabSagem.TabIndex = 1;
            this.tabSagem.Text = "Sagem";
            this.tabSagem.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtBitmapVResolution_tabSagem);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtBitmapHResolution_tabSagem);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtTimeout_tabSagem);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtQualityThreshold_tabSagem);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(8, 60);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(669, 165);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // txtBitmapVResolution_tabSagem
            // 
            this.txtBitmapVResolution_tabSagem.Location = new System.Drawing.Point(209, 119);
            this.txtBitmapVResolution_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBitmapVResolution_tabSagem.Name = "txtBitmapVResolution_tabSagem";
            this.txtBitmapVResolution_tabSagem.Size = new System.Drawing.Size(209, 22);
            this.txtBitmapVResolution_tabSagem.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 123);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 17);
            this.label18.TabIndex = 15;
            this.label18.Text = "Bitmap_VResolution";
            // 
            // txtBitmapHResolution_tabSagem
            // 
            this.txtBitmapHResolution_tabSagem.Location = new System.Drawing.Point(209, 87);
            this.txtBitmapHResolution_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBitmapHResolution_tabSagem.Name = "txtBitmapHResolution_tabSagem";
            this.txtBitmapHResolution_tabSagem.Size = new System.Drawing.Size(209, 22);
            this.txtBitmapHResolution_tabSagem.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 91);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 17);
            this.label16.TabIndex = 13;
            this.label16.Text = "Bitmap_HResolution";
            // 
            // txtTimeout_tabSagem
            // 
            this.txtTimeout_tabSagem.Location = new System.Drawing.Point(209, 55);
            this.txtTimeout_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeout_tabSagem.Name = "txtTimeout_tabSagem";
            this.txtTimeout_tabSagem.Size = new System.Drawing.Size(209, 22);
            this.txtTimeout_tabSagem.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 59);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "Timeout";
            // 
            // txtQualityThreshold_tabSagem
            // 
            this.txtQualityThreshold_tabSagem.Location = new System.Drawing.Point(209, 23);
            this.txtQualityThreshold_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQualityThreshold_tabSagem.Name = "txtQualityThreshold_tabSagem";
            this.txtQualityThreshold_tabSagem.Size = new System.Drawing.Size(209, 22);
            this.txtQualityThreshold_tabSagem.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 27);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 17);
            this.label17.TabIndex = 9;
            this.label17.Text = "Quality Threshold";
            // 
            // cboSagemDevice_tabSagem
            // 
            this.cboSagemDevice_tabSagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSagemDevice_tabSagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSagemDevice_tabSagem.FormattingEnabled = true;
            this.cboSagemDevice_tabSagem.Location = new System.Drawing.Point(129, 27);
            this.cboSagemDevice_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSagemDevice_tabSagem.Name = "cboSagemDevice_tabSagem";
            this.cboSagemDevice_tabSagem.Size = new System.Drawing.Size(500, 24);
            this.cboSagemDevice_tabSagem.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Device";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkJPG_tabSagem);
            this.groupBox3.Controls.Add(this.chkWSQ_tabSagem);
            this.groupBox3.Controls.Add(this.chkANSI_tabSagem);
            this.groupBox3.Location = new System.Drawing.Point(8, 233);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(669, 74);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output File";
            // 
            // chkJPG_tabSagem
            // 
            this.chkJPG_tabSagem.BackColor = System.Drawing.Color.Transparent;
            this.chkJPG_tabSagem.Location = new System.Drawing.Point(32, 23);
            this.chkJPG_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkJPG_tabSagem.Name = "chkJPG_tabSagem";
            this.chkJPG_tabSagem.Size = new System.Drawing.Size(96, 30);
            this.chkJPG_tabSagem.TabIndex = 2;
            this.chkJPG_tabSagem.Text = "JPG";
            this.chkJPG_tabSagem.UseVisualStyleBackColor = false;
            this.chkJPG_tabSagem.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkWSQ_tabSagem
            // 
            this.chkWSQ_tabSagem.BackColor = System.Drawing.Color.Transparent;
            this.chkWSQ_tabSagem.Checked = true;
            this.chkWSQ_tabSagem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWSQ_tabSagem.Enabled = false;
            this.chkWSQ_tabSagem.Location = new System.Drawing.Point(469, 23);
            this.chkWSQ_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkWSQ_tabSagem.Name = "chkWSQ_tabSagem";
            this.chkWSQ_tabSagem.Size = new System.Drawing.Size(96, 30);
            this.chkWSQ_tabSagem.TabIndex = 1;
            this.chkWSQ_tabSagem.Text = "WSQ";
            this.chkWSQ_tabSagem.UseVisualStyleBackColor = false;
            this.chkWSQ_tabSagem.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkANSI_tabSagem
            // 
            this.chkANSI_tabSagem.BackColor = System.Drawing.Color.Transparent;
            this.chkANSI_tabSagem.Checked = true;
            this.chkANSI_tabSagem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkANSI_tabSagem.Enabled = false;
            this.chkANSI_tabSagem.Location = new System.Drawing.Point(251, 23);
            this.chkANSI_tabSagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkANSI_tabSagem.Name = "chkANSI_tabSagem";
            this.chkANSI_tabSagem.Size = new System.Drawing.Size(96, 30);
            this.chkANSI_tabSagem.TabIndex = 1;
            this.chkANSI_tabSagem.Text = "ANSI 378";
            this.chkANSI_tabSagem.UseVisualStyleBackColor = false;
            this.chkANSI_tabSagem.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // tabSecugen
            // 
            this.tabSecugen.Controls.Add(this.groupBox6);
            this.tabSecugen.Controls.Add(this.cboSecugenDevice_tabSecugen);
            this.tabSecugen.Controls.Add(this.label24);
            this.tabSecugen.Controls.Add(this.groupBox7);
            this.tabSecugen.Location = new System.Drawing.Point(4, 25);
            this.tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSecugen.Name = "tabSecugen";
            this.tabSecugen.Size = new System.Drawing.Size(688, 420);
            this.tabSecugen.TabIndex = 3;
            this.tabSecugen.Text = "Secugen";
            this.tabSecugen.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtImageHeight_tabSecugen);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.txtImageWidth_tabSecugen);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txtTimeout_tabSecugen);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.txtQualityThreshold_tabSecugen);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(8, 60);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(669, 165);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Parameters";
            // 
            // txtImageHeight_tabSecugen
            // 
            this.txtImageHeight_tabSecugen.Location = new System.Drawing.Point(209, 119);
            this.txtImageHeight_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImageHeight_tabSecugen.Name = "txtImageHeight_tabSecugen";
            this.txtImageHeight_tabSecugen.Size = new System.Drawing.Size(209, 22);
            this.txtImageHeight_tabSecugen.TabIndex = 16;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 123);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 17);
            this.label20.TabIndex = 15;
            this.label20.Text = "Image Height";
            // 
            // txtImageWidth_tabSecugen
            // 
            this.txtImageWidth_tabSecugen.Location = new System.Drawing.Point(209, 87);
            this.txtImageWidth_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImageWidth_tabSecugen.Name = "txtImageWidth_tabSecugen";
            this.txtImageWidth_tabSecugen.Size = new System.Drawing.Size(209, 22);
            this.txtImageWidth_tabSecugen.TabIndex = 14;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 91);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 17);
            this.label21.TabIndex = 13;
            this.label21.Text = "Image Width";
            // 
            // txtTimeout_tabSecugen
            // 
            this.txtTimeout_tabSecugen.Location = new System.Drawing.Point(209, 55);
            this.txtTimeout_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimeout_tabSecugen.Name = "txtTimeout_tabSecugen";
            this.txtTimeout_tabSecugen.Size = new System.Drawing.Size(209, 22);
            this.txtTimeout_tabSecugen.TabIndex = 12;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(28, 59);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 17);
            this.label22.TabIndex = 11;
            this.label22.Text = "Timeout";
            // 
            // txtQualityThreshold_tabSecugen
            // 
            this.txtQualityThreshold_tabSecugen.Location = new System.Drawing.Point(209, 23);
            this.txtQualityThreshold_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQualityThreshold_tabSecugen.Name = "txtQualityThreshold_tabSecugen";
            this.txtQualityThreshold_tabSecugen.Size = new System.Drawing.Size(209, 22);
            this.txtQualityThreshold_tabSecugen.TabIndex = 10;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(28, 27);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 17);
            this.label23.TabIndex = 9;
            this.label23.Text = "Quality Threshold";
            // 
            // cboSecugenDevice_tabSecugen
            // 
            this.cboSecugenDevice_tabSecugen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSecugenDevice_tabSecugen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSecugenDevice_tabSecugen.FormattingEnabled = true;
            this.cboSecugenDevice_tabSecugen.Location = new System.Drawing.Point(129, 27);
            this.cboSecugenDevice_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSecugenDevice_tabSecugen.Name = "cboSecugenDevice_tabSecugen";
            this.cboSecugenDevice_tabSecugen.Size = new System.Drawing.Size(500, 24);
            this.cboSecugenDevice_tabSecugen.TabIndex = 33;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(33, 32);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 17);
            this.label24.TabIndex = 32;
            this.label24.Text = "Device";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkJPG_tabSecugen);
            this.groupBox7.Controls.Add(this.chkWSQ_tabSecugen);
            this.groupBox7.Controls.Add(this.chkANSI_tabSecugen);
            this.groupBox7.Location = new System.Drawing.Point(8, 233);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox7.Size = new System.Drawing.Size(669, 74);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Output File";
            // 
            // chkJPG_tabSecugen
            // 
            this.chkJPG_tabSecugen.BackColor = System.Drawing.Color.Transparent;
            this.chkJPG_tabSecugen.Location = new System.Drawing.Point(32, 23);
            this.chkJPG_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkJPG_tabSecugen.Name = "chkJPG_tabSecugen";
            this.chkJPG_tabSecugen.Size = new System.Drawing.Size(96, 30);
            this.chkJPG_tabSecugen.TabIndex = 2;
            this.chkJPG_tabSecugen.Text = "JPG";
            this.chkJPG_tabSecugen.UseVisualStyleBackColor = false;
            this.chkJPG_tabSecugen.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkWSQ_tabSecugen
            // 
            this.chkWSQ_tabSecugen.BackColor = System.Drawing.Color.Transparent;
            this.chkWSQ_tabSecugen.Checked = true;
            this.chkWSQ_tabSecugen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWSQ_tabSecugen.Enabled = false;
            this.chkWSQ_tabSecugen.Location = new System.Drawing.Point(469, 23);
            this.chkWSQ_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkWSQ_tabSecugen.Name = "chkWSQ_tabSecugen";
            this.chkWSQ_tabSecugen.Size = new System.Drawing.Size(96, 30);
            this.chkWSQ_tabSecugen.TabIndex = 1;
            this.chkWSQ_tabSecugen.Text = "WSQ";
            this.chkWSQ_tabSecugen.UseVisualStyleBackColor = false;
            this.chkWSQ_tabSecugen.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkANSI_tabSecugen
            // 
            this.chkANSI_tabSecugen.BackColor = System.Drawing.Color.Transparent;
            this.chkANSI_tabSecugen.Checked = true;
            this.chkANSI_tabSecugen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkANSI_tabSecugen.Enabled = false;
            this.chkANSI_tabSecugen.Location = new System.Drawing.Point(251, 23);
            this.chkANSI_tabSecugen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkANSI_tabSecugen.Name = "chkANSI_tabSecugen";
            this.chkANSI_tabSecugen.Size = new System.Drawing.Size(96, 30);
            this.chkANSI_tabSecugen.TabIndex = 1;
            this.chkANSI_tabSecugen.Text = "ANSI 378";
            this.chkANSI_tabSecugen.UseVisualStyleBackColor = false;
            this.chkANSI_tabSecugen.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // tabSignature
            // 
            this.tabSignature.Controls.Add(this.groupBox13);
            this.tabSignature.Controls.Add(this.groupBox8);
            this.tabSignature.Location = new System.Drawing.Point(4, 25);
            this.tabSignature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSignature.Name = "tabSignature";
            this.tabSignature.Size = new System.Drawing.Size(688, 420);
            this.tabSignature.TabIndex = 4;
            this.tabSignature.Text = "Signature";
            this.tabSignature.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rbNone_OCS);
            this.groupBox13.Controls.Add(this.rbAccumulated_OCS);
            this.groupBox13.Controls.Add(this.rbByCapturedDate_OCS);
            this.groupBox13.Enabled = false;
            this.groupBox13.Location = new System.Drawing.Point(8, 96);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox13.Size = new System.Drawing.Size(669, 74);
            this.groupBox13.TabIndex = 33;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Output Consolidated Signature";
            // 
            // rbNone_OCS
            // 
            this.rbNone_OCS.AutoSize = true;
            this.rbNone_OCS.Checked = true;
            this.rbNone_OCS.Location = new System.Drawing.Point(496, 28);
            this.rbNone_OCS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbNone_OCS.Name = "rbNone_OCS";
            this.rbNone_OCS.Size = new System.Drawing.Size(63, 21);
            this.rbNone_OCS.TabIndex = 7;
            this.rbNone_OCS.TabStop = true;
            this.rbNone_OCS.Text = "None";
            this.rbNone_OCS.UseVisualStyleBackColor = true;
            // 
            // rbAccumulated_OCS
            // 
            this.rbAccumulated_OCS.AutoSize = true;
            this.rbAccumulated_OCS.Location = new System.Drawing.Point(279, 28);
            this.rbAccumulated_OCS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbAccumulated_OCS.Name = "rbAccumulated_OCS";
            this.rbAccumulated_OCS.Size = new System.Drawing.Size(110, 21);
            this.rbAccumulated_OCS.TabIndex = 6;
            this.rbAccumulated_OCS.Text = "Accumulated";
            this.rbAccumulated_OCS.UseVisualStyleBackColor = true;
            // 
            // rbByCapturedDate_OCS
            // 
            this.rbByCapturedDate_OCS.AutoSize = true;
            this.rbByCapturedDate_OCS.Location = new System.Drawing.Point(32, 28);
            this.rbByCapturedDate_OCS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbByCapturedDate_OCS.Name = "rbByCapturedDate_OCS";
            this.rbByCapturedDate_OCS.Size = new System.Drawing.Size(141, 21);
            this.rbByCapturedDate_OCS.TabIndex = 5;
            this.rbByCapturedDate_OCS.Text = "By Captured Date";
            this.rbByCapturedDate_OCS.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkTIFF_tabSignature);
            this.groupBox8.Controls.Add(this.chkBMP_tabSignature);
            this.groupBox8.Controls.Add(this.chkJPG_tabSignature);
            this.groupBox8.Location = new System.Drawing.Point(8, 15);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox8.Size = new System.Drawing.Size(669, 74);
            this.groupBox8.TabIndex = 32;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Output File";
            // 
            // chkTIFF_tabSignature
            // 
            this.chkTIFF_tabSignature.BackColor = System.Drawing.Color.Transparent;
            this.chkTIFF_tabSignature.Checked = true;
            this.chkTIFF_tabSignature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTIFF_tabSignature.Location = new System.Drawing.Point(32, 23);
            this.chkTIFF_tabSignature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTIFF_tabSignature.Name = "chkTIFF_tabSignature";
            this.chkTIFF_tabSignature.Size = new System.Drawing.Size(96, 30);
            this.chkTIFF_tabSignature.TabIndex = 2;
            this.chkTIFF_tabSignature.Text = "TIFF";
            this.chkTIFF_tabSignature.UseVisualStyleBackColor = false;
            this.chkTIFF_tabSignature.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkBMP_tabSignature
            // 
            this.chkBMP_tabSignature.BackColor = System.Drawing.Color.Transparent;
            this.chkBMP_tabSignature.Location = new System.Drawing.Point(469, 23);
            this.chkBMP_tabSignature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBMP_tabSignature.Name = "chkBMP_tabSignature";
            this.chkBMP_tabSignature.Size = new System.Drawing.Size(96, 30);
            this.chkBMP_tabSignature.TabIndex = 1;
            this.chkBMP_tabSignature.Text = "BMP";
            this.chkBMP_tabSignature.UseVisualStyleBackColor = false;
            this.chkBMP_tabSignature.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkJPG_tabSignature
            // 
            this.chkJPG_tabSignature.BackColor = System.Drawing.Color.Transparent;
            this.chkJPG_tabSignature.Checked = true;
            this.chkJPG_tabSignature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJPG_tabSignature.Location = new System.Drawing.Point(251, 23);
            this.chkJPG_tabSignature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkJPG_tabSignature.Name = "chkJPG_tabSignature";
            this.chkJPG_tabSignature.Size = new System.Drawing.Size(96, 30);
            this.chkJPG_tabSignature.TabIndex = 1;
            this.chkJPG_tabSignature.Text = "JPG";
            this.chkJPG_tabSignature.UseVisualStyleBackColor = false;
            this.chkJPG_tabSignature.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // tabSplashProcess
            // 
            this.tabSplashProcess.Controls.Add(this.groupBox5);
            this.tabSplashProcess.Location = new System.Drawing.Point(4, 25);
            this.tabSplashProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSplashProcess.Name = "tabSplashProcess";
            this.tabSplashProcess.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSplashProcess.Size = new System.Drawing.Size(688, 420);
            this.tabSplashProcess.TabIndex = 5;
            this.tabSplashProcess.Text = "Splash Process";
            this.tabSplashProcess.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkSignatureTablet_tabSP);
            this.groupBox5.Controls.Add(this.chkBiometric_tabSP);
            this.groupBox5.Controls.Add(this.chkCamera_tabSP);
            this.groupBox5.Controls.Add(this.chkMegamatcherLicense_tabSP);
            this.groupBox5.Location = new System.Drawing.Point(8, 18);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(665, 229);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Validation";
            // 
            // chkSignatureTablet_tabSP
            // 
            this.chkSignatureTablet_tabSP.BackColor = System.Drawing.Color.Transparent;
            this.chkSignatureTablet_tabSP.Location = new System.Drawing.Point(21, 134);
            this.chkSignatureTablet_tabSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSignatureTablet_tabSP.Name = "chkSignatureTablet_tabSP";
            this.chkSignatureTablet_tabSP.Size = new System.Drawing.Size(209, 30);
            this.chkSignatureTablet_tabSP.TabIndex = 4;
            this.chkSignatureTablet_tabSP.Text = "Topaz Signature Tablet";
            this.chkSignatureTablet_tabSP.UseVisualStyleBackColor = false;
            this.chkSignatureTablet_tabSP.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkBiometric_tabSP
            // 
            this.chkBiometric_tabSP.BackColor = System.Drawing.Color.Transparent;
            this.chkBiometric_tabSP.Location = new System.Drawing.Point(21, 97);
            this.chkBiometric_tabSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBiometric_tabSP.Name = "chkBiometric_tabSP";
            this.chkBiometric_tabSP.Size = new System.Drawing.Size(177, 30);
            this.chkBiometric_tabSP.TabIndex = 3;
            this.chkBiometric_tabSP.Text = "Biometric";
            this.chkBiometric_tabSP.UseVisualStyleBackColor = false;
            this.chkBiometric_tabSP.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkCamera_tabSP
            // 
            this.chkCamera_tabSP.BackColor = System.Drawing.Color.Transparent;
            this.chkCamera_tabSP.Location = new System.Drawing.Point(21, 60);
            this.chkCamera_tabSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCamera_tabSP.Name = "chkCamera_tabSP";
            this.chkCamera_tabSP.Size = new System.Drawing.Size(177, 30);
            this.chkCamera_tabSP.TabIndex = 3;
            this.chkCamera_tabSP.Text = "Camera";
            this.chkCamera_tabSP.UseVisualStyleBackColor = false;
            this.chkCamera_tabSP.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // chkMegamatcherLicense_tabSP
            // 
            this.chkMegamatcherLicense_tabSP.BackColor = System.Drawing.Color.Transparent;
            this.chkMegamatcherLicense_tabSP.Location = new System.Drawing.Point(21, 23);
            this.chkMegamatcherLicense_tabSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMegamatcherLicense_tabSP.Name = "chkMegamatcherLicense_tabSP";
            this.chkMegamatcherLicense_tabSP.Size = new System.Drawing.Size(177, 30);
            this.chkMegamatcherLicense_tabSP.TabIndex = 2;
            this.chkMegamatcherLicense_tabSP.Text = "Megamatcher License";
            this.chkMegamatcherLicense_tabSP.UseVisualStyleBackColor = false;
            this.chkMegamatcherLicense_tabSP.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(16, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.RoundedCornersMask = ((byte)(15));
            this.btnSave.Size = new System.Drawing.Size(89, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010BLUE;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 518);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTerminal.ResumeLayout(false);
            this.tabTerminal.PerformLayout();
            this.gbSignatureTablet.ResumeLayout(false);
            this.gbSignatureTablet.PerformLayout();
            this.gbOutputPath.ResumeLayout(false);
            this.gbOutputPath.PerformLayout();
            this.gbModule.ResumeLayout(false);
            this.gbFingerscanner.ResumeLayout(false);
            this.gbFingerscanner.PerformLayout();
            this.gbOutputFile.ResumeLayout(false);
            this.tabPhoto.ResumeLayout(false);
            this.tabPhoto.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSagem.ResumeLayout(false);
            this.tabSagem.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabSecugen.ResumeLayout(false);
            this.tabSecugen.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tabSignature.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tabSplashProcess.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPhoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabSagem;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.TextBox txtPhotoGlobalScore_tabPhoto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGrayscaleDensityMax_tabPhoto;
        private System.Windows.Forms.TextBox txtGrayscaleDensityMin_tabPhoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSharpnessMax_tabPhoto;
        private System.Windows.Forms.TextBox txtSharpnessMin_tabPhoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBGUniformityMax_tabPhoto;
        private System.Windows.Forms.TextBox txtBGUniformityMin_tabPhoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabTerminal;
        private System.Windows.Forms.TextBox txtStationReference_tabTerminal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOperator_tabTerminal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAdminPass_tabTerminal;
        private System.Windows.Forms.Label label10;
        private VIBlend.WinForms.Controls.vButton btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private VIBlend.WinForms.Controls.vCheckBox chkANSI_tabSagem;
        private VIBlend.WinForms.Controls.vCheckBox chkWSQ_tabSagem;
        private System.Windows.Forms.TextBox txtDefaultZoom_tabPhoto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDefaultSharpness_tabPhoto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDefaultBrightness_tabPhoto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtQualityThreshold_tabSagem;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboSagemDevice_tabSagem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBitmapVResolution_tabSagem;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBitmapHResolution_tabSagem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTimeout_tabSagem;
        private System.Windows.Forms.Label label15;
        private VIBlend.WinForms.Controls.vCheckBox chkJPG_tabSagem;
        private System.Windows.Forms.GroupBox gbOutputFile;
        private VIBlend.WinForms.Controls.vCheckBox chkCompressFinalFolder_tabTerminal;
        private VIBlend.WinForms.Controls.vCheckBox chkDeleteFinalFolder_tabTerminal;
        private System.Windows.Forms.TextBox txtFaceDistance_Max;
        private System.Windows.Forms.TextBox txtFaceDistance_Min;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabSecugen;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtImageHeight_tabSecugen;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtImageWidth_tabSecugen;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTimeout_tabSecugen;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtQualityThreshold_tabSecugen;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cboSecugenDevice_tabSecugen;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox7;
        private VIBlend.WinForms.Controls.vCheckBox chkJPG_tabSecugen;
        private VIBlend.WinForms.Controls.vCheckBox chkWSQ_tabSecugen;
        private VIBlend.WinForms.Controls.vCheckBox chkANSI_tabSecugen;
        private System.Windows.Forms.TabPage tabSignature;
        private System.Windows.Forms.GroupBox groupBox8;
        private VIBlend.WinForms.Controls.vCheckBox chkTIFF_tabSignature;
        private VIBlend.WinForms.Controls.vCheckBox chkBMP_tabSignature;
        private VIBlend.WinForms.Controls.vCheckBox chkJPG_tabSignature;
        private System.Windows.Forms.GroupBox gbFingerscanner;
        private System.Windows.Forms.RadioButton rbSecugen;
        private System.Windows.Forms.RadioButton rbSagem;
        private System.Windows.Forms.GroupBox gbModule;
        private VIBlend.WinForms.Controls.vCheckBox chkModuleSignature;
        private VIBlend.WinForms.Controls.vCheckBox chkModuleBiometric;
        private VIBlend.WinForms.Controls.vCheckBox chkModulePhoto;
        private VIBlend.WinForms.Controls.vCheckBox chkModuleDataCapture;
        private VIBlend.WinForms.Controls.vCheckBox chkModulePreview;
        private System.Windows.Forms.GroupBox gbOutputPath;
        private System.Windows.Forms.Button btnBrowseOutputPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RadioButton rbAccumulated_OCP;
        private System.Windows.Forms.RadioButton rbByCapturedDate_OCP;
        private System.Windows.Forms.RadioButton rbAccumulated_OCS;
        private System.Windows.Forms.RadioButton rbByCapturedDate_OCS;
        private System.Windows.Forms.RadioButton rbNone_OCP;
        private System.Windows.Forms.RadioButton rbNone_OCS;
        private System.Windows.Forms.TabPage tabSplashProcess;
        private System.Windows.Forms.GroupBox groupBox5;
        private VIBlend.WinForms.Controls.vCheckBox chkBiometric_tabSP;
        private VIBlend.WinForms.Controls.vCheckBox chkCamera_tabSP;
        private VIBlend.WinForms.Controls.vCheckBox chkMegamatcherLicense_tabSP;
        private VIBlend.WinForms.Controls.vCheckBox chkSignatureTablet_tabSP;
        private System.Windows.Forms.GroupBox gbSignatureTablet;
        private System.Windows.Forms.RadioButton rbEvolisSig;
        private System.Windows.Forms.RadioButton rbTopaz;
    }
}