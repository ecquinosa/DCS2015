using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSDKLib;
using System.IO;
using System.Drawing;

namespace DCS2015.Class
{
    class CanonCamera
    {

        #region Variables

        SDKHandler CameraHandler;
        List<int> AvList;
        List<int> TvList;
        List<int> ISOList;
        public List<Camera> CamList;
        Bitmap Evf_Bmp;
        int LVBw, LVBh, w, h;
        float LVBratio, LVration;
        //Camera SelectedCamera;

        int ErrCount;
        object ErrLock = new object();

        #endregion

        private string _OutputDirectory = "";
        private System.Windows.Forms.PictureBox LiveViewPicBox;
        private string _ErrorMessage;
        private bool _IsSuccess;

        public string PhotoFile
        {
            get
            {
                return CameraHandler.PhotoFile;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
        }

        public bool IsSuccess
        {
            get
            {
                return _IsSuccess;
            }
        }

        public CanonCamera()
        {
            CameraHandler = new SDKHandler();            
       }        

        public CanonCamera(ref System.Windows.Forms.PictureBox LiveViewPicBox)
        {
            try
            {
                this.LiveViewPicBox = LiveViewPicBox;                

                CameraHandler = new SDKHandler();
                CameraHandler.CameraAdded += new SDKHandler.CameraAddedHandler(SDK_CameraAdded);
                CameraHandler.LiveViewUpdated += new SDKHandler.StreamUpdate(SDK_LiveViewUpdated);
                //CameraHandler.ProgressChanged += new SDKHandler.ProgressHandler(SDK_ProgressChanged);
                CameraHandler.CameraHasShutdown += SDK_CameraHasShutdown;
                _OutputDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "RemotePhoto");
                LVBw = LiveViewPicBox.Width;
                LVBh = LiveViewPicBox.Height;
                RefreshCamera();
                _IsSuccess = true;
            }
            catch (DllNotFoundException) 
            { 
                //ReportError("Canon DLLs not found!", true); 
                _ErrorMessage = "Canon DLLs not found!";
                _IsSuccess = false;
            }
            catch (Exception ex) 
            { 
                //ReportError(ex.Message, true);
                _ErrorMessage = ex.Message;
                _IsSuccess = false;
            }
        }

        public void CloseCamera()
        {
            try { if (CameraHandler != null) CameraHandler.Dispose(); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #region SDK Events

        //private void SDK_ProgressChanged(int Progress)
        //{
        //    try
        //    {
        //        if (Progress == 100) Progress = 0;
        //        this.Invoke((Action)delegate { MainProgressBar.Value = Progress; });
        //    }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}             

        private delegate void Action();

        private void SDK_LiveViewUpdated(Stream img)
        {
            try
            {
                
                Evf_Bmp = new Bitmap(img);
                using (Graphics g = LiveViewPicBox.CreateGraphics())
                {
                    LVBratio = LVBw / (float)LVBh;
                    LVration = Evf_Bmp.Width / (float)Evf_Bmp.Height;
                    if (LVBratio < LVration)
                    {
                        w = LVBw;
                        h = (int)(LVBw / LVration);
                    }
                    else
                    {
                        w = (int)(LVBh * LVration);
                        h = LVBh;
                    }
                    g.DrawImage(Evf_Bmp, 0, 0, w, h);
                }


                //DCS_MemberInfo.Data.PhotoRawFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Class.Utilities.PhotoRaw_FileName);
                //Evf_Bmp.Save(DCS_MemberInfo.Data.PhotoRawFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                //Evf_Bmp.Save("CC1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);                               
              
                Evf_Bmp.Dispose();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void SDK_CameraAdded()
        {
            try { RefreshCamera(); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void SDK_CameraHasShutdown(object sender, EventArgs e)
        {
            try { CloseSession(); }
            catch (Exception ex) { ReportError(ex.Message, false); }

        }

        #endregion

        #region Session

        private void SessionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CameraHandler.CameraSessionOpen) CloseSession();
                else OpenSession();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try { RefreshCamera(); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Settings

        //private void TakePhotoButton_Click(object sender, EventArgs e)
        public void TakePhoto()
        {
            try
            {
                //if ((string)TvCoBox.SelectedItem == "Bulb") CameraHandler.TakePhoto((uint)BulbUpDo.Value);
                //else CameraHandler.TakePhoto();

                CameraHandler.TakePhoto();
            }
            catch (Exception ex) 
            { 
                //ReportError(ex.Message, false); 
                _ErrorMessage = ex.Message;
            }
        }

        //private void RecordVideoButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!CameraHandler.IsFilming)
        //        {
        //            if (STComputerButton.Checked || STBothButton.Checked)
        //            {
        //                Directory.CreateDirectory(SavePathTextBox.Text);
        //                CameraHandler.StartFilming(SavePathTextBox.Text);
        //            }
        //            else CameraHandler.StartFilming();
        //            RecordVideoButton.Text = "Stop Video";
        //        }
        //        else
        //        {
        //            CameraHandler.StopFilming();
        //            RecordVideoButton.Text = "Record Video";
        //        }
        //    }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //private void BrowseButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Directory.Exists(SavePathTextBox.Text)) SaveFolderBrowser.SelectedPath = SavePathTextBox.Text;
        //        if (SaveFolderBrowser.ShowDialog() == DialogResult.OK)
        //        {
        //            SavePathTextBox.Text = SaveFolderBrowser.SelectedPath;
        //            CameraHandler.ImageSaveDirectory = SavePathTextBox.Text;
        //        }
        //    }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //private void AvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try { CameraHandler.SetSetting(EDSDK.PropID_Av, CameraValues.AV((string)AvCoBox.SelectedItem)); }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //private void TvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CameraHandler.SetSetting(EDSDK.PropID_Tv, CameraValues.TV((string)TvCoBox.SelectedItem));
        //        if ((string)TvCoBox.SelectedItem == "Bulb") BulbUpDo.Enabled = true;
        //        else BulbUpDo.Enabled = false;
        //    }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //private void ISOCoBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try { CameraHandler.SetSetting(EDSDK.PropID_ISOSpeed, CameraValues.ISO((string)ISOCoBox.SelectedItem)); }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //private void WBCoBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        switch (WBCoBox.SelectedIndex)
        //        {
        //            case 0: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Auto); break;
        //            case 1: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Daylight); break;
        //            case 2: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Cloudy); break;
        //            case 3: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Tangsten); break;
        //            case 4: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Fluorescent); break;
        //            case 5: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Strobe); break;
        //            case 6: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_WhitePaper); break;
        //            case 7: CameraHandler.SetSetting(EDSDK.PropID_WhiteBalance, EDSDK.WhiteBalance_Shade); break;
        //        }
        //    }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //private void SaveToButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (STCameraButton.Checked)
        //        {
        //            CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Camera);
        //            BrowseButton.Enabled = false;
        //            SavePathTextBox.Enabled = false;
        //        }
        //        else
        //        {
        //            if (STComputerButton.Checked) CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Host);
        //            else if (STBothButton.Checked) CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Both);
        //            CameraHandler.SetCapacity();
        //            BrowseButton.Enabled = true;
        //            SavePathTextBox.Enabled = true;
        //            Directory.CreateDirectory(SavePathTextBox.Text);
        //            CameraHandler.ImageSaveDirectory = SavePathTextBox.Text;
        //        }
        //    }
        //    catch (Exception ex) { ReportError(ex.Message, false); }
        //}

        //public Bitmap BitmapTemp
        //{
        //    //get { return bbb; }
        //}

        public void StartCapturing()
        {
            try
            {
                try
                {
                    if (CameraHandler.CameraSessionOpen) CloseSession();
                    else OpenSession();
                }
                catch (Exception ex) { ReportError(ex.Message, false); }

                if (!CameraHandler.IsLiveViewOn)
                {
                    CameraHandler.StartLiveView();                    
                    //LiveViewButton.Text = "Stop LV"; 
                }
                else
                {
                    CameraHandler.StopLiveView();
                    //LiveViewButton.Text = "Start LV"; 
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        public void StopCapturing()
        {
            try
            {
                try
                {
                    if (CameraHandler.CameraSessionOpen) CloseSession();                    
                }
                catch (Exception ex) { ReportError(ex.Message, false); }

                if (CameraHandler.IsLiveViewOn)
                {
                    CameraHandler.StopLiveView();
                }                
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Live view

        private void LiveViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CameraHandler.IsLiveViewOn) 
                { 
                    CameraHandler.StartLiveView(); 
                    //LiveViewButton.Text = "Stop LV"; 
                }
                else 
                { 
                    CameraHandler.StopLiveView(); 
                    //LiveViewButton.Text = "Start LV"; 
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void LiveViewPicBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (CameraHandler.IsLiveViewOn && CameraHandler.IsCoordSystemSet)
                {
                    ushort x = (ushort)((e.X / (double)LiveViewPicBox.Width) * CameraHandler.Evf_CoordinateSystem.width);
                    ushort y = (ushort)((e.Y / (double)LiveViewPicBox.Height) * CameraHandler.Evf_CoordinateSystem.height);
                    CameraHandler.SetManualWBEvf(x, y);
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void LiveViewPicBox_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                LVBw = LiveViewPicBox.Width;
                LVBh = LiveViewPicBox.Height;
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear3Button_Click(object sender, EventArgs e)
        {
            try { CameraHandler.SetFocus(EDSDK.EvfDriveLens_Near3); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear2Button_Click(object sender, EventArgs e)
        {
            try { CameraHandler.SetFocus(EDSDK.EvfDriveLens_Near2); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear1Button_Click(object sender, EventArgs e)
        {
            try { CameraHandler.SetFocus(EDSDK.EvfDriveLens_Near1); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar1Button_Click(object sender, EventArgs e)
        {
            try { CameraHandler.SetFocus(EDSDK.EvfDriveLens_Far1); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar2Button_Click(object sender, EventArgs e)
        {
            try { CameraHandler.SetFocus(EDSDK.EvfDriveLens_Far2); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar3Button_Click(object sender, EventArgs e)
        {
            try { CameraHandler.SetFocus(EDSDK.EvfDriveLens_Far3); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Subroutines

        private void CloseSession()
        {
            CameraHandler.CloseSession();
            //AvCoBox.Items.Clear();
            //TvCoBox.Items.Clear();
            //ISOCoBox.Items.Clear();
            //SettingsGroupBox.Enabled = false;
            //LiveViewGroupBox.Enabled = false;
            //SessionButton.Text = "Open Session";
            //SessionLabel.Text = "No open session";
            RefreshCamera();//Closing the session invalidates the current camera pointer
        }

        public void RefreshCamera()
        {
            //CameraListBox.Items.Clear();
            CamList = CameraHandler.GetCameraList();
            //foreach (Camera cam in CamList) CameraListBox.Items.Add(cam.Info.szDeviceDescription);
            //if (CameraHandler.CameraSessionOpen)
            //{
                //CameraListBox.SelectedIndex = CamList.FindIndex(t => t.Ref == CameraHandler.MainCamera.Ref);
            //}
            //else if (CamList.Count > 0) CameraListBox.SelectedIndex = 0;
        }

        public Bitmap GetImage()
        {
            return CameraHandler.GetFileThumb("CC.jpg");            
        }

        private bool OpenSession()
        {
            //if (CameraListBox.SelectedIndex >= 0)
            if (_IsSuccess)
            {
                //CameraHandler.OpenSession(CamList[CameraListBox.SelectedIndex]);
                CameraHandler.OpenSession(CamList[0]);
                //SessionButton.Text = "Close Session";
                string cameraname = CameraHandler.MainCamera.Info.szDeviceDescription;
                //SessionLabel.Text = cameraname;
                if (CameraHandler.GetSetting(EDSDK.PropID_AEMode) != EDSDK.AEMode_Manual)
                {
                    //MessageBox.Show("Camera is not in manual mode. Some features might not work!");
                    _ErrorMessage = "Camera is not in manual mode. Some features might not work!";
                    _IsSuccess = false;
                    return false;
                }

                CameraHandler.SetSetting(EDSDK.PropID_SaveTo, (uint)EDSDK.EdsSaveTo.Host);
                CameraHandler.SetCapacity();
                //CameraHandler.ImageSaveDirectory = "Camera";
                CameraHandler.ImageSaveDirectory = _OutputDirectory;

                return true;

                //AvList = CameraHandler.GetSettingsList((uint)EDSDK.PropID_Av);
                //TvList = CameraHandler.GetSettingsList((uint)EDSDK.PropID_Tv);
                //ISOList = CameraHandler.GetSettingsList((uint)EDSDK.PropID_ISOSpeed);
                //foreach (int Av in AvList) AvCoBox.Items.Add(CameraValues.AV((uint)Av));
                //foreach (int Tv in TvList) TvCoBox.Items.Add(CameraValues.TV((uint)Tv));
                //foreach (int ISO in ISOList) ISOCoBox.Items.Add(CameraValues.ISO((uint)ISO));
                //AvCoBox.SelectedIndex = AvCoBox.Items.IndexOf(CameraValues.AV((uint)CameraHandler.GetSetting((uint)EDSDK.PropID_Av)));
                //TvCoBox.SelectedIndex = TvCoBox.Items.IndexOf(CameraValues.TV((uint)CameraHandler.GetSetting((uint)EDSDK.PropID_Tv)));
                //ISOCoBox.SelectedIndex = ISOCoBox.Items.IndexOf(CameraValues.ISO((uint)CameraHandler.GetSetting((uint)EDSDK.PropID_ISOSpeed)));
                //int wbidx = (int)CameraHandler.GetSetting((uint)EDSDK.PropID_WhiteBalance);
                //switch (wbidx)
                //{
                //    case EDSDK.WhiteBalance_Auto: WBCoBox.SelectedIndex = 0; break;
                //    case EDSDK.WhiteBalance_Daylight: WBCoBox.SelectedIndex = 1; break;
                //    case EDSDK.WhiteBalance_Cloudy: WBCoBox.SelectedIndex = 2; break;
                //    case EDSDK.WhiteBalance_Tangsten: WBCoBox.SelectedIndex = 3; break;
                //    case EDSDK.WhiteBalance_Fluorescent: WBCoBox.SelectedIndex = 4; break;
                //    case EDSDK.WhiteBalance_Strobe: WBCoBox.SelectedIndex = 5; break;
                //    case EDSDK.WhiteBalance_WhitePaper: WBCoBox.SelectedIndex = 6; break;
                //    case EDSDK.WhiteBalance_Shade: WBCoBox.SelectedIndex = 7; break;
                //    default: WBCoBox.SelectedIndex = -1; break;
                //}
                //SettingsGroupBox.Enabled = true;
                //LiveViewGroupBox.Enabled = true;
            }

            return _IsSuccess;
        }

        private void ReportError(string message, bool lockdown)
        {
            //int errc;
            //lock (ErrLock) { errc = ++ErrCount; }

            //if (lockdown) EnableUI(false);

            //if (errc < 4) MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (errc == 4) MessageBox.Show("Many errors happened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //lock (ErrLock) { ErrCount--; }
        }

        //private void EnableUI(bool enable)
        //{
        //    if (InvokeRequired) Invoke((Action)delegate { EnableUI(enable); });
        //    else
        //    {
        //        SettingsGroupBox.Enabled = enable;
        //        InitGroupBox.Enabled = enable;
        //        LiveViewGroupBox.Enabled = enable;
        //    }
        //}

        #endregion


    }
}
