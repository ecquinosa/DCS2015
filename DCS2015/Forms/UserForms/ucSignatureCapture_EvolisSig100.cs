
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
    public partial class ucSignatureCapture_EvolisSig100 : UserControl
    {

        public ucSignatureCapture_EvolisSig100()
        {
            InitializeComponent();            
        }

        public ucSignatureCapture_EvolisSig100(Action MainAction)
        {
            InitializeComponent();
            _action = MainAction;
        }

        public Action _action;

        private short PenWidth_SelectedIndex = 7; //change also SignatureCapture_Confirm

        private void ucSignatureCapture_EvolisSig100_Load(object sender, EventArgs e)
        {
            if (axSTPadCapt1.DeviceGetCount() == 0)
            {
                chkOverrideSignature.Visible = false;
                btnReset.Visible = false;
                picSig1.Enabled = false;
                picSig2.Enabled = false;
                picSig3.Enabled = false;
                lbReset1.Enabled = false;
                lbReset2.Enabled = false;
                lbReset3.Enabled = false;                
                DisplayMsg("Unable to detect signature tablet device...");
                return;
            }

            InitializeSig100();

            if (cboPenwidth.Items.Count > 0) cboPenwidth.SelectedIndex = PenWidth_SelectedIndex;
            chkOverrideSignature.Checked = DCS_MemberInfo.Data.SignatureOverride;

            if (Properties.Settings.Default.SignatureTablet == "Topaz Siglite")
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile)) { btnDone.Visible = false; }

            BindSignatures();
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

            Class.Utilities.SignatureCapturing_ErrorMessage = "";
            picSig1.BackgroundImage = null;
            picSig2.BackgroundImage = null;
            picSig3.BackgroundImage = null;

            if (cboPenwidth.Items.Count > 0) cboPenwidth.SelectedIndex = PenWidth_SelectedIndex;

            CancelProcess(true);
            StartCancel();
            DCS_MemberInfo.Data.ResetSignature();
            if(_action!=null)_action.Invoke();            
        }

        #endregion    
         

        int timerCount = 0;
        private void Timer1_Tick(System.Object sender, System.EventArgs e)
        {
            timerCount += 1;
            //if (timerCount == 3)
            if (timerCount == 5)
            {
                Timer1.Stop();
                timerCount = 0;
                //SigPlusNET1.SetJustifyMode(5);
                //SaveSignature();
            }
        }

        private void DisplayMsg(string strMsg)
        {
            Class.Utilities.SignatureCapturing_ErrorMessage = strMsg;
            txtMsg.Text = strMsg;
            txtMsg.ForeColor = Color.Orange;
        }

        //public void SaveSignature()
        //{
        //    try
        //    {
        //        Bitmap myimage = default(Bitmap);
        //        List<Class.ListofDimensions> ld = new List<Class.ListofDimensions>();
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 500,
        //            NHeigth = 167
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 490,
        //            NHeigth = 163
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 480,
        //            NHeigth = 160
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 470,
        //            NHeigth = 157
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 460,
        //            NHeigth = 153
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 450,
        //            NHeigth = 150
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 430,
        //            NHeigth = 143
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 400,
        //            NHeigth = 133
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 380,
        //            NHeigth = 126
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 350,
        //            NHeigth = 116
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 300,
        //            NHeigth = 100
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 280,
        //            NHeigth = 93
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 250,
        //            NHeigth = 83
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 240,
        //            NHeigth = 80
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 230,
        //            NHeigth = 77
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 220,
        //            NHeigth = 73
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 210,
        //            NHeigth = 70
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 200,
        //            NHeigth = 67
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 190,
        //            NHeigth = 64
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 180,
        //            NHeigth = 60
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 170,
        //            NHeigth = 57
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 160,
        //            NHeigth = 54
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 150,
        //            NHeigth = 50
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 140,
        //            NHeigth = 47
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 130,
        //            NHeigth = 44
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 120,
        //            NHeigth = 40
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 110,
        //            NHeigth = 37
        //        });
        //        ld.Add(new Class.ListofDimensions
        //        {
        //            NWidth = 100,
        //            NHeigth = 34
        //        });

        //        SigPlusNET1.SetImageXSize(450);
        //        SigPlusNET1.SetImageYSize(150);                

        //        DCS_MemberInfo.Data.SignatureFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.Signature_FileNameTIFF);

        //        if(Properties.Settings.Default.SignatureOutputJPG)
        //            SigPlusNET1.GetSigImage().Save(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);

        //        if (Properties.Settings.Default.SignatureOutputBMP)
        //            SigPlusNET1.GetSigImage().Save(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", ".bmp"), System.Drawing.Imaging.ImageFormat.Bmp);                

        //        int FileSize = 0;
        //        int indx = 0;

        //        int NW = ld[indx].NWidth;
        //        int NH = ld[indx].NHeigth;
        //    again:

        //        SigPlusNET1.SetImageXSize(NW);
        //        SigPlusNET1.SetImageYSize(NH);
        //        //SigPlusNET1.SetJustifyMode(0)

        //        myimage = (Bitmap)SigPlusNET1.GetSigImage();
        //        Bitmap bmp = myimage;
        //        //ToBlackAndWhite(myimage)
        //        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.ColorDepth;
        //        EncoderParameters parameters = new System.Drawing.Imaging.EncoderParameters(1);
        //        ImageCodecInfo enc = GetEncoderInfo(System.Drawing.Imaging.ImageFormat.Tiff);
        //        int im = (Int32)4L;
        //        parameters.Param[0] = new EncoderParameter(myEncoder, im);
        //        bmp.Save(DCS_MemberInfo.Data.SignatureFile, enc, parameters);

        //        if (!IsFileAccepted(DCS_MemberInfo.Data.SignatureFile, ref FileSize))
        //        {
        //            if (FileSize > 1536)
        //            {
        //                indx += 1;
        //                if (indx >= ld.Count)
        //                {
        //                    im = (Int32)1L;
        //                    indx = 0;
        //                }
        //            }
        //            else if (FileSize < 800)
        //            {
        //                if (indx == 0)
        //                {
        //                    indx = ld.Count - 1;
        //                }
        //                indx -= 1;
        //            }
        //            NW = ld[indx].NWidth;
        //            NH = ld[indx].NHeigth;
        //            goto again;
        //        }
        //        SigPlusNET1.SetTabletState(0);                
        //    }
        //    catch (Exception ex)
        //    {
        //        DisplayMsg(ex.Message);
        //    }              
        //}

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
            //SigPlusNET1.SetJustifyMode(5);
            //SaveSignature();
            btnDone.Visible = false;
            if(_action!=null)_action.Invoke();
        }

        private void chkOverrideSignature_CheckedChanged(object sender, EventArgs e)
        {
            DCS_MemberInfo.Data.SignatureOverride = chkOverrideSignature.Checked;
        }

        private string GetSigFile()
        {
            if(DCS_MemberInfo.Data.SignatureFile=="")
                DCS_MemberInfo.Data.SignatureFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.Signature_FileNameTIFF);

            if (!File.Exists(DCS_MemberInfo.Data.SignatureFile))
                return DCS_MemberInfo.Data.SignatureFile;
            else if (!File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
                return DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff");
            else if (!File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                return DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff");
            else return "";
        }       

        #region " Evolis Sig100 "

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private enum ProcessState
        {
            Start = 0,
            Terms,
            Capturing,
            Stopped
        };

        private SignPad[] _signPads = null;
        private int _storeIdSigning = -1;
        private int _storeIdOverlay = -1;
        private int _buttonCancelId = -1;
        private int _buttonRetryId = -1;
        private int _buttonConfirmId = -1;
        private const String _disclaimer = "With my signature, I certify that I'm excited about the signotec LCD Signature Pad and the signotec Pad Capture Control. This demo application has blown me away and I can't wait to integrate all these great features in my own application.";
        private const string _csText = "What you see is what you sign!\nThe hash of this image has been computed inside of the pad and will be digitally signed after capturing. The display content cannot be changed until the signature has been confirmed.";
        private ProcessState _processState = ProcessState.Start;
      

        private void InitializeSig100()
        {
            // scale fonts if screen resolution is not 96 dpi
            Graphics graphics = this.CreateGraphics();
            if (graphics.DpiX != 96F)
                this.Font = new Font(this.Font.FontFamily, this.Font.Size * 96F / graphics.DpiX, this.Font.Style, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
            graphics.Dispose();           
	
            // get connected devices and open first one if any
            GetDevices();
            if (_signPads != null) OpenDevice();            
            if (!Utilities.IsSignaturesComplete()) this.StartCancel();
        }

        private void StartCancel()
        {         
            StartDefaultCapturing();           
        }

        private void ButtonStop_Click()
        {
            this.Cursor = Cursors.WaitCursor;
            // stop capturing
            int rc = axSTPadCapt1.SignatureStop();
            this.Cursor = Cursors.Default;
            if (rc < 0)
            {
                MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);
                return;
            }           

            // check if there are enough points for a valid signature
            CheckForValidSignature(rc);
            
            _processState = ProcessState.Stopped;
        }

        private int SetTarget(int target)
        {    
            // set target
            int id = axSTPadCapt1.DisplaySetTarget(target);            

            return id;
        }

        private bool StartDefaultCapturing()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // erase display                
                int rc = axSTPadCapt1.DisplayErase();
                //if (rc < 0) throw new STPadException(rc, axSTPadCapt1);
                if (rc < 0) InitializeSig100();                

                // clear hot spots
                rc = ClearHotSpots(); 
                if (rc < 0) throw new STPadException(rc, axSTPadCapt1);

                rc = SetTarget(1);                
                if (rc < 0) throw new STPadException(rc, axSTPadCapt1);

                // draw the bitmaps
                IntPtr hBitmap = IntPtr.Zero;
                hBitmap = DCS2015.Properties.Resources.DefaultBitmap_sigma.GetHbitmap();
               
                rc = axSTPadCapt1.DisplaySetImage(0, 0, hBitmap.ToInt32());
                DeleteObject(hBitmap);
                if (rc < 0) throw new STPadException(rc, axSTPadCapt1);                

                short x = 0;
                short y = 0;
                short width = 0;
                short height = 0;                

                // do all drawing operations on the LCD directly
                rc = SetTarget(0);
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);

                rc = axSTPadCapt1.DisplaySetImageFromStore(1);
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);               

                // set default signature window
                x = (short)(_signPads[0].Alpha ? 90 : 0);
                y = (short)(_signPads[0].Sigma ? 50 : (_signPads[0].Omega ? 100 : 600));
                width = (short)(_signPads[0].Alpha ? 590 : 0);
                height = (short)(_signPads[0].Alpha ? 370 : 0);
                rc = axSTPadCapt1.SensorSetSignRect(x, y, width, height);
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);

                // add default hotspots
                x = (short)(_signPads[0].Sigma ? 12 : (_signPads[0].Omega ? 24 : 30));
                y = (short)(_signPads[0].Sigma ? 9 : (_signPads[0].Omega ? 18 : 30));
                width = (short)(_signPads[0].Sigma ? 85 : (_signPads[0].Omega ? 170 : 80));
                height = (short)(_signPads[0].Sigma ? 33 : (_signPads[0].Omega ? 66 : 80));
                rc = axSTPadCapt1.SensorAddHotSpot(x, y, width, height);
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);
                _buttonCancelId = rc;
                x = (short)(axSTPadCapt1.DisplayWidth - (_signPads[0].Sigma ? 203 : (_signPads[0].Omega ? 406 : 424)));
                rc = axSTPadCapt1.SensorAddHotSpot(x, y, width, height);
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);
                _buttonRetryId = rc;
                x = (short)(axSTPadCapt1.DisplayWidth - (_signPads[0].Sigma ? 98 : (_signPads[0].Omega ? 196 : 110)));
                rc = axSTPadCapt1.SensorAddHotSpot(x, y, width, height);
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);
                _buttonConfirmId = rc;                

                // start capturing
                rc = axSTPadCapt1.SignatureStart();
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);
               
                _processState = ProcessState.Capturing;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return true;
        }

        private void GetDevices()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // get number of connected devices
                int deviceCount = axSTPadCapt1.DeviceGetCount();
                if (deviceCount < 0)
                    throw new STPadException(deviceCount, axSTPadCapt1);

                // erase all entries
                //ListOfDevices.Items.Clear();

                // build list
                if (deviceCount <= 0)
                {   // no devices detected
                    _signPads = null;                   
                }
                else
                {   // build device list
                    _signPads = new SignPad[deviceCount];
                    for (int i = 0; i < deviceCount; i++)
                    {
                        _signPads[i] = new SignPad(axSTPadCapt1, i);
                        //ListOfDevices.Items.Add(String.Format("Device {0}", i + 1));
                    }                   
                }
             
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.Cursor = Cursors.Default;
        }

        private void ConfirmCapturing()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // clear hot spots
                int rc = ClearHotSpots();
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);

                // confirm capturing
                rc = axSTPadCapt1.SignatureConfirm();
                if (rc < 0)
                    throw new STPadException(rc, axSTPadCapt1);

                // check if there are enough points for a valid signature
                CheckForValidSignature(rc);
                
                _processState = ProcessState.Start;

                SaveSignature();

                BindSignatures();

                   this.Cursor = Cursors.Default;
                if (!Utilities.IsSignaturesComplete()) this.StartDefaultCapturing();
                else this.CancelProcess(true);               
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.Cursor = Cursors.Default;
        }

        private void BindSignatures()
        {
            if(picSig1.BackgroundImage==null)
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
                    picSig1.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile)));

            if (picSig2.BackgroundImage == null)
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff","2.tiff")))
                    picSig2.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff"))));

            if (picSig3.BackgroundImage == null)
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
                    picSig3.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff"))));
        }        

        private void SaveSignature()
        {  
            short fileType = 0;          

            int options = 0;
            short resolution = 300;
            int width = 0;
            int height = 0;
            short penWidth = Convert.ToInt16(cboPenwidth.Text); //0;
            Color penColor = Color.Black;
                        
            // smoothing
            options |= 0x400;               

            this.Cursor = Cursors.WaitCursor;

            string _sigFile = GetSigFile();

            // save as file
            int rc = axSTPadCapt1.SignatureSaveAsFileEx(_sigFile, resolution, width, height, fileType, penWidth, (uint)ColorTranslator.ToOle(penColor), options);
            if (rc < 0)
                MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);

            if (Properties.Settings.Default.SignatureOutputBMP)
            {
                int rc2 = axSTPadCapt1.SignatureSaveAsFileEx(_sigFile.Replace("tiff","bmp"), resolution, width, height, 2, penWidth, (uint)ColorTranslator.ToOle(penColor), options);
            }

            if (Properties.Settings.Default.SignatureOutputJPG)
            {
                int rc3 = axSTPadCapt1.SignatureSaveAsFileEx(_sigFile.Replace("tiff", "jpg"), resolution, width, height, 3, penWidth, (uint)ColorTranslator.ToOle(penColor), options);
            }

            this.Cursor = Cursors.Default;
        }       

        private void CheckForValidSignature(long pointCount)
        {
            // get sample rate
            float sampleRate = float.MaxValue;
            int rc = axSTPadCapt1.SensorGetSampleRateMode();
            switch (rc)
            {
                case 0:
                    sampleRate = 125.0f;
                    break;
                case 1:
                    sampleRate = 250.0f;
                    break;
                case 2:
                    sampleRate = 500.0f;
                    break;
                case 3:
                    sampleRate = 280.0f;
                    break;
                default:
                    MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);
                    break;
            }

            try
            {
                // check if there are enough points for a valid signature
                if (((float)pointCount / sampleRate) > 0.2f)
                {
                    //LabelCapturedPoints.Text = String.Format("{0} points succesfully captured.", pointCount);

                    short left = 0;
                    short top = 0;
                    short right = 0;
                    short bottom = 0;
                    rc = axSTPadCapt1.SignatureGetBounds(ref left, ref top, ref right, ref bottom, 0);
                    if (rc < 0)
                        throw new STPadException(rc, axSTPadCapt1);
                    //LabelCapturedPoints.Text += String.Format("\nThe signature bounds are: {0}, {1}, {2}, {3}.", left, top, right, bottom);

                }
                //else
                    //LabelCapturedPoints.Text = String.Format("This is not a valid signature!\n({0} points captured.)", pointCount);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
            }           
        }

        private void OpenDevice()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // open device
                try
                {
                    //_signPads[ListOfDevices.SelectedIndex].DeviceOpen();                    
                    _signPads[0].DeviceOpen();                                      
                }
                catch (STPadException exc)
                {
                    Console.Write(exc.Message);
                    //MessageBox.Show(exc.Message);
                    //return;
                }

                _storeIdSigning = -1;
                _storeIdOverlay = -1;

                _buttonCancelId = -1;
                //ButtonRetry.Enabled = false;
                _buttonRetryId = -1;
                //ButtonStop.Enabled = false;
                //ButtonConfirm.Enabled = false;
                _buttonConfirmId = -1;

                if (axSTPadCapt1.DisplayTargetHeight - axSTPadCapt1.DisplayHeight > 0)
                {

                    int currentXPos = 0;
                    int currentYPos = 0;
                    if (axSTPadCapt1.DisplayGetScrollPos(ref currentXPos, ref currentYPos) >= 0)
                    {
                        //TextBoxScrollX.Text = String.Format("{0}", currentXPos);
                        //TextBoxScrollY.Text = String.Format("{0}", currentYPos);
                    }
                }

                axSTPadCapt1.ControlMirrorDisplay = 4;
                SetFont();

                // set pen width and color
                if (!DisplayConfigPen())
                {
                    CloseDevice();
                    return;
                }

                // get sample rate
                int sampleRate = axSTPadCapt1.SensorGetSampleRateMode();
                if (sampleRate < 0)
                    throw new STPadException(sampleRate, axSTPadCapt1);
            }
            catch (STPadException exc)
            {
                CloseDevice();
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CloseDevice()
        {
            this.Cursor = Cursors.WaitCursor;

            // cancel signature process
            CancelProcess(true);

            // close device
            try
            {
                //_signPads[ListOfDevices.SelectedIndex].DeviceClose();
                _signPads[0].DeviceClose();
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
            }

            ResetAfterClose();

            ClearHotSpots();

            this.Cursor = Cursors.Default;
        }

        private void ResetAfterClose()
        {
            
        }

        private bool DisplayConfigPen()
        {
            if (!_signPads[0].Open)
                return false;

            this.Cursor = Cursors.WaitCursor;
            int rc = axSTPadCapt1.DisplayConfigPen((short)(2), (uint)ColorTranslator.ToOle(Color.Black));
            this.Cursor = Cursors.Default;
            if (rc < 0)
            {
                MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);
                return false;
            }
            return true;
        }

        public void CancelProcess(bool silent)
        {
            this.Cursor = Cursors.WaitCursor;
            //LabelCapturedPoints.Text = "";
            int rc = 0;

            try
            {
                // cancel
                if (axSTPadCapt1.SignatureState)
                    // cancel capturing (this clears the LCD, too)
                    rc = axSTPadCapt1.SignatureCancel();
                else    // erase LCD
                    rc = axSTPadCapt1.DisplayErase();
                if ((rc < 0) && !silent)
                    throw new STPadException(rc, axSTPadCapt1);

                // clear all hot spots
                rc = ClearHotSpots();
                if ((rc < 0) && !silent)
                    throw new STPadException(rc, axSTPadCapt1);
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
            _processState = ProcessState.Start;

            this.Cursor = Cursors.Default;
        }

        private int ClearHotSpots()
        {
            int rc = axSTPadCapt1.SensorClearHotSpots();
            if ((rc == 0) || (rc == -22))
            {
                _buttonCancelId = -1;
                _buttonRetryId = -1;
                _buttonConfirmId = -1;               
            }
            return rc;
        }

        private void SetFont()
        {
            
        }

        private void ButtonConfirm_Click()
        {
            if (_processState == ProcessState.Terms)
                // accept disclaimer and start capturing
                StartDefaultCapturing();
            else
                ConfirmCapturing();
        }

        private void ButtonRetry_Click()
        {
            this.Cursor = Cursors.WaitCursor;
           
            int rc = axSTPadCapt1.SignatureRetry();
            
            if (rc < 0)
                MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);            
            this.Cursor = Cursors.Default;
        }

        #region "Events"

        private void axSTPadCapt1_SensorHotSpotPressed(object sender, AxSTPadCaptLib._DSTPadCaptEvents_SensorHotSpotPressedEvent e)
        {
            //if (ButtonSettings.Text.Equals("Advanced Settings"))
            //{   // use default behaviour
            if (e.nHotSpotId == _buttonCancelId)
                this.StartCancel();
            else if (e.nHotSpotId == _buttonRetryId)
                ButtonRetry_Click();
            else if (e.nHotSpotId == _buttonConfirmId)
                ButtonConfirm_Click();
            //}
            //else // custom mode
            //    MessageBox.Show(String.Format("Hot Spot {0} clicked.", e.nHotSpotId + 1));
        }

        private void axSTPadCapt1_SensorTimeoutOccured(object sender, AxSTPadCaptLib._DSTPadCaptEvents_SensorTimeoutOccuredEvent e)
        {
            //MessageBox.Show(String.Format("Timeout occured! {0} points have been captured.", e.nPointsCount));
            //ButtonTimeoutStartStop.Text = "Start";
        }

        #endregion

        #endregion

        private void lbReset1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Utilities.ShowQuestionMessage("Are you sure?") == DialogResult.Yes)
            {
                picSig1.BackgroundImage = null;
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile)) File.Delete(DCS_MemberInfo.Data.SignatureFile);
                if (!Utilities.IsSignaturesComplete()) this.StartDefaultCapturing();
            }

        }

        private void lbReset2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Utilities.ShowQuestionMessage("Are you sure?") == DialogResult.Yes)
            {
                picSig2.BackgroundImage = null;
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff"))) File.Delete(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff"));
                if (!Utilities.IsSignaturesComplete()) this.StartDefaultCapturing();
            }
        }

        private void lbReset3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Utilities.ShowQuestionMessage("Are you sure?") == DialogResult.Yes)
            {
                picSig3.BackgroundImage = null;
                if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff"))) File.Delete(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff"));
                if (!Utilities.IsSignaturesComplete()) this.StartDefaultCapturing();
            }
        }

        private void ucSignatureCapture_EvolisSig100_Leave(object sender, EventArgs e)
        {
            CancelProcess(true);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
