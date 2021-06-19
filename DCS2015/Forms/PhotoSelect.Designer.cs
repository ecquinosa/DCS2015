namespace DCS2015.Forms
{
    partial class PhotoSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoSelect));
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.pnlOne = new System.Windows.Forms.Panel();
            this.pnlTwo = new System.Windows.Forms.Panel();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.pnlThree = new System.Windows.Forms.Panel();
            this.rbThree = new System.Windows.Forms.RadioButton();
            this.pbThree = new System.Windows.Forms.PictureBox();
            this.pbTwo = new System.Windows.Forms.PictureBox();
            this.pbOne = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new VIBlend.WinForms.Controls.vButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOne)).BeginInit();
            this.SuspendLayout();
            // 
            // rbOne
            // 
            this.rbOne.AutoSize = true;
            this.rbOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOne.Location = new System.Drawing.Point(124, 345);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(14, 13);
            this.rbOne.TabIndex = 3;
            this.rbOne.TabStop = true;
            this.rbOne.UseVisualStyleBackColor = true;
            this.rbOne.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // pnlOne
            // 
            this.pnlOne.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlOne.BackgroundImage")));
            this.pnlOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlOne.Location = new System.Drawing.Point(14, 334);
            this.pnlOne.Name = "pnlOne";
            this.pnlOne.Size = new System.Drawing.Size(29, 28);
            this.pnlOne.TabIndex = 4;
            this.pnlOne.Visible = false;
            // 
            // pnlTwo
            // 
            this.pnlTwo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTwo.BackgroundImage")));
            this.pnlTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTwo.Location = new System.Drawing.Point(269, 334);
            this.pnlTwo.Name = "pnlTwo";
            this.pnlTwo.Size = new System.Drawing.Size(29, 28);
            this.pnlTwo.TabIndex = 5;
            this.pnlTwo.Visible = false;
            // 
            // rbTwo
            // 
            this.rbTwo.AutoSize = true;
            this.rbTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTwo.Location = new System.Drawing.Point(381, 345);
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.Size = new System.Drawing.Size(14, 13);
            this.rbTwo.TabIndex = 3;
            this.rbTwo.TabStop = true;
            this.rbTwo.UseVisualStyleBackColor = true;
            this.rbTwo.CheckedChanged += new System.EventHandler(this.rbTwo_CheckedChanged);
            // 
            // pnlThree
            // 
            this.pnlThree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlThree.BackgroundImage")));
            this.pnlThree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlThree.Location = new System.Drawing.Point(524, 334);
            this.pnlThree.Name = "pnlThree";
            this.pnlThree.Size = new System.Drawing.Size(29, 28);
            this.pnlThree.TabIndex = 6;
            this.pnlThree.Visible = false;
            // 
            // rbThree
            // 
            this.rbThree.AutoSize = true;
            this.rbThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThree.Location = new System.Drawing.Point(636, 345);
            this.rbThree.Name = "rbThree";
            this.rbThree.Size = new System.Drawing.Size(14, 13);
            this.rbThree.TabIndex = 3;
            this.rbThree.TabStop = true;
            this.rbThree.UseVisualStyleBackColor = true;
            this.rbThree.CheckedChanged += new System.EventHandler(this.rbThree_CheckedChanged);
            // 
            // pbThree
            // 
            this.pbThree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbThree.Location = new System.Drawing.Point(524, 18);
            this.pbThree.Name = "pbThree";
            this.pbThree.Size = new System.Drawing.Size(234, 310);
            this.pbThree.TabIndex = 2;
            this.pbThree.TabStop = false;
            // 
            // pbTwo
            // 
            this.pbTwo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTwo.Location = new System.Drawing.Point(269, 18);
            this.pbTwo.Name = "pbTwo";
            this.pbTwo.Size = new System.Drawing.Size(234, 310);
            this.pbTwo.TabIndex = 1;
            this.pbTwo.TabStop = false;
            // 
            // pbOne
            // 
            this.pbOne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbOne.Location = new System.Drawing.Point(14, 18);
            this.pbOne.Name = "pbOne";
            this.pbOne.Size = new System.Drawing.Size(234, 310);
            this.pbOne.TabIndex = 0;
            this.pbOne.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AllowAnimations = true;
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.Location = new System.Drawing.Point(688, 377);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.RoundedCornersMask = ((byte)(15));
            this.btnSubmit.Size = new System.Drawing.Size(74, 34);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // PhotoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 423);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbThree);
            this.Controls.Add(this.rbTwo);
            this.Controls.Add(this.rbOne);
            this.Controls.Add(this.pnlThree);
            this.Controls.Add(this.pnlTwo);
            this.Controls.Add(this.pnlOne);
            this.Controls.Add(this.pbThree);
            this.Controls.Add(this.pbTwo);
            this.Controls.Add(this.pbOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PhotoSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PHOTO";
            this.Load += new System.EventHandler(this.PhotoSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOne)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOne;
        private System.Windows.Forms.PictureBox pbTwo;
        private System.Windows.Forms.PictureBox pbThree;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.Panel pnlOne;
        private System.Windows.Forms.Panel pnlTwo;
        private System.Windows.Forms.RadioButton rbTwo;
        private System.Windows.Forms.Panel pnlThree;
        private System.Windows.Forms.RadioButton rbThree;
        private VIBlend.WinForms.Controls.vButton btnSubmit;
    }
}