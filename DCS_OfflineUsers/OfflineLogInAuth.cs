
using System;


namespace DCS_OfflineUsers
{
    public class OfflineLogInAuth
    {

        private string TRIPLEDESKEY = "yIJK123AaP09";
        private string SOURCE_FILE = "DataSource\\UsersAndRoles.txt";
        private string _ErrorMessage = "";

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

        public void SaveTable(System.Data.DataTable dt)
        {
            if (System.IO.Directory.Exists("DataSource"))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (System.Data.DataRow rw in dt.Rows)
                {
                    String strLine = String.Format("{0}|{1}|{2}|{3}", rw[0].ToString(), rw[1].ToString(), rw[2].ToString(), rw[3].ToString());
                    sb.AppendLine(EncryptValue(strLine));
                }

                System.IO.File.WriteAllText(SOURCE_FILE, sb.ToString());
            }        
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
