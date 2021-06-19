using System;
using System.Drawing;
using Sagem.MorphoKit;

namespace DCS2015.Class
{
    class Sagem
    {
        private AcquisitionDevice _device;
        private Coder coder;

        private Bitmap m__bmp;
        private byte[] _SagemTemplate;

        private Utilities.SagemFingerID _SagemFingerID;

        private System.Windows.Forms.PictureBox display;
        private System.Windows.Forms.PictureBox picBox2 = new System.Windows.Forms.PictureBox();

        private System.Windows.Forms.TextBox textQuality;
        private System.Windows.Forms.TextBox textStatus;

        private bool _IsSuccess;

        public Image ImageResult
        {
            //get { return display.Image; }
            get { return display.Image; }
        }

        public byte[] SagemTemplate
        {
            //get { return display.Image; }
            get { return _SagemTemplate; }
        }

        public bool Success
        {
            //get { return display.Image; }
            get { return _IsSuccess; }
        }

        public Sagem()
        {
        }

        public Sagem(ref System.Windows.Forms.PictureBox display, ref System.Windows.Forms.TextBox textQuality, ref System.Windows.Forms.TextBox textStatus)
        {
            try
            {
                this.display = display;
                this.textQuality = textQuality;
                this.textStatus = textStatus;

                _device = new AcquisitionDevice();
                _device.TimeOut = Properties.Settings.Default.SagemCaptureTime * 1000;
                //_device.LiveQualityThreshold = QualityThreshold;//Properties.Settings.Default.FP_Quality_Threshold;//80;

                coder = new Coder();
                //coder.CoderAlgorithm = CoderAlgorithm.V10;
                coder.CoderAlgorithm = CoderAlgorithm.V6;
                coder.JuvenileMode = false;
                coder.TemplateFormat = TemplateFormat.ANSI_378;

                _device.FingerEvent += new FingerEventHandler(device_FingerEvent);
                _device.EnrolmentEvent += new EnrolmentEventHandler(device_EnrolmentEvent);
                _device.QualityEvent += new QualityEventHandler(_device_QualityEvent);
                _device.ImageEvent += new ImageEventHandler(device_ImageEvent);
                _device.Display = this.display.Handle;

                _IsSuccess = true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "Sagem(): Runtime catched error " + ex.Message.ToString());
                _IsSuccess = false;
            }

        }

        public void Initialize()
        {
            _device = new AcquisitionDevice();
            _device.FingerEvent += new FingerEventHandler(device_FingerEvent);
            _device.EnrolmentEvent += new EnrolmentEventHandler(device_EnrolmentEvent);
            _device.QualityEvent += new QualityEventHandler(_device_QualityEvent);
            _device.ImageEvent += new ImageEventHandler(device_ImageEvent);
            _device.Display = this.display.Handle;
        }

        public bool EnumerateDevice(ref System.Windows.Forms.ComboBox listDevices)
        {
            try
            {
                _device = new AcquisitionDevice();

                listDevices.Items.Clear();
                listDevices.Text = "";

                int numberOfDevices = _device.GetNumberOfDevices();
                if (numberOfDevices == 0)
                {
                    return false;
                }

                IAcquisitionDeviceInfo[] deviceInfos = _device.EnumerateDevices();

                foreach (IAcquisitionDeviceInfo info in deviceInfos)
                {
                    listDevices.Items.Add(info.SerialNumber);
                }

                if (listDevices.Items.Count > 0)
                {
                    listDevices.SelectedIndex = 0;
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public System.Windows.Forms.PictureBox pbDisplay
        {
            get { return display; }
            set { display = value; }
        }

        public System.Windows.Forms.TextBox txttextQuality
        {
            get { return textQuality; }
            set { textQuality = value; }
        }

        public System.Windows.Forms.TextBox txttextStatus
        {
            get { return textStatus; }
            set { textStatus = value; }
        }

        void _device_QualityEvent(byte quality)
        {
            this.textQuality.Text = String.Format("Quality: {0}", quality);
            //this.progressQuality.Value = quality < this.progressQuality.Maximum ? quality : this.progressQuality.Maximum;
        }

        private Bitmap CreateGreyscaleBitmap(byte[] buffer, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            // copy the acquire image data to our bitmap
            // this works because the width of all MSO images is a multiple of 4
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bmpData.Scan0, width * height);
            bmp.UnlockBits(bmpData);

            // set up a greyscale palette
            System.Drawing.Imaging.ColorPalette pal = bmp.Palette;
            for (int i = 0; i < 256; i++)
            {
                pal.Entries[i] = Color.FromArgb(i, i, i);
            }
            bmp.Palette = pal;
            m__bmp = bmp;
            return bmp;
        }

        void device_ImageEvent(byte[] buffer, int width, int height, int resolution)
        {
        }

        void device_EnrolmentEvent(int captureIndex)
        {
            this.textStatus.Text = String.Format("EnrolmentEvent {0}", captureIndex);

        }

        void device_FingerEvent(int status)
        {
            FingerEventStatus l_e_FingerEventStatus = FingerEventStatus.UNKNOWN;

            if (Enum.IsDefined(typeof(FingerEventStatus), status))
                l_e_FingerEventStatus = (FingerEventStatus)status;

            String msg = "";

            switch (l_e_FingerEventStatus)
            {
                case FingerEventStatus.NO_FINGER_DETECTED: msg = "No finger"; break;
                case FingerEventStatus.MOVE_FINGER_UP: msg = "Move finger up"; break;
                case FingerEventStatus.MOVE_FINGER_DOWN: msg = "Move finger down"; break;
                case FingerEventStatus.MOVE_FINGER_LEFT: msg = "Move finger left"; break;
                case FingerEventStatus.MOVE_FINGER_RIGHT: msg = "Move finger right"; break;
                case FingerEventStatus.PRESS_FINGER_HARDER: msg = "Press finger harder"; break;
                case FingerEventStatus.LATENT: msg = "Latent"; break;
                case FingerEventStatus.REMOVE_FINGER: msg = "Remove your finger"; break;
                case FingerEventStatus.OK: msg = "Finger accepted"; break;
                case FingerEventStatus.FINGER_DETECTED: msg = "Finger was detected"; break;
                case FingerEventStatus.FINGER_MISPLACED: msg = "Finger is misplaced"; break;
                case FingerEventStatus.LIVE_OK: msg = "Don't remove your finger"; break;
                default: msg = "No finger"; break;
            }

            this.textStatus.Text = msg;
        }

        public void CancelAcquisition()
        {
            this._device.CancelAcquisition();
        }

        public bool Acquire(Utilities.SagemFingerID _SagemFingerID, string fileJPG, string fileANSI378, string fileWSQ, int QualityThreshold)
        {
            this._SagemFingerID = _SagemFingerID;
            _device.LiveQualityThreshold = QualityThreshold;

            bool Consolidate = false;
            String serialNumber = Properties.Settings.Default.SagemDeviceSerial;

            try
            {
                if (Consolidate)
                {
                    // call the Acquire method                        
                    IConsolidatedAcquisitionResult consoAcquisRes = _device.AcquireConsolidated(serialNumber);

                    AcquisitionError l_e_AcquisitionError = AcquisitionError.UNKNOWN;

                    if (Enum.IsDefined(typeof(AcquisitionError), consoAcquisRes.Status))
                        l_e_AcquisitionError = (AcquisitionError)consoAcquisRes.Status;

                    String msg = String.Format("Acquire() returned {0}", l_e_AcquisitionError.ToString());
                    //MessageBox.Show(msg);

                    if (l_e_AcquisitionError == AcquisitionError.OK)
                    {
                        // update our PictureBox with image1 (for example)
                        this.display.Image = CreateGreyscaleBitmap(consoAcquisRes.ImageBuffer1 as byte[], consoAcquisRes.Width, consoAcquisRes.Height);
                        //Coder coder = new Coder();                        
                        IConsolidationResult enrollConsoResult = coder.EnrollConsolidated(consoAcquisRes.ImageBuffer1, consoAcquisRes.ImageBuffer2, consoAcquisRes.ImageBuffer3, consoAcquisRes.Width, consoAcquisRes.Height, Convert.ToByte(_SagemFingerID));
                        if (enrollConsoResult.Success)
                        {
                            //byte[] cfv = enrollConsoResult.Template as byte[];
                            //SaveFileDialog fileDlg = new SaveFileDialog();
                            //fileDlg.AddExtension = true;

                            //fileDlg.FileName = "fingerprint";
                            //fileDlg.Title = "Save fingerprint template";
                            //fileDlg.DefaultExt = "cfv";
                            //fileDlg.Filter = "Morpho CFV Fingerprint Template (*.cfv)|*.cfv|All Files (*.*)|*.*";
                            //if (fileDlg.ShowDialog() == DialogResult.OK)
                            //{
                            //    FileStream fs = new FileStream(fileDlg.FileName, FileMode.Create);
                            //    fs.Write(cfv, 0, cfv.Length);
                            //    fs.Close();
                            //}
                        }
                        else
                        {
                            //msg = String.Format("Consolidation failed");
                            //MessageBox.Show(msg);
                        }
                    }
                }
                else
                {
                    // call the Acquire method                                        
                    IAcquisitionResult result = _device.Acquire(serialNumber);

                    AcquisitionError l_e_AcquisitionError = AcquisitionError.UNKNOWN;

                    if (Enum.IsDefined(typeof(AcquisitionError), result.Status))
                        l_e_AcquisitionError = (AcquisitionError)result.Status;

                    String msg = String.Format("Acquire() returned {0}", l_e_AcquisitionError.ToString());
                    //MessageBox.Show(msg);

                    if (l_e_AcquisitionError == AcquisitionError.OK)
                    {
                        // update our PictureBox
                        this.display.Image = CreateGreyscaleBitmap(result.ImageBuffer as byte[], result.Width, result.Height);

                        //Coder coder = new Coder();                        
                        ICoderResult enrollResult = coder.Enroll(result.ImageBuffer as byte[], result.Width, result.Height, Convert.ToByte(_SagemFingerID));
                        _SagemTemplate = enrollResult.Template;

                        //if (Properties.Settings.Default.SagemOutputJPG)
                        //{                            
                        SaveToJPG(fileJPG);
                        //}

                        if (Properties.Settings.Default.SagemOutputANSI378)
                        {
                            SaveTemplate(enrollResult.Template, fileANSI378);
                        }

                        if (Properties.Settings.Default.SagemOutputWSQ)
                        {
                            SaveToWSQ(result.ImageBuffer as byte[], result.Width, result.Height, fileWSQ);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "Acquire() : Runtime catched error " + ex.Message.ToString());
                return false;
            }
        }


        public bool SaveToJPG(string strFile)
        {
            try
            {
                IncreaseBitmapDPI();
                picBox2.Image.Save(strFile, System.Drawing.Imaging.ImageFormat.Jpeg);

                return true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "SaveToJPG() : Runtime catched error " + ex.Message);
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

                //System.IO.FileStream fs2 = new System.IO.FileStream(strFile.Replace(".ansi-fmr",".cfv"), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //fs2.Write(template, 0, template.Length);
                //fs2.Close();                

                return true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "SaveTemplate() : Runtime catched error " + ex.Message);
                return false;
            }
        }

        //public void SaveWSQ(byte[] buffer, int width, int height, string strFile)
        //{
        //    ActiveMKit_Enroll.MKWsq objWsq = default(ActiveMKit_Enroll.MKWsq);            

        //    object VarWsqBuffer = null;
        //    int resultCompression = 0;
        //    ActiveMKit_Enroll.MKImage newImage = default(ActiveMKit_Enroll.MKImage);
        //    objWsq = new ActiveMKit_Enroll.MKWsq();
        //    newImage = new ActiveMKit_Enroll.MKImage();

        //    int sizeX = 0;
        //    int sizeY = 0;

        //    sizeX = width;
        //    //objImage.sizeX
        //    sizeY = height;
        //    //objImage.sizeY
        //    // Compress image with wsq interface
        //    //resultCompression = objWsq.Compress(objImage.get_raw_image, sizeX, sizeY, VarWsqBuffer)
        //    resultCompression = objWsq.Compress(buffer, (short)sizeX, (short)sizeY, out VarWsqBuffer);
        //    if (resultCompression == 4097)
        //    {
        //        // Do not need to set image information, they are deduced from wsq buffer
        //        newImage.SetImage(-1, 0, 0, 0, VarWsqBuffer);
        //        newImage.SaveFile(strFile, 3);
        //    }
        //    objWsq = null;
        //    newImage = null;
        //}

        public void SaveToWSQ(byte[] buffer, int width, int height, string strFile)
        {
            WSQ wsq = new WSQ();
            SaveTemplate(wsq.Compress(buffer, (uint)width, (uint)height, 12), strFile);
        }

        private bool IncreaseBitmapDPI()
        {
            try
            {
                picBox2.Paint += picBox2_Paint;

                Bitmap myBitmapDPI = new Bitmap(this.display.Image);
                myBitmapDPI.SetResolution((float)Properties.Settings.Default.Bitmap_HResolution, (float)Properties.Settings.Default.Bitmap_VResolution);
                picBox2.Image = myBitmapDPI;
                picBox2.Invalidate();

                return true;
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "IncreaseBitmapDPI() : Runtime catched error " + ex.Message);
                return false;
            }

        }

        private void picBox2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                Bitmap mBmp = new Bitmap(501, 501);
                int w = 0;
                int h = 0;
                float fx = 0;
                float fy = 0;
                fx = e.Graphics.DpiX / mBmp.HorizontalResolution;
                fy = e.Graphics.DpiY / mBmp.VerticalResolution;
                w = Convert.ToInt32(fx * mBmp.Width);
                h = Convert.ToInt32(fy * mBmp.Height);

                e.Graphics.DrawImage(mBmp, 0, 0, w, h);
            }
            catch (Exception ex)
            {
                Utilities.SaveToErrorLog(Utilities.TimeStamp() + "Sagem :: picBox2_Paint(): Runtime catched error " + ex.Message.ToString());
            }
        }

        public bool IsSagemTemplateMatched(byte[] sagemTemplate1, byte[] sagemTemplate2)
        {
            //convert first ANSI378 to morpho cfv format
            Converter _convert = new Converter();
            byte[] sagemTemplate1_CFV = _convert.Convert(sagemTemplate1, TemplateFormat.ANSI_378, Convert.ToByte(0), TemplateFormat.Morpho_CFV);
            byte[] sagemTemplate2_CFV = _convert.Convert(sagemTemplate2, TemplateFormat.ANSI_378, Convert.ToByte(0), TemplateFormat.Morpho_CFV);

            //authenticate
            Authenticator _aut = new Authenticator();
            if (_aut.Authenticate(sagemTemplate1_CFV, sagemTemplate2_CFV) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int IsSagemTemplateMatched2(byte[] sagemTemplate1, byte[] sagemTemplate2)
        {
            //convert first ANSI378 to morpho cfv format
            Converter _convert = new Converter();
            byte[] sagemTemplate1_CFV = _convert.Convert(sagemTemplate1, TemplateFormat.ANSI_378, Convert.ToByte(0), TemplateFormat.Morpho_CFV);
            byte[] sagemTemplate2_CFV = _convert.Convert(sagemTemplate2, TemplateFormat.ANSI_378, Convert.ToByte(0), TemplateFormat.Morpho_CFV);

            //authenticate
            Authenticator _aut = new Authenticator();
            return _aut.Authenticate(sagemTemplate1_CFV, sagemTemplate2_CFV);
        }
    }
}
