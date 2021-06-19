
using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;

namespace DCS2015.Class
{
    class FileEncryptDecrypt
    {
        
        //*************************
        //** Global Variables
        //*************************

        bool blnSuccess;

        private string salt = "";//SharedFunction.SecuraFileEncrption_salt;
        public bool IsSuccess
        {
            get { return blnSuccess; }
        }

        string strFileToEncrypt;
        string strFileToDecrypt;
        string strOutputEncrypt;
        string strOutputDecrypt;
        System.IO.FileStream fsInput;

        System.IO.FileStream fsOutput;
        //Private Const FileExtension As String = ".phic"
        private string FileExtension = ""; //SharedFunction.EncryptDecryptFileExtension;

        private int ExtensionDataLength = 0; //FileExtension.Length;
        //*************************
        //** Create A Key
        //*************************

        private byte[] CreateKey_SHA(string strPassword)
        {
            //Convert strPassword to an array and store in chrData.
            char[] chrData = strPassword.ToCharArray();
            //Use intLength to get strPassword size.
            int intLength = chrData.GetUpperBound(0);
            //Declare bytDataToHash and make it the same size as chrData.
            byte[] bytDataToHash = new byte[intLength + 1];

            //Use For Next to convert and store chrData into bytDataToHash.
            for (int i = 0; i <= chrData.GetUpperBound(0); i++)
            {
                bytDataToHash[i] = Convert.ToByte(Microsoft.VisualBasic.Strings.Asc(chrData[i]));
            }

            //Declare what hash to use.
            System.Security.Cryptography.SHA512Managed SHA512 = new System.Security.Cryptography.SHA512Managed();
            //Declare bytResult, Hash bytDataToHash and store it in bytResult.
            byte[] bytResult = SHA512.ComputeHash(bytDataToHash);
            //Declare bytKey(31).  It will hold 256 bits.
            byte[] bytKey = new byte[32];

            //Use For Next to put a specific size (256 bits) of 
            //bytResult into bytKey. The 0 To 31 will put the first 256 bits
            //of 512 bits into bytKey.
            for (int i = 0; i <= 31; i++)
            {
                bytKey[i] = bytResult[i];
            }

            return bytKey;
            //Return the key.
        }

        private byte[] CreateKey(string strPassword)
        {
            byte[] bytKey = null;
            byte[] bytSalt = System.Text.Encoding.ASCII.GetBytes(salt);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(strPassword, bytSalt);

            bytKey = pdb.GetBytes(32);

            return bytKey;
            //Return the key.
        }

        //*************************
        //** Create An IV
        //*************************

        private byte[] CreateIV_SHA(string strPassword)
        {
            //Convert strPassword to an array and store in chrData.
            char[] chrData = strPassword.ToCharArray();
            //Use intLength to get strPassword size.
            int intLength = chrData.GetUpperBound(0);
            //Declare bytDataToHash and make it the same size as chrData.
            byte[] bytDataToHash = new byte[intLength + 1];

            //Use For Next to convert and store chrData into bytDataToHash.
            for (int i = 0; i <= chrData.GetUpperBound(0); i++)
            {
                bytDataToHash[i] = Convert.ToByte(Microsoft.VisualBasic.Strings.Asc(chrData[i]));
            }

            //Declare what hash to use.
            System.Security.Cryptography.SHA512Managed SHA512 = new System.Security.Cryptography.SHA512Managed();
            //Declare bytResult, Hash bytDataToHash and store it in bytResult.
            byte[] bytResult = SHA512.ComputeHash(bytDataToHash);
            //Declare bytIV(15).  It will hold 128 bits.
            byte[] bytIV = new byte[16];

            //Use For Next to put a specific size (128 bits) of bytResult into bytIV.
            //The 0 To 30 for bytKey used the first 256 bits of the hashed password.
            //The 32 To 47 will put the next 128 bits into bytIV.
            for (int i = 32; i <= 47; i++)
            {
                bytIV[i - 32] = bytResult[i];
            }

            return bytIV;
            //Return the IV.
        }

        private byte[] CreateIV(string strPassword)
        {
            byte[] bytIV = null;
            byte[] bytSalt = System.Text.Encoding.ASCII.GetBytes(salt);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(strPassword, bytSalt);

            bytIV = pdb.GetBytes(16);

            return bytIV;
            //Return the IV.
        }

        //****************************
        //** Encrypt/Decrypt File
        //****************************

        private enum CryptoAction
        {
            //Define the enumeration for CryptoAction.
            ActionEncrypt = 1,
            ActionDecrypt = 2
        }

        private void EncryptOrDecryptFile(string strInputFile, string strOutputFile, byte[] bytKey, byte[] bytIV, CryptoAction Direction)
        {
            //In case of errors.
            try
            {

                //Setup file streams to handle input and output.
                fsInput = new System.IO.FileStream(strInputFile, FileMode.Open, FileAccess.Read);
                fsOutput = new System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate, FileAccess.Write);
                fsOutput.SetLength(0);
                //make sure fsOutput is empty

                //Declare variables for encrypt/decrypt process.
                byte[] bytBuffer = new byte[4097];
                //holds a block of bytes for processing
                long lngBytesProcessed = 0;
                //running count of bytes processed
                long lngFileLength = fsInput.Length;
                //the input file's length
                int intBytesInCurrentBlock = 0;
                //current bytes being processed
                CryptoStream csCryptoStream = default(CryptoStream);
                //Declare your CryptoServiceProvider.
                System.Security.Cryptography.RijndaelManaged cspRijndael = new System.Security.Cryptography.RijndaelManaged();
                //Setup Progress Bar

                //Determine if ecryption or decryption and setup CryptoStream.
                switch (Direction)
                {
                    case CryptoAction.ActionEncrypt:
                        csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);

                        break;
                    case CryptoAction.ActionDecrypt:
                        csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write);
                        break;
                }

                //Use While to loop until all of the file is processed.
                while (lngBytesProcessed < lngFileLength)
                {
                    //Read file with the input filestream.
                    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096);
                    //Write output file with the cryptostream.
                    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock);
                    //Update lngBytesProcessed
                    lngBytesProcessed = lngBytesProcessed + Convert.ToInt64(intBytesInCurrentBlock);
                }

                //Close FileStreams and CryptoStream.
                csCryptoStream.Close();
                fsInput.Close();
                fsOutput.Close();

                blnSuccess = true;
            }
            catch (Exception ex)
            {
                blnSuccess = false;
            }
        }

        public void EncryptFile(string strFile, string strPassword)
        {

            try
            {

                strFileToEncrypt = strFile;

                int iPosition = 0;
                int i = 0;

                //Get the position of the last "\" in the OpenFileDialog.FileName path.
                //-1 is when the character your searching for is not there.
                //IndexOf searches from left to right.
                while (strFileToEncrypt.IndexOf('\\', i) != -1)
                {
                    iPosition = strFileToEncrypt.IndexOf('\\', i);
                    i = iPosition + 1;
                }

                //Assign strOutputFile to the position after the last "\" in the path.
                //This position is the beginning of the file name.
                strOutputEncrypt = strFileToEncrypt.Substring(iPosition + 1);
                //Assign S the entire path, ending at the last "\".
                string S = strFileToEncrypt.Substring(0, iPosition + 1);
                //Replace the "." in the file extension with "_".
                strOutputEncrypt = strOutputEncrypt.Replace('.', '_');
                //The final file name.  XXXXX.encrypt
                //txtDestinationEncrypt.Text = S + strOutputEncrypt + FileExtension
                strOutputEncrypt = S + strOutputEncrypt + FileExtension;

                //Declare variables for the key and iv.
                //The key needs to hold 256 bits and the iv 128 bits.
                byte[] bytKey = null;
                byte[] bytIV = null;
                //Send the password to the CreateKey function.
                bytKey = CreateKey(strPassword);
                //Send the password to the CreateIV function.
                bytIV = CreateIV(strPassword);
                //Start the encryption.
                EncryptOrDecryptFile(strFileToEncrypt, strOutputEncrypt, bytKey, bytIV, CryptoAction.ActionEncrypt);

                //If New FileInfo(strOutputDecrypt).Length > 0 Then
                //    blnSuccess = True
                //Else
                //    blnSuccess = True
                //End If
                blnSuccess = true;
            }
            catch (Exception ex)
            {
                blnSuccess = false;
            }
        }

        public void DecryptFile(string strFile, string strPassword)
        {
            try
            {
                strFileToDecrypt = strFile;

                int iPosition = 0;
                int i = 0;
                //Get the position of the last "\" in the OpenFileDialog.FileName path.
                //-1 is when the character your searching for is not there.
                //IndexOf searches from left to right.

                while (strFileToDecrypt.IndexOf('\\', i) != -1)
                {
                    iPosition = strFileToDecrypt.IndexOf('\\', i);
                    i = iPosition + 1;
                }

                //strOutputFile = the file path minus the last 8 characters (.encrypt)
                strOutputDecrypt = strFileToDecrypt.Substring(0, strFileToDecrypt.Length - ExtensionDataLength);
                //Assign S the entire path, ending at the last "\".
                string S = strFileToDecrypt.Substring(0, iPosition + 1);
                //Assign strOutputFile to the position after the last "\" in the path.
                strOutputDecrypt = strOutputDecrypt.Substring((iPosition + 1));
                //Replace "_" with "."
                //txtDestinationDecrypt.Text = S + strOutputDecrypt.Replace("_"c, "."c)
                strOutputDecrypt = S + strOutputDecrypt.Replace('_', '.');

                //Declare variables for the key and iv.
                //The key needs to hold 256 bits and the iv 128 bits.
                byte[] bytKey = null;
                byte[] bytIV = null;
                //Send the password to the CreateKey function.
                bytKey = CreateKey(strPassword);
                //Send the password to the CreateIV function.
                bytIV = CreateIV(strPassword);
                //Start the decryption.
                EncryptOrDecryptFile(strFileToDecrypt, strOutputDecrypt, bytKey, bytIV, CryptoAction.ActionDecrypt);

                //If New FileInfo(strOutputDecrypt).Length > 0 Then
                //    blnSuccess = True
                //Else
                //    blnSuccess = True
                //End If
                blnSuccess = true;
            }
            catch (Exception ex)
            {
                blnSuccess = false;
            }
        }

    }
}
