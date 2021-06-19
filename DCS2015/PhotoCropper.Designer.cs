namespace DCS2015
{
    partial class PhotoCropper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoCropper));
            this.btnTestOutput = new System.Windows.Forms.Button();
            this.pbRaw = new System.Windows.Forms.PictureBox();
            this.lblRawDimension = new System.Windows.Forms.Label();
            this.lblCroppedDimension = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pbFinalCrop = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlCropped = new System.Windows.Forms.Panel();
            this.pbTemp = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTempHeight = new System.Windows.Forms.TextBox();
            this.txtTempWidth = new System.Windows.Forms.TextBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFailCntr = new System.Windows.Forms.TextBox();
            this.txtStartingY = new System.Windows.Forms.TextBox();
            this.txtSourcePhotos = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbFilterPhotoGood = new System.Windows.Forms.RichTextBox();
            this.rtbFilterPhotoBad = new System.Windows.Forms.RichTextBox();
            this.lblFilterPhotoGood = new System.Windows.Forms.Label();
            this.lblFilterPhotoBad = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtRawPhoto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPassedPhoto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRaw)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalCrop)).BeginInit();
            this.pnlCropped.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTemp)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestOutput
            // 
            this.btnTestOutput.Location = new System.Drawing.Point(15, 124);
            this.btnTestOutput.Name = "btnTestOutput";
            this.btnTestOutput.Size = new System.Drawing.Size(148, 23);
            this.btnTestOutput.TabIndex = 4;
            this.btnTestOutput.Text = "TEST OUTPUT";
            this.btnTestOutput.UseVisualStyleBackColor = true;
            this.btnTestOutput.Click += new System.EventHandler(this.btnTestOutput_Click);
            // 
            // pbRaw
            // 
            this.pbRaw.BackColor = System.Drawing.Color.Transparent;
            this.pbRaw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRaw.Location = new System.Drawing.Point(15, 177);
            this.pbRaw.Name = "pbRaw";
            this.pbRaw.Size = new System.Drawing.Size(352, 474);
            this.pbRaw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRaw.TabIndex = 12;
            this.pbRaw.TabStop = false;
            // 
            // lblRawDimension
            // 
            this.lblRawDimension.AutoSize = true;
            this.lblRawDimension.Location = new System.Drawing.Point(12, 161);
            this.lblRawDimension.Name = "lblRawDimension";
            this.lblRawDimension.Size = new System.Drawing.Size(115, 13);
            this.lblRawDimension.TabIndex = 14;
            this.lblRawDimension.Text = "WIDTH: 0, HEIGHT: 0";
            // 
            // lblCroppedDimension
            // 
            this.lblCroppedDimension.AutoSize = true;
            this.lblCroppedDimension.Location = new System.Drawing.Point(380, 161);
            this.lblCroppedDimension.Name = "lblCroppedDimension";
            this.lblCroppedDimension.Size = new System.Drawing.Size(115, 13);
            this.lblCroppedDimension.TabIndex = 15;
            this.lblCroppedDimension.Text = "WIDTH: 0, HEIGHT: 0";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(16, 669);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(148, 36);
            this.btnProcess.TabIndex = 16;
            this.btnProcess.Text = "PROCESS";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 951);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtPassedPhoto);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtHeight);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtWidth);
            this.tabPage1.Controls.Add(this.txtRawPhoto);
            this.tabPage1.Controls.Add(this.pbFinalCrop);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.pnlCropped);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtY);
            this.tabPage1.Controls.Add(this.txtX);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtTempHeight);
            this.tabPage1.Controls.Add(this.txtTempWidth);
            this.tabPage1.Controls.Add(this.btnRight);
            this.tabPage1.Controls.Add(this.btnLeft);
            this.tabPage1.Controls.Add(this.btnDown);
            this.tabPage1.Controls.Add(this.btnUp);
            this.tabPage1.Controls.Add(this.pbRaw);
            this.tabPage1.Controls.Add(this.btnProcess);
            this.tabPage1.Controls.Add(this.btnTestOutput);
            this.tabPage1.Controls.Add(this.lblCroppedDimension);
            this.tabPage1.Controls.Add(this.lblRawDimension);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 925);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "STEP 1. CROP PHOTO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pbFinalCrop
            // 
            this.pbFinalCrop.BackColor = System.Drawing.Color.Transparent;
            this.pbFinalCrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFinalCrop.Location = new System.Drawing.Point(741, 177);
            this.pbFinalCrop.Name = "pbFinalCrop";
            this.pbFinalCrop.Size = new System.Drawing.Size(352, 474);
            this.pbFinalCrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFinalCrop.TabIndex = 32;
            this.pbFinalCrop.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(387, 779);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 36);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlCropped
            // 
            this.pnlCropped.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCropped.Controls.Add(this.pbTemp);
            this.pnlCropped.Location = new System.Drawing.Point(383, 177);
            this.pnlCropped.Name = "pnlCropped";
            this.pnlCropped.Size = new System.Drawing.Size(352, 474);
            this.pnlCropped.TabIndex = 30;
            // 
            // pbTemp
            // 
            this.pbTemp.BackColor = System.Drawing.Color.Transparent;
            this.pbTemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTemp.Location = new System.Drawing.Point(3, 44);
            this.pbTemp.Name = "pbTemp";
            this.pbTemp.Size = new System.Drawing.Size(206, 214);
            this.pbTemp.TabIndex = 29;
            this.pbTemp.TabStop = false;
            this.pbTemp.LocationChanged += new System.EventHandler(this.pbTemp_LocationChanged);
            this.pbTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbTemp_MouseDown);
            this.pbTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbTemp_MouseMove);
            this.pbTemp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbTemp_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 747);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Y (TOP)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 721);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "LEFT (X)";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(434, 743);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(69, 20);
            this.txtY.TabIndex = 26;
            this.txtY.Text = "50";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(434, 717);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(69, 20);
            this.txtX.TabIndex = 25;
            this.txtX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 695);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "HEIGHT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "WIDTH";
            // 
            // txtTempHeight
            // 
            this.txtTempHeight.Location = new System.Drawing.Point(434, 691);
            this.txtTempHeight.Name = "txtTempHeight";
            this.txtTempHeight.Size = new System.Drawing.Size(69, 20);
            this.txtTempHeight.TabIndex = 22;
            this.txtTempHeight.Text = "320";
            // 
            // txtTempWidth
            // 
            this.txtTempWidth.Location = new System.Drawing.Point(434, 665);
            this.txtTempWidth.Name = "txtTempWidth";
            this.txtTempWidth.Size = new System.Drawing.Size(69, 20);
            this.txtTempWidth.TabIndex = 21;
            this.txtTempWidth.Text = "300";
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(590, 696);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(53, 36);
            this.btnRight.TabIndex = 20;
            this.btnRight.Text = "RIGHT";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(536, 696);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(53, 36);
            this.btnLeft.TabIndex = 19;
            this.btnLeft.Text = "LEFT";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(565, 734);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(53, 36);
            this.btnDown.TabIndex = 18;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(565, 658);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(53, 36);
            this.btnUp.TabIndex = 17;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblFilterPhotoBad);
            this.tabPage2.Controls.Add(this.lblFilterPhotoGood);
            this.tabPage2.Controls.Add(this.rtbFilterPhotoBad);
            this.tabPage2.Controls.Add(this.rtbFilterPhotoGood);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtFailCntr);
            this.tabPage2.Controls.Add(this.txtStartingY);
            this.tabPage2.Controls.Add(this.txtSourcePhotos);
            this.tabPage2.Controls.Add(this.btnFilter);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 731);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "STEP 2. FILTER PHOTO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtFailCntr
            // 
            this.txtFailCntr.Location = new System.Drawing.Point(172, 73);
            this.txtFailCntr.Name = "txtFailCntr";
            this.txtFailCntr.Size = new System.Drawing.Size(64, 20);
            this.txtFailCntr.TabIndex = 18;
            this.txtFailCntr.Text = "30";
            // 
            // txtStartingY
            // 
            this.txtStartingY.Location = new System.Drawing.Point(172, 47);
            this.txtStartingY.Name = "txtStartingY";
            this.txtStartingY.Size = new System.Drawing.Size(64, 20);
            this.txtStartingY.TabIndex = 17;
            this.txtStartingY.Text = "0";
            // 
            // txtSourcePhotos
            // 
            this.txtSourcePhotos.Location = new System.Drawing.Point(172, 21);
            this.txtSourcePhotos.Name = "txtSourcePhotos";
            this.txtSourcePhotos.Size = new System.Drawing.Size(496, 20);
            this.txtSourcePhotos.TabIndex = 16;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(19, 115);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(123, 23);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "START FILTER";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "SOURCE PHOTO/S";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "STARTING Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "NO OF INSTANCE TO FAIL";
            // 
            // rtbFilterPhotoGood
            // 
            this.rtbFilterPhotoGood.Location = new System.Drawing.Point(19, 144);
            this.rtbFilterPhotoGood.Name = "rtbFilterPhotoGood";
            this.rtbFilterPhotoGood.ReadOnly = true;
            this.rtbFilterPhotoGood.Size = new System.Drawing.Size(361, 472);
            this.rtbFilterPhotoGood.TabIndex = 27;
            this.rtbFilterPhotoGood.Text = "";
            // 
            // rtbFilterPhotoBad
            // 
            this.rtbFilterPhotoBad.Location = new System.Drawing.Point(386, 144);
            this.rtbFilterPhotoBad.Name = "rtbFilterPhotoBad";
            this.rtbFilterPhotoBad.ReadOnly = true;
            this.rtbFilterPhotoBad.Size = new System.Drawing.Size(361, 472);
            this.rtbFilterPhotoBad.TabIndex = 28;
            this.rtbFilterPhotoBad.Text = "";
            // 
            // lblFilterPhotoGood
            // 
            this.lblFilterPhotoGood.Location = new System.Drawing.Point(240, 125);
            this.lblFilterPhotoGood.Name = "lblFilterPhotoGood";
            this.lblFilterPhotoGood.Size = new System.Drawing.Size(140, 13);
            this.lblFilterPhotoGood.TabIndex = 29;
            this.lblFilterPhotoGood.Text = "GOOD: 0";
            this.lblFilterPhotoGood.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFilterPhotoBad
            // 
            this.lblFilterPhotoBad.Location = new System.Drawing.Point(607, 125);
            this.lblFilterPhotoBad.Name = "lblFilterPhotoBad";
            this.lblFilterPhotoBad.Size = new System.Drawing.Size(140, 13);
            this.lblFilterPhotoBad.TabIndex = 30;
            this.lblFilterPhotoBad.Text = "BAD: 0";
            this.lblFilterPhotoBad.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(889, 649);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "INFO";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(23, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(723, 553);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "HEIGHT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "WIDTH";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(315, 77);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 37;
            this.txtHeight.Text = "300";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "BROWSE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "RAW PHOTO";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(104, 80);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 34;
            this.txtWidth.Text = "300";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtRawPhoto
            // 
            this.txtRawPhoto.Location = new System.Drawing.Point(112, 25);
            this.txtRawPhoto.Name = "txtRawPhoto";
            this.txtRawPhoto.Size = new System.Drawing.Size(315, 20);
            this.txtRawPhoto.TabIndex = 33;
            this.txtRawPhoto.Text = "D:\\MACEMCO CAPTURES\\DATA - Copy\\PREP\\RAW_TEST";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "BROWSE";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "PASSED PHOTO";
            // 
            // txtPassedPhoto
            // 
            this.txtPassedPhoto.Location = new System.Drawing.Point(113, 51);
            this.txtPassedPhoto.Name = "txtPassedPhoto";
            this.txtPassedPhoto.Size = new System.Drawing.Size(315, 20);
            this.txtPassedPhoto.TabIndex = 40;
            // 
            // PhotoCropper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 975);
            this.Controls.Add(this.tabControl1);
            this.Name = "PhotoCropper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoCropper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhotoCropper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbRaw)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinalCrop)).EndInit();
            this.pnlCropped.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTemp)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTestOutput;
        private System.Windows.Forms.PictureBox pbRaw;
        private System.Windows.Forms.Label lblRawDimension;
        private System.Windows.Forms.Label lblCroppedDimension;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTempHeight;
        private System.Windows.Forms.TextBox txtTempWidth;
        private System.Windows.Forms.PictureBox pbTemp;
        private System.Windows.Forms.Panel pnlCropped;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox pbFinalCrop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFailCntr;
        private System.Windows.Forms.TextBox txtStartingY;
        private System.Windows.Forms.TextBox txtSourcePhotos;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFilterPhotoBad;
        private System.Windows.Forms.Label lblFilterPhotoGood;
        private System.Windows.Forms.RichTextBox rtbFilterPhotoBad;
        private System.Windows.Forms.RichTextBox rtbFilterPhotoGood;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPassedPhoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtRawPhoto;
    }
}