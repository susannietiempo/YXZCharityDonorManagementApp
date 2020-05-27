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
    public partial class Donor : Form
    {
        MainForm myParent;

        public Donor()
        {
            InitializeComponent();
        }

        public Donor(MainForm p)
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

        private void picBoxGift_Click(object sender, EventArgs e)
        {
            try
            {
                Gift gift = new Gift();
                gift.Show();
                this.Close();
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
                Volunteers volunteers = new Volunteers();
                volunteers.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }
    }
}
