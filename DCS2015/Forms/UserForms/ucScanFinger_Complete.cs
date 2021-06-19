
#region " Imports "

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using DCS2015.Class;

#endregion

namespace DCS2015.Forms.UserForms
{
    public partial class ucScanFinger_Complete : UserControl
    {
        public ucScanFinger_Complete()
        {
            InitializeComponent();
            txtQT.Text = Properties.Settings.Default.FP_Quality_Threshold.ToString();
        }        

        private bool IsSequenceCapturing;
        private int intPanelCollectedInitialTop;
        Class.Sagem _sagem;

        private delegate void Action();

        private void ucScanFinger_Complete_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (!CheckIfDeviceIsPresent()) return;

            txtFooterMsg.Text = "Initializing sagem device...";
            txtFooterMsg.ForeColor = Color.Black;
            Application.DoEvents();

            //_sagem = new Class.Sagem(ref display, ref textQuality, ref textStatus);
            Invoke(new Action(InitializeSagem));

            if (_sagem.Success)
            {
                btnSequenceCapture.Visible = true;

                intPanelCollectedInitialTop = pnlCollectedTemplates.Top;

                //_sagem = new Class.Sagem(ref display, ref textQuality, ref textStatus);

                ResetFingerCode();

                chkFingerType_LB.Click += new EventHandler(CLB_Click);
                chkFingerType_LB.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_LP.Click += new EventHandler(CLB_Click);
                chkFingerType_LP.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_LM.Click += new EventHandler(CLB_Click);
                chkFingerType_LM.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_LR.Click += new EventHandler(CLB_Click);
                chkFingerType_LR.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_LPink.Click += new EventHandler(CLB_Click);
                chkFingerType_LPink.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RB.Click += new EventHandler(CLB_Click);
                chkFingerType_RB.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RP.Click += new EventHandler(CLB_Click);
                chkFingerType_RP.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RM.Click += new EventHandler(CLB_Click);
                chkFingerType_RM.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RR.Click += new EventHandler(CLB_Click);
                chkFingerType_RR.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RPink.Click += new EventHandler(CLB_Click);
                chkFingerType_RPink.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);
                               
                BindData();
                txtFooterMsg.Text = "";
            }
            else
            {
                Utilities.BiometricCapturing_ErrorMessage = "Unable to initialize Sagem device...";
                DisplayFooterMsg(Utilities.BiometricCapturing_ErrorMessage);
            }            
        }

        private bool CheckIfDeviceIsPresent()
        {
            _sagem = new Class.Sagem();
            ComboBox cbo = new ComboBox();
            if (_sagem.EnumerateDevice(ref cbo))                
            {                
                return true;
            }
            else
            {
                Utilities.BiometricCapturing_ErrorMessage = "Unable to detect Sagem device...";
                DisplayFooterMsg(Utilities.BiometricCapturing_ErrorMessage);
                return false;
            }
        }

        private void InitializeSagem()
        {
            _sagem = new Class.Sagem(ref display, ref textQuality, ref textStatus);
        }

        public void DisplayFooterMsg(string Msg)
        {
            txtFooterMsg.Text = Msg;
            txtFooterMsg.ForeColor = Color.OrangeRed;
        }

        private void ucScanFinger_Complete_Leave(object sender, EventArgs e)
        {
            _sagem = null;
            GC.Collect();
        }

        private void ucScanFinger_Complete_Resize(object sender, EventArgs e)
        {
            pnlMain.Left = (this.ClientSize.Width - pnlMain.Width) / 2;
            pnlMain.Top = (this.ClientSize.Height - pnlMain.Height) / 2;
        }

        #region " Controls Event "

        private void pbLeftPinkyTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();

                string FingerType = GetSelectedItem_CLB(chkFingerType_LPink);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPinkyFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPinkyFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPinkyFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPinkyFileWSQ);
                }

                //CaptureFingerTemplate(biometric, chkFingerType_LP, Utilities.SagemFingerID.LeftIndex, ResetLeftPinky);
                CaptureFingerTemplate(biometric, "Left Pinky", FingerType, ResetLeftPinky);
                CLB(chkFingerType_LPink);
                SetFingerType(FingerType, chkFingerType_LPink);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbLeftRingTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();

                string FingerType = GetSelectedItem_CLB(chkFingerType_LR);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftRingFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftRingFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftRingFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftRingFileWSQ);
                }

                //CaptureFingerTemplate(biometric, chkFingerType_LP, Utilities.SagemFingerID.LeftIndex, ResetLeftRing);
                CaptureFingerTemplate(biometric, "Left Ring", FingerType, ResetLeftRing);
                CLB(chkFingerType_LR);
                SetFingerType(FingerType, chkFingerType_LR);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbLeftMiddleTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();

                string FingerType = GetSelectedItem_CLB(chkFingerType_LM);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftMiddleFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftMiddleFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftMiddleFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftMiddleFileWSQ);
                }

                //CaptureFingerTemplate(biometric, chkFingerType_LP, Utilities.SagemFingerID.LeftIndex, ResetLeftMiddle);
                CaptureFingerTemplate(biometric, "Left Middle", FingerType, ResetLeftMiddle);
                CLB(chkFingerType_LM);
                SetFingerType(FingerType, chkFingerType_LM);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbLeftPrimaryTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();

                string FingerType = GetSelectedItem_CLB(chkFingerType_LP);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ);
                }

                //CaptureFingerTemplate(biometric, chkFingerType_LP, Utilities.SagemFingerID.LeftIndex, ResetLeftPrimary);
                CaptureFingerTemplate(biometric, "Left Index", FingerType, ResetLeftPrimary);
                CLB(chkFingerType_LP);
                SetFingerType(FingerType, chkFingerType_LP);
            }
            catch
            {}
            finally
            {
                Cursor.Show();
            }
        }

        private void pbLeftThumbTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
            string FingerType = GetSelectedItem_CLB(chkFingerType_LB);

            if (FingerType == "Amputated")
            {
                return;
            }

            byte[] biometric = null;
            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378))
            {
                biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378);
            }
            else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ))
            {
                biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ);
            }           

            //CaptureFingerTemplate(biometric, chkFingerType_LB, Utilities.SagemFingerID.LeftThumb, ResetLeftThumb);
            CaptureFingerTemplate(biometric, "Left Thumb", FingerType, ResetLeftThumb);
            CLB(chkFingerType_LB);
            SetFingerType(FingerType, chkFingerType_LB);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbRightThumbTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
            string FingerType = GetSelectedItem_CLB(chkFingerType_RB);

            if (FingerType == "Amputated")
            {
                return;
            }

            byte[] biometric = null;
            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileANSI378))
            {
                biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileANSI378);
            }
            else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileWSQ))
            {
                biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileWSQ);
            }
            
            //CaptureFingerTemplate(biometric, chkFingerType_RB, Utilities.SagemFingerID.RightThumb, ResetRightThumb);
            CaptureFingerTemplate(biometric, "Right Thumb", FingerType, ResetRightThumb);
            CLB(chkFingerType_RB);
            SetFingerType(FingerType, chkFingerType_RB);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbRightPrimaryTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
            string FingerType = GetSelectedItem_CLB(chkFingerType_RP);

            if (FingerType == "Amputated")
            {
                return;
            }

            byte[] biometric = null;
            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378))
            {
                biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378);
            }
            else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ))
            {
                biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ);
            }

            CaptureFingerTemplate(biometric, "Right Index", FingerType, ResetRightPrimary);
            CLB(chkFingerType_RP);
            SetFingerType(FingerType, chkFingerType_RP);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbRightMiddleTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
                string FingerType = GetSelectedItem_CLB(chkFingerType_RM);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightMiddleFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightMiddleFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightMiddleFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightMiddleFileWSQ);
                }

                CaptureFingerTemplate(biometric, "Right Middle", FingerType, ResetRightMiddle);
                CLB(chkFingerType_RM);
                SetFingerType(FingerType, chkFingerType_RM);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbRightRingTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
                string FingerType = GetSelectedItem_CLB(chkFingerType_RR);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightRingFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightRingFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightRingFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightRingFileWSQ);
                }

                CaptureFingerTemplate(biometric, "Right Ring", FingerType, ResetRightRing);
                CLB(chkFingerType_RR);
                SetFingerType(FingerType, chkFingerType_RR);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void pbRightPinkyTemplate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
                string FingerType = GetSelectedItem_CLB(chkFingerType_RPink);

                if (FingerType == "Amputated")
                {
                    return;
                }

                byte[] biometric = null;
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPinkyFileANSI378))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPinkyFileANSI378);
                }
                else if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPinkyFileWSQ))
                {
                    biometric = System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPinkyFileWSQ);
                }

                CaptureFingerTemplate(biometric, "Right Pinky", FingerType, ResetRightPinky);
                CLB(chkFingerType_RPink);
                SetFingerType(FingerType, chkFingerType_RPink);
            }
            catch
            { }
            finally
            {
                Cursor.Show();
            }
        }

        private void btnSequenceCapture_Click(object sender, EventArgs e)
        {
            IsSequenceCapturing = true;

            pbLeftThumbTemplate_DoubleClick(pbLeftThumbTemplate, null);
            WaitForNextProcess();

            pbLeftPrimaryTemplate_DoubleClick(pbLeftPrimaryTemplate, null);
            WaitForNextProcess();

            pbLeftMiddleTemplate_DoubleClick(pbLeftMiddleTemplate, null);
            WaitForNextProcess();

            pbLeftRingTemplate_DoubleClick(pbLeftRingTemplate, null);
            WaitForNextProcess();

            pbLeftPinkyTemplate_DoubleClick(pbLeftPinkyTemplate, null);
            WaitForNextProcess();

            pbRightThumbTemplate_DoubleClick(pbRightThumbTemplate, null);
            WaitForNextProcess();

            pbRightPrimaryTemplate_DoubleClick(pbRightPrimaryTemplate, null);            
            WaitForNextProcess();

            pbRightMiddleTemplate_DoubleClick(pbRightMiddleTemplate, null);
            WaitForNextProcess();

            pbRightRingTemplate_DoubleClick(pbRightRingTemplate, null);
            WaitForNextProcess();

            IsSequenceCapturing = false;
            pbRightPinkyTemplate_DoubleClick(pbRightPinkyTemplate, null);
        }

        private void CLB_Click(object sender, EventArgs e)
        {
            CLB((CheckedListBox)sender);
        }

        private void CLB(CheckedListBox clb)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, false);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Utilities.ShowMessage("Are you sure you want to reset captured biometrics?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class.Utilities.BiometricCapturing_ErrorMessage = "";
                DCS_MemberInfo.Data.ResetBiometrics();

                ResetFingerCode();
                ResetPBTemplates();
            }
        }

        #endregion

        private void BindData()
        {
            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))
            {
                pbLeftPrimaryTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG)));             
                lblLeftPrimaryTemplate.Text = DCS_MemberInfo.Data.BiometricLeftPrimaryQualityScore;                
            }

            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
            {
                pbLeftThumbTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG)));         
                lblLeftThumbTemplate.Text = DCS_MemberInfo.Data.BiometricLeftThumbQualityScore;
            }

            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))
            {
                pbRightPrimaryTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG)));                
                lblRightPrimaryTemplate.Text = DCS_MemberInfo.Data.BiometricRightPrimaryQualityScore;
            }

            if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
            {
                pbRightThumbTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG)));                
                lblRightThumbTemplate.Text = DCS_MemberInfo.Data.BiometricRightThumbQualityScore;
            }

            if (DCS_MemberInfo.Data.LeftPrimaryCode != "")
            {
                CLB(chkFingerType_LP);
                SetFingerType(DCS_MemberInfo.Data.LeftPrimaryCode, chkFingerType_LP);
            }
            if (DCS_MemberInfo.Data.LeftThumbCode != "")
            {
                CLB(chkFingerType_LB);
                SetFingerType(DCS_MemberInfo.Data.LeftThumbCode, chkFingerType_LB);
            }
            if (DCS_MemberInfo.Data.RightPrimaryCode != "")
            {
                CLB(chkFingerType_RP);
                SetFingerType(DCS_MemberInfo.Data.RightPrimaryCode, chkFingerType_RP);
            }
            if (DCS_MemberInfo.Data.RightThumbCode != "")
            {
                CLB(chkFingerType_RB);
                SetFingerType(DCS_MemberInfo.Data.RightThumbCode, chkFingerType_RB);
            }

            if (Properties.Settings.Default.ScanFingerType == 1)
            {
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftMiddleFileJPG))
                {
                    pbLeftMiddleTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftMiddleFileJPG)));
                    lblLeftMiddleTemplate.Text = DCS_MemberInfo.Data.BiometricLeftMiddleQualityScore;
                }
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftRingFileJPG))
                {
                    pbLeftRingTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftRingFileJPG)));
                    lblLeftRingTemplate.Text = DCS_MemberInfo.Data.BiometricLeftRingQualityScore;
                }
                 if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPinkyFileJPG))
                {
                    pbLeftPinkyTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPinkyFileJPG)));
                    lblLeftPinkyTemplate.Text = DCS_MemberInfo.Data.BiometricLeftPinkyQualityScore;
                }

                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightMiddleFileJPG))
                {
                    pbRightMiddleTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightMiddleFileJPG)));
                    lblRightMiddleTemplate.Text = DCS_MemberInfo.Data.BiometricRightMiddleQualityScore;
                }
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightRingFileJPG))
                {
                    pbRightRingTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightRingFileJPG)));
                    lblRightRingTemplate.Text = DCS_MemberInfo.Data.BiometricRightRingQualityScore;
                }
                if (System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPinkyFileJPG))
                {
                    pbRightPinkyTemplate.Image = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPinkyFileJPG)));
                    lblRightPinkyTemplate.Text = DCS_MemberInfo.Data.BiometricRightPinkyQualityScore;
                }

                if (DCS_MemberInfo.Data.RightMiddleCode != "")
                {
                    CLB(chkFingerType_RM);
                    SetFingerType(DCS_MemberInfo.Data.RightMiddleCode, chkFingerType_RM);
                }

                if (DCS_MemberInfo.Data.RightRingCode != "")
                {
                    CLB(chkFingerType_RR);
                    SetFingerType(DCS_MemberInfo.Data.RightRingCode, chkFingerType_RR);
                }

                if (DCS_MemberInfo.Data.RightPinkyCode != "")
                {
                    CLB(chkFingerType_RPink);
                    SetFingerType(DCS_MemberInfo.Data.RightPinkyCode, chkFingerType_RPink);
                }

                if (DCS_MemberInfo.Data.LeftMiddleCode != "")
                {
                    CLB(chkFingerType_LM);
                    SetFingerType(DCS_MemberInfo.Data.LeftMiddleCode, chkFingerType_LM);
                }

                if (DCS_MemberInfo.Data.LeftRingCode != "")
                {
                    CLB(chkFingerType_LR);
                    SetFingerType(DCS_MemberInfo.Data.LeftRingCode, chkFingerType_LR);
                }

                if (DCS_MemberInfo.Data.LeftPinkyCode != "")
                {
                    CLB(chkFingerType_LPink);
                    SetFingerType(DCS_MemberInfo.Data.LeftPinkyCode, chkFingerType_LPink);
                }
            }

        }    

        private void WaitForNextProcess()
        {
            this.pbBlinking.Image = Properties.Resources.left_right_hand4;
            txtMsg.Text = "Initialiazing please wait...";
            Application.DoEvents(); 
        }

        private void DisplayGIF(Utilities.SagemFingerID _SagemFingerID, Utilities.SagemFingerID _ActualFingerID)
        {
            string PositionFingerMsg = "PLACE YOUR ? FINGER ON SCANNER";

            GC.Collect();
            pnlCollectedTemplates.Top = intPanelCollectedInitialTop + 170;//180;
            pnlLiveScan.Visible = true;            
            Application.DoEvents();               
            System.Threading.Thread.Sleep(3000);

            switch (_SagemFingerID)
            {
                case Utilities.SagemFingerID.LeftThumb:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "LEFT THUMB");
                    this.pbBlinking.Image = Properties.Resources.left_hand___thumb_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricLeftThumbFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);
                    DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);
                    DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);

                    if (Capture(ref pbLeftThumbTemplate, lblLeftThumbTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricLeftThumbFileJPG, DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378, DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricLeftThumbQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.LeftThumbCode = GetSelectedItem_CLB(chkFingerType_LB);
                    }

                    break;
                case Utilities.SagemFingerID.LeftIndex:                               
                    txtMsg.Text = PositionFingerMsg.Replace("?", "LEFT INDEX");
                    this.pbBlinking.Image = Properties.Resources.left_hand___primary_blinking;                    
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);
                    DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);
                    DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);

                    if (Capture(ref pbLeftPrimaryTemplate, lblLeftPrimaryTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG, DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378, DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricLeftPrimaryQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.LeftPrimaryCode = GetSelectedItem_CLB(chkFingerType_LP);
                    }
                                                         
                    break;

                case Utilities.SagemFingerID.LeftMiddle:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "LEFT MIDDLE");
                    this.pbBlinking.Image = Properties.Resources.left_hand___middle_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricLeftMiddleFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftMiddle_FileName);
                    DCS_MemberInfo.Data.BiometricLeftMiddleFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftMiddle_FileName);
                    DCS_MemberInfo.Data.BiometricLeftMiddleFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftMiddle_FileName);

                    if (Capture(ref pbLeftMiddleTemplate, lblLeftMiddleTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricLeftMiddleFileJPG, DCS_MemberInfo.Data.BiometricLeftMiddleFileANSI378, DCS_MemberInfo.Data.BiometricLeftMiddleFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricLeftMiddleQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.LeftMiddleCode = GetSelectedItem_CLB(chkFingerType_LM);
                    }

                    break;
                case Utilities.SagemFingerID.LeftRing:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "LEFT RING");
                    this.pbBlinking.Image = Properties.Resources.left_hand___ring_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricLeftRingFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftRing_FileName);
                    DCS_MemberInfo.Data.BiometricLeftRingFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftRing_FileName);
                    DCS_MemberInfo.Data.BiometricLeftRingFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftRing_FileName);

                    if (Capture(ref pbLeftRingTemplate, lblLeftRingTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricLeftRingFileJPG, DCS_MemberInfo.Data.BiometricLeftRingFileANSI378, DCS_MemberInfo.Data.BiometricLeftRingFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricLeftRingQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.LeftRingCode = GetSelectedItem_CLB(chkFingerType_LR);
                    }

                    break;
                case Utilities.SagemFingerID.LeftPinky:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "LEFT PINKY");
                    this.pbBlinking.Image = Properties.Resources.left_hand___pinky_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricLeftPinkyFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPinky_FileName);
                    DCS_MemberInfo.Data.BiometricLeftPinkyFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPinky_FileName);
                    DCS_MemberInfo.Data.BiometricLeftPinkyFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPinky_FileName);

                    if (Capture(ref pbLeftPinkyTemplate, lblLeftPinkyTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricLeftPinkyFileJPG, DCS_MemberInfo.Data.BiometricLeftPinkyFileANSI378, DCS_MemberInfo.Data.BiometricLeftPinkyFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricLeftPinkyQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.LeftPinkyCode = GetSelectedItem_CLB(chkFingerType_LPink);
                    }

                    break;
                case Utilities.SagemFingerID.RightThumb:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "RIGHT THUMB");
                    this.pbBlinking.Image = Properties.Resources.right_hand___thumb_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricRightThumbFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);
                    DCS_MemberInfo.Data.BiometricRightThumbFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);
                    DCS_MemberInfo.Data.BiometricRightThumbFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);

                    if (Capture(ref pbRightThumbTemplate, lblRightThumbTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricRightThumbFileJPG, DCS_MemberInfo.Data.BiometricRightThumbFileANSI378, DCS_MemberInfo.Data.BiometricRightThumbFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricRightThumbQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.RightThumbCode = GetSelectedItem_CLB(chkFingerType_RB);
                    }

                    break;
                case Utilities.SagemFingerID.RightIndex:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "RIGHT INDEX");
                    this.pbBlinking.Image = Properties.Resources.right_hand___primary_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);
                    DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);
                    DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);

                    if (Capture(ref pbRightPrimaryTemplate, lblRightPrimaryTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG, DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378, DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricRightPrimaryQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.RightPrimaryCode = GetSelectedItem_CLB(chkFingerType_RP);
                    }

                    break;
                case Utilities.SagemFingerID.RightMiddle:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "RIGHT MIDDLE");
                    this.pbBlinking.Image = Properties.Resources.right_hand___middle_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricRightMiddleFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightMiddle_FileName);
                    DCS_MemberInfo.Data.BiometricRightMiddleFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightMiddle_FileName);
                    DCS_MemberInfo.Data.BiometricRightMiddleFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightMiddle_FileName);

                    if (Capture(ref pbRightMiddleTemplate, lblRightMiddleTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricRightMiddleFileJPG, DCS_MemberInfo.Data.BiometricRightMiddleFileANSI378, DCS_MemberInfo.Data.BiometricRightMiddleFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricRightMiddleQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.RightMiddleCode = GetSelectedItem_CLB(chkFingerType_RM);
                    }

                    break;
                case Utilities.SagemFingerID.RightRing:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "RIGHT RING");
                    this.pbBlinking.Image = Properties.Resources.right_hand___ring_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricRightRingFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightRing_FileName);
                    DCS_MemberInfo.Data.BiometricRightRingFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightRing_FileName);
                    DCS_MemberInfo.Data.BiometricRightRingFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightRing_FileName);

                    if (Capture(ref pbRightRingTemplate, lblRightRingTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricRightRingFileJPG, DCS_MemberInfo.Data.BiometricRightRingFileANSI378, DCS_MemberInfo.Data.BiometricRightRingFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricRightRingQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.RightRingCode = GetSelectedItem_CLB(chkFingerType_RR);
                    }

                    break;
                case Utilities.SagemFingerID.RightPinky:
                    txtMsg.Text = PositionFingerMsg.Replace("?", "RIGHT PINKY");
                    this.pbBlinking.Image = Properties.Resources.right_hand___pinky_blinking;
                    Application.DoEvents();

                    DCS_MemberInfo.Data.BiometricRightPinkyFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPinky_FileName);
                    DCS_MemberInfo.Data.BiometricRightPinkyFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPinky_FileName);
                    DCS_MemberInfo.Data.BiometricRightPinkyFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPinky_FileName);

                    if (Capture(ref pbRightPinkyTemplate, lblRightPinkyTemplate, _ActualFingerID, DCS_MemberInfo.Data.BiometricRightPinkyFileJPG, DCS_MemberInfo.Data.BiometricRightPinkyFileANSI378, DCS_MemberInfo.Data.BiometricRightPinkyFileWSQ))
                    {
                        DCS_MemberInfo.Data.BiometricRightPinkyQualityScore = textQuality.Text;
                        DCS_MemberInfo.Data.RightPinkyCode = GetSelectedItem_CLB(chkFingerType_RPink);
                    }

                    break;

                default:
                    break;
            }

            this.pbBlinking.Image = Properties.Resources.left_right_hand4;
            textQuality.Clear();
        }

        //private void CaptureFingerTemplate(byte[] biometric, CheckedListBox clb, Utilities.SagemFingerID _SagemFingerID, Action _action)
        private void CaptureFingerTemplate(byte[] biometric, string FingerType, string ActualFingerType, Action _action)
        {
            if (biometric != null)
            {
                if (Utilities.ShowQuestionMessage(string.Format("Recapture {0}?", FingerType)) == DialogResult.Yes)
                    Invoke(new Action(_action));
                else return;
            }

            DisplayGIF(Utilities.GetSagemIDByFingerType(FingerType), Utilities.GetSagemIDByFingerType(ActualFingerType));

            if (!IsSequenceCapturing) { NormalView(); }
        }

        private new bool Capture(ref PictureBox pb, Label lbl, Utilities.SagemFingerID _SagemFingerID, string fileJPG, string fileANSI378, string fileWSQ)
        {
            try
            {
                if (_sagem.Acquire(_SagemFingerID, fileJPG, fileANSI378, fileWSQ, Convert.ToInt16(txtQT.Text)))
                {
                    pb.Image = _sagem.ImageResult;
                    lbl.Text = textQuality.Text;                    
                    display.Image = null;
                    textStatus.Clear();
                    //textQuality.Clear();

                    return true;
                }
                else
                {
                    Utilities.BiometricCapturing_ErrorMessage = "Biometric capturing failed...";
                    DisplayFooterMsg(Utilities.BiometricCapturing_ErrorMessage);
                    return false;
                }
            }
            catch(Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "Capture() : Runtime catched error " + ex.Message.ToString());
                DisplayFooterMsg("Capture() : Runtime catched error " + ex.Message.ToString());
                return false;
            }
        }

        private void NormalView()
        {
            pnlLiveScan.Visible = false;
            pnlCollectedTemplates.Left = (pnlMain.ClientSize.Width - pnlCollectedTemplates.Width) / 2;
            pnlCollectedTemplates.Top = (pnlMain.ClientSize.Height - pnlCollectedTemplates.Height) / 2;
        }

        private string GetSelectedItem_CLB(CheckedListBox clb)
        {
            string result = "";

            foreach (var item in clb.CheckedItems)
            {
                result = item.ToString();
            }

            return result;
        }

        private void CLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            string FingerCode = GetSelectedItem_CLB(clb);
            switch (clb.Name)
            {
                case "chkFingerType_LPink":
                    {
                        if (pbLeftPinkyTemplate.Image != null & FingerCode == "Amputated")
                        {
                            DCS_MemberInfo.Data.LeftPinkyCode = "Amputated";
                        }
                        else if (pbLeftPinkyTemplate.Image != null & FingerCode != "Left Pinky")
                        {
                            if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pbLeftPinkyTemplate_DoubleClick(pbLeftPinkyTemplate, null);
                            }
                            else
                            {
                                CLB(chkFingerType_LPink);
                                chkFingerType_LPink.SetItemChecked(4, true);
                            }
                        }
                        break;
                    }
                case "chkFingerType_LR":
                    {
                        if (pbLeftRingTemplate.Image != null & FingerCode == "Amputated")
                        {
                            DCS_MemberInfo.Data.LeftRingCode = "Amputated";
                        }
                        else if (pbLeftRingTemplate.Image != null & FingerCode != "Left Ring")
                        {
                            if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pbLeftRingTemplate_DoubleClick(pbLeftRingTemplate, null);
                            }
                            else
                            {
                                CLB(chkFingerType_LR);
                                chkFingerType_LR.SetItemChecked(3, true);
                            }
                        }
                        break;
                    }
                case "chkFingerType_LM":
                    {
                        if (pbLeftMiddleTemplate.Image != null & FingerCode == "Amputated")
                        {
                            DCS_MemberInfo.Data.LeftMiddleCode = "Amputated";
                        }
                        else if (pbLeftMiddleTemplate.Image != null & FingerCode != "Left Middle")
                        {
                            if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pbLeftMiddleTemplate_DoubleClick(pbLeftMiddleTemplate, null);
                            }
                            else
                            {
                                CLB(chkFingerType_LM);
                                chkFingerType_LM.SetItemChecked(2, true);
                            }
                        }
                        break;
                    }
                case "chkFingerType_LP":
                {
                    if (pbLeftPrimaryTemplate.Image != null & FingerCode == "Amputated")
                    {
                        DCS_MemberInfo.Data.LeftPrimaryCode = "Amputated";
                    }
                    else if (pbLeftPrimaryTemplate.Image != null & FingerCode != "Left Index")
                    {   if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            pbLeftPrimaryTemplate_DoubleClick(pbLeftPrimaryTemplate, null);                        
                        }
                        else
                        {
                            CLB(chkFingerType_LP);
                            chkFingerType_LP.SetItemChecked(1, true);
                        }
                    }
                    break;
                }
                case "chkFingerType_LB":
                {
                    if (pbLeftThumbTemplate.Image != null & FingerCode == "Amputated")
                    {
                        DCS_MemberInfo.Data.LeftThumbCode = "Amputated";
                    }
                    else if (pbLeftThumbTemplate.Image != null & FingerCode != "Left Thumb")
                    {
                        if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            pbLeftThumbTemplate_DoubleClick(pbLeftThumbTemplate, null);
                        }
                        else
                        {
                            CLB(chkFingerType_LB);
                            chkFingerType_LB.SetItemChecked(0, true);
                        }
                    }
                    break;
                }
                case "chkFingerType_RPink":
                    {
                        if (pbRightPinkyTemplate.Image != null & FingerCode == "Amputated")
                        {
                            DCS_MemberInfo.Data.RightPinkyCode = "Amputated";
                        }
                        else if (pbRightPinkyTemplate.Image != null & FingerCode != "Right Pinky")
                        {
                            if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pbRightPinkyTemplate_DoubleClick(pbRightPinkyTemplate, null);
                            }
                            else
                            {
                                CLB(chkFingerType_RPink);
                                chkFingerType_RPink.SetItemChecked(4, true);
                            }
                        }
                        break;
                    }
                case "chkFingerType_RR":
                    {
                        if (pbRightRingTemplate.Image != null & FingerCode == "Amputated")
                        {
                            DCS_MemberInfo.Data.RightRingCode = "Amputated";
                        }
                        else if (pbRightRingTemplate.Image != null & FingerCode != "Right Ring")
                        {
                            if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pbRightRingTemplate_DoubleClick(pbRightRingTemplate, null);
                            }
                            else
                            {
                                CLB(chkFingerType_RR);
                                chkFingerType_RR.SetItemChecked(3, true);
                            }
                        }
                        break;
                    }
                case "chkFingerType_RM":
                    {
                        if (pbRightMiddleTemplate.Image != null & FingerCode == "Amputated")
                        {
                            DCS_MemberInfo.Data.RightMiddleCode = "Amputated";
                        }
                        else if (pbRightMiddleTemplate.Image != null & FingerCode != "Right Middle")
                        {
                            if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                pbRightMiddleTemplate_DoubleClick(pbRightMiddleTemplate, null);
                            }
                            else
                            {
                                CLB(chkFingerType_RM);
                                chkFingerType_RM.SetItemChecked(2, true);
                            }
                        }
                        break;
                    }
                case "chkFingerType_RP":
                {
                    if (pbRightPrimaryTemplate.Image != null & FingerCode == "Amputated")
                    {
                        DCS_MemberInfo.Data.RightPrimaryCode = "Amputated";
                    }
                    else if (pbRightPrimaryTemplate.Image != null & FingerCode != "Right Index")
                    {
                        if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            pbRightPrimaryTemplate_DoubleClick(pbRightPrimaryTemplate, null);
                        }
                        else
                        {
                            CLB(chkFingerType_RP);
                            chkFingerType_RP.SetItemChecked(1, true);
                        }
                    }
                    break;
                }
                case "chkFingerType_RB":
                {
                    if (pbRightThumbTemplate.Image != null & FingerCode == "Amputated")
                    {
                        DCS_MemberInfo.Data.RightThumbCode = "Amputated";
                    }
                    else if (pbRightThumbTemplate.Image != null & FingerCode != "Right Thumb")
                    {
                        if (Utilities.ShowMessage("Changing finger type shall require recapturing. Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            pbRightThumbTemplate_DoubleClick(pbRightThumbTemplate, null);
                        }
                        else
                        {
                            CLB(chkFingerType_RB);
                            chkFingerType_RB.SetItemChecked(0, true);
                        }
                    }
                    break;
                }
                
                default:
                    break;
            }
        }

        private void ResetFingerCode()
        {
            CLB(chkFingerType_LPink);
            CLB(chkFingerType_LR);
            CLB(chkFingerType_LM);
            CLB(chkFingerType_LP);
            CLB(chkFingerType_LB);
            CLB(chkFingerType_RPink);
            CLB(chkFingerType_RR);
            CLB(chkFingerType_RM);
            CLB(chkFingerType_RP);
            CLB(chkFingerType_RB);

            chkFingerType_LPink.SetItemChecked(4, true);
            chkFingerType_LR.SetItemChecked(3, true);
            chkFingerType_LM.SetItemChecked(2, true);
            chkFingerType_LP.SetItemChecked(1, true);
            chkFingerType_LB.SetItemChecked(0, true);
            chkFingerType_RB.SetItemChecked(0, true);
            chkFingerType_RP.SetItemChecked(1, true);
            chkFingerType_RM.SetItemChecked(2, true);
            chkFingerType_RR.SetItemChecked(3, true);
            chkFingerType_RPink.SetItemChecked(4, true);
        }

        private void ResetPBTemplates()
        {
            pbLeftThumbTemplate.Image = Properties.Resources.doubletap;
            pbLeftPrimaryTemplate.Image = Properties.Resources.doubletap;
            pbLeftMiddleTemplate.Image = Properties.Resources.doubletap;
            pbLeftRingTemplate.Image = Properties.Resources.doubletap;
            pbLeftPinkyTemplate.Image = Properties.Resources.doubletap;

            pbRightThumbTemplate.Image = Properties.Resources.doubletap;
            pbRightPrimaryTemplate.Image = Properties.Resources.doubletap;            
            pbRightMiddleTemplate.Image = Properties.Resources.doubletap;
            pbRightRingTemplate.Image = Properties.Resources.doubletap;
            pbRightPinkyTemplate.Image = Properties.Resources.doubletap;

            lblLeftMiddleTemplate.Text = "";
            lblLeftRingTemplate.Text = "";
            lblLeftPinkyTemplate.Text = "";
            lblLeftPrimaryTemplate.Text = "";
            lblLeftThumbTemplate.Text = "";
            lblRightPrimaryTemplate.Text = "";
            lblRightThumbTemplate.Text = "";
            lblRightMiddleTemplate.Text = "";
            lblRightRingTemplate.Text = "";
            lblRightPinkyTemplate.Text = "";
        }        

        private void ResetLeftThumb()
        {
            CLB(chkFingerType_LB);
            chkFingerType_LB.SetItemChecked(0, true);
            pbLeftThumbTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftThumb();
        }

        private void ResetLeftPrimary()
        {
            CLB(chkFingerType_LP);
            chkFingerType_LP.SetItemChecked(1, true);
            pbLeftPrimaryTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftPrimary();
        }

        private void ResetLeftMiddle()
        {
            CLB(chkFingerType_LM);
            chkFingerType_LM.SetItemChecked(2, true);
            pbLeftMiddleTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftMiddle();
        }

        private void ResetLeftRing()
        {
            CLB(chkFingerType_LR);
            chkFingerType_LR.SetItemChecked(3, true);
            pbLeftRingTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftRing();
        }

        private void ResetLeftPinky()
        {
            CLB(chkFingerType_LPink);
            chkFingerType_LPink.SetItemChecked(4, true);
            pbLeftPinkyTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftPinky();
        }

        private void ResetRightMiddle()
        {
            CLB(chkFingerType_RM);
            chkFingerType_RM.SetItemChecked(2, true);
            pbRightMiddleTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricRightMiddle();
        }

        private void ResetRightRing()
        {
            CLB(chkFingerType_RR);
            chkFingerType_RR.SetItemChecked(3, true);
            pbRightRingTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricRightRing();
        }

        private void ResetRightPinky()
        {
            CLB(chkFingerType_RPink);
            chkFingerType_RPink.SetItemChecked(4, true);
            pbRightPinkyTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricRightPinky();
        }

        private void ResetRightPrimary()
        {
            CLB(chkFingerType_RP);
            chkFingerType_RP.SetItemChecked(1, true);
            pbRightPrimaryTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricRightPrimary();
        }

        private void ResetRightThumb()
        {
            CLB(chkFingerType_RB);
            chkFingerType_RB.SetItemChecked(0, true);
            pbRightThumbTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricRightThumb();
        }

        private void vScroll_Quality_Scroll(object sender, ScrollEventArgs e)
        {
            lblQuality.Text = string.Format("Quality: {0}", vScroll_Quality.Value.ToString());
            _sagem = new Class.Sagem(ref display, ref textQuality, ref textStatus);        
        }

        private void lblQuality_Click(object sender, EventArgs e)
        {

        }

        private void SetFingerType(string FingerType, CheckedListBox clb)
        {
            switch (FingerType)
            {
                case "Amputated":
                    clb.SetItemChecked(5, true);
                    break;
                case "Left Thumb": case "Right Thumb":
                    clb.SetItemChecked(0, true);
                    break;
                case "Left Index": case "Right Index":
                    clb.SetItemChecked(1, true);
                    break;
                case "Left Middle": case "Right Middle":
                    clb.SetItemChecked(2, true);                    
                    break;
                case "Left Ring": case "Right Ring":
                    clb.SetItemChecked(3, true);
                    break;
                case "Left Pinky": case "Right Pinky":
                    clb.SetItemChecked(4, true);
                    break;
                default:
                    break;
            }
        }       
    }
}

