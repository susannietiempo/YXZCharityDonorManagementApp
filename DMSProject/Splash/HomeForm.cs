using System;
using System.Data;
using System.Windows.Forms;

namespace Splash
{
    public partial class HomeForm : Form
    {
        MainForm myParent;
        public HomeForm()
        {
            InitializeComponent();
        }

        public HomeForm(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            //get data for the overview
            lblTtlDonor.Text = DataAccess.GetValue("SELECT COUNT(AccountId) FROM Account").ToString();
            lblAvgGift.Text = Convert.ToDecimal(DataAccess.GetValue("SELECT AVG(ReceivedAmount) FROM Gift")).ToString("c");
            lblTtlGiftAmt.Text = Convert.ToDecimal(DataAccess.GetValue("SELECT SUM(ReceivedAmount) FROM Gift")).ToString("c");
            lblTtlNoGift.Text = DataAccess.GetValue("SELECT COUNT(ReceivedAmount) FROM Gift").ToString();
            lblTtlVolunteers.Text = DataAccess.GetValue("Select COUNT(DISTINCT AccountId) From VolunteerAssignment").ToString();
            lblTtlHours.Text = DataAccess.GetValue("Select SUM(HoursCompleted) From VolunteerAssignment").ToString();

            //get data for the recent gifts
            ListViewItem itm;
            DataTable dt = new DataTable();

            dt = DataAccess.GetData("SELECT TOP(10) KeyName, GiftDate, ReceivedAmount " +
                                    "FROM Gift INNER JOIN Account ON Gift.AccountId = Account.AccountId ORDER BY GiftDate DESC");

            foreach (DataRow row in dt.Rows)
            {
                string[] gift = { row[0].ToString(), Convert.ToDateTime(row[1]).ToShortDateString(), Convert.ToDecimal(row[2]).ToString("c") };
                itm = new ListViewItem(gift);
                lsvRecentGifts.Items.Add(itm);
            }

            myParent.toolStripStatusLabel1.Text = ($"Welcome, {Environment.UserName}");
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Display.ShowChildForm(control,myParent,this);
        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
