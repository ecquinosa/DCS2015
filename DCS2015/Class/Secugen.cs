using System;
using System.Text;
using System.Drawing;

using SecuGen.FDxSDKPro.Windows;

namespace DCS2015.Class
{
    class Secugen
    {

        private SGFingerPrintManager m_FPM;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Int32 m_Dpi;
        private SGFPMSecurityLevel m_SecurityLevel;

        private Byte[] ansi;
        
        private Byte[] m_StoredTemplate;
        private bool m_DeviceOpened;

        private bool _IsSuccess;
        private string _ErrorMessage;

        private string _fileWSQ;
        private string _fileANSI378;
        private string _fileJPG;

        private SGFPMDeviceList[] m_DevList; // Used for EnumerateDevice

        private Utilities.SagemFingerID _FingerID;

        //private System.Windows.Forms.PictureBox _pb;

        public Secugen()
        {
            _IsSuccess = Init();
        }

        //public System.Windows.Forms.PictureBox PictureBoxOutput
        //{
        //    get { return _pb; }
        //    set { _pb = value; }
        //}

       public string FileANSI378
        {
            get { return _fileANSI378; }
            set { _fileANSI378 = value; }
        }

        public string FileJPG
        {
            get { return _fileJPG; }
            set { _fileJPG = value; }
        }

        public string FileWSQ
        {
            get { return _fileWSQ; }
            set { _fileWSQ = value; }
        }

        public Utilities.SagemFingerID FingerID
        {
            get { return _FingerID; }
            set { _FingerID = value; }
        }

        public bool Success
        {            
            get { return _IsSuccess; }
        }

        public string ErrorMessage
        {         
            get { return _ErrorMessage; }
        }

        public void EnumerateDevice(System.Windows.Forms.ComboBox cbo)
        {
            Int32 iError;
            string enum_device;

            cbo.Items.Clear();

            // Enumerate Device
            iError = m_FPM.EnumerateDevice();

            // Get enumeration info into SGFPMDeviceList
            m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];

            for (int i = 0; i < m_FPM.NumberOfDevice; i++)
            {
                m_DevList[i] = new SGFPMDeviceList();
                m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
                enum_device = m_DevList[i].DevName.ToString() + " : " + m_DevList[i].DevID;
                cbo.Items.Add(enum_device);
            }

            if (cbo.Items.Count > 0)
            {
                // Add Auto Selection
                enum_device = "Auto Selection";
                cbo.Items.Add(enum_device);

                cbo.SelectedIndex = 0;  //First selected one
            }

        }

        private bool Init()
        {
            try
            {
                m_SecurityLevel = SGFPMSecurityLevel.NORMAL;
                m_StoredTemplate = null;
                m_ImageWidth = (int)Properties.Settings.Default.ImageWidth_Secugen;
                m_ImageHeight = (int)Properties.Settings.Default.ImageHeight_Secugen;
                m_Dpi = 508;
                m_FPM = new SGFingerPrintManager();

                Int32 error;
                SGFPMDeviceName device_name = SGFPMDeviceName.DEV_UNKNOWN;
                Int32 device_id = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;

                m_DeviceOpened = false;

                //Get device name
                if (Properties.Settings.Default.SecugenDevice.Contains("FDU02"))
                    device_name = SGFPMDeviceName.DEV_FDU02;
                else if (Properties.Settings.Default.SecugenDevice.Contains("FDU03"))
                    device_name = SGFPMDeviceName.DEV_FDU03;
                else if (Properties.Settings.Default.SecugenDevice.Contains("FDU04"))
                    device_name = SGFPMDeviceName.DEV_FDU04;
                else if (Properties.Settings.Default.SecugenDevice == "Auto Selection")
                    device_name = SGFPMDeviceName.DEV_AUTO;

                if (device_name != SGFPMDeviceName.DEV_UNKNOWN)
                    error = m_FPM.Init(device_name);
                else
                    error = m_FPM.InitEx(m_ImageWidth, m_ImageHeight, m_Dpi);

                if (error == (Int32)SGFPMError.ERROR_NONE)
                {
                    SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
                    m_FPM.GetDeviceInfo(pInfo);
                    m_ImageWidth = pInfo.ImageWidth;
                    m_ImageHeight = pInfo.ImageHeight;

                    Console.Write(pInfo.ImageDPI);
                    Console.Write(pInfo.Brightness);

                    Console.WriteLine("Initialization Success");
                }
                else
                {
                    Console.WriteLine("Init() Error " + error);
                    Utilities.SaveToErrorLog("Init() Error " + error);
                    return false;
                }

                // Set template format to ANSI 378
                error = m_FPM.SetTemplateFormat(SGFPMTemplateFormat.ANSI378);

                // Get Max template size
                Int32 max_template_size = 0;
                error = m_FPM.GetMaxTemplateSize(ref max_template_size);

                ansi = new Byte[max_template_size];

                // OpenDevice if device is selected
                if (device_name != SGFPMDeviceName.DEV_UNKNOWN)
                {
                    error = m_FPM.OpenDevice(device_id);
                    if (error == (Int32)SGFPMError.ERROR_NONE)
                    {
                        m_DeviceOpened = true;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("OpenDevice() Error : " + error);
                        Utilities.SaveToErrorLog("OpenDevice() Error : " + error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog("Init() Error : " + ex.Message);
                return false;
            }            
        }

        //private Utilities.SagemFingerID _FingerID;

        private delegate void Action();

        //public void CaptureFingerprint()
        public bool CaptureFingerprint(Utilities.SagemFingerID _FingerID, string fileJPG, string fileANSI378, string fileWSQ, int QualityThreshold, ref System.Windows.Forms.PictureBox pb)        
        {
            //this._FingerID = _FingerID;

            Byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            Int32 error = (Int32)SGFPMError.ERROR_NONE;
            Int32 img_qlty = QualityThreshold;

            if (m_DeviceOpened)
                error = m_FPM.GetImageEx(fp_image, (int)Properties.Settings.Default.Timeout_Secugen * 1000, pb.Handle.ToInt32(), img_qlty);
            else
                error = GetImageFromFile(fp_image);

            if (error == (Int32)SGFPMError.ERROR_NONE)
            {
                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                //progressBar_R1.Value = img_qlty;

                //DrawImage(fp_image, pb);
                DrawImage(fp_image, pb);

                SGFPMFingerInfo finger_info = new SGFPMFingerInfo();                
                finger_info.FingerNumber = (SGFPMFingerPosition)_FingerID;
                finger_info.ImageQuality = (Int16)img_qlty;
                finger_info.ImpressionType = (Int16)SGFPMImpressionType.IMPTYPE_LP;
                finger_info.ViewNumber = 1;

                // CreateTemplate
                error = m_FPM.CreateTemplate(finger_info, fp_image, ansi);

                if (error == (Int32)SGFPMError.ERROR_NONE)
                {
                    //CreateFingerprintFile(fileJPG, fileWSQ, ref pb);
                    //SaveTemplate(ansi, fileANSI378);

                    CreateFingerprintFile(fileJPG, fileWSQ, ref pb);
                    SaveTemplate(ansi, fileANSI378);

                    Console.WriteLine("Image is captured");
                    return true;
                    //StatusBar.Text = "First image is captured";
            }
                else
                {
                    Console.WriteLine("GetMinutiae() Error : " + error);
                    return false;
                    //StatusBar.Text = "GetMinutiae() Error : " + error;
                }
            }
            else
            {
                Console.WriteLine("GetImage() Error : " + error);
                return false;
                //StatusBar.Text = "GetImage() Error : " + error;
            }
      
        }

        public bool CreateFingerprintFile(string fileJPG, string fileWSQ, ref System.Windows.Forms.PictureBox ImageBox)
        {
            try
            {
                int Height = 500;
                int Width = 500;

                System.Windows.Forms.PictureBox tempPicBox = new System.Windows.Forms.PictureBox();
                Bitmap tBMP = new Bitmap(Width, Height);

                tempPicBox.Width = Width;
                tempPicBox.Height = Height;
                //tempPicBox.SizeMode = PictureBoxSizeMode.CenterImage
                //tempPicBox.BackColor = Color.White
                tempPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

                tempPicBox.Image = ImageBox.Image;
                tempPicBox.DrawToBitmap(tBMP, new Rectangle(0, 0, Width, Height));

                tBMP.Save(fileJPG, System.Drawing.Imaging.ImageFormat.Jpeg);
                tempPicBox.Dispose();

                PhotoAnalysis.SaveToWSQ(tBMP, fileWSQ);

                tBMP.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool SaveTemplate(byte[] template, string strFile)
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(strFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                fs.Write(template, 0, template.Length);
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "SaveTemplate() : Runtime catched error " + ex.Message);
                return false;
            }
        }

        /////////////////////////////////////
        private void DrawImage(Byte[] imgData, System.Windows.Forms.PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }

        /////////////////////////////////////
        private Int32 GetImageFromFile(Byte[] data)
        {
            System.Windows.Forms.OpenFileDialog open_dlg;
            open_dlg = new System.Windows.Forms.OpenFileDialog();

            open_dlg.Title = "Image raw file dialog";
            open_dlg.Filter = "Image raw files (*.raw)|*.raw";

            if (open_dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.FileStream inStream = System.IO.File.OpenRead(open_dlg.FileName);

                System.IO.BinaryReader br = new System.IO.BinaryReader(inStream);

                Byte[] local_data = new Byte[data.Length];
                local_data = br.ReadBytes(data.Length);
                Array.Copy(local_data, data, data.Length);

                br.Close();
                return (Int32)SGFPMError.ERROR_NONE;
            }
            return (Int32)SGFPMError.ERROR_FUNCTION_FAILED;
        }
    }
}
