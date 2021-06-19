namespace DCS2015.Forms
{
    partial class SignatureCapture_Confirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignatureCapture_Confirm));
            this.axSTPadCapt1 = new AxSTPadCaptLib.AxSTPadCapt();
            this.txtDisclaimer = new System.Windows.Forms.TextBox();
            this.btnCancel = new VIBlend.WinForms.Controls.vButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPenwidth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axSTPadCapt1)).BeginInit();
            this.SuspendLayout();
            // 
            // axSTPadCapt1
            // 
            this.axSTPadCapt1.Enabled = true;
            this.axSTPadCapt1.Location = new System.Drawing.Point(60, 88);
            this.axSTPadCapt1.Name = "axSTPadCapt1";
            this.axSTPadCapt1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSTPadCapt1.OcxState")));
            this.axSTPadCapt1.Size = new System.Drawing.Size(320, 160);
            this.axSTPadCapt1.TabIndex = 52;
            this.axSTPadCapt1.SensorHotSpotPressed += new AxSTPadCaptLib._DSTPadCaptEvents_SensorHotSpotPressedEventHandler(this.axSTPadCapt1_SensorHotSpotPressed);
            // 
            // txtDisclaimer
            // 
            this.txtDisclaimer.BackColor = System.Drawing.Color.White;
            this.txtDisclaimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDisclaimer.Enabled = false;
            this.txtDisclaimer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisclaimer.ForeColor = System.Drawing.Color.DimGray;
            this.txtDisclaimer.Location = new System.Drawing.Point(4, 5);
            this.txtDisclaimer.Multiline = true;
            this.txtDisclaimer.Name = "txtDisclaimer";
            this.txtDisclaimer.Size = new System.Drawing.Size(432, 73);
            this.txtDisclaimer.TabIndex = 53;
            this.txtDisclaimer.Text = resources.GetString("txtDisclaimer.Text");
            // 
            // btnCancel
            // 
            this.btnCancel.AllowAnimations = true;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(12, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundedCornersMask = ((byte)(15));
            this.btnCancel.Size = new System.Drawing.Size(74, 34);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 56;
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
            this.cboPenwidth.Location = new System.Drawing.Point(326, 254);
            this.cboPenwidth.Name = "cboPenwidth";
            this.cboPenwidth.Size = new System.Drawing.Size(54, 21);
            this.cboPenwidth.TabIndex = 55;
            // 
            // SignatureCapture_Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 316);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPenwidth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDisclaimer);
            this.Controls.Add(this.axSTPadCapt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SignatureCapture_Confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGN TO CONFIRM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignatureCapture_Confirm_FormClosing);
            this.Load += new System.EventHandler(this.SignatureCapture_Confirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSTPadCapt1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxSTPadCaptLib.AxSTPadCapt axSTPadCapt1;
        private System.Windows.Forms.TextBox txtDisclaimer;
        private VIBlend.WinForms.Controls.vButton btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPenwidth;
    }
}