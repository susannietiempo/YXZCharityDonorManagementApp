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
    public partial class Gift : Form
    {
        MainForm myParent;
        public Gift()
        {
            InitializeComponent();
        }

        public Gift(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        private void picBoxHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void picBoxVolunteer_Click(object sender, EventArgs e)
        {
            try
            {
                Volunteers volunteers = new Volunteers();
                volunteers.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void picBoxDonor_Click(object sender, EventArgs e)
        {
            try
            {
                Donor donor = new Donor();
                donor.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

    }
}
