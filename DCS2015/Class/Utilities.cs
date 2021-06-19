
using System;
using System.Text;
using System.Drawing;
using System.Management;
using System.Linq;

namespace DCS2015.Class
{
    class Utilities
    {

       public readonly static string MessageBoxHeader = "ALLCARD :: DCS";       

       public static string DataCapturing_ErrorMessage = "";
       public static string PhotoCapturing_ErrorMessage = "";
       public static string SignatureCapturing_ErrorMessage = "";
       public static string BiometricCapturing_ErrorMessage = "";

        public static string CAPTUREDDATA_REPOSITORY = Properties.Settings.Default.CapturedOutputPath; //@"Captured Data";
       public static string CAPTUREDDATA_RAW_REPOSITORY = string.Format(@"{0}\RAW\{1}\{2}", CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"), SessionReference());
       public static string CAPTUREDDATA_FINAL_REPOSITORY="";// = string.Format(@"{0}\FINAL\{1}\{2}", CAPTUREDDATA_REPOSITORY, DateTime.Now.ToString("MMddyyyy"),DCS_MemberInfo.Data.MemberID);

        public static string CAPTUREDDATA_FINAL_PHOTO_REPO = "";
        public static string CAPTUREDDATA_FINAL_SIGNATURE_REPO = "";

        public static string CAPTUREDDATA_SINGLEFILE_REPOSITORY = string.Format(@"{0}\SINGLEFILE", CAPTUREDDATA_REPOSITORY);

        public static string SSV_FORUPLOAD_REPOSITORY = string.Format(@"{0}\SSC_FORUPLOAD", CAPTUREDDATA_REPOSITORY);
        public static string SSV_NOTFORUPLOAD_REPOSITORY = string.Format(@"{0}\SSC_NOTFORUPLOAD", CAPTUREDDATA_REPOSITORY);

        public static System.Collections.Generic.List<string> DeviceManagerList = null;

       //public readonly static string CAPTUREDDATA_RAW_REPOSITORY = string.Format(@"{0}\RAW\", CAPTUREDDATA_REPOSITORY);
       //public readonly static string CAPTUREDDATA_FINAL_REPOSITORY = string.Format(@"{0}\FINAL\", CAPTUREDDATA_REPOSITORY);

       public static string MemberDataXML_FileName = SessionReference() + ".xml";
       public static string MemberDataSingleFile_FileName = SessionReference();

       public static string PhotoRaw_FileName = SessionReference() + "_Raw_Photo.jpg";
       public static string PhotoFinal_FileName = SessionReference() + "_ICAO_Photo.jpg";

       public static string Signature_FileNameTIFF = SessionReference() + "_Signature.tiff";
       public static string Signature_FileNameBMP = SessionReference() + "_Signature.bmp";

        public static string BiometricLeftThumb_FileName = SessionReference() + "_Lbackup";
        public static string BiometricLeftPrimary_FileName = SessionReference() + "_Lprimary";
        public static string BiometricLeftMiddle_FileName = SessionReference() + "_Lmiddle";
        public static string BiometricLeftRing_FileName = SessionReference() + "_Lring";
        public static string BiometricLeftPinky_FileName = SessionReference() + "_Lpinky";

        public static string BiometricRightThumb_FileName = SessionReference() + "_Rbackup";
        public static string BiometricRightPrimary_FileName = SessionReference() + "_Rprimary";
        public static string BiometricRightMiddle_FileName = SessionReference() + "_Rmiddle";
        public static string BiometricRightRing_FileName = SessionReference() + "_Rring";
        public static string BiometricRightPinky_FileName = SessionReference() + "_Rpinky";


        public static string AFPSLAI_SSC_FileName = "";

       public static VIBlend.Utilities.VIBLEND_THEME VIBlendActiveButton = VIBlend.Utilities.VIBLEND_THEME.METROORANGE;
       public static VIBlend.Utilities.VIBLEND_THEME VIBlendNotActiveButton = VIBlend.Utilities.VIBLEND_THEME.OFFICE2010SILVER;

       public static FormTab PreviousTab = FormTab.Data;
       public static FormTab CurrentTab = FormTab.Data;

       public enum FormTab : short
       { 
           Data = 1,
           Photo,
           Biometric,
           Signature,           
           Preview
       }

       public enum SagemFingerID : short
       {
           Amputated=0,
           RightThumb=1,
           RightIndex,
           RightMiddle,
           RightRing,
           RightPinky,
           LeftThumb,
           LeftIndex,
           LeftMiddle,
           LeftRing,
           LeftPinky,
       }

        public enum SplashProcessValidation : short
        {
            MegamatcherLicense=0,
            Camera,
            Biometric,
            TopazSignatureTablet
        }

       public static System.Windows.Forms.DialogResult ShowMessage(string strMsg, System.Windows.Forms.MessageBoxButtons msgBoxBtn, System.Windows.Forms.MessageBoxIcon msgBoxIcn)
       {
           return System.Windows.Forms.MessageBox.Show(strMsg, MessageBoxHeader, msgBoxBtn, msgBoxIcn);
       }

       public static System.Windows.Forms.DialogResult ShowQuestionMessage(string strMsg)
       {
           return System.Windows.Forms.MessageBox.Show(strMsg, MessageBoxHeader, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
       }

       public static System.Windows.Forms.DialogResult ShowInfoMessage(string strMsg)
       {
           return System.Windows.Forms.MessageBox.Show(strMsg, MessageBoxHeader, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
       }

       public static System.Windows.Forms.DialogResult ShowErrorMessage(string strMsg)
       {
           return System.Windows.Forms.MessageBox.Show(strMsg, MessageBoxHeader, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
       }

       public static string TimeStamp()
       {
           return DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt").PadRight(25, ' ');
       }

       public static string SessionReference()
       {
            //return string.Format("{0}_{1}_{2}",Properties.Settings.Default.StationReference.Trim(),DateTime.Now.ToString("yyyyMMdd"),(Properties.Settings.Default.CaptureCntr+1).ToString().PadLeft(4,'0'));
            string _sessionReference = string.Format("{0}_{1}_{2}", Properties.Settings.Default.StationReference.Trim(), DateTime.Now.ToString("yyyyMMdd_hhmmss"), (GetCaptureCntr() + 1).ToString().PadLeft(4, '0'));

            if (System.IO.File.Exists("LastSessionReference"))
           {
                if (System.IO.File.Exists("DraftData")) return System.IO.File.ReadAllText("LastSessionReference");
                else
                {
                    System.IO.File.WriteAllText("LastSessionReference", _sessionReference);
                    return _sessionReference;
                }
           }
           else
           {                
                System.IO.File.WriteAllText("LastSessionReference", _sessionReference);
                return _sessionReference;
           }           
       }

       //public static string LastSessionReference()
       //{
       //    if (System.IO.File.Exists("LastSessionReference"))
       //    {
       //        return System.IO.File.ReadAllText("LastSessionReference");
       //    }
       //    else
       //    {
       //        return SessionReference();
       //    }
       //}

       public static void InitCapturedDataFolder()
       {
           //if (!System.IO.Directory.Exists(CAPTUREDDATA_RAW_REPOSITORY)) System.IO.Directory.CreateDirectory(CAPTUREDDATA_RAW_REPOSITORY);

            switch (DCS_DataCapture.DataCapture.ClientName)
            {                
                case "Philhealth":
                    if (!System.IO.Directory.Exists(CAPTUREDDATA_SINGLEFILE_REPOSITORY)) System.IO.Directory.CreateDirectory(CAPTUREDDATA_SINGLEFILE_REPOSITORY);                    
                    break;
                case "AFPSLAI":
                    if (!System.IO.Directory.Exists(SSV_FORUPLOAD_REPOSITORY)) System.IO.Directory.CreateDirectory(SSV_FORUPLOAD_REPOSITORY);
                    if (!System.IO.Directory.Exists(SSV_NOTFORUPLOAD_REPOSITORY)) System.IO.Directory.CreateDirectory(SSV_NOTFORUPLOAD_REPOSITORY);
                    break;
            }                       
       }

       public static bool IsBiometricTabPassed()
       {
           bool bln = true;

           switch (DCS_DataCapture.DataCapture.ClientName)
           {               
               case "AFPSLAI":
                   if (System.IO.File.Exists("OtherVariable"))
                   {
                       //|Left Index||Left Thumb||Right Index||Right Thumb
                       string[] arr = System.IO.File.ReadAllText("OtherVariable").Split('|');
                       DCS_MemberInfo.Data.LeftPrimaryCode=arr[1];
                       DCS_MemberInfo.Data.LeftThumbCode = arr[3];
                       DCS_MemberInfo.Data.RightPrimaryCode = arr[5];
                       DCS_MemberInfo.Data.RightThumbCode = arr[7];
                   }                   
                   break;
           }                       
           
           if (DCS_MemberInfo.Data.LeftPrimaryCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPrimaryFileJPG)) bln = false;
           if (DCS_MemberInfo.Data.LeftThumbCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftThumbFileJPG)) bln = false;
           if (DCS_MemberInfo.Data.RightPrimaryCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG)) bln = false;
           if (DCS_MemberInfo.Data.RightThumbCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG)) bln = false;           

            if (Properties.Settings.Default.ScanFingerType == 1)
            {
                if (DCS_MemberInfo.Data.LeftMiddleCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftMiddleFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.LeftRingCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftRingFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.LeftPinkyCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricLeftPinkyFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.RightThumbCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightThumbFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.RightPrimaryCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPrimaryFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.RightMiddleCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightMiddleFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.RightRingCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightRingFileJPG)) bln = false;
                if (DCS_MemberInfo.Data.RightPinkyCode != "Amputated" & !System.IO.File.Exists(DCS_MemberInfo.Data.BiometricRightPinkyFileJPG)) bln = false;
            }

           return bln;
       }

       public static void CreateCaptureCntr(int Cntr)
       {
           System.IO.StreamWriter sw = new System.IO.StreamWriter("CapturedCntr");
           sw.WriteLine(Cntr);
           sw.Dispose();
           sw.Close();
           sw = null;
       }

       public static int GetCaptureCntr()
       {
           int Cntr=0;

           if (System.IO.File.Exists("CapturedCntr"))
           {
               System.IO.StreamReader sr = new System.IO.StreamReader("CapturedCntr");
               while (!sr.EndOfStream)
               {
                   Cntr = Convert.ToInt32(sr.ReadLine());
               }
               sr.Dispose();
               sr.Close();
               sr = null;
           }
           else
           {
               CreateCaptureCntr(0);
           }

           return Cntr;
       }

       public static void ResetSessionReferenceVariables()
       {           
           MemberDataXML_FileName = SessionReference() + ".xml";
           MemberDataSingleFile_FileName = SessionReference();
           PhotoRaw_FileName = SessionReference() + "_Raw_Photo.jpg";
           PhotoFinal_FileName = SessionReference() + "_ICAO_Photo.jpg";
           Signature_FileNameTIFF = SessionReference() + "_Signature.tiff";                      
           BiometricLeftPrimary_FileName = SessionReference() + "_Lprimary";
           BiometricLeftThumb_FileName = SessionReference() + "_Lbackup";
           BiometricRightPrimary_FileName = SessionReference() + "_Rprimary";
           BiometricRightThumb_FileName = SessionReference() + "_Rbackup";
           DCS_MemberInfo.Data.SessionReference = Utilities.SessionReference();
           DCS_MemberInfo.Data.MemberDataXMLFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_RAW_REPOSITORY, Utilities.MemberDataXML_FileName);
           DCS_MemberInfo.Data.MemberDataSingleFile = string.Format(@"{0}\{1}", Class.Utilities.CAPTUREDDATA_SINGLEFILE_REPOSITORY, Utilities.MemberDataSingleFile_FileName);

            if (Properties.Settings.Default.ScanFingerType == 1)
            {
                BiometricLeftMiddle_FileName = SessionReference() + "_Lmiddle";
                BiometricLeftRing_FileName = SessionReference() + "_Lring";
                BiometricLeftPinky_FileName = SessionReference() + "_Lpinky";
                BiometricRightMiddle_FileName = SessionReference() + "_Rmiddle";
                BiometricRightRing_FileName = SessionReference() + "_Rring";
                BiometricRightPinky_FileName = SessionReference() + "_Rpinky";
            }
        }

        //public static void CombinedJpgs(Image Photo, Image Signature, params Image Biometrics)
       public static void CombinedJpgs(Image Photo, Image Signature)
       {
           Bitmap bitmap = new Bitmap(Photo.Width + Signature.Width, Math.Max(Photo.Height, Signature.Height));
           using (Graphics g = Graphics.FromImage(bitmap))
           {
               g.DrawImage(Photo, 0, 0);
               g.DrawImage(Signature, Photo.Width, 0);
           }
           bitmap.Save(CAPTUREDDATA_RAW_REPOSITORY + @"\CombinedJpgs.jpg");
       }

       //public static Image ResizeImage(Image sourceImage, int maxWidth, int maxHeight)
       //{
       //    // Determine which ratio is greater, the width or height, and use
       //    // this to calculate the new width and height. Effectually constrains
       //    // the proportions of the resized image to the proportions of the original.
       //    double xRatio = (double)sourceImage.Width / maxWidth;
       //    double yRatio = (double)sourceImage.Height / maxHeight;
       //    double ratioToResizeImage = Math.Max(xRatio, yRatio);
       //    int newWidth = (int)Math.Floor(sourceImage.Width / ratioToResizeImage);
       //    int newHeight = (int)Math.Floor(sourceImage.Height / ratioToResizeImage);

       //    // Create new image canvas -- use maxWidth and maxHeight in this function call if you wish
       //    // to set the exact dimensions of the output image.
       //    Bitmap newImage = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

       //    // Render the new image, using a graphic object
       //    using (Graphics newGraphic = Graphics.FromImage(newImage))
       //    {
       //        using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
       //        {
       //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
       //            newGraphic.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
       //        }

       //        // Set the background color to be transparent (can change this to any color)
       //        newGraphic.Clear(Color.Transparent);

       //        // Set the method of scaling to use -- HighQualityBicubic is said to have the best quality
       //        newGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

       //        // Apply the transformation onto the new graphic
       //        Rectangle sourceDimensions = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
       //        Rectangle destinationDimensions = new Rectangle(0, 0, newWidth, newHeight);
       //        newGraphic.DrawImage(sourceImage, destinationDimensions, sourceDimensions, GraphicsUnit.Pixel);
       //    }

       //    // Image has been modified by all the references to it's related graphic above. Return changes.
       //    return newImage;
       //}      

       public static void TT()
       {
           StringBuilder sb = new StringBuilder();
           //using (var searcher = new ManagementObjectSearcher("select * from win32_processor"))
           //{
           //    ManagementObjectCollection objectCollection = searcher.Get();

           //    foreach (ManagementBaseObject managementBaseObject in objectCollection)
           //    {
           //        sb.AppendLine(managementBaseObject.GetText();
           //        //foreach (PropertyData propertyData in managementBaseObject.Properties)
           //        //{
                       
           //            //Console.WriteLine("Property:  {0}, Value: {1}", propertyData.Name, propertyData.Value);                       
           //        //}
           //    }
           //}

            ManagementPath path = new ManagementPath();
            ManagementClass devs = null;
            path.Server = ".";
            path.NamespacePath = @"root\CIMV2";
            path.RelativePath = @"Win32_PnPentity";
            using(devs = new ManagementClass(new ManagementScope(path), path, new ObjectGetOptions(null, new TimeSpan(0,0,0,2), true)))
            {
                ManagementObjectCollection moc = devs.GetInstances();

                RelatedObjectQuery relatedQuery = new RelatedObjectQuery("associators of {Win32_PnPEntity}");
                ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(new ManagementScope(path),relatedQuery);
                foreach (ManagementObject mob in searcher.Get())
                {
                    sb.AppendLine("fds");
                }
                
                //foreach(ManagementObject mo in moc) 
                //{
                    //sb.AppendLine(mo.Properties["Name"].ToString());


                    //PropertyDataCollection devsProperties = mo.Properties;
                    //foreach (PropertyData devProperty in devsProperties ) 
                    //{
                    //    if (devProperty.Type == CimType.DateTime) 
                    //    {
                    //        //if(devProperty.Value != null){
                    //    //Console.WriteLine("Date {0}", ToDateTime(devProperty.Value.ToString()));
                    //    }
                    //}
                //}
            //else
                //Console.WriteLine("Property = {0}\t Value = {1}",
                //devProperty.Name, devProperty.Value);
            }

            //RelatedObjectQuery relatedQuery = new RelatedObjectQuery("associators of {Win32_PnPEntity.DeviceID='" + mo["DeviceID"]+ "'}");
            //ManagementObjectSearcher searcher =
            //new ManagementObjectSearcher(new ManagementScope(path),relatedQuery);
            //foreach (ManagementObject mob in searcher.Get()) 
            //{

            //Console.WriteLine("--------------------------->>>>>>");
            //Console.WriteLine(mob["Description"]);

            //}
            Console.WriteLine("----------------------");
                        

           ShowInfoMessage(sb.ToString());
       }

       public static void ExtractDeviceManagerList()
       {
           //System.Collections.Generic.List<string> _list = null;
           DeviceManagerList = new System.Collections.Generic.List<string>();

           ManagementPath path = new ManagementPath();
           ManagementClass devs = null;
           path.Server = ".";
           path.NamespacePath = @"root\CIMV2";
           path.RelativePath = @"Win32_PnPentity";
           using (devs = new ManagementClass(new ManagementScope(path), path, new ObjectGetOptions(null, new TimeSpan(0, 0, 0, 2), true)))
           {
               ManagementObjectCollection moc = devs.GetInstances();
               foreach (ManagementObject mo in moc)
               {
                   DeviceManagerList.Add(mo["Name"].ToString());                   
               }
           }           
       }

       public static string CheckDeviceIfConnected(string Device)
       {
           StringBuilder sb = new StringBuilder();
           var results = from dName in DeviceManagerList.Distinct() where dName.Contains(Device) select dName;
           foreach (string _result in results)
           {
               sb.AppendLine(_result);
           }

           return sb.ToString();
       }

       public static bool IsCameraCanon()
       {
           if (Properties.Settings.Default.Camera.Contains("Canon"))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public static SagemFingerID GetSagemIDByFingerType(string FingerType)
       {
           switch (FingerType)
           {                  
               case "Amputated":                   
                   return SagemFingerID.Amputated;
               case "Right Thumb":
                   return SagemFingerID.RightThumb;
               case "Right Index":
                   return SagemFingerID.RightIndex;
               case "Right Middle":
                   return SagemFingerID.RightMiddle;
               case "Right Ring":
                   return SagemFingerID.RightRing;
               case "Right Pinky":
                   return SagemFingerID.RightPinky;
               case "Left Thumb":
                   return SagemFingerID.LeftThumb;
               case "Left Index":
                   return SagemFingerID.LeftIndex;
               case "Left Middle":
                   return SagemFingerID.LeftMiddle;
               case "Left Ring":
                   return SagemFingerID.LeftRing;
               case "Left Pinky":
                   return SagemFingerID.LeftPinky;               
               default:
                   return 0;
           }
       }

       #region " Logs "

       private static string SystemLog = @"Logs\" + DateTime.Now.ToString("MMddyyyy") + @"\SystemLog.log";
       private static string ErrorLog = @"Logs\" + DateTime.Now.ToString("MMddyyyy") + @"\ErrorLog.log";
       private static string CapturedList = @"Logs\" + DateTime.Now.ToString("MMddyyyy") + @"\CapturedList.log";
       private static string CapturedListCSV = @"Logs\" + DateTime.Now.ToString("MMddyyyy") + @"\CapturedListCSV.csv";

        private static void InitLogFolder()
       {
           if (!System.IO.Directory.Exists(@"Logs\" + DateTime.Now.ToString("MMddyyyy")))
           {
               System.IO.Directory.CreateDirectory(@"Logs\" + DateTime.Now.ToString("MMddyyyy"));
           }
       }

        public static void ControlDisposition(bool bln, System.Windows.Forms.Cursor cursor, params System.Windows.Forms.Control[] ctrls)
        {
            foreach (System.Windows.Forms.Control ctrl in ctrls)
            {
                ctrl.Enabled = !bln;
            }

            if (!bln) cursor = System.Windows.Forms.Cursors.WaitCursor;            
            else cursor = System.Windows.Forms.Cursors.Default;            
        }

       public static void GetCapturedData(ref System.Data.DataTable dt, bool IsAllData)
       {
           InitLogFolder();

           try
           {
               string[] strLines = System.IO.File.ReadAllLines(CapturedList);
               StringBuilder sbHeader = new StringBuilder();
               StringBuilder sbData = new StringBuilder();
                foreach (string strLine in strLines)
                {
                    if (sbHeader.ToString() == "")
                        sbHeader.AppendLine(strLine);
                    else sbData.AppendLine(strLine); 
                }

                dt = new System.Data.DataTable();

                foreach (string strHeaderLabel in sbHeader.ToString().Split('|'))
                {
                    dt.Columns.Add(strHeaderLabel, Type.GetType("System.String"));
                }             

               string[] strDataLines = sbData.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
               foreach (string strLine in strDataLines)
               {
                   System.Data.DataRow rw = dt.NewRow();
                   short i = 0;
                   foreach (string strField in strLine.Split('|'))
                   {
                       if (i == 0)
                       {
                           rw[i] = strField;
                       }
                       else
                       {
                           if(IsAllData)
                           {
                               rw[i] = strField;
                           }
                       }
                       i++;
                   }

                    if (dt==null)
                    {                        
                        
                    }
                    else
                    { dt.Rows.Add(rw); }                   
               }
           }
           catch (Exception ex)
           {
               //SaveToErrorLog(TimeStamp() + "SaveToSystemLog(): Runtime catched error " + ex.Message.ToString());
           }
       }       

       public static void SaveToCapturedData(string strHeader, string strData)
       {
           InitLogFolder();

            bool IsFirstLog = !System.IO.File.Exists(CapturedList);            

            try
           {
               System.IO.StreamWriter sw = new System.IO.StreamWriter(CapturedList, true);               
                if(IsFirstLog) sw.WriteLine(strHeader);
                sw.WriteLine(strData);
               sw.Dispose();
               sw.Close();
           }
           catch (Exception ex)
           {
               SaveToErrorLog(TimeStamp() + "SaveToCapturedData(): Runtime catched error " + ex.Message.ToString());
           }
       }

        public static void SaveToCapturedDataCSV(string strHeader, string strData)
        {
            InitLogFolder();

            bool IsFirstLog = !System.IO.File.Exists(CapturedListCSV);

            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(CapturedListCSV, true);
                if (IsFirstLog) sw.WriteLine(strHeader);
                sw.WriteLine(strData);
                sw.Dispose();
                sw.Close();
            }
            catch (Exception ex)
            {
                SaveToErrorLog(TimeStamp() + "SaveToCapturedDataCSV(): Runtime catched error " + ex.Message.ToString());
            }
        }

        public static void SaveToSystemLog(string strData)
       {
           InitLogFolder();
           
           try
           {
               System.IO.StreamWriter sw = new System.IO.StreamWriter(SystemLog, true);
               sw.WriteLine(strData);
               sw.Dispose();
               sw.Close();
           }
           catch (Exception ex)
           {
               SaveToErrorLog(TimeStamp() + "SaveToSystemLog(): Runtime catched error " + ex.Message.ToString());
           }
       }

       public static void SaveToErrorLog(string strData)
       {
           InitLogFolder();
           
           try
           {
               System.IO.StreamWriter sw = new System.IO.StreamWriter(ErrorLog, true);
               sw.WriteLine(strData);
               sw.Dispose();
               sw.Close();
           }
           catch (Exception ex)
           {
               SaveToErrorLog(TimeStamp() + "SaveToErrorLog(): Runtime catched error " + ex.Message.ToString());
           }
       }

        #endregion

        public static int IsProgramRunning(string Program)
        {
            System.Diagnostics.Process[] p = null;
            p = System.Diagnostics.Process.GetProcessesByName(Program.Replace(".exe", "").Replace(".EXE", ""));

            return p.Length;
        }

        public static void KillProgram(string Program)
        {
            try
            {
                System.Diagnostics.Process[] programs = System.Diagnostics.Process.GetProcessesByName(Program.Replace(".exe", "").Replace(".EXE", ""));
                foreach (System.Diagnostics.Process _program in programs)
                {
                    _program.Kill();
                }                
            }
            catch (Exception ex)
            {
                SaveToErrorLog(TimeStamp() + "KillProgram(): Runtime catched error " + ex.Message);
            }
        }        

        public static void PopulateDevices(ref System.Data.DataTable dtDevices)
        {
            if (dtDevices == null)
            {
                dtDevices = new System.Data.DataTable();
                dtDevices.Columns.Add("DeviceName", Type.GetType("System.String"));
            }
            else dtDevices.Clear();

            System.Management.ManagementObjectSearcher objSearcher = new System.Management.ManagementObjectSearcher(@"\root\cimv2", @"Select * From Win32_PnPEntity");
            System.Management.ManagementObjectCollection objCollection = objSearcher.Get();

            foreach (System.Management.ManagementObject obj in objCollection)
            {
                try
                {
                    if (obj.GetPropertyValue("Name") != null)
                    {
                        System.Data.DataRow rw = dtDevices.NewRow();
                        rw[0] = obj.GetPropertyValue("Name").ToString();
                        dtDevices.Rows.Add(rw);
                    }
                }
                catch { }
            }
        }

        public static bool IsSignaturesComplete()
        {
            short intCntr = 0;
            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile)) intCntr += 1;
            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "2.tiff"))) intCntr += 1;
            if (System.IO.File.Exists(DCS_MemberInfo.Data.SignatureFile.Replace(".tiff", "3.tiff"))) intCntr += 1;

            if (intCntr == 3) return true; else return false;
        }
    }
}
