using System;
using System.Windows.Forms;

namespace Splash
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " - Login";
            txtUserName.Text = "Username";
            txtPassword.Text = "Password";
        }

        private void picBoxCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = string.Empty;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
        }

        private void picBoxLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtPassword.Text.Trim()) || String.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    MessageBox.Show("Password and Username are required", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string userPassword = DataAccess.GetValue($"Select Password FROM LogIn Where UserID = (SELECT UserId FROM [USER] WHERE UserName = '{txtUserName.Text.Trim()}')").ToString();
                if (txtPassword.Text.Trim() == userPassword)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Login failed. Incorrect Password", "Log In Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
