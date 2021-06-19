
#region " Imports "

using System.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCS2015.Class;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

#endregion

namespace DCS2015.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //StringBuilder sb = new StringBuilder();
            //string login_banner = @"\Images\login_banner.png";
            //string clientlogo = @"\Images\clientlogo.jpg";
            //if (!File.Exists(login_banner)) sb.AppendLine("Login banner image is missing...");
            //if (!File.Exists(clientlogo)) sb.AppendLine("Client logo is missing...");
            //if (sb.ToString() != "")
            //{
            //    Utilities.ShowErrorMessage(sb.ToString());
            //    ss = null;
            //    Application.Exit();
            //}
            //else
            //{
                if (Utilities.IsProgramRunning("DCS2015.exe") > 1) Utilities.KillProgram("DCS2015.exe");
                ss.ShowDialog();
            //}
        }

        SplashScreen ss = new SplashScreen();
        private delegate void Action();

        //Class.Webcam wc;
        //Class.CanonCamera cc;

        public static string AssemblyNameAndProductVersion
        {
            get
            {
                string attributes = System.Reflection.Assembly.GetExecutingAssembly().FullName;
                return attributes;
            }
        }

        private bool IsDataLoadedFromDraft;
        private bool IsFormInitialLoad = true;        
        public static DCS_DataCapture.DataCapture _ucDataCapture;                
       
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (!ss.Success)
                {
                    ss = null;
                    Application.Exit();
                }

               this.Text = string.Format("ALLCARD DCS - {0}", AssemblyNameAndProductVersion.Split(',')[1].Trim());

                if (Properties.Settings.Default.UserRole.ToUpper().Contains("ADMINISTRATOR"))
                {
                    manageDataCaptureFieldsToolStripMenuItem.Visible = true;
                    systemSettingsToolStripMenuItem.Visible = true;
                }
                else
                {
                    manageDataCaptureFieldsToolStripMenuItem.Visible = false;
                    systemSettingsToolStripMenuItem.Visible = false;
                }

                //Properties.Settings.Default.Camera = "HD Pro Webcam C920";
                //Properties.Settings.Default.Save();

                ModulesAvailability();
                Initialization();
                BindFooterLabel();            
                btnData.PerformClick();

                IsFormInitialLoad = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //this.Text = this.Size.ToString();
        }

        #region " Controls Event "

        private void ModulesAvailability()
        {
            int intLeftStartLocation = 4;
            int intBtnWidth = 111;
            short intDistance = 2;
            int intComputingLeftLocation = intLeftStartLocation;

            btnData.Visible = Properties.Settings.Default.DataCapture_Module;
            if (btnData.Visible)
            {
                btnData.Left = intComputingLeftLocation;
                intComputingLeftLocation += intBtnWidth + intDistance;
            }

            btnPhoto.Visible = Properties.Settings.Default.Photo_Module;
            if (btnPhoto.Visible)
            {
                btnPhoto.Left = intComputingLeftLocation;
                intComputingLeftLocation += intBtnWidth + intDistance;
            }

            btnBiometrics.Visible = Properties.Settings.Default.Biometric_Module;
            if (btnBiometrics.Visible)
            {
                btnBiometrics.Left = intComputingLeftLocation;
                intComputingLeftLocation += intBtnWidth + intDistance;
            }

            btnSignature.Visible = Properties.Settings.Default.Signature_Module;
            if (btnSignature.Visible)
            {
                btnSignature.Left = intComputingLeftLocation;
                intComputingLeftLocation += intBtnWidth + intDistance;
            }

            btnPreview.Visible = Properties.Settings.Default.Preview_Module;
            if (btnPreview.Visible)
            {
                btnPreview.Left = intComputingLeftLocation;
                intComputingLeftLocation = intBtnWidth + intDistance;
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (!IsFormInitialLoad)
            {
                if (!ValidateTabs(Utilities.FormTab.Data)) { return; }                
            }

            txtFooterMsg.Clear();
            Utilities.PreviousTab = Utilities.CurrentTab;
            Utilities.CurrentTab = Utilities.FormTab.Data;
            NavigationControl();
            
            ShowUserControl(new Forms.UserForms.ucDataCapture(ref _ucDataCapture));            
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            if (!ValidateTabs(Utilities.FormTab.Photo)) { return; }

            txtFooterMsg.Clear();
            Utilities.PreviousTab = Utilities.CurrentTab;
            Utilities.CurrentTab = Utilities.FormTab.Photo;
            NavigationControl();

            ShowUserControl(new Forms.UserForms.ucPhotoCapture(ref txtFooterMsg));            
        }

        private void btnSignature_Click(object sender, EventArgs e)
        {
            if (!ValidateTabs(Utilities.FormTab.Signature)) { return; }

            txtFooterMsg.Clear();
            Utilities.PreviousTab = Utilities.CurrentTab;
            Utilities.CurrentTab = Utilities.FormTab.Signature;
            NavigationControl();

            if(Properties.Settings.Default.Preview_Module)
            {
                if (Properties.Settings.Default.SignatureTablet == "Topaz Siglite")
                    ShowUserControl(new Forms.UserForms.ucSignatureCapture());
                else
                    ShowUserControl(new Forms.UserForms.ucSignatureCapture_EvolisSig100());
            }
            else
                ShowUserControl(new Forms.UserForms.ucSignatureCapture(NavigationControl));            
        }

        private void btnBiometrics_Click(object sender, EventArgs e)
        {
            if (!ValidateTabs(Utilities.FormTab.Biometric)) { return; }

            txtFooterMsg.Clear();
            Utilities.PreviousTab = Utilities.CurrentTab;
            Utilities.CurrentTab = Utilities.FormTab.Biometric;
            NavigationControl();

            if (Properties.Settings.Default.FingerScanner == "Sagem")
            {
                if (Properties.Settings.Default.ScanFingerType == 0) ShowUserControl(new Forms.UserForms.ucScanFinger());
                else if (Properties.Settings.Default.ScanFingerType == 1) ShowUserControl(new Forms.UserForms.ucScanFinger_Complete());
            }
            else
            {
                switch (DCS_DataCapture.DataCapture.ClientName)
                {
                    case "AFPSLAI":
                        //ShowUserControl(new Forms.UserForms.ucScanFingerSecugen());

                        if (DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG == "") DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);
                        if (DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378 == "") DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);
                        if (DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ == "") DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);

                        if (DCS_MemberInfo.Data.BiometricLeftThumbFileJPG == "") DCS_MemberInfo.Data.BiometricLeftThumbFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);
                        if (DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378 == "") DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);
                        if (DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ == "") DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);

                        if (DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG == "") DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);
                        if (DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378 == "") DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);
                        if (DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ == "") DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);

                        if (DCS_MemberInfo.Data.BiometricRightThumbFileJPG == "") DCS_MemberInfo.Data.BiometricRightThumbFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);
                        if (DCS_MemberInfo.Data.BiometricRightThumbFileANSI378 == "") DCS_MemberInfo.Data.BiometricRightThumbFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);
                        if (DCS_MemberInfo.Data.BiometricRightThumbFileWSQ == "") DCS_MemberInfo.Data.BiometricRightThumbFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);


                        ShowUserControl(new DCS_SignatureCapture.ucScanFingerSecugen(Properties.Settings.Default.Timeout_Secugen,
                            Properties.Settings.Default.ImageWidth_Secugen, Properties.Settings.Default.ImageHeight_Secugen,
                            Properties.Settings.Default.QualityThreshold_Secugen, Properties.Settings.Default.SecugenOutputANSI378,
                            Properties.Settings.Default.SecugenOutputWSQ, Properties.Settings.Default.SecugenOutputJPG,
                            Properties.Settings.Default.FingerScanner, Properties.Settings.Default.SecugenDevice,
                            DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG, DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378, DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ,
                            DCS_MemberInfo.Data.BiometricLeftThumbFileJPG, DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378, DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ,
                            DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG, DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378, DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ,
                            DCS_MemberInfo.Data.BiometricRightThumbFileJPG, DCS_MemberInfo.Data.BiometricRightThumbFileANSI378, DCS_MemberInfo.Data.BiometricRightThumbFileWSQ));
                        //DCS_MemberInfo.Data.BiometricLeftPrimaryQualityScore = _BiometricLeftPrimaryQualityScore;
                        //DCS_MemberInfo.Data.LeftPrimaryCode = _LeftPrimaryCode;
                        //DCS_MemberInfo.Data.BiometricLeftThumbQualityScore = _BiometricLeftThumbQualityScore;
                        //DCS_MemberInfo.Data.LeftThumbCode = _LeftThumbCode;
                        //DCS_MemberInfo.Data.BiometricRightPrimaryQualityScore = _BiometricRightPrimaryQualityScore;
                        //DCS_MemberInfo.Data.RightPrimaryCode = _RightPrimaryCode;
                        //DCS_MemberInfo.Data.BiometricRightThumbQualityScore = _BiometricRightThumbQualityScore;
                        //DCS_MemberInfo.Data.RightThumbCode = _RightThumbCode;
                        break;
                    default:
                        ShowUserControl(new Forms.UserForms.ucScanFingerSecugen());
                        break;
                }
            }              
                
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            txtFooterMsg.Clear();

            Utilities.PreviousTab = Utilities.CurrentTab;
            Utilities.CurrentTab = Utilities.FormTab.Preview;
            NavigationControl();

            ShowUserControl(new Forms.UserForms.ucPreview());
        }

        #endregion

        public void BindFooterLabel()
        {
            label1.Text = string.Format("User: {0}     |     Station Reference: {1}     |     SessionID: {2}     |     Reference APIs: {3} {4}, {5} {6}", Properties.Settings.Default.Operator.Trim(), Properties.Settings.Default.StationReference.Trim(), Utilities.SessionReference(), DCS_DataCapture.DataCapture.AssemblyNameAndProductVersion.Split(',')[0], DCS_DataCapture.DataCapture.AssemblyNameAndProductVersion.Split(',')[1], DCS_MemberInfo.Data.AssemblyNameAndProductVersion.Split(',')[0], DCS_MemberInfo.Data.AssemblyNameAndProductVersion.Split(',')[1]);            
        }

        private void Initialization()
        {
            _ucDataCapture = new DCS_DataCapture.DataCapture();
            
            Utilities.InitCapturedDataFolder();            
            DCS_MemberInfo.Data.PhotoOverride = false;
            DCS_MemberInfo.Data.SignatureOverride = false;
            DCS_MemberInfo.Data.PhotoScore = 0;
            DCS_MemberInfo.Data.OperatorID = Properties.Settings.Default.Operator.ToUpper();
            DCS_MemberInfo.Data.TerminalName = Properties.Settings.Default.StationReference;
            DCS_MemberInfo.Data.CapturedDataRepo = Properties.Settings.Default.CapturedOutputPath;
            DCS_MemberInfo.Data.InitMemberInfo();            
            //DCS_MemberInfo.Data.MemberDataXMLFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.MemberDataXML_FileName);
            //DCS_MemberInfo.Data.MemberDataSingleFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_SINGLEFILE_REPOSITORY, Utilities.MemberDataSingleFile_FileName);

            if (Properties.Settings.Default.SystemDate.ToShortDateString() != DateTime.Now.ToShortDateString())
            {             
                Properties.Settings.Default.SystemDate = DateTime.Now;
                Properties.Settings.Default.Save();
                Utilities.CreateCaptureCntr(0);
            }            

            //51, 45 original size of logo
            pbClientLogo.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(@"Images\clientlogo.jpg")));
            
            Utilities.CurrentTab = Utilities.FormTab.Data;
        }

        public void ShowUserControl(UserControl uc)
        {
            foreach (Control ctrl in splitContUpper.Panel2.Controls)
            {
                //ctrl.Dispose();
                splitContUpper.Panel2.Controls.Remove(ctrl);
            }
           
            uc.Dock = DockStyle.Fill;
            splitContUpper.Panel2.Controls.Add(uc);                        
        }
        

        public void DisplayFooterMsg(string Msg)
        {            
            txtFooterMsg.Text = Msg;
            txtFooterMsg.ForeColor = Color.OrangeRed;
        }

        private void T2(string Msg)
        {
            txtFooterMsg.Text = Msg;
            txtFooterMsg.ForeColor = Color.OrangeRed;
        }   
       
        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (Utilities.CurrentTab)
            {
                case Utilities.FormTab.Data:
                    if (!IsDataCaptureLocalValidation()) DisplayFooterMsg(_ucDataCapture.ErrorMessage);
                    else
                    {
                        txtFooterMsg.Clear();
                        SaveToDraft2();
                        Utilities.CAPTUREDDATA_RAW_REPOSITORY = string.Format(@"{0}\RAW\{1}\{2}", Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), Utilities.SessionReference());
                        if (!System.IO.Directory.Exists(Utilities.CAPTUREDDATA_RAW_REPOSITORY)) System.IO.Directory.CreateDirectory(Utilities.CAPTUREDDATA_RAW_REPOSITORY);
                        Utilities.ResetSessionReferenceVariables();
                        //DCS_MemberInfo.Data.MemberDataXMLFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.MemberDataXML_FileName);                        
                        if (Properties.Settings.Default.Photo_Module)
                        {
                            btnPhoto.Enabled = true;
                            btnPhoto.PerformClick();
                        }
                        else
                        {
                            Utilities.CurrentTab = Utilities.FormTab.Photo;
                            btnNext.PerformClick();
                        }
                    }

                    break;
                case Utilities.FormTab.Photo:
                    if (!IsPhotoValidation()) DisplayFooterMsg("Please capture required photo...");
                    else
                    {
                        txtFooterMsg.Clear();
                        SaveToDraft2();
                        if (Properties.Settings.Default.Biometric_Module) {     btnBiometrics.Enabled = true; btnBiometrics.PerformClick();  }
                        else if (Properties.Settings.Default.Signature_Module) {    btnSignature.Enabled = true; btnSignature.PerformClick(); }
                        else if (Properties.Settings.Default.Preview_Module) {  btnPreview.Enabled = true; btnPreview.PerformClick(); }
                        else
                        {
                            Utilities.CurrentTab = Utilities.FormTab.Biometric;
                            btnNext.PerformClick();
                        }                        
                    }
                    
                    break;
                case Utilities.FormTab.Biometric:
                    if (!IsBiometricValidation()) DisplayFooterMsg("Please capture required biometrics...");
                    else
                    {
                        txtFooterMsg.Clear();
                        btnSignature.Enabled = true;
                        SaveToDraft2();
                        if (Properties.Settings.Default.Signature_Module) btnSignature.PerformClick();
                        else
                        {
                            Utilities.CurrentTab = Utilities.FormTab.Signature;
                            btnNext.PerformClick();
                        }                        
                    }                     
                    break;
                case Utilities.FormTab.Signature:
                    if (!IsSignatureValidation()) DisplayFooterMsg("Please capture required signature...");
                    else
                    {
                        txtFooterMsg.Clear();
                        btnPreview.Enabled = true;
                        SaveToDraft2();
                        if (Properties.Settings.Default.Signature_Module)
                        {
                            btnPreview.PerformClick();
                        }
                        else
                        {
                            Utilities.CurrentTab = Utilities.FormTab.Preview;
                            btnNext.PerformClick();
                        }                        
                    }
                    break;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            switch (Utilities.CurrentTab)
            {                
                case Utilities.FormTab.Photo:
                    if (Properties.Settings.Default.DataCapture_Module) btnData.PerformClick();
                    else
                    {
                        Utilities.CurrentTab = Utilities.FormTab.Data;
                        btnPrevious.PerformClick();
                    }
                    break;            
                case Utilities.FormTab.Biometric:                    
                    if (Properties.Settings.Default.Photo_Module) btnPhoto.PerformClick();
                    else
                    {
                        Utilities.CurrentTab = Utilities.FormTab.Photo;
                        btnPrevious.PerformClick();
                    }
                    break;
                case Utilities.FormTab.Signature:                    
                    if (Properties.Settings.Default.Biometric_Module) btnBiometrics.PerformClick();                    
                    else
                    {
                        Utilities.CurrentTab = Utilities.FormTab.Biometric;
                        btnPrevious.PerformClick();
                    }
                    break;
                case Utilities.FormTab.Preview:
                    if (Properties.Settings.Default.Signature_Module) btnSignature.PerformClick();
                    else
                    {
                        Utilities.CurrentTab = Utilities.FormTab.Signature;
                        btnPrevious.PerformClick();
                    }                    
                    break;
            }
        }        

        private void SubmitBtnVisibility()
        {
            btnSubmit.Visible = false;
            if (!IsFormInitialLoad)
            {
                if (IsDataCaptureLocalValidation() & IsPhotoValidation() & IsBiometricValidation() & IsSignatureValidation())
                {
                    btnSubmit.Visible = true;
                }
                else
                {
                    btnSubmit.Visible = false;
                }
            }
         }

        private bool IsDataCaptureLocalValidation()
        {
            if (Properties.Settings.Default.DataCapture_Module)
                return _ucDataCapture.IsLocalValidation();
            else
                return true;
        }

        private bool IsPhotoValidation()
        {
            if (Properties.Settings.Default.Photo_Module)
                return System.IO.File.Exists(DCS_MemberInfo.Data.PhotoICAOFile);
            else
                return true;
        }

        private bool IsBiometricValidation()
        {
            if (Properties.Settings.Default.Biometric_Module)
                return Utilities.IsBiometricTabPassed();
            else
                return true;
        }

        private bool IsSignatureValidation()
        {
            if (Properties.Settings.Default.Signature_Module)
                if (!DCS_MemberInfo.Data.SignatureOverride)
                {
                    if (Properties.Settings.Default.SignatureTablet == "Topaz Siglite")
                        return System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile);
                    else
                        return Utilities.IsSignaturesComplete();
                }                    
                else
                    return true;
            else
                return true;
        }        

        public void NavigationControl()
        {
            if (DCS_MemberInfo.Data.MemberInfo != null & IsPhotoValidation())
            {
                btnResetAll.Visible = true;
            }
            else
            {
                btnResetAll.Visible = false;
            }

            switch (Utilities.CurrentTab)
            { 
                case Utilities.FormTab.Data:
                    btnData.VIBlendTheme = Utilities.VIBlendActiveButton;
                    btnPhoto.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnSignature.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnBiometrics.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPreview.VIBlendTheme = Utilities.VIBlendNotActiveButton;

                    btnPrevious.Visible = false;
                    btnNext.Visible = true;
                    SubmitBtnVisibility();
                    break;
                case Utilities.FormTab.Photo:
                    btnData.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPhoto.VIBlendTheme = Utilities.VIBlendActiveButton;
                    btnSignature.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnBiometrics.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPreview.VIBlendTheme = Utilities.VIBlendNotActiveButton;

                    btnPrevious.Visible = true;
                    btnNext.Visible = true;
                    btnSubmit.Visible = false;
                    break;               
                case Utilities.FormTab.Biometric:
                    btnData.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPhoto.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnSignature.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnBiometrics.VIBlendTheme = Utilities.VIBlendActiveButton;
                    btnPreview.VIBlendTheme = Utilities.VIBlendNotActiveButton;

                    btnPrevious.Visible = true;
                    btnNext.Visible = true;
                    btnSubmit.Visible = false;
                    break;                    
                case Utilities.FormTab.Signature:
                    btnData.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPhoto.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnSignature.VIBlendTheme = Utilities.VIBlendActiveButton;
                    btnBiometrics.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPreview.VIBlendTheme = Utilities.VIBlendNotActiveButton;

                    btnPrevious.Visible = true;
                    btnNext.Visible = Properties.Settings.Default.Preview_Module;
                    btnSubmit.Visible = false;
                    if (Properties.Settings.Default.Preview_Module)
                        btnSubmit.Visible = false;
                    else SubmitBtnVisibility();                    
                    break;
                case Utilities.FormTab.Preview:
                    btnData.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPhoto.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnSignature.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnBiometrics.VIBlendTheme = Utilities.VIBlendNotActiveButton;
                    btnPreview.VIBlendTheme = Utilities.VIBlendActiveButton;

                    btnPrevious.Visible = true;
                    btnNext.Visible = false;
                    SubmitBtnVisibility();
                    break;
                default:
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (DCS_DataCapture.DataCapture.ClientName)
            {
                case "AFPSLAI":
                    if (Properties.Settings.Default.Signature_Module)
                    {
                        if (!DCS_MemberInfo.Data.SignatureOverride)
                        {
                            SignatureCapture_Confirm sigConfirm = new SignatureCapture_Confirm();
                            sigConfirm.ShowDialog();
                            if (!sigConfirm.IsConfirm) return;
                        }
                    }
                    break;
                default:                    
                    break;
            }


            Cursor = Cursors.WaitCursor;
            btnSubmit.Enabled = false;

            txtFooterMsg.Text = "Data submission ongoing please wait...";
            txtFooterMsg.ForeColor = Color.Green;
            Application.DoEvents();

            if (_ucDataCapture.Submit())
            {
                //Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\FINAL\{1}\{2}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), DCS_MemberInfo.Data.MemberID);
                Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\{1}\{2}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), DCS_MemberInfo.Data.MemberID);
                //Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\FINAL\{1}\{2}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), DCS_MemberInfo.Data.SessionReference);

                switch (DCS_DataCapture.DataCapture.ClientName.ToUpper())
                {
                    case "AFP":
                        Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DCS_MemberInfo.Data.MemberID);
                        break;
                    case "CITYOFPASIG":
                        Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\FINAL\{1}\{2}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), DCS_MemberInfo.Data.MemberID);
                        break;
                    case "CITYGOVOFQC":
                        Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\FINAL\{1}\{2}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), DCS_MemberInfo.Data.MemberID);
                        break;
                    default:
                        Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\{1}\{2}", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), DCS_MemberInfo.Data.MemberID);
                        break;
                }

                if (Properties.Settings.Default.OC_Photo == 1)
                    Class.Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO = string.Format(@"{0}\FINAL\{1}\PHOTO", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"));
                else if (Properties.Settings.Default.OC_Photo == 2)
                    Class.Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO = string.Format(@"{0}\FINAL\PHOTO", Class.Utilities.CAPTUREDDATA_REPOSITORY);

                if (Properties.Settings.Default.OC_Signature == 1)
                    Class.Utilities.CAPTUREDDATA_FINAL_SIGNATURE_REPO = string.Format(@"{0}\FINAL\{1}\SIGNATURE", Class.Utilities.CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"));
                else if (Properties.Settings.Default.OC_Signature == 2)
                    Class.Utilities.CAPTUREDDATA_FINAL_SIGNATURE_REPO = string.Format(@"{0}\FINAL\SIGNATURE", Class.Utilities.CAPTUREDDATA_REPOSITORY);

                //create directories
                if (Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY != "" & !System.IO.Directory.Exists(Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY))
                    System.IO.Directory.CreateDirectory(Class.Utilities.CAPTUREDDATA_FINAL_REPOSITORY);

                if (Class.Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO != "" & !System.IO.Directory.Exists(Class.Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO))
                    System.IO.Directory.CreateDirectory(Class.Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO);                

                if (Class.Utilities.CAPTUREDDATA_FINAL_SIGNATURE_REPO != "" & !System.IO.Directory.Exists(Class.Utilities.CAPTUREDDATA_FINAL_SIGNATURE_REPO))
                    System.IO.Directory.CreateDirectory(Class.Utilities.CAPTUREDDATA_FINAL_SIGNATURE_REPO);

                //create xml data
                XMLMemberData _xmlMD = new XMLMemberData();
                if (!_xmlMD.Create(DCS_MemberInfo.Data.MemberInfo, DCS_MemberInfo.Data.MemberDataXMLFile))
                {
                    Utilities.SaveToErrorLog(string.Format("{0}{1}{2}", Utilities.TimeStamp(), "XML creation for member's data failed ", DCS_MemberInfo.Data.MemberDataXMLFile));
                    Utilities.ShowInfoMessage("XML creation for member's data failed. Please check if backup file is created.");
                    txtFooterMsg.Text = "";
                    Cursor = Cursors.Default;
                    btnSubmit.Enabled = true;
                    return;
                }                                           
                                
                //0{philhealth#}|1{fname}|2{mname}|3{lname}|4{suffix}|5{company}|6{branch}|7{sessionreference}|8{operatorid}|9{timestamp}
                StringBuilder sbHeader = new StringBuilder();
                StringBuilder sb = new StringBuilder();
                DataRow[] rws = DCS_MemberInfo.Data.MemberInfo.Select("IsCapturedListViewable=True");

                foreach (DataRow rw in rws)
                {
                    if (sb.ToString() == "")
                    {
                        sbHeader.Append(rw[0].ToString().Trim());
                        sb.Append(rw[1].ToString().Trim());
                    }
                    else
                    {
                        sbHeader.Append("|" + rw[0].ToString().Trim());
                        sb.Append("|" + rw[1].ToString().Trim());
                    }
                }

                //default fields
                sbHeader.Append("|" + "SessionReference");
                sbHeader.Append("|" + "Operator");
                sbHeader.Append("|" + "Timestamp");

                sb.Append("|" + DCS_MemberInfo.Data.SessionReference);
                sb.Append("|" + Properties.Settings.Default.Operator);
                sb.Append("|" + DateTime.Now.ToString());                

                //Utilities.SaveToCapturedData(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", DCS_MemberInfo.Data.MemberInfo.Select("Field='PhilhealthNo'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.MemberInfo.Select("Field='FirstName'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.MemberInfo.Select("Field='MiddleName'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.MemberInfo.Select("Field='LastName'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.MemberInfo.Select("Field='Suffix'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.MemberInfo.Select("Field='Company'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.MemberInfo.Select("Field='Branch'")[0][1].ToString().Trim(), DCS_MemberInfo.Data.SessionReference, Properties.Settings.Default.Operator, DateTime.Now.ToString()));
                Utilities.SaveToCapturedData(sbHeader.ToString(), sb.ToString());
                Utilities.SaveToCapturedDataCSV(sbHeader.ToString().Replace("|",Microsoft.VisualBasic.Constants.vbTab), sb.ToString().Replace("|", Microsoft.VisualBasic.Constants.vbTab));

                switch (DCS_DataCapture.DataCapture.ClientName)
                {
                    case "AFPSLAI":
                        CombinedJpgs();
                        break;
                    default:
                        break;
                }

                string tempPhoto = Application.StartupPath + "\\tempPhoto.jpg";

                //zip raw folder
                string ZipPassword = "";
                FileCompression _fc = new FileCompression();
                if (SaveToFinalFolder())
                {
                    if (Properties.Settings.Default.IsCompressFinalFolder)
                    {
                        switch (DCS_DataCapture.DataCapture.ClientName)
                        {
                            case "CityOfPasig":
                                ZipPassword = string.Format("pyT719aE_{0}", DCS_MemberInfo.Data.MemberID.Substring(0,4));
                                break;
                            case "AFPSLAI":
                                //create temporary photo for middle server copy
                                string photoPath = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_photo_{1}.jpg", DCS_MemberInfo.Data.MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                if (File.Exists(photoPath)) File.Copy(photoPath, tempPhoto, true);
                                break;
                        }  

                        if (_fc.Compress(Utilities.CAPTUREDDATA_FINAL_REPOSITORY, ZipPassword)) { }
                        if (Properties.Settings.Default.IsDeleteFinalFolder) System.IO.Directory.Delete(Utilities.CAPTUREDDATA_FINAL_REPOSITORY, true);                        
                    }
                }

                if (_fc.Compress(Utilities.CAPTUREDDATA_RAW_REPOSITORY, ZipPassword)) System.IO.Directory.Delete(Utilities.CAPTUREDDATA_RAW_REPOSITORY, true);
                //if (Properties.Settings.Default.IsCompressFinalFolder) System.IO.Directory.Delete(Utilities.CAPTUREDDATA_RAW_REPOSITORY, true);

                _fc = null;                

                int Cntr = Utilities.GetCaptureCntr() + 1;
                Utilities.CreateCaptureCntr(Cntr); 

                if (System.IO.File.Exists("DraftData")) { System.IO.File.Delete("DraftData"); }
                if (System.IO.File.Exists("LastSessionReference")) { System.IO.File.Delete("LastSessionReference"); }
                if (System.IO.File.Exists("OtherVariable")) { System.IO.File.Delete("OtherVariable"); }

                switch (DCS_DataCapture.DataCapture.ClientName)
                {
                    case "AFPSLAI":
                        string errMsg = "";
                        //string photoPath = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_photo_{1}.jpg", DCS_MemberInfo.Data.MemberID, DateTime.Today.ToString("ddMMyyyy")));
                        string zipFilePath = string.Format(@"{0}.zip", Utilities.CAPTUREDDATA_FINAL_REPOSITORY);
                        if (!_ucDataCapture.InsertToDbase(ref errMsg,Properties.Settings.Default.StationReference, tempPhoto, zipFilePath))
                        {
                            //DCS.data.memberinfo.select("field='cif_id'")[0]["value"].tostring()
                            Utilities.SaveToErrorLog(string.Format("{0}failed to insert to database {1}. {2}", Utilities.TimeStamp(), _ucDataCapture.MemberID, errMsg));
                            Utilities.ShowInfoMessage("data and biometric capture are success but database insertion failed...");
                        }
                        else Utilities.ShowInfoMessage("data and biometric capture are success!");

                        break;
                    case "Philhealth":
                        if (!System.IO.File.Exists(DCS_MemberInfo.Data.MemberDataSingleFile))
                        {
                            Utilities.SaveToErrorLog(string.Format("{0}{1}{2}", Utilities.TimeStamp(), "Single file creation for member's data failed ", DCS_MemberInfo.Data.MemberDataSingleFile));
                            Utilities.ShowErrorMessage("Single file creation for member's data failed");
                        }

                        Utilities.ShowInfoMessage("Data and biometric capture are success!");
                        break;
                    default:
                        Utilities.ShowInfoMessage("Data and biometric capture are success!");
                        break;
                }                

                ResetAll();
            }

            Cursor = Cursors.Default;
            btnSubmit.Enabled = true;
        }

        private bool SaveToFinalFolder()
        {
            try
            {
                bool IsPhotoProcessed = false;

                //copy to final folder
                string MemberID = DCS_MemberInfo.Data.MemberID;
                //string MemberID = DCS_MemberInfo.Data.SessionReference;
                string[] filenames = System.IO.Directory.GetFiles(Utilities.CAPTUREDDATA_RAW_REPOSITORY);
                foreach (string file in filenames)
                {
                    string filenameOnly = System.IO.Path.GetFileName(file);
                    string Ext = System.IO.Path.GetExtension(file).ToUpper();
                    switch (Ext)
                    {
                        case ".XML":
                            switch (DCS_DataCapture.DataCapture.ClientName)
                            {
                                case "AFPSLAI":
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_{1}.xml", MemberID,DateTime.Today.ToString("ddMMyyyy"))));
                                    break;
                                default:
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}.xml", MemberID)));
                                    break;
                            }
                            
                            break;
                        case ".TIFF":
                            if (Properties.Settings.Default.SignatureOutputTIFF)
                            {
                                //string strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature.tiff", MemberID));
                                string strDestinationFile = "";

                                switch (DCS_DataCapture.DataCapture.ClientName)
                                {
                                    case "AFPSLAI":
                                        strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature4_{1}.tiff", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                        if (file.Contains("_Signature2.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature2_{1}.tiff", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                        if (file.Contains("_Signature3.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature3_{1}.tiff", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                        if (file.Contains("_Signature4.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature_{1}.tiff", MemberID, DateTime.Today.ToString("ddMMyyyy")));

                                        break;
                                    default:
                                        strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature.tiff", MemberID));
                                        if (file.Contains("_Signature2.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature2.tiff", MemberID));
                                        if (file.Contains("_Signature3.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature3.tiff", MemberID));
                                        if (file.Contains("_Signature4.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature4.tiff", MemberID));
                                        break;
                                }                                

                                CopyFile(file, strDestinationFile);
                                SaveConsolidatedSignature(strDestinationFile);
                            }
                            break;
                        case ".BMP":
                            if (Properties.Settings.Default.SignatureOutputBMP)
                            {
                                string strDestinationFile = "";

                                switch (DCS_DataCapture.DataCapture.ClientName)
                                {
                                    case "AFPSLAI":
                                        strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature4_{1}.bmp", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                        if (file.Contains("_Signature2.bmp")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature2_{1}.bmp", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                        if (file.Contains("_Signature3.bmp")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature3_{1}.bmp", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                        if (file.Contains("_Signature4.bmp")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature_{1}.bmp", MemberID, DateTime.Today.ToString("ddMMyyyy")));

                                        break;
                                    default:
                                        strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature.bmp", MemberID));
                                        if (file.Contains("_Signature2.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature2.bmp", MemberID));
                                        if (file.Contains("_Signature3.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature3.bmp", MemberID));
                                        if (file.Contains("_Signature4.tiff")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature4.bmp", MemberID));
                                        break;
                                }

                                CopyFile(file, strDestinationFile);
                                }
                                break;
                        case ".JPG":
                            if (filenameOnly.Contains("ICAO"))
                            {
                                if (!IsPhotoProcessed)
                                {
                                    string strDestinationFile = "";

                                    switch (DCS_DataCapture.DataCapture.ClientName)
                                    {
                                        case "AFPSLAI":
                                            strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_photo_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                            CopyFile(file, strDestinationFile);
                                            SaveConsolidatedPhoto(strDestinationFile);
                                            IsPhotoProcessed = true;
                                            break;
                                        case "Metrobank":
                                            strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Photo.jpg", MemberID));
                                            CopyFile(file, strDestinationFile);
                                            SaveConsolidatedPhoto2(strDestinationFile);
                                            IsPhotoProcessed = true;
                                            break;
                                        default:
                                            strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Photo.jpg", MemberID));
                                            CopyFile(file, strDestinationFile);
                                            SaveConsolidatedPhoto(strDestinationFile);
                                            IsPhotoProcessed = true;
                                            break;
                                    }                                         
                                }
                            }
                            else if (filenameOnly.Contains("Signature"))
                            {
                                if (Properties.Settings.Default.SignatureOutputJPG)
                                {
                                    string strDestinationFile = "";

                                    switch (DCS_DataCapture.DataCapture.ClientName)
                                    {
                                        case "AFPSLAI":
                                            if (!IsBiometricsJPG(file))
                                            {
                                                strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature4_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                                if (file.Contains("_Signature2.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature2_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                                if (file.Contains("_Signature3.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature3_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                                if (file.Contains("_Signature4.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_signature_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                            }
                                            else
                                            {
                                                if (file.Contains("_Rprimary.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                                if (file.Contains("_Rbackup.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                                if (file.Contains("_Lprimary.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                                if (file.Contains("_Lbackup.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy")));
                                            }

                                            break;
                                        default:
                                            strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature.jpg", MemberID));
                                            if (file.Contains("_Signature2.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature2.jpg", MemberID));
                                            if (file.Contains("_Signature3.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature3.jpg", MemberID));
                                            if (file.Contains("_Signature4.jpg")) strDestinationFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature4.jpg", MemberID));
                                            break;
                                    }

                                    CopyFile(file, strDestinationFile);
                                    //CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Signature.jpg", MemberID)));
                                }
                                    
                            }
                            else if (filenameOnly.Contains("_ssc"))
                            {
                                CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_ssc_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                if(Convert.ToBoolean(DCS_MemberInfo.Data.MemberInfo.Select("Field='ForUpload'")[0]["Value"]))
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.SSV_FORUPLOAD_REPOSITORY, string.Format("{0}_ssc_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                else
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.SSV_NOTFORUPLOAD_REPOSITORY, string.Format("{0}_ssc_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                            }
                            else
                            {
                                if (Properties.Settings.Default.FingerScanner == "Sagem")
                                {
                                    if (Properties.Settings.Default.SagemOutputJPG)
                                    {
                                        if (filenameOnly.Contains("Lprimary"))
                                        {
                                            
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Lbackup"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));                                                    
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Lmiddle"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lmiddle_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lmiddle.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Lring"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lring_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lring.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Lpinky"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lpinky_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lpinky.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Rprimary"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary.jpg", MemberID)));
                                                    break;
                                            }                                            
                                        }
                                        else if (filenameOnly.Contains("Rbackup"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup.jpg", MemberID)));
                                                    break;
                                            }                                            
                                        }
                                        else if (filenameOnly.Contains("Rmiddle"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rmiddle_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rmiddle.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Rring"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rring_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rring.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                        else if (filenameOnly.Contains("Rpinky"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rpinky_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rpinky.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Properties.Settings.Default.SecugenOutputJPG)
                                    {
                                        if (filenameOnly.Contains("Lprimary"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary.jpg", MemberID)));
                                                    break;
                                            }                                            
                                        }
                                        else if (filenameOnly.Contains("Lbackup"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup.jpg", MemberID)));
                                                    break;
                                            }                                            
                                        }
                                        else if (filenameOnly.Contains("Rprimary"))
                                        {
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary.jpg", MemberID)));
                                                    break;
                                            }                                            
                                        }
                                        else if (filenameOnly.Contains("Rbackup"))
                                        {                                            
                                            switch (DCS_DataCapture.DataCapture.ClientName)
                                            {
                                                case "AFPSLAI":                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup_{1}.jpg", MemberID, DateTime.Today.ToString("ddMMyyyy"))));
                                                    break;
                                                default:                                                    
                                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup.jpg", MemberID)));
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case ".ANSI-FMR":
                            if (Properties.Settings.Default.SagemOutputANSI378)
                            {
                                if (filenameOnly.Contains("Lprimary"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lbackup"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lmiddle"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lmiddle.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lring"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lring.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lpinky"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lpinky.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rprimary"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rbackup"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rmiddle"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rmiddle.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rring"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rring.ansi-fmr", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rpinky"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rpinky.ansi-fmr", MemberID)));
                                }
                            }
                            break;
                        case ".WSQ":
                            if (Properties.Settings.Default.SagemOutputWSQ)
                            {
                                if (filenameOnly.Contains("Lprimary"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lprimary.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lbackup"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lbackup.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lmiddle"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lmiddle.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lring"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lring.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Lpinky"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Lpinky.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rprimary"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rprimary.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rbackup"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rbackup.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rmiddle"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rmiddle.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rring"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rring.wsq", MemberID)));
                                }
                                else if (filenameOnly.Contains("Rpinky"))
                                {
                                    CopyFile(file, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_REPOSITORY, string.Format("{0}_Rpinky.wsq", MemberID)));
                                }
                            }
                            break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "SaveToFinalFolder(): Runtime catched error " + ex.Message.ToString());                
                return false;
            }
        }

        private bool IsBiometricsJPG(string strFile)
        {
            if (Path.GetFileNameWithoutExtension(strFile).Contains("Rprimary"))
                return true;
            else if (Path.GetFileNameWithoutExtension(strFile).Contains("Rbackup"))
                return true;
            else if (Path.GetFileNameWithoutExtension(strFile).Contains("Lprimary"))
                return true;
            else if (Path.GetFileNameWithoutExtension(strFile).Contains("Lbackup"))
                return true;
            else
                return false;            
        }

        private void CopyFile(string Source, string Destination)
        {
            if (System.IO.File.Exists(Destination)) { System.IO.File.Delete(Destination); }
            System.IO.File.Copy(Source, Destination);
        }

        private bool ValidateTabs(Utilities.FormTab SourceTab)
        {
            if (SourceTab == Utilities.CurrentTab) return false;            

            bool bln = true;
            switch (Utilities.CurrentTab)
            {
                case Utilities.FormTab.Data:

                    if(SourceTab > Utilities.CurrentTab)
                    { 
                        //validate current tab before leaving
                        if (!IsDataCaptureLocalValidation())
                        {
                            txtFooterMsg.Text = _ucDataCapture.ErrorMessage;
                            txtFooterMsg.ForeColor = Color.OrangeRed;
                            bln = false;
                        }
                        else txtFooterMsg.Clear();
                    }
                    break;
                case Utilities.FormTab.Photo:
                    if (SourceTab > Utilities.CurrentTab)
                    {
                        if (!IsPhotoValidation())
                        {
                            txtFooterMsg.Text = "Please capture required photo...";
                            txtFooterMsg.ForeColor = Color.OrangeRed;
                            bln = false;
                        }
                        else
                        {
                            txtFooterMsg.Clear();

                            //if (!DCS_MemberInfo.Data.PhotoOverride)
                            //{
                            //    if (Properties.Settings.Default.PhotoGlobalScore > DCS_MemberInfo.Data.PhotoScore)
                            //    {
                            //        txtFooterMsg.Text = "Score quality of photo is below minimum";
                            //        txtFooterMsg.ForeColor = Color.OrangeRed;
                            //        bln = false;
                            //    }
                            //}
                            //else txtFooterMsg.Clear();
                        }
                    }
                    break;                
                case Utilities.FormTab.Biometric:
                    if (SourceTab > Utilities.CurrentTab)
                    {
                        if (!IsBiometricValidation())
                        {
                            txtFooterMsg.Text = "Please capture required biometrics...";
                            txtFooterMsg.ForeColor = Color.OrangeRed;
                            bln = false;
                        }
                        else txtFooterMsg.Clear();
                    }
                    break;
                case Utilities.FormTab.Signature:
                    if (SourceTab > Utilities.CurrentTab)
                    {
                        if (!IsSignatureValidation())
                        {
                            txtFooterMsg.Text = "Please capture required signature/s...";
                            txtFooterMsg.ForeColor = Color.OrangeRed;
                            bln = false;
                        }
                        else txtFooterMsg.Clear();                        
                    }
                    break;
            }

            return bln;            
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            Forms.Settings frm = new Forms.Settings();
            frm.ShowDialog();            
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            if (Utilities.ShowQuestionMessage("Are you sure you want to reset all?") == DialogResult.Yes)
            {
                ResetAll();
            }
        }

        private void ResetAll()
        {
            txtFooterMsg.Clear();

            Utilities.PhotoCapturing_ErrorMessage = "";
            Utilities.SignatureCapturing_ErrorMessage = "";
            Utilities.BiometricCapturing_ErrorMessage = "";

            btnPhoto.Enabled = false;
            btnBiometrics.Enabled = false;
            btnSignature.Enabled = false;
            btnPreview.Enabled = false;

            DCS_MemberInfo.Data.ResetData();

            Initialization();
            BindFooterLabel();

            IsFormInitialLoad = true;

            btnData.PerformClick();

            IsFormInitialLoad = false;
            IsDataLoadedFromDraft = false;
        }

        private void SaveToDraft(Control _control, ref StringBuilder sb)
        {
            //loop in controls of pnlMain
            foreach (Control ctrl in _control.Controls)
            {
                if (ctrl is Panel) SaveToDraft(ctrl, ref sb);
                else if (ctrl is GroupBox) SaveToDraft(ctrl, ref sb);
                else if (ctrl is TextBox)
                {
                    switch (DCS_DataCapture.DataCapture.ClientName)
                    {
                        case "San Pedro Poveda College":
                            sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((TextBox)ctrl).Text, "TextBox"));
                            break;                        
                        default:
                            sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((TextBox)ctrl).Text.ToUpper(), "TextBox"));
                            break;
                    }
                }
                else if (ctrl is ComboBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((ComboBox)ctrl).Text.ToUpper(), "ComboBox"));
                else if (ctrl is MaskedTextBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((MaskedTextBox)ctrl).Text.ToUpper(), "MaskedTextBox"));
                else if (ctrl is CheckBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((CheckBox)ctrl).Checked, "CheckBox"));
                else if (ctrl is DateTimePicker) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((DateTimePicker)ctrl).Text.ToUpper(), "DateTimePicker"));
            }
        }

        private void SaveToDraft2()
        {
            //save to draft
            StringBuilder sb = new StringBuilder();
            SaveToDraft(_ucDataCapture.Controls[0], ref sb);
            //other fields
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.PhotoOverride, "PhotoOverride"));
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.PhotoScore, "PhotoScore"));
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.SignatureOverride, "SignatureOverride"));

            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftPrimaryCode, "LeftPrimaryCode"));
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftThumbCode, "LeftThumbCode"));
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightPrimaryCode, "RightPrimaryCode"));
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightThumbCode, "RightThumbCode"));

            if (Properties.Settings.Default.ScanFingerType == 1)
            {
                sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftMiddleCode, "LeftMiddleCode"));
                sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftRingCode, "LeftRingCode"));
                sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftPinkyCode, "LeftPinkyCode"));
                sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightMiddleCode, "RightMiddleCode"));
                sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightRingCode, "RightRingCode"));
                sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightPinkyCode, "RightPinkyCode"));
            }            

            //bayambang only
            //sb.AppendLine(string.Format("{0}¿{1}¿{2}", "Field", _ucDataCapture.ContactPersonDetails, "ContactPersonDetails"));
            System.IO.File.WriteAllText("DraftData", sb.ToString());
            if (!System.IO.File.Exists("LastSessionReference")) { System.IO.File.WriteAllText("LastSessionReference", DCS_MemberInfo.Data.SessionReference); }
            //
        }

        private void SaveToDraft_bak(Control _control)
        {
            StringBuilder sb = new StringBuilder();

            //loop in controls of pnlMain
            foreach (Control ctrl in _control.Controls)
            {
                if (ctrl is Panel) SaveToDraft(ctrl, ref sb);
                else if (ctrl is GroupBox) SaveToDraft(ctrl, ref sb);
                else if (ctrl is TextBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((TextBox)ctrl).Text, "TextBox"));
                else if (ctrl is ComboBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((ComboBox)ctrl).Text, "ComboBox"));
                else if (ctrl is MaskedTextBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((MaskedTextBox)ctrl).Text, "MaskedTextBox"));
                else if (ctrl is CheckBox) sb.AppendLine(string.Format("{0}|{1}|{2}", ctrl.Name, ((CheckBox)ctrl).Checked, "CheckBox"));
            }

            //other fields
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.PhotoOverride, "PhotoOverride"));
            sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.SignatureOverride, "SignatureOverride"));

            //bayambang only
            //sb.AppendLine(string.Format("{0}¿{1}¿{2}", "Field", _ucDataCapture.ContactPersonDetails, "ContactPersonDetails"));

            System.IO.File.WriteAllText("DraftData", sb.ToString());

            //System.IO.StreamWriter sw = new System.IO.StreamWriter("DraftData",true);
            //sw.Write(sb.ToString());
            //sw.Dispose();
            //sw.Close();
            //sw = null;

            if (!System.IO.File.Exists("LastSessionReference")) { System.IO.File.WriteAllText("LastSessionReference", DCS_MemberInfo.Data.SessionReference); }

            //Properties.Settings.Default.LastSessionReference = Utilities.SessionReference();
            //Properties.Settings.Default.Save();
        }

        private void LoadDraftData(Control _control)
        {
            StringBuilder sb = new StringBuilder();

            using (System.IO.StreamReader sr = new System.IO.StreamReader("DraftData"))
            {
                while (!sr.EndOfStream)
                {                    
                    string strLine = sr.ReadLine();
                    sb.AppendLine(strLine);
                }

                sr.Dispose();
                sr.Close();                
            }

            PopulateDraftData(_control, sb);

            string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
            string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);            

            foreach (string str in lines)
            {
                if(str.Contains("Field"))
                {
                    if (str.Contains("¿"))
                    {
                        //if (str.Split('¿')[2] == "ContactPersonDetails") _ucDataCapture.ContactPersonDetails = str.Split('¿')[1];
                    }
                    else                    
                    { if (str.Split('|')[2] == "PhotoScore") DCS_MemberInfo.Data.PhotoScore = Convert.ToDouble(str.Split('|')[1]); }
                    { if (str.Split('|')[2] == "PhotoOverride") DCS_MemberInfo.Data.PhotoOverride = Convert.ToBoolean(str.Split('|')[1]); }
                    { if (str.Split('|')[2] == "SignatureOverride") DCS_MemberInfo.Data.SignatureOverride = Convert.ToBoolean(str.Split('|')[1]); }

                    { if (str.Split('|')[2] == "LeftPrimaryCode") DCS_MemberInfo.Data.LeftPrimaryCode = str.Split('|')[1]; }
                    { if (str.Split('|')[2] == "LeftThumbCode") DCS_MemberInfo.Data.LeftThumbCode = str.Split('|')[1]; }
                    { if (str.Split('|')[2] == "RightPrimaryCode") DCS_MemberInfo.Data.RightPrimaryCode = str.Split('|')[1]; }
                    { if (str.Split('|')[2] == "RightThumbCode") DCS_MemberInfo.Data.RightThumbCode = str.Split('|')[1]; }

                    if (Properties.Settings.Default.ScanFingerType == 1)
                    {
                        { if (str.Split('|')[2] == "LeftMiddleCode") DCS_MemberInfo.Data.LeftMiddleCode = str.Split('|')[1]; }
                        { if (str.Split('|')[2] == "LeftRingCode") DCS_MemberInfo.Data.LeftRingCode = str.Split('|')[1]; }
                        { if (str.Split('|')[2] == "LeftPinkyCode") DCS_MemberInfo.Data.LeftPinkyCode = str.Split('|')[1]; }
                        { if (str.Split('|')[2] == "RightMiddleCode") DCS_MemberInfo.Data.RightMiddleCode = str.Split('|')[1]; }
                        { if (str.Split('|')[2] == "RightRingCode") DCS_MemberInfo.Data.RightRingCode = str.Split('|')[1]; }
                        { if (str.Split('|')[2] == "RightPinkyCode") DCS_MemberInfo.Data.RightPinkyCode = str.Split('|')[1]; }

                        //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftMiddleCode, "LeftMiddleCode"));
                        //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftRingCode, "LeftRingCode"));
                        //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftPinkyCode, "LeftPinkyCode"));
                        //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightMiddleCode, "RightMiddleCode"));
                        //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightRingCode, "RightRingCode"));
                        //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightPinkyCode, "RightPinkyCode"));
                    }

                    //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftPrimaryCode, "LeftPrimaryCode"));
                    //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.LeftThumbCode, "LeftThumbCode"));
                    //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightPrimaryCode, "RightPrimaryCode"));
                    //sb.AppendLine(string.Format("{0}|{1}|{2}", "Field", DCS_MemberInfo.Data.RightThumbCode, "RightThumbCode"));
                }                                
            }

            DCS_MemberInfo.Data.MemberID = _ucDataCapture.MemberID;
            //DCS_MemberInfo.Data.MemberID = DCS_MemberInfo.Data.SessionReference;

            DCS_MemberInfo.Data.PhotoICAOFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.PhotoFinal_FileName);
            DCS_MemberInfo.Data.SignatureFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.Signature_FileNameTIFF);

            DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);
            DCS_MemberInfo.Data.BiometricLeftPrimaryFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);
            DCS_MemberInfo.Data.BiometricLeftPrimaryFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPrimary_FileName);

            DCS_MemberInfo.Data.BiometricLeftThumbFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);
            DCS_MemberInfo.Data.BiometricLeftThumbFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);
            DCS_MemberInfo.Data.BiometricLeftThumbFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftThumb_FileName);

            DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);
            DCS_MemberInfo.Data.BiometricRightPrimaryFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);
            DCS_MemberInfo.Data.BiometricRightPrimaryFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPrimary_FileName);

            DCS_MemberInfo.Data.BiometricRightThumbFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);
            DCS_MemberInfo.Data.BiometricRightThumbFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);
            DCS_MemberInfo.Data.BiometricRightThumbFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightThumb_FileName);

            if (Properties.Settings.Default.ScanFingerType == 1)
            {
                DCS_MemberInfo.Data.BiometricRightMiddleFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightMiddle_FileName);
                DCS_MemberInfo.Data.BiometricRightMiddleFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightMiddle_FileName);
                DCS_MemberInfo.Data.BiometricRightMiddleFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightMiddle_FileName);
                DCS_MemberInfo.Data.BiometricRightRingFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightRing_FileName);
                DCS_MemberInfo.Data.BiometricRightRingFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightRing_FileName);
                DCS_MemberInfo.Data.BiometricRightRingFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightRing_FileName);
                DCS_MemberInfo.Data.BiometricRightPinkyFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPinky_FileName);
                DCS_MemberInfo.Data.BiometricRightPinkyFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPinky_FileName);
                DCS_MemberInfo.Data.BiometricRightPinkyFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricRightPinky_FileName);

                DCS_MemberInfo.Data.BiometricLeftMiddleFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftMiddle_FileName);
                DCS_MemberInfo.Data.BiometricLeftMiddleFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftMiddle_FileName);
                DCS_MemberInfo.Data.BiometricLeftMiddleFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftMiddle_FileName);
                DCS_MemberInfo.Data.BiometricLeftRingFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftRing_FileName);
                DCS_MemberInfo.Data.BiometricLeftRingFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftRing_FileName);
                DCS_MemberInfo.Data.BiometricLeftRingFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftRing_FileName);
                DCS_MemberInfo.Data.BiometricLeftPinkyFileJPG = string.Format(@"{0}\{1}.jpg", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPinky_FileName);
                DCS_MemberInfo.Data.BiometricLeftPinkyFileANSI378 = string.Format(@"{0}\{1}.ansi-fmr", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPinky_FileName);
                DCS_MemberInfo.Data.BiometricLeftPinkyFileWSQ = string.Format(@"{0}\{1}.wsq", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.BiometricLeftPinky_FileName);
            }
        }

        private void PopulateDraftData(Control _control, StringBuilder sb)
        { 
            foreach (Control ctrl in _control.Controls)
            {
                if (ctrl is Panel)
                {
                    PopulateDraftData(ctrl, sb);
                }
                else if (ctrl is GroupBox)
                {
                    PopulateDraftData(ctrl, sb);
                }
                else if (ctrl is Label)
                {
                }
                else if (ctrl is TextBox)
                {
                    string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
                    string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);

                    foreach (string str in lines)
                    {
                        if (ctrl.Name == str.Split('|')[0])
                        {
                            ((TextBox)ctrl).Text = str.Split('|')[1];
                        }
                    }
                }
                else if (ctrl is ComboBox)
                {
                    string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
                    string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);

                    foreach (string str in lines)
                    {
                        if (ctrl.Name == str.Split('|')[0])
                        {
                            ((ComboBox)ctrl).Text = str.Split('|')[1];
                        }
                    }
                }
                else if (ctrl is MaskedTextBox)
                {
                    string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
                    string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);

                    foreach (string str in lines)
                    {
                        if (ctrl.Name == str.Split('|')[0])
                        {
                            ((MaskedTextBox)ctrl).Text = str.Split('|')[1];
                        }
                    }
                }
                else if (ctrl is DateTimePicker)
                {
                    string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
                    string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);

                    foreach (string str in lines)
                    {
                        if (ctrl.Name == str.Split('|')[0])
                        {
                            switch (DCS_DataCapture.DataCapture.ClientName)
                            {
                                case "AFPSLAI":
                                    //((DateTimePicker)ctrl).Format = DateTimePickerFormat.Custom;
                                    //((DateTimePicker)ctrl).CustomFormat = "dd/MM/yyyy";
                                    //DateTime d=
                                    //((DateTimePicker)ctrl).Text = Convert.ToDateTime(str.Split('|')[1]).ToString("dd/MM/yyyy");                                                           
                                    ((DateTimePicker)ctrl).Text = DateTime.ParseExact(str.Split('|')[1], "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture).ToString(); 
                                    break;
                                default:
                                    ((DateTimePicker)ctrl).Text = str.Split('|')[1];
                                    break;
                            }                            
                        }
                    }
                }
                else if (ctrl is CheckBox)
                {
                    string[] delim = { Environment.NewLine, "\n" }; // "\n" added in case you manually appended a newline
                    string[] lines = sb.ToString().Split(delim, StringSplitOptions.None);

                    foreach (string str in lines)
                    {
                        if (ctrl.Name == str.Split('|')[0])
                        {
                            ((CheckBox)ctrl).Checked = Convert.ToBoolean(str.Split('|')[1]);
                        }
                    }
                }               
            }
        }

        private void retrieveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to load draft data?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!System.IO.File.Exists("DraftData"))
                {
                    Utilities.ShowInfoMessage("No draft data found");
                    return;
                }

                LoadDraftData(_ucDataCapture.Controls[0]);
                IsDataLoadedFromDraft = true;
            }            
        }


        private System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
        internal System.Drawing.Printing.PreviewPrintController ppc = new System.Drawing.Printing.PreviewPrintController();

        private Image imgPhoto;
        private Image imgSignature;
        private Image imgLP;
        private Image imgLB;
        private Image imgRP;
        private Image imgRB;        

        bool IsInitial = true;

        private void CombinedJpgs()
        {
            printDocument1.PrintController = ppc;
            printDocument1.PrinterSettings.PrintToFile = true;

            if (IsInitial)
            {
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument5_PrintPage);
                printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_EndPrint);
                IsInitial = false;
            }

            printDocument1.Print();

            ResizeSSC_Image(Utilities.AFPSLAI_SSC_FileName);            
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.PageUnit = GraphicsUnit.Pixel;

            SolidBrush dBlack = new SolidBrush(Color.Black);
            Font fontGeneric = new Font("Arial", 30);

            //e.Graphics.DrawString(_ucDataCapture.MemberName, fontGeneric, dBlack, 83, 50);
            e.Graphics.DrawString("", fontGeneric, dBlack, 83, 50);

            int intPhotoWidth = 220;
            int intPhotoHeight = 250;
            e.Graphics.DrawImage(imgPhoto, 83, 190, intPhotoWidth, intPhotoHeight);

            //add left
            e.Graphics.DrawImage(imgSignature, 83 + intPhotoWidth + 20, 190, 300, 150);

            int intBiometricWidth = 170;
            int intBiometricHeight = 200;

            //add top
            e.Graphics.DrawImage(imgLP, 83, 190 + intPhotoHeight + 20, intBiometricWidth, intBiometricHeight);

            //add top and left
            e.Graphics.DrawImage(imgLB, (83 + intBiometricWidth + 10), (190 + intPhotoHeight + 20), intBiometricWidth, intBiometricHeight);
            e.Graphics.DrawImage(imgRP, (83 + intBiometricWidth + intBiometricWidth + 20), (190 + intPhotoHeight + 20), intBiometricWidth, intBiometricHeight);
            e.Graphics.DrawImage(imgRB, (83 + intBiometricWidth + intBiometricWidth + intBiometricWidth + 30), (190 + intPhotoHeight + 20), intBiometricWidth, intBiometricHeight);

            printDocument1.PrintController = ppc;
        }

        private void printDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            SolidBrush dBlack = new SolidBrush(Color.Black);

            Font fontHightlight = new Font("Arial", (float)10.5, FontStyle.Bold);
            Font fontGeneric = new Font("Arial", (float)7.5);

            //TEMPLATE
            if (File.Exists(@"Images\digitID_New.jpg"))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(@"Images\digitID_New.jpg"))),
                                 40, 0, 5050, 3700);

            //PHOTO
            if (File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
                                 4200, 430, 700, 750);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MembershipType'")[0][1].ToString().Trim(), fontHightlight, dBlack, 800, 950);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='AssociateType'")[0][1].ToString().Trim(), fontHightlight, dBlack, 800, 1110);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID'")[0][1].ToString().Trim(), fontHightlight, dBlack, 90, 1370);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='LastName'")[0][1].ToString().Trim(), fontHightlight, dBlack, 990, 1370);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='FirstName'")[0][1].ToString().Trim(), fontHightlight, dBlack, 1740, 1370);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='Suffix'")[0][1].ToString().Trim(), fontHightlight, dBlack, 2430, 1370);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MiddleName'")[0][1].ToString().Trim(), fontHightlight, dBlack, 3290, 1370);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='DateOfBirth'")[0][1].ToString().Trim(), fontHightlight, dBlack, 90, 1660);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='Gender'")[0][1].ToString().Trim(), fontHightlight, dBlack, 1020, 1660);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MembershipDate'")[0][1].ToString().Trim(), fontHightlight, dBlack, 1900, 1660);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID_PrincipalMember'")[0][1].ToString().Trim(), fontHightlight, dBlack, 2880, 1660);

            //SIGNATURES
            //#1
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
                                     300, 1980, 1150, 300);
            //#2
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
                                 300, 2360, 1150, 300);
            //#3
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
                                 2180, 1980, 1150, 300);

            //#4
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
                                 2180, 2360, 1150, 300);


            //BIO
            //#left thumb
            if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 260, 3000, 500, 530);
            //#right thumb
            if (File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
                                 1160, 3000, 500, 530);
            //#left index
            if (File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))),
                                 2100, 3000, 500, 530);

            //#right index
            if (File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))),
                                 3150, 3000, 500, 530);

            printDocument1.PrintController = ppc;
        }

        //3
        private void printDocument3_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            SolidBrush dBlack = new SolidBrush(Color.Black);

            Font fontHightlight = new Font("Arial", (float)9, FontStyle.Bold);
            Font fontGeneric = new Font("Arial", (float)7.5);

            //TEMPLATE
            if (File.Exists(@"Images\digitID_New.jpg"))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(@"Images\AFPSLAIForm.jpg"))),
                                 0, 0, 5050, 3700);//40, 0, 5050, 3700);

            //temp
            //string sourceFolder = @"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\RAW\05122017\StationName_20170512_050852_0006";

            //PHOTO
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
            if (File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
                                    3610, 250, 1000, 1000);

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_ICAO_Photo.jpg")))),

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID'")[0][1].ToString().Trim(), fontHightlight, dBlack, 140, 980);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CCANo'")[0][1].ToString().Trim(), fontHightlight, dBlack, 1290, 980);
            //e.Graphics.DrawString("999123499912", fontHightlight, dBlack, 1290, 980);            
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='LastName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 140, 1280);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='FirstName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 830, 1280);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='Suffix'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 1590, 1280);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MiddleName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 2680, 1280);

            e.Graphics.DrawString(DateTime.Now.ToString("MMMM dd"), fontHightlight, dBlack, 1500, 1490);
            e.Graphics.DrawString(DateTime.Now.ToString("yy"), fontHightlight, dBlack, 3000, 1490);

            e.Graphics.DrawString(DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight, dBlack, 140, 3315);
            e.Graphics.DrawString(DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight, dBlack, 3000, 2715);
            //Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text));

            //e.Graphics.DrawString("1234567890123", fontHightlight, dBlack, 140, 980);
            //e.Graphics.DrawString("LAST NAME", fontHightlight, dBlack, 140, 1280);
            //e.Graphics.DrawString("FIRST NAME", fontHightlight, dBlack, 830, 1280);
            //e.Graphics.DrawString("SUFFIX", fontHightlight, dBlack, 1590, 1280);
            //e.Graphics.DrawString("MIDD LENAME", fontHightlight, dBlack, 2680, 1280);

            //SIGNATURES
            //#1
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
                 e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
                                        400, 1780, 950, 150);

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_Signature.tiff")))),

            //400,1780,1150,200
            //300, 1980, 1150, 300);
            //#2
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
                                    400, 2160, 950, 150);

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_Signature2.tiff")))),

            //300, 2360, 1150, 300);
            //#3
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
                                 3120, 1780, 950, 150);//3120, 1780, 1150, 200);

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_Signature3.tiff")))),

            //#4
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
                                 3120, 2160, 950, 150);

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_Signature4.tiff")))),

            ////BIO
            //#left thumb
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
            if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 520, 2515, 480, 460);

            e.Graphics.DrawString(DCS_MemberInfo.Data.LeftThumbCode, fontGeneric, dBlack, 1010, 2615);
            //e.Graphics.DrawString("Left Thumb", fontGeneric, dBlack, 1020, 2615);            

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_Lbackup.jpg")))),

            //560, 2550, 500, 520);

            //560,2515,480,460
            //#right thumb
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
            if (File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
                                 1860, 2515, 480, 460);

            e.Graphics.DrawString(DCS_MemberInfo.Data.RightThumbCode, fontGeneric, dBlack, 2340, 2615);

            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(string.Format(@"{0}\{1}", sourceFolder, "StationName_20170512_050852_0006_Lbackup.jpg")))),

            printDocument1.PrintController = ppc;
        }

        //4
        private void printDocument4_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;            

            SolidBrush dBlack = new SolidBrush(Color.Black);

            Font fontHightlight = new Font("Arial", (float)2.5, FontStyle.Bold);
            Font fontGeneric = new Font("Arial", (float)1.5);

            //TEMPLATE
            if (File.Exists(@"Images\AFPSLAI_SSC_FORM.jpg"))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(@"Images\AFPSLAI_SSC_FORM.jpg"))),
                                 0, 0, 1364, 974);//0, 0, 682, 487)

            //temp
            //string sourceFolder = @"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\RAW\05122017\StationName_20170512_050852_0006";

            //PHOTO
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
            if (File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
                                    1050, 65, 240, 265);

            string[] IDs = DCS_MemberInfo.Data.MemberInfo.Select("Field='IDs'")[0][1].ToString().Split(',');

            //if regular
            if(IDs[4]=="1")e.Graphics.DrawString("X", fontHightlight, dBlack, 319, 217);

            //if associate
            if (IDs[4] == "2") e.Graphics.DrawString("X", fontHightlight, dBlack, 446, 217);

            //if dependent
            if (IDs[6] == "1") e.Graphics.DrawString("X", fontHightlight, dBlack, 319, 263);

            //if pvao
            if (IDs[6] == "2") e.Graphics.DrawString("X", fontHightlight, dBlack, 446, 263);

            //if cadet
            if (IDs[6] == "3") e.Graphics.DrawString("X", fontHightlight, dBlack, 537, 263);

            //if male
            if(DCS_MemberInfo.Data.MemberInfo.Select("Field='Gender'")[0][1].ToString().Trim().ToUpper().Substring(0,1)=="M")
                e.Graphics.DrawString("X", fontHightlight, dBlack, 725, 263);
            else //if female
                e.Graphics.DrawString("X", fontHightlight, dBlack, 837, 263);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CCANo'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 670,215);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='LastName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 12, 335);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='FirstName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 255, 335);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='Suffix'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 557, 335);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MiddleName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 810, 335);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 12, 415);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MembershipDate'")[0][1].ToString().Trim().Replace("/", "-"), fontHightlight, dBlack, 340, 415);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='DateOfBirth'")[0][1].ToString().Trim().Replace("/","-"), fontHightlight, dBlack, 680, 415);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID_PrincipalMember'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 1000, 415);

            e.Graphics.DrawString(DateTime.Now.ToString("MMMM dd"), fontHightlight, dBlack, 570, 460);
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy"), fontHightlight, dBlack, 810, 460);

            e.Graphics.DrawString(DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight, dBlack, 810, 845);

            //System.Windows.Forms.TextFormatFlags flags = TextFormatFlags.HorizontalCenter;
            //Rectangle rec = new Rectangle() 
            //TextRenderer.DrawText(e.Graphics, DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight, New Rectangle(ce.Name_X, (intTextTopLocationBase + (intAddedValue * 2)), ce.Barcode_Width, 450), Color.Black, flags)

            //SIGNATURES
            //#1
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
                                       160, 510, 200, 100);
            else
                //fingerprint
                if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 160, 500, 100, 120);            
            
            ////#2
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
                                    160, 630, 200, 100);//880, 510, 200, 100            
            

            ////300, 2360, 1150, 300);
            ////#3
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
                                 880, 510, 200, 100);//3120, 1780, 1150, 200);
            else
                //fingerprint
                if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 880, 500, 100, 120);


            ////#4
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
                                 880, 630, 200, 100);            

            //////BIO
            ////#left thumb
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
            if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 120, 810, 100, 120);
            
            ////#right thumb
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
            if (File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
                                 440, 810, 100, 120);            

            printDocument1.PrintController = ppc;
        }

        //5
        private void printDocument5_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            SolidBrush dBlack = new SolidBrush(Color.Black);

            Font fontHightlight = new Font("Arial", (float)2.5, FontStyle.Bold);
            Font fontGeneric = new Font("Arial", (float)1.5);

            //TEMPLATE
            if (File.Exists(@"Images\AFPSLAI_SSC_FORM.jpg"))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(@"Images\AFPSLAI_SSC_FORM.jpg"))),
                                 0, 0, 1364, 974);//0, 0, 682, 487)

            //temp
            //string sourceFolder = @"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\RAW\05122017\StationName_20170512_050852_0006";

            //PHOTO
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
            if (File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile))),
                                    1050, 65, 240, 265);

            string[] IDs = DCS_MemberInfo.Data.MemberInfo.Select("Field='IDs'")[0][1].ToString().Split(',');

            //if regular
            if (IDs[4] == "1") e.Graphics.DrawString("X", fontHightlight, dBlack, 197, 217);

            //if associate
            if (IDs[4] == "2") e.Graphics.DrawString("X", fontHightlight, dBlack, 363, 217);

            //if dependent
            if (IDs[6] == "1") e.Graphics.DrawString("X", fontHightlight, dBlack, 183, 263);

            //if pvao
            if (IDs[6] == "2") e.Graphics.DrawString("X", fontHightlight, dBlack, 319, 263);

            //if cadet
            if (IDs[6] == "3") e.Graphics.DrawString("X", fontHightlight, dBlack, 468, 263);

            //if male
            if (DCS_MemberInfo.Data.MemberInfo.Select("Field='Gender'")[0][1].ToString().Trim().ToUpper().Substring(0, 1) == "M")
                e.Graphics.DrawString("X", fontHightlight, dBlack, 679, 263);
            else //if female
                e.Graphics.DrawString("X", fontHightlight, dBlack, 787, 263);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CCANo'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 670, 215);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='LastName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 12, 335);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='FirstName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 255, 335);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='Suffix'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 540, 335);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MiddleName'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 745, 335);

            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 12, 415);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='MembershipDate'")[0][1].ToString().Trim().Replace("/", "-"), fontHightlight, dBlack, 340, 415);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='DateOfBirth'")[0][1].ToString().Trim().Replace("/", "-"), fontHightlight, dBlack, 680, 415);
            e.Graphics.DrawString(DCS_MemberInfo.Data.MemberInfo.Select("Field='CIF_ID_PrincipalMember'")[0][1].ToString().Trim().ToUpper(), fontHightlight, dBlack, 1000, 415);

            e.Graphics.DrawString(DateTime.Now.ToString("MMMM dd"), fontHightlight, dBlack, 570, 460);
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy"), fontHightlight, dBlack, 810, 460);

            Font fontHightlight3 = new Font("Arial", (float)15, FontStyle.Bold);
            System.Windows.Forms.TextFormatFlags flags = TextFormatFlags.HorizontalCenter;
            //Pen pen = new Pen(Color.Black, 2);
            //pen.Alignment = PenAlignment.Inset;
            Rectangle rect = new Rectangle(710, 845, 600, 30);
            //e.Graphics.DrawRectangle(pen, rect);
            System.Windows.Forms.TextRenderer.DrawText(e.Graphics, DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight3, rect, Color.Black, flags);
            //e.Graphics.DrawString(DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight, dBlack, 810, 845);

            //System.Windows.Forms.TextFormatFlags flags = TextFormatFlags.HorizontalCenter;
            //Rectangle rec = new Rectangle() 
            //TextRenderer.DrawText(e.Graphics, DCS_MemberInfo.Data.OperatorID.ToUpper(), fontHightlight, New Rectangle(ce.Name_X, (intTextTopLocationBase + (intAddedValue * 2)), ce.Barcode_Width, 450), Color.Black, flags)

            //SIGNATURES
            //#1
            //e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile))),
                                       160, 510, 200, 100);
            else
            {

                //fingerprint
                if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))                                    
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                 160, 510, 100, 110);
                else if (File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))                
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG))),
                                 160, 510, 100, 110);
            }

            ////#2
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))),
                                    160, 630, 200, 100);//880, 510, 200, 100            


            ////300, 2360, 1150, 300);
            ////#3
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))),
                                 880, 515, 200, 110);//3120, 1780, 1150, 200);
            else
            {
                //fingerprint
                if (File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
                                 880, 510, 100, 110);
                else if(File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG))),
                                 880, 510, 100, 110);
            }


            ////#4
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
            if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))
                e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff")))),
                                 880, 630, 200, 100);

            //////BIO
            ////#left thumb
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
            if (DCS_MemberInfo.Data.LeftThumbCode == "Amputated")
                e.Graphics.DrawString(DCS_MemberInfo.Data.LeftThumbCode, fontHightlight, dBlack, 120, 860);
            else 
            {
                if (DCS_MemberInfo.Data.LeftThumbCode != "Left Thumb") e.Graphics.DrawString(DCS_MemberInfo.Data.LeftThumbCode, fontHightlight, dBlack, 120, 780);
                if (File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG))),
                                     120, 810, 100, 120);
            }

            ////#right thumb
            ////e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
            if (DCS_MemberInfo.Data.RightThumbCode == "Amputated")
                e.Graphics.DrawString(DCS_MemberInfo.Data.RightThumbCode, fontHightlight, dBlack, 440, 860);
            else 
            {
                if (DCS_MemberInfo.Data.RightThumbCode != "Right Thumb") e.Graphics.DrawString(DCS_MemberInfo.Data.RightThumbCode, fontHightlight, dBlack, 440, 780);
                if (File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))
                    e.Graphics.DrawImage(Image.FromStream(new MemoryStream(File.ReadAllBytes(DCS_MemberInfo.Data.BiometricRightThumbFileJPG))),
                                     440, 810, 100, 120);
            }

            printDocument1.PrintController = ppc;
        }

        private void printDocument1_EndPrint(System.Object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                Utilities.AFPSLAI_SSC_FileName = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.SessionReference() + "_ssc.jpg");
                //string outputFile = string.Format(@"{0}\{1}", @"D:\EDEL", "test_New.jpg");
                //Utilities.AFPSLAI_SSC_FileName = outputFile;
                System.Drawing.Printing.PreviewPageInfo[] ppi = ppc.GetPreviewPageInfo();
                for (int x = 0; x <= ppi.Length - 1; x++)
                {
                    ppi[x].Image.Save(Utilities.AFPSLAI_SSC_FileName);
                    //ppi[x].Image.Save(outputFile);
                }
            }
            catch { }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string origFile = @"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\05192017\9409090942222\9409090942222_ssc.jpg";
            //ResizeSSC_Image(origFile);
            CombinedJpgs();

            //picTemp.BackgroundImage = Image.FromFile(@"D:\EDEL\test_New.jpg");
        }

        private void ResizeSSC_Image(string fileSSC)
        {            
            //string outputFile = @"D:\EDEL\ACC\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\05192017\9409090942222\test.jpg";
            string tempSSC = "tempSSC1.jpg";
            string tempSSC2 = "tempSSC2.jpg";
            System.IO.File.Copy(fileSSC, tempSSC, true);
            CropImage(tempSSC, tempSSC2, 1363, 969);
            System.IO.File.Copy(tempSSC2, fileSSC, true);
            //System.Drawing.Bitmap bmp = (Bitmap)Image.FromFile(tempSSC2);
            //ResizeBitmap(bmp, 1700, 1400, 100, fileSSC);
        }

        public void ResizeBitmap(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

            // Create an Encoder object for the Quality parameter.
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 
            EncoderParameters encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            newImage.Save(filePath, imageCodecInfo, encoderParameters);
        }
      
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        public void CropImage(string inputFile, string outputFile, int width, int height)
        {
            //string imagePath = @"C:\Users\Admin\Desktop\test.jpg";
            Bitmap croppedImage;

            // Here we capture the resource - image file.
            using (var originalImage = new Bitmap(inputFile))
            {
                Rectangle crop = new Rectangle(0, 0, width, height);

                // Here we capture another resource.
                croppedImage = originalImage.Clone(crop, originalImage.PixelFormat);

            } // Here we release the original resource - bitmap in memory and file on disk.

            // At this point the file on disk already free - you can record to the same path.
            croppedImage.Save(outputFile, ImageFormat.Jpeg);
            //outputBMP = croppedImage;

            // It is desirable release this resource too.
            croppedImage.Dispose();
        }

        private void capturedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.CapturedList2 frm = new Forms.CapturedList2();
            frm.ShowDialog(); 
        }       

        private void systemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Settings frm = new Forms.Settings();
            frm.ShowDialog();
            if (frm.IsHaveChanges)
            {
                _ucDataCapture.CloseDataCapture();
                RunBat();
            }
        }

        private void localListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.CapturedList frm = new Forms.CapturedList();
            frm.ShowDialog(); 
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _ucDataCapture.CloseDataCapture();
                Utilities.KillProgram("DCS2015.exe");
                System.Environment.Exit(1);
            }
            catch { }
            
        }

        private void manageDataCaptureFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ucDataCapture.ShowManageDataCaptureFieldsForm();
        }

        private void SaveConsolidatedPhoto(string PhotoFile)
        {
            switch (Properties.Settings.Default.OC_Photo)
            {
                case 1: case 2:
                    CopyFile(PhotoFile, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO, System.IO.Path.GetFileName(PhotoFile)));
                    break;
            }
        }

        private void SaveConsolidatedPhoto2(string PhotoFile)
        {
           
            switch (Properties.Settings.Default.OC_Photo)
            {
                case 1:
                case 2:
                    CopyFile(PhotoFile, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_PHOTO_REPO, System.IO.Path.GetFileName(PhotoFile).Replace("_Photo","")));
                    break;
            }
        }

        private void SaveConsolidatedSignature(string SignatureFile)
        {
            switch (Properties.Settings.Default.OC_Signature)
            {
                case 1: case 2:
                    CopyFile(SignatureFile, string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_FINAL_SIGNATURE_REPO, System.IO.Path.GetFileName(SignatureFile)));
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string bmpFile = ofd.FileName;
                string wsqFile = bmpFile.Replace(Path.GetExtension(ofd.FileName), ".wsq");

                Bitmap bmp = new Bitmap(bmpFile);

                PhotoAnalysis.SaveToWSQ(bmp, wsqFile);
                PhotoAnalysis.DrawScoreToFingerPrintImage(wsqFile);
            
            }

            ofd.Dispose();
            ofd = null;            

            return;

            if (Utilities.ShowQuestionMessage("Are you sure you want to logout?") == DialogResult.Yes)
            {
                _ucDataCapture.CloseDataCapture();
                RunBat();
                //Utilities.KillProgram("DCS2015.exe");
                //System.Environment.Exit(1);
            }
        }

        private void RunBat()
        {
            System.Diagnostics.Process.Start("restart_dcs.bat");
        }
    }
}
