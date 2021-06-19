using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS2015.Forms
{
    public partial class PhotoSelect : Form
    {
        public PhotoSelect()
        {
            InitializeComponent();
        }

        private string[] files = new string[1];
        private string SelectedPhoto = "";
        public string FinalSelectedPhoto = "";

        private void PhotoSelect_Load(object sender, EventArgs e)
        {            
            short index = 0;

            foreach (string strFile in System.IO.Directory.GetFiles(Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY))
            {
                if (System.IO.Path.GetFileName(strFile).Contains("ICAO_Photo"))
                {                    
                    files[index] = strFile;
                    index += 1;
                    Array.Resize(ref files, index + 1);
                }
            }

            switch (files.Length - 1)
            {
                case 0:
                    rbOne.Enabled = false;
                    rbTwo.Enabled = false;
                    rbThree.Enabled = false;
                    break;
                case 1:
                    pbOne.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(files[files.Length-2])));
                    rbOne.Checked = true;                    
                    rbTwo.Enabled = false;
                    rbThree.Enabled = false;
                    break;
                case 2:
                    pbOne.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(files[files.Length - 2])));
                    pbTwo.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(files[files.Length - 3])));

                    if (files[files.Length - 2] == DCS_MemberInfo.Data.PhotoICAOFile)
                        rbOne.Checked = true;
                    else if (files[files.Length - 3] == DCS_MemberInfo.Data.PhotoICAOFile)
                        rbTwo.Checked = true;
                    
                    rbThree.Enabled = false;
                    break;
                default:
                    pbOne.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(files[files.Length - 2])));
                    pbTwo.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(files[files.Length - 3])));
                    pbThree.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(files[files.Length - 4])));

                    if (files[files.Length - 2] == DCS_MemberInfo.Data.PhotoICAOFile)
                        rbOne.Checked = true;
                    else if (files[files.Length - 3] == DCS_MemberInfo.Data.PhotoICAOFile)
                        rbTwo.Checked = true;
                    else if (files[files.Length - 4] == DCS_MemberInfo.Data.PhotoICAOFile)
                        rbThree.Checked = true;
                    break;
            } 
        }

        private void rbOne_CheckedChanged(object sender, EventArgs e)
        {
            SelectedPhoto = files[files.Length - 2];
            pnlOne.Visible = rbOne.Checked;
            pnlTwo.Visible = !rbOne.Checked;
            pnlThree.Visible = !rbOne.Checked;
        }

        private void rbTwo_CheckedChanged(object sender, EventArgs e)
        {
            SelectedPhoto = files[files.Length - 3];
            pnlOne.Visible = !rbTwo.Checked;
            pnlTwo.Visible = rbTwo.Checked;
            pnlThree.Visible = !rbTwo.Checked;
        }

        private void rbThree_CheckedChanged(object sender, EventArgs e)
        {
            SelectedPhoto = files[files.Length - 4];
            pnlOne.Visible = !rbThree.Checked;
            pnlTwo.Visible = !rbThree.Checked;
            pnlThree.Visible = rbThree.Checked;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FinalSelectedPhoto = SelectedPhoto;
            Close();
        }
    }
}
