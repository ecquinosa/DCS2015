
using System;
using System.Windows.Forms;
using System.Linq;

namespace DCS2015.Forms
{
    public partial class ChangePassword : Form
    {

        System.Data.DataTable dt;

        public ChangePassword(string Username)
        {
            InitializeComponent();
            this.Username = Username;
        }

        private string Username;
        public bool IsSuccess = false;

        private void ChangePassword_Load(object sender, EventArgs e)
        {            
            DCS_OfflineUsers.OfflineLogInAuth users = new DCS_OfflineUsers.OfflineLogInAuth();
            dt = users.UserAndRoleTable;
            users = null;            
        }

        private bool ValidatePassword(string _password)
        {
            return (_password.Any(char.IsUpper) && _password.Any(char.IsLower) && _password.Any(char.IsDigit));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text.Length < 8)
            {
                lblResult.Text = "Password should be 8 to 15 characters";
                txtNewPass.Focus();
            }            
            else if (!ValidatePassword(txtNewPass.Text))
            {
                lblResult.Text = "Password should be alphanumeric and with upper and lowercase";
                txtNewPass.Focus();
            }
            else if (txtConfirmPass.Text.Length < 8)
            {
                lblResult.Text = "Password should be 8 to 15 characters";
                txtConfirmPass.Focus();
            }
            else if (txtNewPass.Text != txtConfirmPass.Text)
            {
                lblResult.Text = "Passwords are not identical";
                txtConfirmPass.Focus();
            }
            else
            {                
                dt.Select("Username='" + Username + "'")[0]["Password"] = txtNewPass.Text;
                DCS_OfflineUsers.OfflineLogInAuth users = new DCS_OfflineUsers.OfflineLogInAuth();
                users.SaveTable(dt);
                users = null;
                IsSuccess = true;
                MessageBox.Show("Password has been changed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
