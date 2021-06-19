using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCS2015.Class
{
    class OfflineLogInAuth
    {

        private string TRIPLEDESKEY = "yIJK123AaP09";
        private string SOURCE_FILE = "DataSource\\UsersAndRoles.txt";
        private string _ErrorMessage="";

        public OfflineLogInAuth()
        {
            CreateTable();
            PopulateFromFile();
        }

        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
        }

        public System.Data.DataTable UserAndRoleTable
        {
            get
            {
                return dtUserAndRole;
            }
        }


        private System.Data.DataTable dtUserAndRole;

        private void CreateTable()
        {
            if (dtUserAndRole == null)
            {
                dtUserAndRole = new System.Data.DataTable();
                dtUserAndRole.Columns.Add("Username", Type.GetType("System.String"));
                dtUserAndRole.Columns.Add("Password", Type.GetType("System.String"));
                dtUserAndRole.Columns.Add("Role", Type.GetType("System.String"));
                dtUserAndRole.Columns.Add("Name", Type.GetType("System.String"));
            }
            else
            {
                dtUserAndRole.Clear();
            }
        }

        private void PopulateFromFile()
        {
            if (System.IO.File.Exists(SOURCE_FILE))
            {
                string[] strLines = System.IO.File.ReadAllLines(SOURCE_FILE);
                foreach (string strLine in strLines)
                {
                    string strDecryptedLine = DecryptValue(strLine);

                    AddRow(strDecryptedLine.Split('|')[0], strDecryptedLine.Split('|')[1], strDecryptedLine.Split('|')[2], strDecryptedLine.Split('|')[3]);
                }
            }
        }

        private void AddRow(string Username, string Password, string Role, string Name)
        {
            System.Data.DataRow rw = dtUserAndRole.NewRow();
            rw[0] = Username;
            rw[1] = Password;
            rw[2] = Role;
            rw[3] = Name;
            dtUserAndRole.Rows.Add(rw);
        }

        private string EncryptValue(string value)
        {
            AllcardEncryptDecrypt.EncryptDecrypt encdec = new AllcardEncryptDecrypt.EncryptDecrypt(TRIPLEDESKEY);
            try
            {
                return encdec.TripleDesEncryptText(value);
            }
            catch
            {
                return "";
            }
            finally
            {
                encdec = null;
            }

        }

        private string DecryptValue(string value)
        {
            AllcardEncryptDecrypt.EncryptDecrypt encdec = new AllcardEncryptDecrypt.EncryptDecrypt(TRIPLEDESKEY);
            try
            {
                return encdec.TripleDesDecryptText(value);
            }
            catch
            {
                return "";
            }
            finally
            {
                encdec = null;
            }

        }
    }
}
