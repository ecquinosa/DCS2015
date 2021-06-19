
#region " Imports "

using System;
using System.Data;
using System.Windows.Forms;

#endregion

namespace DCS2015.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public bool IsHaveChanges = false;

        private void Settings_Load(object sender, EventArgs e)
        {
            Class.CanonCamera cc;
            try
            {
                cc = new Class.CanonCamera();
                cc.RefreshCamera();
                foreach (EDSDKLib.Camera cam in cc.CamList)
                {
                    comboBoxCameras.Items.Add(cam.Info.szDeviceDescription);
                }
            }
            catch { }
            finally { cc = null; }

            try
            {
                foreach (Touchless.Vision.Camera.Camera cam in Touchless.Vision.Camera.CameraService.AvailableCameras)
                {
                    comboBoxCameras.Items.Add(cam.Name);
                }
            }
            catch { }

            if (comboBoxCameras.Items.Count>0)comboBoxCameras.SelectedIndex = comboBoxCameras.FindStringExact(Properties.Settings.Default.Camera);

            Class.Sagem _sagem;
            try
            {
                _sagem = new Class.Sagem();
                if (_sagem.EnumerateDevice(ref cboSagemDevice_tabSagem))
                {
                }
            }
            catch { }
            finally { _sagem = null; }

            Class.Secugen _secugen;
            try
            {
                _secugen = new Class.Secugen();
                _secugen.EnumerateDevice(cboSecugenDevice_tabSecugen);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);

            }
            finally { _secugen = null; }                        

            BindSettings();

            FingerScannerDispo();
            gbFingerscanner.Visible = chkModuleBiometric.Checked;
            gbSignatureTablet.Visible = chkModuleSignature.Checked;
            SplashProcessValidationDispo();
        }

        private void BindSettings()
        {
            //tab terminal
            txtOperator_tabTerminal.Text = Properties.Settings.Default.Operator;
            txtStationReference_tabTerminal .Text = Properties.Settings.Default.StationReference;
            txtAdminPass_tabTerminal.Text = Properties.Settings.Default.AdminPass;
            chkCompressFinalFolder_tabTerminal.Checked=Properties.Settings.Default.IsCompressFinalFolder;
            chkDeleteFinalFolder_tabTerminal.Checked = Properties.Settings.Default.IsDeleteFinalFolder;

            if (Properties.Settings.Default.FingerScanner == "Sagem")
                rbSagem.Checked = true;
            else
                rbSecugen.Checked = true;

            if (Properties.Settings.Default.SignatureTablet == "Topaz Siglite")
                rbTopaz.Checked = true;
            else
                rbEvolisSig.Checked = true;

            //tab photo
            comboBoxCameras.SelectedIndex = comboBoxCameras.FindStringExact(Properties.Settings.Default.Camera);             
            txtBGUniformityMin_tabPhoto.Text = Properties.Settings.Default.BGUniformityMin.ToString();
            txtBGUniformityMax_tabPhoto.Text = Properties.Settings.Default.BGUniformityMax.ToString();
            txtSharpnessMin_tabPhoto.Text = Properties.Settings.Default.SharpnessMin.ToString();
            txtSharpnessMax_tabPhoto.Text = Properties.Settings.Default.SharpnessMax.ToString();
            txtGrayscaleDensityMin_tabPhoto.Text = Properties.Settings.Default.GrayscaleDensityMin.ToString();
            txtGrayscaleDensityMax_tabPhoto.Text = Properties.Settings.Default.GrayscaleDensityMax.ToString();
            txtPhotoGlobalScore_tabPhoto.Text = Properties.Settings.Default.PhotoGlobalScore.ToString();
            txtDefaultBrightness_tabPhoto.Text = Properties.Settings.Default.DefaultBrightness.ToString();
            txtDefaultSharpness_tabPhoto.Text = Properties.Settings.Default.DefaultSharpness.ToString();
            txtDefaultZoom_tabPhoto.Text = Properties.Settings.Default.DefaultZoom.ToString();
                        
            txtFaceDistance_Min.Text = Properties.Settings.Default.FaceDistance_Min.ToString();
            txtFaceDistance_Max.Text = Properties.Settings.Default.FaceDistance_Max.ToString();

            //tab sagem
            cboSagemDevice_tabSagem.SelectedIndex = cboSagemDevice_tabSagem.FindStringExact(Properties.Settings.Default.SagemDeviceSerial);             
            txtQualityThreshold_tabSagem.Text = Properties.Settings.Default.FP_Quality_Threshold.ToString();
            txtTimeout_tabSagem.Text = Properties.Settings.Default.SagemCaptureTime.ToString();
            txtBitmapHResolution_tabSagem.Text = Properties.Settings.Default.Bitmap_HResolution.ToString();
            txtBitmapVResolution_tabSagem.Text = Properties.Settings.Default.Bitmap_VResolution.ToString();
            chkJPG_tabSagem.Checked = Properties.Settings.Default.SagemOutputJPG;
            chkANSI_tabSagem.Checked = Properties.Settings.Default.SagemOutputANSI378;
            chkWSQ_tabSagem.Checked = Properties.Settings.Default.SagemOutputWSQ;

            //tab secugen
            cboSecugenDevice_tabSecugen.SelectedIndex = cboSecugenDevice_tabSecugen.FindStringExact(Properties.Settings.Default.SecugenDevice);
            txtQualityThreshold_tabSecugen.Text = Properties.Settings.Default.QualityThreshold_Secugen.ToString();
            txtTimeout_tabSecugen.Text = Properties.Settings.Default.SagemCaptureTime.ToString();
            txtImageWidth_tabSecugen.Text = Properties.Settings.Default.ImageWidth_Secugen.ToString();
            txtImageHeight_tabSecugen.Text = Properties.Settings.Default.ImageHeight_Secugen.ToString();
            chkJPG_tabSecugen.Checked = Properties.Settings.Default.SecugenOutputJPG;
            chkANSI_tabSecugen.Checked = Properties.Settings.Default.SecugenOutputANSI378;
            chkWSQ_tabSecugen.Checked = Properties.Settings.Default.SecugenOutputWSQ;

            //tab signature
            chkTIFF_tabSignature.Checked = Properties.Settings.Default.SignatureOutputTIFF;
            chkJPG_tabSignature.Checked = Properties.Settings.Default.SignatureOutputJPG;
            chkBMP_tabSignature.Checked = Properties.Settings.Default.SignatureOutputBMP;

            //modules
            chkModuleDataCapture.Checked = Properties.Settings.Default.DataCapture_Module;
            chkModulePhoto.Checked = Properties.Settings.Default.Photo_Module;
            chkModuleBiometric.Checked = Properties.Settings.Default.Biometric_Module;
            chkModuleSignature.Checked = Properties.Settings.Default.Signature_Module;
            chkModulePreview.Checked = Properties.Settings.Default.Preview_Module;

            FingerScannerDispo();

            if (System.IO.Directory.Exists(Properties.Settings.Default.CapturedOutputPath))
                txtOutputPath.Text= Properties.Settings.Default.CapturedOutputPath;
            else
                txtOutputPath.Text = "Captured Data";

            switch (Properties.Settings.Default.OC_Photo)
            {
                case 1:
                    rbByCapturedDate_OCP.Checked = true;
                    break;
                case 2:
                    rbAccumulated_OCP.Checked = true;
                    break;
                default:
                    rbByCapturedDate_OCP.Checked = false;
                    rbAccumulated_OCP.Checked = false;
                    break;
            }          

            switch (Properties.Settings.Default.OC_Signature)
            {
                case 1:
                    rbByCapturedDate_OCS.Checked = true;
                    break;
                case 2:
                    rbAccumulated_OCS.Checked = true;
                    break;
                default:
                    rbByCapturedDate_OCS.Checked = false;
                    rbAccumulated_OCS.Checked = false;
                    break;
            }

            foreach (string chr in Properties.Settings.Default.SplashProcessValidation.Split(','))
            {
                if (chr != "")
                {
                    if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.MegamatcherLicense) { chkMegamatcherLicense_tabSP.Checked = true; }
                    if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.Camera) { chkCamera_tabSP.Checked = true; }
                    if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.Biometric) { chkBiometric_tabSP.Checked = true; }
                    if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.TopazSignatureTablet) { chkSignatureTablet_tabSP.Checked = true; }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            IsHaveChanges = true;
        }

        private void SaveSettings()
        {//tab terminal
            Properties.Settings.Default.Operator = txtOperator_tabTerminal.Text;
            Properties.Settings.Default.StationReference = txtStationReference_tabTerminal.Text;
            Properties.Settings.Default.AdminPass = txtAdminPass_tabTerminal.Text;
            Properties.Settings.Default.IsCompressFinalFolder = chkCompressFinalFolder_tabTerminal.Checked;
            Properties.Settings.Default.IsDeleteFinalFolder = chkDeleteFinalFolder_tabTerminal.Checked;

            //tab photo
            if (comboBoxCameras.Text != "")
            {
                Properties.Settings.Default.Camera = comboBoxCameras.SelectedItem.ToString();
            }
            
            Properties.Settings.Default.BGUniformityMin = Convert.ToInt16(txtBGUniformityMin_tabPhoto.Text);
            Properties.Settings.Default.BGUniformityMax = Convert.ToInt16(txtBGUniformityMax_tabPhoto.Text);
            Properties.Settings.Default.SharpnessMin = Convert.ToInt16(txtSharpnessMin_tabPhoto.Text);
            Properties.Settings.Default.SharpnessMax = Convert.ToInt16(txtSharpnessMax_tabPhoto.Text);
            Properties.Settings.Default.GrayscaleDensityMin = Convert.ToInt16(txtGrayscaleDensityMin_tabPhoto.Text);
            Properties.Settings.Default.GrayscaleDensityMax = Convert.ToInt16(txtGrayscaleDensityMax_tabPhoto.Text);
            Properties.Settings.Default.PhotoGlobalScore = Convert.ToDouble(txtPhotoGlobalScore_tabPhoto.Text);
            Properties.Settings.Default.DefaultBrightness=Convert.ToInt32(txtDefaultBrightness_tabPhoto.Text);
            Properties.Settings.Default.DefaultSharpness=Convert.ToInt32(txtDefaultSharpness_tabPhoto.Text);
            Properties.Settings.Default.DefaultZoom = Convert.ToInt32(txtDefaultZoom_tabPhoto.Text);

            Properties.Settings.Default.FaceDistance_Min = Convert.ToInt32(txtFaceDistance_Min.Text);
            Properties.Settings.Default.FaceDistance_Max = Convert.ToInt32(txtFaceDistance_Max.Text);

            //tab sagem
            if (cboSagemDevice_tabSagem.Text != "")
            {
                Properties.Settings.Default.SagemDeviceSerial = cboSagemDevice_tabSagem.Text;
            }
            
            Properties.Settings.Default.FP_Quality_Threshold = Convert.ToInt32(txtQualityThreshold_tabSagem.Text);
            Properties.Settings.Default.SagemCaptureTime=Convert.ToInt32(txtTimeout_tabSagem.Text);
            Properties.Settings.Default.Bitmap_HResolution=Convert.ToInt32(txtBitmapHResolution_tabSagem.Text);
            Properties.Settings.Default.Bitmap_VResolution = Convert.ToInt32(txtBitmapVResolution_tabSagem.Text);
            Properties.Settings.Default.SagemOutputJPG=chkJPG_tabSagem.Checked;
            Properties.Settings.Default.SagemOutputANSI378=chkANSI_tabSagem.Checked;
            Properties.Settings.Default.SagemOutputWSQ=chkWSQ_tabSagem.Checked;

            Properties.Settings.Default.SecugenDevice = cboSecugenDevice_tabSecugen.Text;
            Properties.Settings.Default.QualityThreshold_Secugen = Convert.ToInt16(txtQualityThreshold_tabSecugen.Text);
            Properties.Settings.Default.ImageWidth_Secugen = Convert.ToInt32(txtImageWidth_tabSecugen.Text);
            Properties.Settings.Default.ImageHeight_Secugen = Convert.ToInt32(txtImageHeight_tabSecugen.Text);
            Properties.Settings.Default.Timeout_Secugen = Convert.ToInt16(txtTimeout_tabSecugen.Text);
            Properties.Settings.Default.SecugenOutputJPG = chkJPG_tabSecugen.Checked;
            Properties.Settings.Default.SecugenOutputANSI378 = chkANSI_tabSecugen.Checked;
            Properties.Settings.Default.SecugenOutputWSQ = chkWSQ_tabSecugen.Checked;

            Properties.Settings.Default.SignatureOutputTIFF = chkTIFF_tabSignature.Checked;
            Properties.Settings.Default.SignatureOutputJPG = chkJPG_tabSignature.Checked;
            Properties.Settings.Default.SignatureOutputBMP = chkBMP_tabSignature.Checked;

            if (rbSagem.Checked)
                Properties.Settings.Default.FingerScanner = "Sagem";
            else
                Properties.Settings.Default.FingerScanner = "Secugen";

            if (rbTopaz.Checked)
                Properties.Settings.Default.SignatureTablet = "Topaz Siglite";
            else
                Properties.Settings.Default.SignatureTablet = "Evolis SigX";

            //modules
            Properties.Settings.Default.DataCapture_Module= chkModuleDataCapture.Checked;
            Properties.Settings.Default.Photo_Module= chkModulePhoto.Checked;
            Properties.Settings.Default.Biometric_Module= chkModuleBiometric.Checked;
            Properties.Settings.Default.Signature_Module= chkModuleSignature.Checked;
            Properties.Settings.Default.Preview_Module= chkModulePreview.Checked;

            if(System.IO.Directory.Exists(txtOutputPath.Text))
                Properties.Settings.Default.CapturedOutputPath = txtOutputPath.Text;
            else
                Properties.Settings.Default.CapturedOutputPath = "Captured Data";

            if(!rbByCapturedDate_OCP.Checked && !rbAccumulated_OCP.Checked)
                Properties.Settings.Default.OC_Photo = 0;
            else if(rbByCapturedDate_OCP.Checked && !rbAccumulated_OCP.Checked)
                Properties.Settings.Default.OC_Photo = 1;
            else if (!rbByCapturedDate_OCP.Checked && rbAccumulated_OCP.Checked)
                Properties.Settings.Default.OC_Photo = 2;

            if (!rbByCapturedDate_OCS.Checked && !rbAccumulated_OCS.Checked)
                Properties.Settings.Default.OC_Signature = 0;
            else if (rbByCapturedDate_OCS.Checked && !rbAccumulated_OCS.Checked)
                Properties.Settings.Default.OC_Signature = 1;
            else if (!rbByCapturedDate_OCS.Checked && rbAccumulated_OCS.Checked)
                Properties.Settings.Default.OC_Signature = 2;

            System.Text.StringBuilder sbSplashProcessValidation = new System.Text.StringBuilder();
            if (chkMegamatcherLicense_tabSP.Checked) sbSplashProcessValidation.Append((short)Class.Utilities.SplashProcessValidation.MegamatcherLicense + ",");
            if (chkCamera_tabSP.Checked) sbSplashProcessValidation.Append((short)Class.Utilities.SplashProcessValidation.Camera + ",");
            if (chkBiometric_tabSP.Checked) sbSplashProcessValidation.Append((short)Class.Utilities.SplashProcessValidation.Biometric + ",");
            if (chkSignatureTablet_tabSP.Checked) sbSplashProcessValidation.Append((short)Class.Utilities.SplashProcessValidation.TopazSignatureTablet + ",");            

            Properties.Settings.Default.SplashProcessValidation = sbSplashProcessValidation.ToString().Substring(0, sbSplashProcessValidation.Length-1);

            Properties.Settings.Default.Save();

            Class.Utilities.ShowInfoMessage("Settings is saved." + Environment.NewLine + Environment.NewLine + "Please restart application to reflect changes.");
        }

        private void chkCompressFinalFolder_tabTerminal_CheckedChanged(object sender, EventArgs e)
        {
            chkDeleteFinalFolder_tabTerminal.Checked = chkCompressFinalFolder_tabTerminal.Checked;
        }
       

        private void FingerScannerDispo()
        {
            if (rbSagem.Checked)
            {
                tabSecugen.Parent = null; // hide
                tabSagem.Parent = this.tabControl1; //show   
            }
            else
            {
                tabSagem.Parent = null; // hide
                tabSecugen.Parent = this.tabControl1; //show 
            }            
        }       

        private void rbSagem_CheckedChanged(object sender, EventArgs e)
        {
            FingerScannerDispo();
        }

        private void rbSecugen_CheckedChanged(object sender, EventArgs e)
        {
            FingerScannerDispo();
        }

        private void chkModulePhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModulePhoto.Checked) tabPhoto.Parent = this.tabControl1; else tabPhoto.Parent = null;
            SplashProcessValidationDispo();
        }

        private void chkModuleBiometric_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModuleBiometric.Checked)
            {
                tabSagem.Parent = this.tabControl1;
                tabSecugen.Parent = this.tabControl1;                
            }
            else
            {
                tabSagem.Parent = null;
                tabSecugen.Parent = null;
            }
            gbFingerscanner.Visible = chkModuleBiometric.Checked;
            SplashProcessValidationDispo();
        }

        private void chkModuleSignature_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModuleSignature.Checked) tabSignature.Parent = this.tabControl1; else tabSignature.Parent = null;
            gbSignatureTablet.Visible = chkModuleSignature.Checked;
            SplashProcessValidationDispo();
        }

        private void SplashProcessValidationDispo()
        {
            chkMegamatcherLicense_tabSP.Checked = chkModulePhoto.Checked;
            chkCamera_tabSP.Checked = chkModulePhoto.Checked;
            chkBiometric_tabSP.Checked = chkModuleBiometric.Checked;
            chkSignatureTablet_tabSP.Checked = chkModuleSignature.Checked;
        }

        private void btnBrowseOutputPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = fbd.SelectedPath;
            }
            fbd.Dispose();
            fbd = null;
        }
    }
}
