using System;
using System.Windows.Forms;
using DCS2015.Class;
using System.Drawing;

namespace DCS2015.Forms
{
    public partial class SignatureCapture_Confirm : Form
    {
        public SignatureCapture_Confirm()
        {
            InitializeComponent();
        }

        public bool IsConfirm = false;

        private void SignatureCapture_Confirm_Load(object sender, EventArgs e)
        {
            if (cboPenwidth.Items.Count > 0) cboPenwidth.SelectedIndex = 7;
            InitializeSig100();
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
            this.StartCancel();
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
                {
                    throw new STPadException(rc, axSTPadCapt1);
                    return;
                }

                // confirm capturing
                rc = axSTPadCapt1.SignatureConfirm();
                if (rc < 0)
                { 
                    throw new STPadException(rc, axSTPadCapt1);
                return;
                }

                // check if there are enough points for a valid signature
                if (CheckForValidSignature(rc))
                {
                    if (SaveSignature())
                    {
                        _processState = ProcessState.Start;

                        IsConfirm = true;

                        this.Cursor = Cursors.Default;

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No signature detected",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                        this.StartCancel();
                    }
                }
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
            }

            this.Cursor = Cursors.Default;
        }

        //private void BindSignatures()
        //{
        //    if (picSig1.BackgroundImage == null)
        //        if (File.Exists(DCS_MemberInfo.Data.SignatureFile))
        //            picSig1.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile)));

        //    if (picSig2.BackgroundImage == null)
        //        if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff")))
        //            picSig2.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff"))));

        //    if (picSig3.BackgroundImage == null)
        //        if (File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff")))
        //            picSig3.BackgroundImage = Bitmap.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff"))));
        //}

        private bool SaveSignature()
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

            // save as file
            int rc = axSTPadCapt1.SignatureSaveAsFileEx(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff"), resolution, width, height, fileType, penWidth, (uint)ColorTranslator.ToOle(penColor), options);
            if (rc < 0)
            {
                //MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);
                this.Cursor = Cursors.Default;
                return false;
            }

            if (Properties.Settings.Default.SignatureOutputBMP)
            {
                int rc2 = axSTPadCapt1.SignatureSaveAsFileEx(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff").Replace("tiff", "bmp"), resolution, width, height, 2, penWidth, (uint)ColorTranslator.ToOle(penColor), options);
            }

            if (Properties.Settings.Default.SignatureOutputJPG)
            {
                int rc3 = axSTPadCapt1.SignatureSaveAsFileEx(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "4.tiff").Replace("tiff", "jpg"), resolution, width, height, 3, penWidth, (uint)ColorTranslator.ToOle(penColor), options);
            }

            this.Cursor = Cursors.Default;
            return true;
        }

        private bool CheckForValidSignature(long pointCount)
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
                    {
                        throw new STPadException(rc, axSTPadCapt1);
                        return false;
                    }
                    //LabelCapturedPoints.Text += String.Format("\nThe signature bounds are: {0}, {1}, {2}, {3}.", left, top, right, bottom);                    
                }
                //else
                //LabelCapturedPoints.Text = String.Format("This is not a valid signature!\n({0} points captured.)", pointCount);
                return true;
            }
            catch (STPadException exc)
            {
                MessageBox.Show(exc.Message);
                return false;
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

            if (rc < 0) MessageBox.Show(new STPadException(rc, axSTPadCapt1).Message);
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

        private void SignatureCapture_Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelProcess(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
