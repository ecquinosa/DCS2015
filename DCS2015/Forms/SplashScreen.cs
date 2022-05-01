
#region " Imports "

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace DCS2015.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();                   
        }

        LogIN li = null;
        accAfpslaiEmvLogIn.LogIN liAfpslai;
        private bool isLogSuccess = false;

        private bool IsCameraConnected = false;
        private bool IsSagemDeviceConnected = false;
        private bool IsSecugenDeviceConnected = false;
        private bool IsSignatureTabletConnected = false;        

        //private string PROCESSES = "Checking webservices connection..., Checking required devices..., Checking megamatcher license...";
        //private string PROCESSES = "Checking required devices..., Checking megamatcher license...";

        public bool Success
        {
            get 
            {
                if (sb.ToString() == "")
                { return true; }
                else { return false; }
            }
        }

        private System.Data.DataTable dtDevices;

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            try
            {
                switch (DCS_DataCapture.DataCapture.ClientName)
                {
                    case "AFPSLAI":
                        if (Class.Utilities.DCS_DataCaptureVersion() == "1")
                        {
                            li = new LogIN();
                        }
                        else
                        {
                            DCS_DataCapture.DataCapture dc = new DCS_DataCapture.DataCapture();
                            liAfpslai = new accAfpslaiEmvLogIn.LogIN(dc.middleServerApi());                            
                        }

                        break;
                    default:
                        li = new LogIN();
                        break;
                }

                if (li != null)
                {
                    li.ShowDialog();
                    isLogSuccess = li.Success;
                }
                else if (liAfpslai != null)
                {
                    liAfpslai.ShowDialog();
                    isLogSuccess = liAfpslai.IsSuccess;
                    if (isLogSuccess)
                    {
                        if (accAfpslaiEmvLogIn.LogIN.msa.dcsUser.roleId == 2)
                        {
                            Properties.Settings.Default.UserRole = "ADMINISTRATOR";                            
                        } else Properties.Settings.Default.UserRole = accAfpslaiEmvLogIn.LogIN.msa.dcsUser.roleDesc;

                        Properties.Settings.Default.Operator = accAfpslaiEmvLogIn.LogIN.msa.dcsUser.fullName.Trim();
                        Properties.Settings.Default.UserRole = accAfpslaiEmvLogIn.LogIN.msa.dcsUser.roleDesc;
                        Properties.Settings.Default.Save();
                        DCS_MemberInfo.Data.UserRole = Properties.Settings.Default.UserRole;
                        DCS_MemberInfo.Data.OperatorID = Properties.Settings.Default.Operator;
                    }
                    //else Environment.Exit(0);
                }

                if (!isLogSuccess)
                {
                    if (li != null) li = null;
                    if (liAfpslai != null) li = null;
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {

            }

            Version.Text = Main.AssemblyNameAndProductVersion.Split(',')[1];
            CheckForIllegalCrossThreadCalls = false;

            switch (DCS_DataCapture.DataCapture.ClientName)
            {
                case "AFPSLAI":
                    Label1.Text = "AFPSLAI";
                    break;
                default:
                    Label1.Text = "ALLCARD";
                    break;
            }

            Class.Utilities.PopulateDevices(ref dtDevices);

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //foreach (System.Data.DataRow rw in dtDevices.Rows)
            //{
            //    sb.AppendLine(rw[0].ToString());
            //}

            //System.IO.File.WriteAllText("devices.txt", sb.ToString());

            bg.RunWorkerAsync();
        }
        
        public static System.Text.StringBuilder sb = new System.Text.StringBuilder();

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            sb.Clear();

            //short intTotalProcess = (short)PROCESSES.Split(',').Length;
            short intTotalProcess = (short)Properties.Settings.Default.SplashProcessValidation.Split(',').Length;
            ProgressBar1.Maximum = intTotalProcess;

            short intProcess = 1;

            foreach (string chr in Properties.Settings.Default.SplashProcessValidation.Split(','))
            {
                if (chr != "")
                {
                    if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.MegamatcherLicense)
                    {
                        if (!Class.PhotoAnalysis.ObtainLicense()) sb.AppendLine("Unable to detect megamatcher license...");

                        try { Class.PhotoAnalysis.ReleaseLicense(); }
                        catch (Exception ex) { }
                    }
                    else if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.Camera)
                    {
                        if (dtDevices.Select("DeviceName LIKE '*Canon EOS*'").Length > 0)
                            IsCameraConnected = true;

                        if (!IsCameraConnected)
                            if (dtDevices.Select("DeviceName LIKE '*Webcam C920*'").Length > 0)
                                IsCameraConnected = true;

                        if (!IsCameraConnected)
                            if (dtDevices.Select("DeviceName LIKE '*C922*'").Length > 0)
                                IsCameraConnected = true;

                        else sb.AppendLine("Unable to detect camera device...");

                    }
                    else if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.Biometric)
                    {
                        if (Properties.Settings.Default.FingerScanner.Contains("Sagem"))
                        {
                            if (dtDevices.Select("DeviceName LIKE '*Sagem*'").Length > 0) 
                                IsSagemDeviceConnected = true;
                            else if (dtDevices.Select("DeviceName LIKE '*MSO300*'").Length > 0)
                                IsSagemDeviceConnected = true;
                            else sb.AppendLine("Unable to detect biometric device...");
                        }
                        else if (Properties.Settings.Default.FingerScanner.Contains("Secugen"))
                        {
                            if (dtDevices.Select("DeviceName LIKE '*Secugen*'").Length > 0) IsSecugenDeviceConnected = true;
                            else sb.AppendLine("Unable to detect biometric device...");
                        }                        
                    }
                    else if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.TopazSignatureTablet)
                    {
                        if (Properties.Settings.Default.SignatureTablet == "Topaz Siglite")
                        {
                            if (dtDevices.Select("DeviceName LIKE '*HID-compliant vendor-defined device*'").Length > 0)
                                IsSignatureTabletConnected = true;
                        }
                        else
                        {
                            if (!IsSignatureTabletConnected)                            
                                if (dtDevices.Select("DeviceName LIKE '*signotec*'").Length > 0) IsSignatureTabletConnected = true;
                                                        
                            if (!IsSignatureTabletConnected)
                                if (dtDevices.Select("DeviceName LIKE '*HID - compliant device*'").Length > 0) IsSignatureTabletConnected = true;                            

                            if (!IsSignatureTabletConnected)                            
                                if (dtDevices.Select("DeviceName = 'HID - compliant device'").Length > 0) IsSignatureTabletConnected = true;                            

                            if (!IsSignatureTabletConnected)                            
                                if (dtDevices.Select("DeviceName = 'HID-compliant device'").Length > 0) IsSignatureTabletConnected = true;                            

                            if (!IsSignatureTabletConnected)                            
                                if (dtDevices.Select("DeviceName LIKE '*USB Input Device*'").Length > 0) IsSignatureTabletConnected = true;                            
                        }                               

                        if (!IsSignatureTabletConnected)
                            sb.AppendLine("Unable to detect signature tablet device...");
                    }

                    lblStatus.Text = string.Format("Processing {0} of {1}, {2}", intProcess, intTotalProcess, ProcessDescription(chr));
                    ProgressBar1.Value = intProcess;
                    intProcess += 1;
                    System.Threading.Thread.Sleep(1000);
                }                
            }                      
        }

        //public bool WebServiceRunning_securaWS()
        //{
        //    try
        //    {
        //        System.Uri siteUri = new System.Uri(DCS_DataCapture.DataCapture.securaWS().Url.ToString());
        //        System.Net.WebRequest webRequest = System.Net.WebRequest.Create(siteUri);
        //        System.Net.WebResponse webResponse = webRequest.GetResponse();
        //        webRequest.Timeout = 10000;
        //        if ((webResponse == null))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sb.AppendLine(ex.Message);
        //        return false;
        //    }
        //}


        public bool WebServiceRunning_OnlineRegistrationWS()
        {
            return true;

            //try
            //{
            //    System.Uri siteUri = new System.Uri(DCS_DataCapture.PreRegistered.OnlineRegistrationWS().Url.ToString());
            //    System.Net.WebRequest webRequest = System.Net.WebRequest.Create(siteUri);
            //    System.Net.WebResponse webResponse = webRequest.GetResponse();
            //    webRequest.Timeout = 10000;
            //    if ((webResponse == null)) return false;
            //    else return true;                
            //}
            //catch (Exception ex)
            //{
            //    sb.AppendLine(ex.Message);
            //    return false;
            //}
        }        

        private void CheckingDevices()
        {
            try
            {
               

                System.Management.ManagementObjectSearcher objSearcher = new System.Management.ManagementObjectSearcher(@"\root\cimv2", @"Select * From Win32_PnPEntity");
                System.Management.ManagementObjectCollection objCollection = objSearcher.Get();                

                foreach (System.Management.ManagementObject obj in objCollection)
                {
                    try
                    {
                        string DeviceName = obj.GetPropertyValue("Name").ToString();

                        //if (DeviceName.Contains("Canon"))
                        //{
                        //    Console.Write("Test");
                        //}
                        //else if (DeviceName.Contains("Human"))
                        //{
                        //    Console.Write("Test");
                        //}

                        if (DeviceName.Contains("Canon EOS"))
                        {
                            IsCameraConnected = true;
                        }
                        else if (DeviceName.Contains("Webcam C920"))
                        {
                            IsCameraConnected = true;
                        }
                        else if (DeviceName.Contains("MSO300"))
                        {
                            IsSagemDeviceConnected = true;
                        }
                        else if (DeviceName.Contains("SecuGen"))
                        {
                            IsSecugenDeviceConnected = true;
                        }
                    }
                    catch { }
                }                

                if (!IsCameraConnected)
                    sb.AppendLine("Unable to detect camera...");

                if (Properties.Settings.Default.FingerScanner.Contains("Sagem"))
                {
                    if (!IsSagemDeviceConnected) sb.AppendLine("Unable to detect sagem device...");                    
                }
                else if (Properties.Settings.Default.FingerScanner.Contains("Secugen"))
                {
                    if (!IsSecugenDeviceConnected) sb.AppendLine("Unable to detect secugen device...");
                }
                                         
                if (!IsSignatureTabletConnected)
                    sb.AppendLine("Unable to detect signature tablet...");
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void lbContinue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sb.Clear();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                btnClose.Visible = true;
                Class.Utilities.ShowErrorMessage(sb.ToString());
                lbContinue.Visible = true;
            }
            else
            {
                Close();
            }
        }

        private string ProcessDescription(string chr)
        {
            string process = "";                        
            if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.MegamatcherLicense) process = "Checking megamatcher license...";
            if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.Camera) process = "Checking camera device...";
            if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.Biometric) process = "Checking biometric device...";
            if (Convert.ToInt16(chr) == (short)Class.Utilities.SplashProcessValidation.TopazSignatureTablet) process = "Checking signature tablet device...";            

            return process;
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
