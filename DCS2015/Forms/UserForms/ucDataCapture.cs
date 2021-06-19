using System;
using System.Windows.Forms;

namespace DCS2015.Forms.UserForms
{
    public partial class ucDataCapture : UserControl
    {           
        public DCS_DataCapture.DataCapture _ucDataCapture;
        
        public ucDataCapture(ref DCS_DataCapture.DataCapture _ucDataCapture)
        {
            InitializeComponent();
            this._ucDataCapture = _ucDataCapture;
            this.pnlMain.Controls.Add(this._ucDataCapture);
        }

        private void ucDataCapture_Resize(object sender, EventArgs e)
        {
            pnlMain.Left = (this.ClientSize.Width - pnlMain.Width) / 2;
            pnlMain.Top = (this.ClientSize.Height - pnlMain.Height) / 2;
        }
    }
}
