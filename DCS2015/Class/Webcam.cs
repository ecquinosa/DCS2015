
using System;
using System.Collections.Generic;
using Touchless.Vision.Camera;

namespace DCS2015.Class
{
    class Webcam
    {
        public Webcam(ref System.Windows.Forms.PictureBox _photo)
        {
            try
            {
                this._photo = _photo;

                //if (CameraService.AvailableCameras.Count == 1)
                //{
                //    _IsSuccess = false;
                //    _ErrorMessage = "Check camera status/ connectivity.";
                //    return;
                //}

                foreach (Camera cam in CameraService.AvailableCameras)
                    //HD Pro Webcam C920, Lenovo EasyCamera
                    if (cam.Name == Properties.Settings.Default.Camera)
                    //if (cam.Name == "Lenovo EasyCamera")
                    //if (cam.Name == "HD Pro Webcam C920")
                    {
                        _CurrentCamera = cam;
                    }                
            
                startCapturing();
                InitializeCameraPropertyControls();

                _IsBrightnessSupported = CurrentCamera.IsCameraPropertySupported(CameraProperty.Brightness);
                _IsSharpnessSupported = CurrentCamera.IsCameraPropertySupported(CameraProperty.Sharpness);
                _IsZoomSupported = CurrentCamera.IsCameraPropertySupported(CameraProperty.Zoom_mm);

                if (_IsBrightnessSupported)
                {
                    CameraPropertyCapabilities propertyCapabilities = CurrentCameraPropertyCapabilities[CameraProperty.Brightness];
                    UpdateCameraPropertyRange(propertyCapabilities, CameraProperty.Brightness);
                }

                if (_IsSharpnessSupported)
                {
                    CameraPropertyCapabilities propertyCapabilities = CurrentCameraPropertyCapabilities[CameraProperty.Sharpness];
                    UpdateCameraPropertyRange(propertyCapabilities, CameraProperty.Sharpness);
                }

                if (_IsZoomSupported)
                {
                    CameraPropertyCapabilities propertyCapabilities = CurrentCameraPropertyCapabilities[CameraProperty.Zoom_mm];
                    UpdateCameraPropertyRange(propertyCapabilities, CameraProperty.Zoom_mm);
                }

                _IsSuccess = true;
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message.ToString();
                _IsSuccess = false;
            }

        }

        public bool IsPropertySupported(CameraProperty property)
        {
            return CurrentCamera.IsCameraPropertySupported(property);
        }

        private bool _IsBrightnessSupported;
        private bool _IsSharpnessSupported;
        private bool _IsZoomSupported;

        private string _ErrorMessage;
        private bool _IsSuccess;

        private System.Windows.Forms.PictureBox _photo;
        public CameraFrameSource _frameSource;
        public System.Drawing.Bitmap _latestFrame;

        public bool IsBrightnessSupported
        {
            get { return _IsBrightnessSupported; }
        }

        public bool IsSharpnessSupported
        {
            get { return _IsSharpnessSupported; }
        }

        public bool IsZoomSupported
        {
            get { return _IsZoomSupported; }
        }

        public Camera CurrentCamera
        {
            get
            {
                return _CurrentCamera;
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

        public bool IsCapturing
        {
            get
            {
                return _IsCapturing;
            }
            set
            {
                _IsCapturing = value;
            }
        }

        private bool _IsCapturing;
        private Camera _CurrentCamera;

        
        public void startCapturing()
        {
            try
            {
                Camera c = CurrentCamera;
                setFrameSource(new CameraFrameSource(c));
                _frameSource.Camera.CaptureWidth = 640;                
                _frameSource.Camera.CaptureHeight = 480;
                //_frameSource.Camera.CaptureWidth = 533;
                //_frameSource.Camera.CaptureHeight = 431;
                _frameSource.Camera.Fps = 50;
                _frameSource.NewFrame += OnImageCaptured;

                _IsCapturing = true;

                this._photo.Paint += new System.Windows.Forms.PaintEventHandler(drawLatestImage);
                //cameraPropertyValue.Enabled = _frameSource.StartFrameCapture();
                if(_frameSource!=null)_frameSource.StartFrameCapture();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //comboBoxCameras.Text = "Select A Camera";
                //MessageBox.Show(ex.Message);
            }
        }


        private void drawLatestImage(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                if (_latestFrame != null)
                {
                    // Draw the latest image from the active camera
                    e.Graphics.DrawImage(_latestFrame, 0, 0, _latestFrame.Width, _latestFrame.Height);
                }
            }
            catch { }
        }

        public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource, Touchless.Vision.Contracts.Frame frame, double fps)
        {
            try
            {
                GC.Collect();
                _latestFrame = frame.Image;
                this._photo.Invalidate();
            }
            catch
            {
            }
        }

        public void setFrameSource(CameraFrameSource cameraFrameSource)
        {
            try
            {
                if (_frameSource == cameraFrameSource)
                    return;

                _frameSource = cameraFrameSource;
            }
            catch { }
        }

        //

        public void thrashOldCamera()
        {
            // Trash the old camera
            try
            {
                if (_frameSource != null)
                {
                    _frameSource.NewFrame -= OnImageCaptured;
                    _frameSource.Camera.Dispose();
                    setFrameSource(null);
                    _IsCapturing = false;
                    this._photo.Paint -= new System.Windows.Forms.PaintEventHandler(drawLatestImage);
                }
            }
            catch { }
        }


        private IDictionary<String, CameraProperty> displayPropertyValues;

        private IDictionary<String, CameraProperty> DisplayPropertyValues
        {
            get
            {
                if (displayPropertyValues == null)
                    displayPropertyValues = new Dictionary<String, CameraProperty>()
                 {
                    { "Pan (Degrees)", CameraProperty.Pan_degrees }, 
                    { "Tilt (Degrees)", CameraProperty.Tilt_degrees }, 
                    { "Roll (Degrees)", CameraProperty.Roll_degrees }, 
                    { "Zoom (mm)", CameraProperty.Zoom_mm }, 
                    { "Exposure (log2(seconds))", CameraProperty.Exposure_lgSec }, 
                    { "Iris (10f)", CameraProperty.Iris_10f }, 
                    { "Focal Length (mm)", CameraProperty.FocalLength_mm }, 
                    { "Flash", CameraProperty.Flash }, 
                    { "Brightness", CameraProperty.Brightness }, 
                    { "Contrast", CameraProperty.Contrast }, 
                    { "Hue", CameraProperty.Hue }, 
                    { "Saturation", CameraProperty.Saturation }, 
                    { "Sharpness", CameraProperty.Sharpness }, 
                    { "Gamma", CameraProperty.Gamma }, 
                    { "Color Enable", CameraProperty.ColorEnable }, 
                    { "White Balance", CameraProperty.WhiteBalance }, 
                    { "Backlight Compensation", CameraProperty.BacklightCompensation }, 
                    { "Gain", CameraProperty.Gain }, 
                 };

                return displayPropertyValues;
            }
        }

        private IDictionary<CameraProperty, CameraPropertyCapabilities> CurrentCameraPropertyCapabilities
        {
            get;
            set;
        }

        private IDictionary<CameraProperty, CameraPropertyRange> CurrentCameraPropertyRanges
        {
            get;
            set;
        }

        //private CameraProperty SelectedCameraProperty
        //{
        //    get
        //    {
        //        Int32 selectedIndex = cameraPropertyValue.SelectedIndex;
        //        String selectedItem = cameraPropertyValue.Items[selectedIndex] as String;

        //        CameraProperty result = DisplayPropertyValues[selectedItem];
        //        return result;
        //    }
        //}

        private Boolean IsSelectedCameraPropertySupported
        {
            get;
            set;
        }      

        private Boolean SuppressCameraPropertyValueValueChangedEvent
        {
            get;
            set;
        }

        private Boolean CameraPropertyControlInitializationComplete
        {
            get;
            set;
        }

        private void InitializeCameraPropertyControls()
        {
            try
            {
                CameraPropertyControlInitializationComplete = false;

                CurrentCameraPropertyCapabilities = CurrentCamera.CameraPropertyCapabilities;
                CurrentCameraPropertyRanges = new Dictionary<CameraProperty, CameraPropertyRange>();

                CameraPropertyControlInitializationComplete = true;

                _IsSuccess = true;
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message.ToString();
                _IsSuccess = false;
            }
            
        }

        private void UpdateCameraPropertyRange(CameraPropertyCapabilities propertyCapabilities, CameraProperty property)
        {
            String text;
            if (IsSelectedCameraPropertySupported && propertyCapabilities.IsGetRangeSupported && propertyCapabilities.IsGetSupported)
            {
                CameraPropertyRange range = CurrentCamera.GetCameraPropertyRange(property);
                text = String.Format("[ {0}, {1} ], step: {2}", range.Minimum, range.Maximum, range.Step);

                //Int32 decimalPlaces = 0;
                Decimal minimum = range.Minimum;
                Decimal maximum = range.Maximum;
                Decimal increment = range.Step;

                if (CurrentCameraPropertyRanges.ContainsKey(property))
                    CurrentCameraPropertyRanges[property] = range;
                else
                    CurrentCameraPropertyRanges.Add(property, range);

                CameraPropertyValue value = CurrentCamera.GetCameraProperty(property, true);

                SuppressCameraPropertyValueValueChangedEvent = true;               
                SuppressCameraPropertyValueValueChangedEvent = false;
            }
            else
                text = "N/A";          
        }

        //private void cameraPropertyValueTypeSelection_SelectedIndexChanged(Object sender, EventArgs e)
        //{
        //    if (CameraPropertyControlInitializationComplete)
        //    {
        //        CameraPropertyCapabilities propertyCapabilities = CurrentCameraPropertyCapabilities[SelectedCameraProperty];

        //        CameraPropertyRange range = CurrentCameraPropertyRanges[SelectedCameraProperty];

        //        Decimal previousValue = cameraPropertyValueValue.Value;

        //        UpdateCameraPropertyRange(propertyCapabilities);

        //        Decimal newValue;
        //        if (IsCameraPropertyValueTypeValue) // The previous value was a percentage.
        //            newValue = range.DomainSize * previousValue / 100 + range.Minimum;
        //        else if (IsCameraPropertyValueTypePercentage) // The previous value was a value.
        //            newValue = (previousValue - range.Minimum) * 100 / range.DomainSize;
        //        else
        //            throw new NotSupportedException(String.Format("Camera property value type '{0}' is not supported.", (String)cameraPropertyValueTypeSelection.SelectedItem));

        //        newValue = Math.Round(newValue);

        //        if (newValue > range.Maximum)
        //            newValue = range.Maximum;
        //        else if (newValue < range.Minimum)
        //            newValue = range.Minimum;

        //        SuppressCameraPropertyValueValueChangedEvent = true;
        //        cameraPropertyValueValue.Value = newValue;
        //        SuppressCameraPropertyValueValueChangedEvent = false;
        //    }
        //}

                 
        public void hScrollBarBrightness_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (CameraPropertyControlInitializationComplete && !SuppressCameraPropertyValueValueChangedEvent)
            {
                CameraPropertyValue value = new CameraPropertyValue(false, e.NewValue, false);
                CurrentCamera.SetCameraProperty(CameraProperty.Brightness, value);              
            }
        }

        public void hScrollBarSharpness_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (CameraPropertyControlInitializationComplete && !SuppressCameraPropertyValueValueChangedEvent)
            {
                CameraPropertyValue value = new CameraPropertyValue(false, e.NewValue, false);
                CurrentCamera.SetCameraProperty(CameraProperty.Sharpness, value);             
            }
        }

        public void hScrollBarZoom_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            if (CameraPropertyControlInitializationComplete && !SuppressCameraPropertyValueValueChangedEvent)
            {
                CameraPropertyValue value = new CameraPropertyValue(false, e.NewValue, false);
                CurrentCamera.SetCameraProperty(CameraProperty.Zoom_mm, value);              
            }
        }   
      
    }
}
