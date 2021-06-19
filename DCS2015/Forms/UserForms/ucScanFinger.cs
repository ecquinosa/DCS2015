
#region " Imports "

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using DCS2015.Class;

#endregion

namespace DCS2015.Forms.UserForms
{
    public partial class ucScanFinger : UserControl
    {
        public ucScanFinger()
        {
            InitializeComponent();
            txtQT.Text = Properties.Settings.Default.FP_Quality_Threshold.ToString();
        }        

        private bool IsSequenceCapturing;
        private int intPanelCollectedInitialTop;
        Class.Sagem _sagem;

        private delegate void Action();

        private void ucScanFinger_Load(object sender, EventArgs e)
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

                chkFingerType_LP.Click += new EventHandler(CLB_Click);
                chkFingerType_LP.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_LB.Click += new EventHandler(CLB_Click);
                chkFingerType_LB.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RP.Click += new EventHandler(CLB_Click);
                chkFingerType_RP.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

                chkFingerType_RB.Click += new EventHandler(CLB_Click);
                chkFingerType_RB.SelectedIndexChanged += new EventHandler(CLB_SelectedIndexChanged);

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

        private void ucScanFinger_Leave(object sender, EventArgs e)
        {
            _sagem = null;
            GC.Collect();
        }

        private void ucScanFinger_Resize(object sender, EventArgs e)
        {
            pnlMain.Left = (this.ClientSize.Width - pnlMain.Width) / 2;
            pnlMain.Top = (this.ClientSize.Height - pnlMain.Height) / 2;
        }

        #region " Controls Event "

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

        private void btnSequenceCapture_Click(object sender, EventArgs e)
        {
            IsSequenceCapturing = true;
            
            pbLeftPrimaryTemplate_DoubleClick(pbLeftPrimaryTemplate, null);
            WaitForNextProcess();
            
            pbLeftThumbTemplate_DoubleClick(pbLeftThumbTemplate, null);
            WaitForNextProcess();

            pbRightPrimaryTemplate_DoubleClick(pbRightPrimaryTemplate, null);            
            WaitForNextProcess();

            IsSequenceCapturing = false;
            pbRightThumbTemplate_DoubleClick(pbRightThumbTemplate, null);
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
            pnlCollectedTemplates.Top = intPanelCollectedInitialTop + 180;
            pnlLiveScan.Visible = true;            
            Application.DoEvents();               
            System.Threading.Thread.Sleep(3000);

            switch (_SagemFingerID)
            {
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
                            chkFingerType_LP.SetItemChecked(0, true);
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
                            chkFingerType_RP.SetItemChecked(0, true);
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
            CLB(chkFingerType_LP);
            CLB(chkFingerType_LB);
            CLB(chkFingerType_RP);
            CLB(chkFingerType_RB);

            chkFingerType_LP.SetItemChecked(0, true);
            chkFingerType_LB.SetItemChecked(0, true);
            chkFingerType_RB.SetItemChecked(0, true);
            chkFingerType_RP.SetItemChecked(0, true);            
        }

        private void ResetPBTemplates()
        {
            pbLeftPrimaryTemplate.Image = Properties.Resources.doubletap;
            pbLeftThumbTemplate.Image = Properties.Resources.doubletap;
            pbRightPrimaryTemplate.Image = Properties.Resources.doubletap;
            pbRightThumbTemplate.Image = Properties.Resources.doubletap;

            lblLeftPrimaryTemplate.Text = "";
            lblLeftThumbTemplate.Text = "";
            lblRightPrimaryTemplate.Text = "";
            lblRightThumbTemplate.Text = "";
        }

        private void ResetLeftPrimary()
        {
            CLB(chkFingerType_LP);            
            chkFingerType_LP.SetItemChecked(0, true);
            pbLeftPrimaryTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftPrimary();
        }

        private void ResetLeftThumb()
        {
            CLB(chkFingerType_LB);
            chkFingerType_LB.SetItemChecked(0, true);
            pbLeftThumbTemplate.Image = Properties.Resources.doubletap;
            DCS_MemberInfo.Data.ResetBiometricLeftThumb();
        }

        private void ResetRightPrimary()
        {
            CLB(chkFingerType_RP);
            chkFingerType_RP.SetItemChecked(0, true);
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
                    clb.SetItemChecked(4, true);
                    break;
                case "Left Thumb": case "Right Thumb": case "Left Index": case "Right Index":
                    clb.SetItemChecked(0, true);
                    break;
                //case "Left Index": case "Right Index":
                //    clb.SetItemChecked(0, true);
                //    break;
                case "Left Middle": case "Right Middle":
                    clb.SetItemChecked(1, true);                    
                    break;
                case "Left Ring": case "Right Ring":
                    clb.SetItemChecked(2, true);
                    break;
                case "Left Pinky": case "Right Pinky":
                    clb.SetItemChecked(3, true);
                    break;
                default:
                    break;
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }       
    }
}
