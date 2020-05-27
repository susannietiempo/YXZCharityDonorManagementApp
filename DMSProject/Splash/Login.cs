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

                //TO DO: Update log in
                if (1==1)
                    //(txtUserName.Text == Environment.UserName &&
                    //txtPassword.Text.Trim().ToLower() == ConfigurationManager.AppSettings["DefaultPassword"].ToString().ToLower())
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Login failed.", "Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
