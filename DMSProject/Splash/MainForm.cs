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
            try
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

                //get data for the overview
                lblTtlDonor.Text = DataAccess.GetValue("SELECT COUNT(AccountId) FROM Account").ToString();
                lblAvgGift.Text = Convert.ToDecimal(DataAccess.GetValue("SELECT AVG(ReceivedAmount) FROM Gift")).ToString("c");
                lblTtlGiftAmt.Text = Convert.ToDecimal(DataAccess.GetValue("SELECT SUM(ReceivedAmount) FROM Gift")).ToString("c");
                lblTtlNoGift.Text = DataAccess.GetValue("SELECT COUNT(ReceivedAmount) FROM Gift").ToString();
                lblTtlVolunteers.Text = DataAccess.GetValue("Select COUNT(DISTINCT AccountId) From VolunteerAssignment").ToString();
                lblTtlHours.Text = DataAccess.GetValue("Select SUM(HoursCompleted) From VolunteerAssignment").ToString();

                //get data for the recent gifts
                string donor;
                ListViewItem itm;
                DataTable dt = new DataTable();
                
                dt = DataAccess.GetData("SELECT TOP(10) FirstName + ' ' + LastName AS FullName, [Organization Name], GiftDate, ReceivedAmount " +
                                        "FROM Gift INNER JOIN Account ON Gift.AccountId = Account.AccountId ORDER BY GiftDate DESC");

                foreach (DataRow row in dt.Rows)
                {
                    donor = (String.IsNullOrEmpty(row[0].ToString()) || String.IsNullOrWhiteSpace(row[0].ToString())) ? row[1].ToString() : row[0].ToString();
                    string[] gift = { donor, Convert.ToDateTime(row[2]).ToShortDateString(), Convert.ToDecimal(row[3]).ToString("c")  };
                    itm = new ListViewItem(gift);
                    lsvRecentGifts.Items.Add(itm);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }


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

        private void labelLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
