
#region " Imports "

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using DCS2015.Class;

#endregion

namespace DCS2015.Forms.UserForms
{
    public partial class ucSignatureCapture : UserControl
    {

        public ucSignatureCapture()
        {
            InitializeComponent();            
        }

        public ucSignatureCapture(Action MainAction)
        {
            InitializeComponent();
            _action = MainAction;
        }

        public Action _action;

        private void ucSignatureCapture_Load(object sender, EventArgs e)
        {
            InitializeSignature();

            chkOverrideSignature.Checked = DCS_MemberInfo.Data.SignatureOverride;
            if(File.Exists(DCS_MemberInfo.Data.SignatureFile)){ btnDone.Visible=false; }
            
            BindData();
        }

        private void ucSignatureCapture_Resize(object sender, EventArgs e)
        {
            pnlMain.Left = (this.ClientSize.Width - pnlMain.Width) / 2;
            pnlMain.Top = (this.ClientSize.Height - pnlMain.Height) / 2;
        }

        #region " Controls Event "

        private void btnReset_Click(object sender, EventArgs e)
        {            
            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile))
            {
                if (Utilities.ShowQuestionMessage("Recapture signature?") == DialogResult.No)
                {
                    return;
                }
            }

            btnDone.Visible = true;

            Class.Utilities.SignatureCapturing_ErrorMessage = "";
            SigPlusNET1.BackgroundImage = null;

            SigPlusNET1.SetImageXSize(0);
            SigPlusNET1.SetImageYSize(0);
            SigPlusNET1.SetJustifyMode(0);
            InitializeSignature();
            DCS_MemberInfo.Data.ResetSignature();
            if(_action!=null)_action.Invoke();
        }

        #endregion

        #region " SigPlusNET "

        private void SigPlusNET1_PenDown(System.Object sender, System.EventArgs e)
        {
            SigPlusNET1.SetJustifyMode(0);
            Timer1.Stop();
        }

        private void SigPlusNET1_DeviceRemoved(System.Object sender, System.EventArgs e)
        {
            DisplayMsg("Signature panel has been disconnected.");
        }

        private void SigPlusNET1_DeviceArrived(System.Object sender, System.EventArgs e)
        {
            InitializeSignature();
        }

        private void SigPlusNET1_PenUp(System.Object sender, System.EventArgs e)
        {
            //Timer1.Start();
        }

        #endregion        

        public void InitializeSignature()
        {
            try
            {                
                SigPlusNET1.ClearTablet();             
                SigPlusNET1.SetTabletState(1);
            }
            catch (Exception ex)
            {
                DisplayMsg(ex.Message);
            }            
        }

        private void BindData()
        {
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
            {
                SigPlusNET1.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile)));
                SigPlusNET1.BackgroundImageLayout = ImageLayout.Center;
                SigPlusNET1.SetTabletState(0);
            }
        }        

        int timerCount = 0;
        private void Timer1_Tick(System.Object sender, System.EventArgs e)
        {
            timerCount += 1;
            //if (timerCount == 3)
            if (timerCount == 5)
            {
                Timer1.Stop();
                timerCount = 0;
                SigPlusNET1.SetJustifyMode(5);
                SaveSignature();
            }
        }

        private void DisplayMsg(string strMsg)
        {
            Class.Utilities.SignatureCapturing_ErrorMessage = strMsg;
            txtMsg.Text = strMsg;
            txtMsg.ForeColor = Color.Orange;
        }

        public void SaveSignature()
        {
            try
            {
                Bitmap myimage = default(Bitmap);
                List<Class.ListofDimensions> ld = new List<Class.ListofDimensions>();
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 500,
                    NHeigth = 167
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 490,
                    NHeigth = 163
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 480,
                    NHeigth = 160
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 470,
                    NHeigth = 157
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 460,
                    NHeigth = 153
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 450,
                    NHeigth = 150
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 430,
                    NHeigth = 143
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 400,
                    NHeigth = 133
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 380,
                    NHeigth = 126
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 350,
                    NHeigth = 116
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 300,
                    NHeigth = 100
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 280,
                    NHeigth = 93
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 250,
                    NHeigth = 83
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 240,
                    NHeigth = 80
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 230,
                    NHeigth = 77
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 220,
                    NHeigth = 73
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 210,
                    NHeigth = 70
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 200,
                    NHeigth = 67
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 190,
                    NHeigth = 64
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 180,
                    NHeigth = 60
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 170,
                    NHeigth = 57
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 160,
                    NHeigth = 54
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 150,
                    NHeigth = 50
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 140,
                    NHeigth = 47
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 130,
                    NHeigth = 44
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 120,
                    NHeigth = 40
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 110,
                    NHeigth = 37
                });
                ld.Add(new Class.ListofDimensions
                {
                    NWidth = 100,
                    NHeigth = 34
                });

                SigPlusNET1.SetImageXSize(450);
                SigPlusNET1.SetImageYSize(150);                

                DCS_MemberInfo.Data.SignatureFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.Signature_FileNameTIFF);

                if(Properties.Settings.Default.SignatureOutputJPG)
                    SigPlusNET1.GetSigImage().Save(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

                if (Properties.Settings.Default.SignatureOutputBMP)
                    SigPlusNET1.GetSigImage().Save(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", ".bmp"), System.Drawing.Imaging.ImageFormat.Bmp);                

                int FileSize = 0;
                int indx = 0;

                int NW = ld[indx].NWidth;
                int NH = ld[indx].NHeigth;
            again:

                SigPlusNET1.SetImageXSize(NW);
                SigPlusNET1.SetImageYSize(NH);
                //SigPlusNET1.SetJustifyMode(0)

                myimage = (Bitmap)SigPlusNET1.GetSigImage();
                Bitmap bmp = myimage;
                //ToBlackAndWhite(myimage)
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.ColorDepth;
                EncoderParameters parameters = new System.Drawing.Imaging.EncoderParameters(1);
                ImageCodecInfo enc = GetEncoderInfo(System.Drawing.Imaging.ImageFormat.Tiff);
                int im = (Int32)4L;
                parameters.Param[0] = new EncoderParameter(myEncoder, im);
                bmp.Save(DCS_MemberInfo.Data.SignatureFile, enc, parameters);

                if (!IsFileAccepted(DCS_MemberInfo.Data.SignatureFile, ref FileSize))
                {
                    if (FileSize > 1536)
                    {
                        indx += 1;
                        if (indx >= ld.Count)
                        {
                            im = (Int32)1L;
                            indx = 0;
                        }
                    }
                    else if (FileSize < 800)
                    {
                        if (indx == 0)
                        {
                            indx = ld.Count - 1;
                        }
                        indx -= 1;
                    }
                    NW = ld[indx].NWidth;
                    NH = ld[indx].NHeigth;
                    goto again;
                }
                SigPlusNET1.SetTabletState(0);                
            }
            catch (Exception ex)
            {
                DisplayMsg(ex.Message);
            }              
        }

        public bool IsFileAccepted(string strFile, ref int FileSize)
        {            
            FileInfo fi = new FileInfo(strFile);
            if (fi.Exists)
            {
                if (fi.Length >= 800 && fi.Length <= 1536)
                {
                    FileSize = (int)fi.Length;
                    return true;
                }
            }
            FileSize = (int)fi.Length;
            File.Delete(fi.FullName);
            return false;
        }

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            int j = 0;
            ImageCodecInfo[] encoders = null;
            encoders = ImageCodecInfo.GetImageEncoders();

            j = 0;
            while (j < encoders.Length)
            {
                if (encoders[j].FormatID == format.Guid)
                {
                    return encoders[j];
                }
                j += 1;
            }
            return null;

        }        

        private void btnDone_Click(object sender, EventArgs e)
        {
            SigPlusNET1.SetJustifyMode(5);
            SaveSignature();
            btnDone.Visible = false;
            if(_action!=null)_action.Invoke();
        }

        private void chkOverrideSignature_CheckedChanged(object sender, EventArgs e)
        {
            DCS_MemberInfo.Data.SignatureOverride = chkOverrideSignature.Checked;            
        }
    }
}
