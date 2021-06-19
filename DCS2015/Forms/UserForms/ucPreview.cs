using System;
using System.Windows.Forms;

namespace DCS2015.Forms.UserForms
{
    public partial class ucPreview : UserControl
    {           
        public DCS_DataCapture.Preview _ucPreview;
        
        public ucPreview()
        {
            InitializeComponent();
            _ucPreview = new DCS_DataCapture.Preview();
            //this.pnlMain2.Controls.Add(this._ucPreview);
            splitContainer1.Panel2.Controls.Add(this._ucPreview);
        }

        private void ucPreview_Resize(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Left = (this.ClientSize.Width - splitContainer1.Panel2.Width) / 2;
            splitContainer1.Panel2.Top = 10;//((this.ClientSize.Height - pnlMain.Height) / 2)-20;         
            //_ucPreview.Left = (pnlMain.Width - _ucPreview.Width) / 2;
            //_ucPreview.Top = (pnlMain.Height - _ucPreview.Height) / 2;            
        }
        
    }
}
