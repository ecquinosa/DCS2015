
using System;
using System.Data;
using System.Drawing;
using Neurotec;
using Neurotec.Biometrics;
using Neurotec.Biometrics.Gui;
using Neurotec.Biometrics.Tools;
using Neurotec.Biometrics.Standards;
using Neurotec.Devices;
using Neurotec.Gui;
using Neurotec.Images;
using Neurotec.Licensing;
using Neurotec.IO;
using System.IO;

namespace DCS2015.Class
{
    public class PhotoAnalysis
    {
        private NFPosition NFFingerPosition = NFPosition.Unknown;

        private NImage neuroImage;
        private NImage neuroToken;
        private NleDetectionDetails[] neuroDetectionDetails = null;
        private NLExtractor neuroExtractor;
        private Ntfi neuroTFI;

        private double faceConfidence = 0;

        private bool IsFacePosePassed;
        private bool IsFaceSharpnessPassed;
        private bool IsBackgroundUniformityPassed;
        private bool IsFaceDistancePassed;
        private bool IsFaceCenterPassed;

        private bool IsFaceDetected;
        private bool _IsCameraCanonEOS;

        private string _faceCentering = "Face Centering";
        private string _faceSharpness = "Face Sharpness";
        private string _faceDistance = "Face Distance";
        private string _facePose = "Face Pose";
        private string _BackgroundUniformity = "Background Uniformity";
        
        private string _faceConfidenceDetail;
        private string _faceErectDetail;
        private string _eyeConfidenceDetail;
        private string _headPitchDetail;
        private string _headRollDetail;
        private string _headYawDetail;

        private string _FaceWidthAndHeight;

        private string _globalScore;

        private string _BGUniformityDetail;
        private string _SharpnessDetail;
        private string _GrayDensityDetail;
                  
        private DataTable facePointsTable = new DataTable();        

        private Rectangle RightEye;
        private Rectangle LeftEye;
        private Rectangle Nose;
        private Rectangle Mouth;

        //private double globalquality = 0;
        //private bool OverrideChecking = false;

        public enum PhotoProperty : short
        {             
            FaceDetected=1,
            FaceCentering,
            FaceDistance,
            BackgroundUniformity,
            FaceSharpness,
            FacePose,
            FaceConfidence,
            FaceRectangleSize,
            EyeConfidence,
            BGUniformity,
            Sharpness,
            GrayDensity,
            HeadPitch,
            HeadRoll,
            HeadYaw,
            FaceWidthAndHeight,
            PhotoScore
        }

        public string FaceDetected
        {
            get { return IsFaceDetected.ToString(); }
        }

        public string FaceCentering
        {
            get { return _faceCentering; }
        }

        public string FaceSharpness
        {
            get { return _faceSharpness; }
        }

        public string FaceDistance
        {
            get { return _faceDistance; }
        }

        public string FacePose
        {
            get { return _facePose; }
        }

        public string BackgroundUniformity
        {
            get { return _BackgroundUniformity; }
        }

        public string FaceConfidenceDetail
        {
            get { return _faceConfidenceDetail; }
        }

        public string FaceErectDetail
        {
            get { return _faceErectDetail; }
        }

        public string EyeConfidenceDetail
        {
            get { return _eyeConfidenceDetail; }
        }

        public string HeadRollDetail
        {
            get { return _headRollDetail; }
        }

        public string HeadPitchDetail
        {
            get { return _headPitchDetail; }
        }

        public string HeadYawDetail
        {
            get { return _headYawDetail; }
        }

        public string BGUniformityDetail
        {
            get { return _BGUniformityDetail; }
        }

        public string SharpnessDetail
        {
            get { return _SharpnessDetail; }
        }

        public string GrayDensityDetail
        {
          get { return _GrayDensityDetail; }            
        }

        public string GlobalScore
        {
            get { return _globalScore; }
        }

        public string FaceWidthAndHeight
        {
            get { return _FaceWidthAndHeight ; }
        }

        //public bool CameraCanonEOS
        //{
        //    get { return IsCameraCanonEOS; }
        //}       

        public bool IsCameraCanonEOS
        {
            get { return _IsCameraCanonEOS; }
            set { _IsCameraCanonEOS = value; }
        }

        private void DefaultAnalysis()
        {
           IsFaceCenterPassed = false;            
            _faceCentering = "Face Centering";

            IsFaceSharpnessPassed = false;            
            _faceSharpness = "Face Sharpness";

            IsBackgroundUniformityPassed = false;
            _BackgroundUniformity = "Background Uniformity";

            IsFaceDistancePassed = false;
            _faceDistance = "Face Distance";

            IsFacePosePassed = false;
            _facePose = "Face Pose";
        }

        private void SetFacePointsColumn()
        {
            if (facePointsTable.Columns.Count == 0)
            {
                facePointsTable.Columns.Add("CaptureIndex");
                facePointsTable.Columns.Add("RigthEyeX");
                facePointsTable.Columns.Add("RigthEyeY");
                facePointsTable.Columns.Add("LeftEyeX");
                facePointsTable.Columns.Add("LeftEyeY");
                facePointsTable.Columns.Add("NoseX");
                facePointsTable.Columns.Add("NoseY");
                facePointsTable.Columns.Add("MouthX");
                facePointsTable.Columns.Add("MouthY");
                facePointsTable.Columns.Add("FaceConfidence");
                facePointsTable.Columns.Add("FaceRectangleX");
                facePointsTable.Columns.Add("FaceRectangleY");
                facePointsTable.Columns.Add("FaceRectangleH");
                facePointsTable.Columns.Add("FaceRectangleW");
                facePointsTable.Columns.Add("LeftEyeConfidence");
                facePointsTable.Columns.Add("RightEyeConfidence");
                facePointsTable.Columns.Add("FaceRoll");
                facePointsTable.Columns.Add("FacePitch");
                facePointsTable.Columns.Add("FaceYaw");
                facePointsTable.Columns.Add("GlobalScore");
            }
        }

        public void UpdateScore(Bitmap capturedBitmap)
        {
            try
            {
                ObtainLicense();

                Bitmap bitmap = capturedBitmap;

                if (bitmap != null)
                {
                    neuroImage = NImage.FromBitmap(bitmap);
                    NGrayscaleImage neuroGrayScaleImage = neuroImage.ToGrayscale();
                    neuroDetectionDetails = DetectFaceDetails(neuroGrayScaleImage);

                    neuroExtractor.FavorLargestFace = true;
                    neuroExtractor.DetectAllFeaturePoints = true;
                    neuroExtractor.MaxRollAngleDeviation = Convert.ToInt16(30);
                    neuroExtractor.MaxYawAngleDeviation = Convert.ToInt16(30);
                    //_extractor.LivenessThreshold = 50
                    //_extractor.FaceConfidenceThreshold = 50
                    //_extractor.FaceQualityThreshold = 50
                    neuroExtractor.UseLivenessCheck = true;
                    neuroExtractor.MinIod = 90;

                    NleFace neuroFace;
                    bool isFaceDetected = neuroExtractor.DetectFace(neuroGrayScaleImage, out neuroFace);

                    if (isFaceDetected)
                    {
                        if (neuroDetectionDetails.Length != 0)
                        {
                            RightEye = new Rectangle(neuroDetectionDetails[0].RightEyeCenter.X, neuroDetectionDetails[0].RightEyeCenter.Y, 3, 3);
                            LeftEye = new Rectangle(neuroDetectionDetails[0].LeftEyeCenter.X, neuroDetectionDetails[0].LeftEyeCenter.Y, 3, 3);
                            Nose = new Rectangle(neuroDetectionDetails[0].NoseTip.X, neuroDetectionDetails[0].NoseTip.Y, 3, 3);
                            Mouth = new Rectangle(neuroDetectionDetails[0].MouthCenter.X, neuroDetectionDetails[0].MouthCenter.Y, 3, 3);

                            faceConfidence = neuroDetectionDetails[0].Face.Confidence;

                            _faceConfidenceDetail = faceConfidence.ToString();
                            _faceErectDetail = string.Format("X= {0}, Y= {1} H= {2} W= {3}", neuroDetectionDetails[0].Face.Rectangle.X, neuroDetectionDetails[0].Face.Rectangle.Y, neuroDetectionDetails[0].Face.Rectangle.Height, neuroDetectionDetails[0].Face.Rectangle.Width);
                            _eyeConfidenceDetail = string.Format("Right = {0}, Left = {1}", neuroDetectionDetails[0].RightEyeCenter.Confidence, neuroDetectionDetails[0].LeftEyeCenter.Confidence);
                            _headRollDetail = neuroDetectionDetails[0].Face.Rotation.Roll.ToString();
                            _headPitchDetail = neuroDetectionDetails[0].Face.Rotation.Pitch.ToString();
                            _headYawDetail = neuroDetectionDetails[0].Face.Rotation.Yaw.ToString();

                            NImage neuroImageValue = NImage.FromBitmap(bitmap);
                            neuroTFI = new Ntfi() { SharpnessThreshold = 0.3, TokenFaceImageWidth = 480, UseLightnessNormalization = true };
                            neuroToken = neuroTFI.CreateTokenFaceImage(neuroImage, new Point(Convert.ToInt32(neuroDetectionDetails[0].RightEyeCenter.X), Convert.ToInt32(neuroDetectionDetails[0].RightEyeCenter.Y)), new Point(neuroDetectionDetails[0].LeftEyeCenter.X, neuroDetectionDetails[0].LeftEyeCenter.Y));                            
                            NtfiAttributes neuroAttributes = null;

                            //double globalScore = neuroTFI.TestTokenFaceImage(neuroToken, out neuroAttributes);
                            _globalScore = neuroTFI.TestTokenFaceImage(neuroToken, out neuroAttributes).ToString();

                            _BGUniformityDetail = neuroAttributes.BackgroundUniformity.ToString();
                            _SharpnessDetail = neuroAttributes.Sharpness.ToString();
                            _GrayDensityDetail = neuroAttributes.GrayscaleDensity.ToString();

                           //if (!OverrideChecking)
                           // {
                           //     _globalScore = (((((Convert.ToDouble(_BGUniformityDetail)) + (Convert.ToDouble(_SharpnessDetail)) + Convert.ToDouble(_GrayDensityDetail)) / 3) * 100) + 5).ToString();
                           // }                         

                            string detectionMessage = string.Empty;

                            if (_IsCameraCanonEOS)
                            {
                                // --- FACE DISTANCE ---
                                int intFaceWidth = neuroDetectionDetails[0].Face.Rectangle.Width;
                                int intFaceHeight = neuroDetectionDetails[0].Face.Rectangle.Height;

                                _FaceWidthAndHeight = string.Format("{0},{1}-(Min {2}, Max {3})", intFaceWidth.ToString(), intFaceHeight.ToString(), Properties.Settings.Default.FaceDistance_Min.ToString(), Properties.Settings.Default.FaceDistance_Max.ToString());
                                
                                if (Face.CheckDistance(intFaceWidth, intFaceHeight, Properties.Settings.Default.FaceDistance_Min, Properties.Settings.Default.FaceDistance_Max, ref detectionMessage))                                                             
                                    _faceDistance = string.Format("Passed"); else _faceDistance = string.Format("{0}", detectionMessage);                                
                            }
                            else
                            {
                                int intFaceWidth = neuroDetectionDetails[0].Face.Rectangle.Width;
                                int intFaceHeight = neuroDetectionDetails[0].Face.Rectangle.Height;

                                _FaceWidthAndHeight = string.Format("{0},{1}-(Min {2}, Max {3})", intFaceWidth.ToString(), intFaceHeight.ToString(), Properties.Settings.Default.FaceDistance_Min.ToString(), Properties.Settings.Default.FaceDistance_Max.ToString());

                                //if (Face.CheckDistance(intFaceWidth, intFaceHeight, 175, 350, ref detectionMessage))
                                if (Face.CheckDistance(intFaceWidth, intFaceHeight, Properties.Settings.Default.FaceDistance_Min, Properties.Settings.Default.FaceDistance_Max, ref detectionMessage))
                                    _faceDistance = string.Format("Passed"); else _faceDistance = string.Format("{0}", detectionMessage);                            

                                ////if (Face.CheckDistance(neuroDetectionDetails[0].Face.Rectangle.Width, neuroDetectionDetails[0].Face.Rectangle.Height, 65, 85, ref detectionMessage))
                                //if (Face.CheckDistance(neuroDetectionDetails[0].Face.Rectangle.Width, neuroDetectionDetails[0].Face.Rectangle.Height, 175, 350, ref detectionMessage))
                                //{
                                //    _faceDistance = "Passed";
                                //}
                                //else
                                //{
                                //    _faceDistance = string.Format("{0}", detectionMessage);
                                //}
                            }

                            // --- FACE CENTERING ---
                            if (Face.CheckFaceCentering(neuroDetectionDetails[0].Face.Rectangle.X, neuroDetectionDetails[0].Face.Rectangle.Y, bitmap, ref detectionMessage))
                                _faceCentering = "Passed"; else _faceCentering = string.Format("{0}", detectionMessage);
                            

                            // --- BACKGROUND UNIFORMITY ---
                            //if (((neuroAttributes.BackgroundUniformity * 100) >= 20) && ((neuroAttributes.BackgroundUniformity * 100) <= 100))
                            if (((neuroAttributes.BackgroundUniformity * 100) >= Properties.Settings.Default.BGUniformityMin) && ((neuroAttributes.BackgroundUniformity * 100) <= Properties.Settings.Default.BGUniformityMax))                            
                                _BackgroundUniformity = "Passed"; else _BackgroundUniformity = "Not passed";
                            

                            // --- FACE POSE ---
                            if (neuroDetectionDetails[0].Face.Rotation.Roll >= -3 && neuroDetectionDetails[0].Face.Rotation.Roll <= 3)                            
                                _facePose = "Passed"; else _facePose = "Not passed";                            

                            //// --- BACKGROUND UNIFORMITY ---
                            //if ((neuroAttributes.BackgroundUniformity * 100) >= Properties.Settings.Default.PhotoMinBackgroundUniformity && (neuroAttributes.BackgroundUniformity * 100) <= Properties.Settings.Default.PhotoMaxBackgroundUniformity)
                            //{
                            //    labelBGUniformity.ForeColor = Color.Green;
                            //    pbBGUniformity.Image = imageListAnalysis.Images[1];
                            //}
                            //else
                            //{
                            //    labelBGUniformity.ForeColor = Color.Red;
                            //    pbBGUniformity.Image = imageListAnalysis.Images[0];
                            //}

                            // --- FACE SHARPNESS ---
                            //if ((neuroAttributes.Sharpness * 100) >= 20 && (neuroAttributes.Sharpness * 100) <= 100)
                            if ((neuroAttributes.Sharpness * 100) >= Properties.Settings.Default.SharpnessMin && (neuroAttributes.Sharpness * 100) <= Properties.Settings.Default.SharpnessMax)
                                _faceSharpness = "Passed"; else _faceSharpness = "Not passed";                            

                            IsFaceDetected = true;
                        }
                    }
                    else
                    {
                        IsFaceDetected = false;
                        _globalScore = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private NleDetectionDetails[] DetectFaceDetails(NGrayscaleImage neuroGrayScaleImage)
        {
            try
            {
                neuroExtractor = new NLExtractor();

                if (neuroGrayScaleImage != null)
                {
                    neuroExtractor.MaxRollAngleDeviation = (short)30;
                    neuroExtractor.MaxYawAngleDeviation = (short)30;
                    neuroExtractor.MaxRecordsPerTemplate = 1;
                    neuroExtractor.DetectAllFeaturePoints = true;
                    neuroExtractor.FavorLargestFace = true;
                    neuroExtractor.UseLivenessCheck = true;                    

                    NleFace[] neuroFaces = neuroExtractor.DetectFaces(neuroGrayScaleImage.ToGrayscale());
                    NleDetectionDetails[] detectionDetails = new NleDetectionDetails[neuroFaces.Length];

                    for (int counter = 0; counter < detectionDetails.Length; counter++)
                        detectionDetails[counter] = neuroExtractor.DetectFacialFeatures(neuroGrayScaleImage, neuroFaces[counter]);
                    return detectionDetails;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string PhotoField(short i)
        { 
            switch((PhotoProperty)i)
            {
                case PhotoProperty.FaceDetected:
                    return "Face Detected";                   
                case PhotoProperty.FaceCentering:
                    return "Face Centering";                    
                case PhotoProperty.FaceDistance:
                    return "Face Distance";                    
                case PhotoProperty.BackgroundUniformity:
                    return "Background Uniformity";                   
                case PhotoProperty.FaceSharpness:
                    return "Face Sharpness";                    
                case PhotoProperty.FacePose:
                    return "Face Pose";                   
                case PhotoProperty.FaceConfidence:
                    return "Face Confidence";                    
                case PhotoProperty.FaceRectangleSize:
                    return "Face Rectangle Size";                   
                case PhotoProperty.EyeConfidence:
                    return "Eye Confidence";                   
                case PhotoProperty.BGUniformity:
                    return "BG Uniformity";                    
                case PhotoProperty.Sharpness:
                    return "Sharpness";                    
                case PhotoProperty.GrayDensity:
                    return "Gray Density";                    
                case PhotoProperty.HeadPitch:
                    return "Head Pitch";                    
                case PhotoProperty.HeadRoll:
                    return "Head Roll";                    
                case PhotoProperty.HeadYaw:
                    return "Head Yaw";
                case PhotoProperty.FaceWidthAndHeight:
                    return "Face Width/ Height";     
                case PhotoProperty.PhotoScore:
                    return "Score";                    
                default:
                    return "";                    
            }
        }

        private static string[] components = new string[] { "Biometrics.FingerDetection", "Devices.FingerScanners", "Biometrics.FingerExtraction", "Biometrics.FingerMatching", "Biometrics.Standards.Faces", "Biometrics.FaceDetection", "Biometrics.FaceSegmentation", "Biometrics.FaceQualityAssessment" };

        public static bool ObtainLicense()
        {
            try
            {
                bool obtained = false;
                foreach (string component in components)
                    obtained = obtained | NLicense.ObtainComponents(@"/local", 5000, component);

                if (!obtained)
                    throw new Exception(string.Format("Unable to obtain licenses from any components{0}", components));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //private static string[] componentsWSQ = new string[] { "FacesExtractor", "FacesBSS" };
        private static string[] componentsWSQ = new string[] { "Images.WSQ" };

        public static bool ObtainLicenseWSQ()
        {
            try
            {
                bool obtained = false;
                foreach (string component in componentsWSQ)
                    obtained = obtained | NLicense.ObtainComponents(@"/local", 5000, component);                

                if (!obtained)
                    throw new Exception(string.Format("Unable to obtain licenses from any components{0}", componentsWSQ));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SaveToWSQ(Bitmap image, string strFilename)
        {
            try
            {
                ObtainLicenseWSQ();
                NImage wsq = NImage.FromBitmap(image);
                wsq.Save(strFilename, NImageFormat.Wsq);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                ReleaseLicenseWSQ();
            }
        }
    

        public static void ReleaseLicenseWSQ()
        {
            try
            {
                foreach (string component in componentsWSQ)
                    NLicense.ReleaseComponents(component);
            }
            catch (Exception)
            {
                throw new Exception("Unable to release license");
            }
        }

        public static void ReleaseLicense()
        {
            try
            {
                foreach (string component in components)
                    NLicense.ReleaseComponents(component);

            }
            catch (Exception)
            {
                throw new Exception("Unable to release license");
            }
        }

        internal Neurotec.Biometrics.Gui.NLView facesView;


        public void Convert_TO_ICAO_Test(string strFile, Size photoSize, ref string icaoPhoto, ref string _ntfiAttributes)
        {
            try
            {
                icaoPhoto = strFile.Replace(".jpg", "_icao.jpg");
                facesView = new Neurotec.Biometrics.Gui.NLView();                
                
                this.facesView.BackColor = System.Drawing.Color.White;
                this.facesView.DetectionDetails = null;
                this.facesView.FaceIds = null;
                this.facesView.FaceRectangleColor = System.Drawing.Color.LimeGreen;                
                this.facesView.Name = "facesView";
                
                this.facesView.Size = new System.Drawing.Size(photoSize.Width, photoSize.Height);                

                ObtainLicense();

                NLExtractor _extractor = new NLExtractor();
                Ntfi ntfi = new Ntfi();

                FileStream fs = new FileStream(strFile, FileMode.Open);
                Bitmap bitmap = (Bitmap)Image.FromStream(fs);
                NImage img = NImage.FromBitmap(bitmap);
                fs.Close();

                NImage displayIMG = NImage.FromBitmap(Resizeimage(strFile));                

                _extractor.FavorLargestFace = true;
                _extractor.DetectAllFeaturePoints = true;
                _extractor.MaxRollAngleDeviation = Convert.ToInt16(30);
                _extractor.MaxYawAngleDeviation = Convert.ToInt16(30);                
                _extractor.UseLivenessCheck = true;
                _extractor.MinIod = 90;

                facesView.Visible = true;
                facesView.Image = displayIMG.ToBitmap();

                using (NGrayscaleImage grayscaleImage = img.ToGrayscale())
                {
                    //Dim status As NleExtractionStatus
                    NleDetectionDetails[] details = null;
                    NleDetectionDetails[] details1 = null;

                    NleFace face = default(NleFace);
                    bool isfacedetected = _extractor.DetectFace(grayscaleImage, out face);                    

                    //NleExtractionStatus dtstatus = NleExtractionStatus.None;

                    details = DetectFaceDetails(displayIMG.ToGrayscale());
                    details1 = DetectFaceDetails(grayscaleImage);                    

                    ntfi.SharpnessThreshold = 0.3;
                    ntfi.TokenFaceImageWidth = photoSize.Width;                    
                    ntfi.UseLightnessNormalization = true;

                    //neuroToken = neuroTFI.CreateTokenFaceImage(neuroImage, new Point(Convert.ToInt32(neuroDetectionDetails[0].RightEyeCenter.X), Convert.ToInt32(neuroDetectionDetails[0].RightEyeCenter.Y)), new Point(neuroDetectionDetails[0].LeftEyeCenter.X, neuroDetectionDetails[0].LeftEyeCenter.Y));                                                
                    NImage token;                    
                    token = ntfi.CreateTokenFaceImage(img, new Point(details1[0].RightEyeCenter.X, details1[0].RightEyeCenter.Y), new Point(details1[0].LeftEyeCenter.X, details1[0].LeftEyeCenter.Y));
                    Neurotec.Biometrics.Tools.NtfiAttributes ntfiAttributes = null;
                    double quality = ntfi.TestTokenFaceImage(token, out ntfiAttributes);

                    DCS_MemberInfo.Data.PhotoScore = quality;

                    _ntfiAttributes = ntfiAttributes.BackgroundUniformity.ToString() + "|" + ntfiAttributes.Sharpness.ToString() + "|" + ntfiAttributes.GrayscaleDensity.ToString() + "|" + quality.ToString();

                    facesView.DetectionDetails = details;                    
                    token.Save(icaoPhoto, NImageFormat.Jpeg);
                    System.Threading.Thread.Sleep(2000);                    
                }               

                img.Dispose();
                _extractor.Dispose();
            }
            catch (Exception ex)
            {                
                Class.Utilities.SaveToErrorLog(Class.Utilities.TimeStamp() + "Convert_TO_ICAO(): " + ex.Message);
            }
            finally
            {
                ReleaseLicense();
            }

        }

        public void Convert_TO_ICAO(ref string _ntfiAttributes)
        {
            try
            {
                string strFile = DCS_MemberInfo.Data.PhotoRawFile;
                facesView = new Neurotec.Biometrics.Gui.NLView();
                
                this.facesView.BackColor = System.Drawing.Color.White;
                this.facesView.DetectionDetails = null;
                this.facesView.FaceIds = null;
                this.facesView.FaceRectangleColor = System.Drawing.Color.LimeGreen;                
                this.facesView.Name = "facesView";                
                this.facesView.Size = new System.Drawing.Size(480, 640);                

                ObtainLicense();

                NLExtractor _extractor = new NLExtractor();
                Ntfi ntfi = new Ntfi();

                FileStream fs = new FileStream(strFile, FileMode.Open);
                Bitmap bitmap = (Bitmap)Image.FromStream(fs);
                NImage img = NImage.FromBitmap(bitmap);
                fs.Close();

                NImage displayIMG = NImage.FromBitmap(Resizeimage(strFile));

                _extractor.FavorLargestFace = true;
                _extractor.DetectAllFeaturePoints = true;
                _extractor.MaxRollAngleDeviation = Convert.ToInt16(30);
                _extractor.MaxYawAngleDeviation = Convert.ToInt16(30);                
                _extractor.UseLivenessCheck = true;
                _extractor.MinIod = 90;

                facesView.Visible = true;
                facesView.Image = displayIMG.ToBitmap();

                using (NGrayscaleImage grayscaleImage = img.ToGrayscale())
                {
                    //Dim status As NleExtractionStatus
                    NleDetectionDetails[] details = null;
                    NleDetectionDetails[] details1 = null;

                    NleFace face = default(NleFace);
                    bool isfacedetected = _extractor.DetectFace(grayscaleImage, out face);

                    //NleExtractionStatus dtstatus = NleExtractionStatus.None;

                    details = DetectFaceDetails(displayIMG.ToGrayscale());
                    details1 = DetectFaceDetails(grayscaleImage);

                    ntfi.SharpnessThreshold = 0.3;
                    ntfi.TokenFaceImageWidth = 480;
                    ntfi.UseLightnessNormalization = true;
                    
                    NImage token;
                    token = ntfi.CreateTokenFaceImage(img, new Point(details1[0].RightEyeCenter.X, details1[0].RightEyeCenter.Y), new Point(details1[0].LeftEyeCenter.X, details1[0].LeftEyeCenter.Y));
                    Neurotec.Biometrics.Tools.NtfiAttributes ntfiAttributes = null;
                    double quality = ntfi.TestTokenFaceImage(token, out ntfiAttributes);

                    DCS_MemberInfo.Data.PhotoScore = quality;

                    _ntfiAttributes = ntfiAttributes.BackgroundUniformity.ToString() + "|" + ntfiAttributes.Sharpness.ToString() + "|" + ntfiAttributes.GrayscaleDensity.ToString() + "|" + quality.ToString();

                    facesView.DetectionDetails = details;
                    DCS_MemberInfo.Data.PhotoICAOFile = string.Format(@"{0}\{1}", Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.PhotoFinal_FileName);
                    token.Save(DCS_MemberInfo.Data.PhotoICAOFile, NImageFormat.Jpeg);
                    System.Threading.Thread.Sleep(2000);
                }

                img.Dispose();
                _extractor.Dispose();
            }
            catch (Exception ex)
            {
                Class.Utilities.SaveToErrorLog(Class.Utilities.TimeStamp() + "Convert_TO_ICAO(): " + ex.Message);
            }
            finally
            {
                ReleaseLicense();
            }

        }

        public Bitmap Resizeimage(string strFile)
        {
            FileStream fs = new FileStream(strFile, FileMode.Open);	        
            Bitmap img = (Bitmap)Image.FromStream(fs);

	        int x = 0;
	        int y = 0;
	        int imgw = 0;
	        int imgh = 0;
	        int imghPercent = 0;
	        int imgwPercent = 0;

	        if (img.Height > facesView.Height) {
		        imghPercent = ((img.Height - facesView.Height) / img.Height) * 100;
	        }

	        if (img.Height > facesView.Height) {
		        imgwPercent = ((img.Width - facesView.Width) / img.Width) * 100;
	        }

	        if (imghPercent > imgwPercent) {
		        imgw = img.Width - ((img.Width / 100) * imghPercent);
		        imgh = img.Height - ((img.Height / 100) * imghPercent);
	        } else {
		        imgw = img.Width - ((img.Width / 100) * imgwPercent);
		        imgh = img.Height - ((img.Height / 100) * imgwPercent);
	        }

	        if (imgw < facesView.Width) {
		        x = (facesView.Width / 2) - (imgw / 2);
	        }
	        if (imgh < facesView.Height) {
		        y = (facesView.Height / 2) - (imgh / 2);
	        }

	        Bitmap bmp = new Bitmap(facesView.Width, facesView.Height);

	        Graphics g = Graphics.FromImage(bmp);
	        fs.Close();
	        g.FillRectangle(Brushes.White, 0, 0, facesView.Width, facesView.Height);
	        //g.DrawRectangle(Pens.Red, 0, 0, rect.Width, rect.Height)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
	        g.DrawImage(img, x, y, imgw, imgh);            
            return bmp;    
        }

        public Bitmap Resizeimage_2x2(string strFile)
        {
            FileStream fs = new FileStream(strFile, FileMode.Open);            
            Bitmap img = (Bitmap)Image.FromStream(fs);

            int x = 0;
            int y = 0;
            int imgw = 0;
            int imgh = 0;
            int imghPercent = 0;
            int imgwPercent = 0;

            if (img.Height > 600)
            {
                imghPercent = ((img.Height - 600) / img.Height) * 100;
            }

            if (img.Height > 600)
            {
                imgwPercent = ((img.Width - 600) / img.Width) * 100;
            }

            if (imghPercent > imgwPercent)
            {
                imgw = img.Width - ((img.Width / 100) * imghPercent);
                imgh = img.Height - ((img.Height / 100) * imghPercent);
            }
            else
            {
                imgw = img.Width - ((img.Width / 100) * imgwPercent);
                imgh = img.Height - ((img.Height / 100) * imgwPercent);
            }

            if (imgw < 600)
            {
                x = (600 / 2) - (imgw / 2);
            }
            if (imgh < 600)
            {
                y = (600 / 2) - (imgh / 2);
            }

            Bitmap bmp = new Bitmap(600, 600);

            Graphics g = Graphics.FromImage(bmp);
            fs.Close();
            g.FillRectangle(Brushes.White, 0, 0, 600, 600);            
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.DrawImage(img, x, y, imgw, imgh);
            return bmp;
        }

        public static bool DrawScoreToFingerPrintImage(string wsqFile)
        {
            ObtainLicense();

            FileStream fs = new FileStream(wsqFile,FileMode.Open);
            NImage _NImage = NImage.FromStream(fs);
            NGrayscaleImage imggrayscale = null;
            using(_NImage)
            {
                if(_NImage!=null)
                {
                    Single horzResolution = _NImage.HorzResolution;
                    Single vertResolution = _NImage.VertResolution;
                    if(horzResolution < 250)_NImage.HorzResolution = 500;                    
                    if(vertResolution < 250)_NImage.VertResolution = 500;
                    imggrayscale = _NImage.ToGrayscale();
                }
            }

            fs.Close();
            fs.Dispose();
            fs = null;

            ////FileStream fss = new FileStream(".bmp", FileMode.Open);
            ////Bitmap img = new Bitmap(fss);
            ////fss.Close();
            ////fss.Dispose();
            ////fs.Close();

            ////NFExtractor extractor = null;
            ////NfeExtractionStatus status;
            ////NFRecord record = null;

            ////record = extractor.Extract(imggrayscale, NFFingerPosition, NFImpressionType.LatentPhoto, out status);

            FileStream fs1 = new FileStream(wsqFile, FileMode.Open);
            NGrayscaleImage NgrayScaleImg = NImage.FromStream(fs1).ToGrayscale();            

            //If FPQuality > 120 Then FPQuality = 120
            var NFIQScore1 = Nfiq.Compute(NgrayScaleImg);

            int NFIQValue = 0;
            switch(NFIQScore1)
            {
                case NfiqQuality.Excellent:
                    NFIQValue = 1;
                    break;
                case NfiqQuality.VeryGood:
                    NFIQValue = 2;
                    break;
                case NfiqQuality.Good:
                    NFIQValue = 3;
                    break;
                case NfiqQuality.Fair:
                    NFIQValue = 4;
                    break;
                case NfiqQuality.Poor:
                    NFIQValue = 5;
                    break;                

            }

            System.Windows.Forms.MessageBox.Show("NFIQ: " + NFIQValue.ToString());

            return true;
        }

        


        //public void Teamplate_Showdetails()
        //{
        //    facesView.ShowEyes = true;
        //    //lblstatus.Text = "Processing"
        //    //ProgressBar1.Value += 1
        //    System.Threading.Thread.Sleep(500);
        //    facesView.Refresh();

        //    facesView.ShowEyesConfidence = true;
        //    //ProgressBar1.Value += 1
        //    System.Threading.Thread.Sleep(500);
        //    facesView.Refresh();
        //    //facesView.ShowFaceConfidence = True
        //    //ProgressBar1.Value += 1
        //    //delay()
        //    facesView.ShowMouth = true;
        //    //ProgressBar1.Value += 1
        //    System.Threading.Thread.Sleep(500);
        //    facesView.Refresh();
        //    facesView.ShowMouthConfidence = true;
        //    //ProgressBar1.Value += 1
        //    System.Threading.Thread.Sleep(500);
        //    facesView.Refresh();
        //    facesView.ShowNose = true;
        //    //ProgressBar1.Value += 1
        //    System.Threading.Thread.Sleep(500);
        //    facesView.Refresh();
        //    facesView.ShowNoseConfidence = true;
        //    //lblstatus.Text = "Ready"


        //    facesView.ShowEyes = false;
        //    facesView.ShowEyesConfidence = false;
        //    facesView.ShowFaceConfidence = false;
        //    facesView.ShowMouth = false;
        //    facesView.ShowMouthConfidence = false;
        //    facesView.ShowNose = false;
        //    facesView.ShowNoseConfidence = false;
        //}
    }
}
