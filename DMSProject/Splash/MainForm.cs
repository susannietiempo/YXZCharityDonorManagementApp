using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Splash splash = new Splash();
            Login loginScreen = new Login();
            splash.ShowDialog();

            if (splash.DialogResult != DialogResult.OK)
                this.Close();
            else
                loginScreen.ShowDialog();

            if (loginScreen.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }


        }
    }
}
