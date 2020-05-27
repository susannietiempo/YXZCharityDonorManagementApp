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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBoxHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
           
        }

        private void picBoxDonors_Click(object sender, EventArgs e)
        {
            try
            {
                Donor donor = new Donor(this);
                donor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
         
        }

        private void picBoxVolunteers_Click(object sender, EventArgs e)
        {
            try
            {
                Volunteers volunteers = new Volunteers(this);
                volunteers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void picBoxGifts_Click(object sender, EventArgs e)
        {
            try
            {
                Gift gift = new Gift(this);
                gift.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }
    }
}
