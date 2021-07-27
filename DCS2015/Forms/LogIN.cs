using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DCS2015.Forms
{
    public partial class LogIN : Form
    {
        public LogIN()
        {
            InitializeComponent();

            switch (DCS_DataCapture.DataCapture.ClientName)
            {
                case "AFPSLAI":
                    panel1.BackgroundImage = Image.FromStream(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(string.Format(@"{0}\Images\login_banner.png",Application.StartupPath))));
                    break;                
            }
        }

        bool IsSuccess = false;

        public bool Success
        {
            get
            {
                return IsSuccess;
            }
        }        

        private void LogIN_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
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
            bmp.Save(@"E:\Projects\UMID DATA COMPRESSOR\0120161108J0ID069001\0120161108J0ID069001_Lbackup.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return bmp;
        }

        private void SaveToWSQ()
        {
            string file = (@"E:\Projects\DCS2015\DCS2015\bin\Debug\Captured Data\223\223_Lbackup.wsq");
            Sagem.MorphoKit.WSQ wsq = new Sagem.MorphoKit.WSQ();
            wsq.DecompressBitmap(System.IO.File.ReadAllBytes(file)).Save(file.Replace(".wsq", ".tif"), System.Drawing.Imaging.ImageFormat.Tiff);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                lblResult.Text = "Please enter valid credential";
                txtUsername.Focus();
            }
            else if (txtUsername.Text != "" && txtPassword.Text == "")
            {
                lblResult.Text = "Please enter valid credential";
                txtPassword.Focus();
            }
            else if (txtUsername.Text == "" && txtPassword.Text != "")
            {
                lblResult.Text = "Please enter valid credential";
                txtUsername.Focus();
            }
            else
            {
                switch (DCS_DataCapture.DataCapture.ClientName)
                {
                    case "Philhealth":
                        if (ValidateLogIN()) Login();
                        break;
                    case "AFPSLAI":
                        if (ValidateLogIN_AFPSLAI()) Login();
                        break;
                    default:
                        if (ValidateLogIN_Offline())Login();
                        break;
                }                
            }
        }

        

        public static string HashEncryptString(string s)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
	        byte[] clearBytes = System.Text.Encoding.UTF8.GetBytes(s);
	        byte[] hashedBytes = Hasher.ComputeHash(clearBytes);
	        return Convert.ToBase64String(hashedBytes);
        }

        private void Login()
        {            
            switch (DCS_DataCapture.DataCapture.ClientName)
            {
                case "AFPSLAI":
                    if (txtPassword.Text == "afpslai")
                    {
                        ChangePassword cp = new ChangePassword(txtUsername.Text);
                        cp.ShowDialog();
                        if (cp.IsSuccess)
                        {
                            IsSuccess = true;
                            Close();
                        }
                        else Close();
                    }
                    else
                    {
                        IsSuccess = true;
                        Close();
                    } 
                    break;
                default:
                    IsSuccess = true;
                    Properties.Settings.Default.Operator = txtUsername.Text;
                    Properties.Settings.Default.Save();
                    Close();
                    break;
            }                        
        }

        private void LogIN_FormClosing(object sender, FormClosingEventArgs e)
        {
                
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLogin.PerformClick();
            //else if (e.KeyChar == (char)27)
            //    this.Close();
        }

        private bool ValidateLogIN()
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ACCALLCARD.""tblUser"".""UserID"", ACCALLCARD.""tblUser"".""Username"", ACCALLCARD.""tblUser"".""Password"", ");
            sb.Append(@"ACCALLCARD.""tblUser"".""FName"", ACCALLCARD.""tblUser"".""MName"", ACCALLCARD.""tblUser"".""LName"", ACCALLCARD.""tblRole"".""RoleDesc"" ");
            sb.Append(@"FROM ACCALLCARD.""tblUser"" ");
            sb.Append(@"INNER JOIN ACCALLCARD.""tblRole"" ON ACCALLCARD.""tblUser"".""RoleID"" = ACCALLCARD.""tblRole"".""RoleID"" ");
            sb.Append(@"WHERE ACCALLCARD.""tblRole"".""RoleDesc"" LIKE 'DCS_%' AND ACCALLCARD.""tblUser"".""IsActive"" = 1 ");
            sb.Append(string.Format(@"AND ACCALLCARD.""tblUser"".""Username""='{0}' AND ACCALLCARD.""tblUser"".""Password""='{1}' ", txtUsername.Text, HashEncryptString(txtPassword.Text)));

            try
            {
                DataTable dtUser = null;
                string ErrorMsg = "";
                securaWS().SP100("(*812aAiP*@", sb.ToString(), ref dtUser, ref ErrorMsg);

                if (ErrorMsg != "")
                {
                    lblResult.Text = ErrorMsg;
                    txtUsername.Focus();
                    return false;
                }
                else
                {
                    if(dtUser.DefaultView.Count>0)
                    {
                        Properties.Settings.Default.UserRole = dtUser.Rows[0]["RoleDesc"].ToString().Trim();
                        Properties.Settings.Default.Save();
                        return true;
                    }
                    else
                    {
                        lblResult.Text = "Invalid credential";
                        txtUsername.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        private bool ValidateLogIN_AFPSLAI()
        {
            DCS_DataCapture.DataCapture dc = new DCS_DataCapture.DataCapture();
            var response = dc.ValidateLogIn(txtUsername.Text, txtPassword.Text);            

            return response;
         }

        private bool ValidateLogIN_Offline()
        {
            try
            {
                Class.OfflineLogInAuth ola = new Class.OfflineLogInAuth();

                if (ola.ErrorMessage != "")
                {
                    lblResult.Text = ola.ErrorMessage;
                    txtUsername.Focus();
                    return false;
                }
                else
                {
                    if (ola.UserAndRoleTable.Select(string.Format("Username='{0}' AND Password='{1}'", txtUsername.Text, txtPassword.Text)).Length > 0)
                    {
                        Properties.Settings.Default.Operator = ola.UserAndRoleTable.Select(string.Format("Username='{0}' AND Password='{1}'", txtUsername.Text, txtPassword.Text))[0]["Name"].ToString().Trim();                        
                        Properties.Settings.Default.UserRole = ola.UserAndRoleTable.Select(string.Format("Username='{0}' AND Password='{1}'", txtUsername.Text, txtPassword.Text))[0]["Role"].ToString().Trim();                        
                        Properties.Settings.Default.Save();
                        DCS_MemberInfo.Data.UserRole = Properties.Settings.Default.UserRole;
                        DCS_MemberInfo.Data.OperatorID = Properties.Settings.Default.Operator;
                        return true;
                    }
                    else
                    {
                        lblResult.Text = "Invalid credential";
                        txtUsername.Focus();
                        return false;
                    }
                }               
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public static ph_com_allcard_philhealth_secura.Allcard securaWS()
        {
            return new ph_com_allcard_philhealth_secura.Allcard();
        }
    }
}
