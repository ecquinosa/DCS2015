
using System;
using System.Drawing;
using System.Windows.Forms;
using Touchless.Vision.Camera;
using System.Runtime.InteropServices;

namespace DCS2015.Forms.UserForms
{
    public partial class ucPhotoCapture : UserControl
    {       

        Class.Webcam wc;
        Class.CanonCamera cc;
        //private Class.Webcam wc = new Class.Webcam();

        private TextBox txtFooterMsg;

        public ucPhotoCapture()
        {
            InitializeComponent();
        }

        public ucPhotoCapture(ref TextBox txtFooterMsg)
        {
            InitializeComponent();
            this.txtFooterMsg = txtFooterMsg;
        }            

        private void ucPhotoCapture_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (!DesignMode) PopulateListView();            

            if (Class.Utilities.IsCameraCanon())
            {
                hScrollBarBrightness.Visible = false;
                lblBrightness.Visible = false;
                hScrollBarSharpness.Visible = false;
                lblSharpness.Visible = false;
                hScrollBarZoom.Visible = false;
                lblZoom.Visible = false;
            }

            BindData();

            switch (DCS_DataCapture.DataCapture.ClientName)
            {
                case "YGC":
                case "AFP":
                case "AFPSLAI":
                case "San Pedro Poveda College":
                case "CityOfPasig":
                case "CityGovOfQC":
                    if (Class.Utilities.IsCameraCanon())
                        lvPhotoProperty.Visible = false;
                    else
                    {
                        if (DCS_DataCapture.DataCapture.ClientName == "CityOfPasig")
                            chkOverrideChecking.Checked = true;
                        else
                        {
                        chkOverrideChecking.Checked = true;
                        chkOverrideChecking.Visible = false;
                        }
                    }

                    if (DCS_DataCapture.DataCapture.ClientName == "AFP") { btnPreview.Visible = false; }
                    if (DCS_DataCapture.DataCapture.ClientName == "CityOfPasig") { btnPreview.Visible = false; }
                    if (DCS_DataCapture.DataCapture.ClientName == "CityGovOfQC") { btnPreview.Visible = false; }
                    break;                
            }
        }       

        private void BindData()
        {
            if (System.IO.File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
            {
                try
                {
                    pbPhoto.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile)));
                }
                catch
                {
                    DisplayFooterMsg("Failed to bind photo");
                }                
            }

            chkOverrideChecking.Checked = DCS_MemberInfo.Data.PhotoOverride;
        }

        private void PopulateListView()
        {
            lvPhotoProperty.Items.Clear();
            Array PhotoProperty = System.Enum.GetNames(typeof(Class.PhotoAnalysis.PhotoProperty));            

            ListViewItem lvi;
            ListViewItem.ListViewSubItem lvsi;

           for (short i = 0; i <= PhotoProperty.Length; i++)
            {
                lvi = new ListViewItem();
                lvsi = new ListViewItem.ListViewSubItem();

                lvi.UseItemStyleForSubItems = false;

                if (i == 0)
                {
                    lvi.Text = "Camera";
                    lvsi.Text = Properties.Settings.Default.Camera;
                }
                else
                {
                    lvi.Text = Class.PhotoAnalysis.PhotoField(i);
                    lvsi.Text = "";
                }                

                if (lvi.Text == "Score")
                {
                    lvi.Font = new Font(lvi.Font.Name, 10, FontStyle.Bold);
                    lvsi.Font = lvi.Font;
                }                
                                       
                lvPhotoProperty.Items.Add(lvi).SubItems.Add(lvsi);                
            }
        }
       
        private void BindElementData(Class.PhotoAnalysis.PhotoProperty pp, string data)
        {
            lvPhotoProperty.Items[(short)pp].SubItems[1].Text = data;
            switch (pp)
            {
                case Class.PhotoAnalysis.PhotoProperty.FaceCentering:
                case Class.PhotoAnalysis.PhotoProperty.FaceDistance:
                case Class.PhotoAnalysis.PhotoProperty.BackgroundUniformity:
                case Class.PhotoAnalysis.PhotoProperty.FaceSharpness:
                case
                Class.PhotoAnalysis.PhotoProperty.FacePose:
                    if (data != "Passed") lvPhotoProperty.Items[(short)pp].SubItems[1].ForeColor = Color.Red;                    
                    else lvPhotoProperty.Items[(short)pp].SubItems[1].ForeColor = Color.Black;                    
                    break;
                default:
                    break;
            }           
        }

       private delegate void dlgtProcess();
       private System.Threading.Thread _thread;

        public void StartThread()
        {
            System.Threading.Thread objNewThread = new System.Threading.Thread(ProgramThread);
            objNewThread.Start();
            _thread = objNewThread;
        }

        private void ProgramThread()
        {
            try
            {
                //while (wc.IsCapturing)
                while (true)
                {
                   dlgtProcess _delegate = new dlgtProcess(UpdateScore);
                    _delegate.Invoke();                    
                    _delegate = null;
                    System.Threading.Thread.Sleep(500);                                            
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddScrollBarsHandler()
        {
            hScrollBarBrightness.Enabled = wc.IsBrightnessSupported;
            hScrollBarSharpness.Enabled = wc.IsSharpnessSupported;
            hScrollBarZoom.Enabled = wc.IsZoomSupported;

            if (wc.IsBrightnessSupported)
            {
                hScrollBarBrightness.Minimum = wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Brightness).Minimum;
                hScrollBarBrightness.Maximum = wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Brightness).Maximum;                                
            }

            if (wc.IsSharpnessSupported)
            {
                hScrollBarSharpness.Minimum = wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Sharpness).Minimum;
                hScrollBarSharpness.Maximum = wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Sharpness).Maximum;                
            }

            if (wc.IsZoomSupported)
            {
                hScrollBarZoom.Minimum = wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Zoom_mm).Minimum;
                hScrollBarZoom.Maximum = wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Zoom_mm).Maximum;                
            }

            this.hScrollBarBrightness.Scroll += new ScrollEventHandler(wc.hScrollBarBrightness_Scroll);
            this.hScrollBarSharpness.Scroll += new ScrollEventHandler(wc.hScrollBarSharpness_Scroll);
            this.hScrollBarZoom.Scroll += new ScrollEventHandler(wc.hScrollBarZoom_Scroll);            

            //if (!Class.Utilities.IsCameraCanon())
            //{
            //    hScrollBarBrightness.Value = Properties.Settings.Default.DefaultBrightness;
            //    hScrollBarSharpness.Value = Properties.Settings.Default.DefaultSharpness;
            //    hScrollBarZoom.Value = Properties.Settings.Default.DefaultZoom;
            //}  

            if (!Class.Utilities.IsCameraCanon())
            {
                hScrollBarBrightness.Value = wc.CurrentCamera.GetCameraProperty_value(CameraProperty.Brightness).Value;
                hScrollBarSharpness.Value = wc.CurrentCamera.GetCameraProperty_value(CameraProperty.Sharpness).Value;
                hScrollBarZoom.Value = wc.CurrentCamera.GetCameraProperty_value(CameraProperty.Zoom_mm).Value;
            }
        }

        private void RemoveScrollBarsHandler()
        {
            try
            {
                this.hScrollBarBrightness.Scroll -= new ScrollEventHandler(wc.hScrollBarBrightness_Scroll);
                this.hScrollBarSharpness.Scroll -= new ScrollEventHandler(wc.hScrollBarSharpness_Scroll);
                this.hScrollBarZoom.Scroll -= new ScrollEventHandler(wc.hScrollBarZoom_Scroll);

                this.hScrollBarBrightness.Enabled = false;
                this.hScrollBarSharpness.Enabled = false;
                this.hScrollBarZoom.Enabled = false;
            }
            catch { }
        }      
             

       private void UpdateScore()
        {
            try
            {
                Class.PhotoAnalysis photoAnalysis = new Class.PhotoAnalysis();

                if (Class.Utilities.IsCameraCanon())
                {
                    Bitmap tempBmp = (Bitmap)Image.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoRawFile)));
                    //Image.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoRawFile)));
                    photoAnalysis.IsCameraCanonEOS = true;
                    photoAnalysis.UpdateScore((Bitmap)tempBmp.Clone());
                    tempBmp.Dispose();
                    tempBmp = null;
                }
                else
                {
                    if(wc!=null) photoAnalysis.UpdateScore((Bitmap)wc._latestFrame.Clone());
                }

                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceDetected, photoAnalysis.FaceDetected);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceCentering, photoAnalysis.FaceCentering);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceDistance, photoAnalysis.FaceDistance);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.BackgroundUniformity, photoAnalysis.BackgroundUniformity);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceSharpness, photoAnalysis.FaceSharpness);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FacePose, photoAnalysis.FacePose);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceConfidence, photoAnalysis.FaceConfidenceDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceRectangleSize, photoAnalysis.FaceErectDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.EyeConfidence, photoAnalysis.EyeConfidenceDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.BGUniformity, photoAnalysis.BGUniformityDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.Sharpness, photoAnalysis.SharpnessDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.GrayDensity, photoAnalysis.GrayDensityDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.HeadRoll, photoAnalysis.HeadRollDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.HeadPitch, photoAnalysis.HeadPitchDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.HeadYaw, photoAnalysis.HeadYawDetail);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.FaceWidthAndHeight, photoAnalysis.FaceWidthAndHeight);
                BindElementData(Class.PhotoAnalysis.PhotoProperty.PhotoScore, (Math.Round(Convert.ToDouble(photoAnalysis.GlobalScore) * 100, 2)).ToString());

                //DCS_MemberInfo.Data.PhotoScore = Convert.ToDouble(photoAnalysis.GlobalScore);

                //if checkbox override is not checked, implement properties checking
                if (!chkOverrideChecking.Checked)
                {
                    //implement auto checker for webcam only
                    if (IsPhotoPropertiesPassed(true) && !Class.Utilities.IsCameraCanon())
                    {
                        btnCapture.Enabled = true;
                        if (!chkManualCapture.Checked) CapturePhoto();
                    }
                    else btnCapture.Enabled = false;
                }
                else btnCapture.Enabled = true;

                Application.DoEvents();
            }
            catch (Exception ex)
            {
                //DisplayFooterMsg("Camera exception [" + ex.Message.ToString() + "]");
            }
        }

        private bool IsPhotoPropertiesPassed(bool IsIncludePhotoScore)
        {
            if (lvPhotoProperty.Items[(short)Class.PhotoAnalysis.PhotoProperty.FaceCentering].SubItems[1].Text == "Passed" & lvPhotoProperty.Items[(short)Class.PhotoAnalysis.PhotoProperty.FaceDistance].SubItems[1].Text == "Passed" & lvPhotoProperty.Items[(short)Class.PhotoAnalysis.PhotoProperty.BackgroundUniformity].SubItems[1].Text == "Passed" & lvPhotoProperty.Items[(short)Class.PhotoAnalysis.PhotoProperty.FaceSharpness].SubItems[1].Text == "Passed" & lvPhotoProperty.Items[(short)Class.PhotoAnalysis.PhotoProperty.FacePose].SubItems[1].Text == "Passed")
                if (IsIncludePhotoScore)
                {
                    if (Properties.Settings.Default.PhotoGlobalScore > (Convert.ToDouble(lvPhotoProperty.Items[(short)Class.PhotoAnalysis.PhotoProperty.PhotoScore].SubItems[1].Text) / 100))
                    {
                        DisplayFooterMsg("Score quality of photo is below minimum");
                        return false;
                    }
                    else
                    {
                        DisplayFooterMsg("");
                        return true;
                    }
                }
                else return true;
            else
                return false;
        }

       private void DisplayFooterMsg(string Msg)
       {
           txtFooterMsg.Text = Msg;
           txtFooterMsg.ForeColor = Color.OrangeRed;
       }      

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(DCS_MemberInfo.Data.PhotoICAOFile)) if (Class.Utilities.ShowQuestionMessage("Recapture photo?") == DialogResult.No) return;

                short intCntr = 1;
                foreach (string strFile in System.IO.Directory.GetFiles(Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY))
                    if (System.IO.Path.GetFileName(strFile).Contains("ICAO_Photo")) intCntr += 1;

                if (System.IO.File.Exists(DCS_MemberInfo.Data.PhotoICAOFile))
                    System.IO.File.Copy(DCS_MemberInfo.Data.PhotoICAOFile, DCS_MemberInfo.Data.PhotoICAOFile.Replace(".jpg", "_" + intCntr.ToString() + ".jpg"));

                ResetPhoto();

                if (Class.Utilities.IsCameraCanon())
                {
                    cc = new Class.CanonCamera(ref pbPhoto);
                    cc.StartCapturing();

                    Class.Utilities.PhotoCapturing_ErrorMessage = "";

                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    btnCapture.Enabled = true;
                    //StartThread();
                }
                else
                {
                    wc = new Class.Webcam(ref pbPhoto);

                    if (wc.IsSuccess)
                    {
                        Class.Utilities.PhotoCapturing_ErrorMessage = "";

                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;

                        // Early return if we've selected the current camera
                        //if (_frameSource != null && _frameSource.Camera == comboBoxCameras.SelectedItem)
                        //    return;

                        //wc.thrashOldCamera();
                        //wc.startCapturing();

                        AddScrollBarsHandler();

                        StartThread();
                    }
                    else
                    {
                        if (wc.ErrorMessage == "Object reference not set to an instance of an object.")
                        {
                            DisplayFooterMsg(string.Format("Check camera status/ connectivity. [{0}].", wc.ErrorMessage));
                        }
                        else
                        {
                            DisplayFooterMsg(string.Format("[{0}].", wc.ErrorMessage));
                        }

                        wc.thrashOldCamera();
                        wc = null;
                        GC.Collect();
                    }
                }
            }
            catch { }                       
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = true;
                btnCapture.Enabled = false;                
                btnDisconnect.Enabled = false;

                PopulateListView();

                if (Class.Utilities.IsCameraCanon())
                {
                    cc.CloseCamera();
                }
                else
                {
                    RemoveScrollBarsHandler();
                    wc.thrashOldCamera();
                }
            }
            catch { }
            finally
            {
                if (cc != null) cc = null;
                if (wc != null) wc = null;
            }           
        }

        private void ResetPhoto()
        {
            DisplayFooterMsg("");
            PopulateListView();
            pbPhoto.Image = null;
            pbPhoto.BackgroundImage = null;
            Class.Utilities.PhotoCapturing_ErrorMessage = "";
            DCS_MemberInfo.Data.ResetPhoto();
        }

       
        private string strFile;

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (Class.Utilities.IsCameraCanon())
            {                
                Cursor = Cursors.WaitCursor;
                btnCapture.Enabled = false;

                if (btnCapture.Text == "Capture")
                {
                    cc.TakePhoto();                    
                    btnCapture.Text = "Process";
                    btnCapture.Enabled = true;                    
                }
                else
                {
                    DisplayFooterMsg("Waiting for photo to be ready...");
                    Application.DoEvents();

                    while (IsFileLocked(cc.PhotoFile))
                    {                        
                        System.Threading.Thread.Sleep(1000);
                    }

                    DisplayFooterMsg("");                    
                    CapturePhoto();
                    btnCapture.Text = "Capture";                    
                }

                Cursor = Cursors.Default;                
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                CapturePhoto();
                Cursor = Cursors.Default;
            }            
        }

        public bool IsFileLocked(string filePath)
        {
            try
            {
                using (System.IO.File.Open(filePath, System.IO.FileMode.Open)) { }
            }
            catch (System.IO.IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);

                return errorCode == 32 || errorCode == 33;
            }

            return false;
        }

        private void CapturePhoto()
        {
            //DCS_MemberInfo.Data.PhotoOverride = chkOverrideChecking.Checked;
            //DCS_MemberInfo.Data.IsICAO = chkICAO.Checked;

            Bitmap current=null;
            DCS_MemberInfo.Data.PhotoRawFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Class.Utilities.PhotoRaw_FileName);

            try
            {
                if (Class.Utilities.IsCameraCanon())
                {                   
                    System.IO.File.Copy(cc.PhotoFile, DCS_MemberInfo.Data.PhotoRawFile,true);                    
                    //Bitmap tempBmp = (Bitmap)Image.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoRawFile)));
                    //current = (Bitmap)tempBmp.Clone();
                    //tempBmp.Dispose();
                    //tempBmp = null;
                    //UpdateScore();                                                      
                }
                else
                {
                    if (wc._frameSource == null)
                        return;

                    wc.IsCapturing = false;
                    current = (Bitmap)wc._latestFrame.Clone();
                    current.Save(DCS_MemberInfo.Data.PhotoRawFile, System.Drawing.Imaging.ImageFormat.Jpeg);                    
                }

                if (current != null) current.Dispose();

                Class.PhotoAnalysis photoAnalysis = new Class.PhotoAnalysis();                

                if (chkICAO.Checked)
                {
                    string _ntfiAttributes = "";
                    photoAnalysis.Convert_TO_ICAO(ref _ntfiAttributes);
                }
                else
                {                    
                    DCS_MemberInfo.Data.PhotoICAOFile = string.Format(@"{0}\{1}", DCS2015.Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, DCS2015.Class.Utilities.PhotoFinal_FileName);
                    //DCS_MemberInfo.Data.PhotoICAOFile = string.Format(@"{0}\{1}", DCS2015.Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Class.Utilities.LastSessionReference() + "_ICAO_Photo.jpg");

                    if (System.IO.File.Exists(DCS_MemberInfo.Data.PhotoRawFile))
                    {
                        System.IO.File.Copy(DCS_MemberInfo.Data.PhotoRawFile, DCS_MemberInfo.Data.PhotoICAOFile);
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                        Class.Utilities.ShowErrorMessage("Unable to find raw photo");
                }              

                if (Class.Utilities.IsCameraCanon())
                {
                    //cc.StopCapturing();
                    cc.CloseCamera();
                }
                else
                {
                    RemoveScrollBarsHandler();
                    wc.thrashOldCamera();
                    wc = null;
                }

                if (DCS_MemberInfo.Data.PhotoICAOFile != "")
                {
                    pbPhoto.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile)));
                    Class.Utilities.ShowInfoMessage("Done...");
                    Class.Utilities.PhotoCapturing_ErrorMessage = "";
                    DisplayFooterMsg("");
                }
                else
                    Class.Utilities.ShowErrorMessage("Unable to detect captured photo");                

                btnConnect.Enabled = true;
                btnCapture.Enabled = false;
                btnDisconnect.Enabled = false;
            }
            catch (Exception ex)
            {
                Class.Utilities.SaveToErrorLog(Class.Utilities.TimeStamp() + "CapturePhoto(): " + ex.Message);
                Class.Utilities.ShowErrorMessage("An error has occurred");
            }
        }

        private void hScrollBarBrightness_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                lblBrightness.Text = string.Format("Brightness [{0} - {1}]: {2}", wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Brightness).Minimum, wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Brightness).Maximum, hScrollBarBrightness.Value.ToString());           
            }
            catch { }            
        }

        private void hScrollBarSharpness_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                lblSharpness.Text = string.Format("Sharpness [{0} - {1}]: {2}", wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Sharpness).Minimum, wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Sharpness).Maximum, hScrollBarSharpness.Value.ToString());           
            }
            catch { }            
        }

        private void hScrollBarZoom_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                lblZoom.Text = string.Format("Zoom [{0} - {1}]: {2}", wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Zoom_mm).Minimum, wc.CurrentCamera.GetCameraPropertyRange(CameraProperty.Zoom_mm).Maximum, hScrollBarZoom.Value.ToString());           
            }
            catch { }            
        }

        private void ucPhotoCapture_Leave(object sender, EventArgs e)
        {
            if (wc != null)
            {
                wc.thrashOldCamera();
                wc = null;
            }
            
        }

        private void ucPhotoCaptureCapture_Resize(object sender, EventArgs e)
        {
            pnlMain.Left = (this.ClientSize.Width - pnlMain.Width) / 2;
            pnlMain.Top = (this.ClientSize.Height - pnlMain.Height) / 2;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetPhoto();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FaceDistance_Min = Convert.ToInt32(textBox1.Text);
            Properties.Settings.Default.FaceDistance_Max = Convert.ToInt32(textBox2.Text);
            Properties.Settings.Default.Save();
            //cc.GetImage();
            //RectangleF r = new RectangleF(0, 0, pbPhoto.Width, pbPhoto.Height);
            //pictureBox1.Image = copyFrame(r);
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            DCS_MemberInfo.Data.PhotoRawFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Class.Utilities.PhotoRaw_FileName);
            UpdateScore();
            Class.Utilities.ShowInfoMessage("Done...");            
        }

        private void chkOverrideChecking_CheckedChanged(object sender, EventArgs e)
        {
            DCS_MemberInfo.Data.PhotoOverride = chkOverrideChecking.Checked;
            txtFooterMsg.Text = "";
        }

        private void chkICAO_CheckedChanged(object sender, EventArgs e)
        {
            DCS_MemberInfo.Data.IsICAO = chkICAO.Checked;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PhotoSelect _frm = new PhotoSelect();
            _frm.ShowDialog();
            if (_frm.FinalSelectedPhoto == "") return;

            if (_frm.FinalSelectedPhoto != DCS_MemberInfo.Data.PhotoICAOFile)
            {
                string tempOldFile = "tempOldFile.jpg";
                string tempNewFile = "tempNewFile.jpg";

                //create temporary files
                System.IO.File.Copy(DCS_MemberInfo.Data.PhotoICAOFile, tempOldFile);
                System.IO.File.Copy(_frm.FinalSelectedPhoto, tempNewFile);

                //delete files to accept renaming of files
                System.IO.File.Delete(DCS_MemberInfo.Data.PhotoICAOFile);
                System.IO.File.Delete(_frm.FinalSelectedPhoto);

                System.IO.File.Move(tempOldFile, _frm.FinalSelectedPhoto);
                System.IO.File.Move(tempNewFile, DCS_MemberInfo.Data.PhotoICAOFile);

                //delete temporary files
                System.IO.File.Delete(tempOldFile);
                System.IO.File.Delete(tempNewFile);

                //DCS_MemberInfo.Data.PhotoICAOFile = _frm.FinalSelectedPhoto;
                pbPhoto.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.PhotoICAOFile)));
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
