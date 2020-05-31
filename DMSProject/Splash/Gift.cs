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
        #region Constructors
        public Gift()
        {
            InitializeComponent();
        }

        public Gift(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        #endregion

        #region Fields

        private int currentRecord;
        private int currentGiftId;
        private int firstGiftId;
        private int lastGiftId;
        private int? previousGiftId;
        private int? nextGiftId;
        private int totalGiftCount;
        private MainForm myParent;

        #endregion

        #region Events


        #endregion

        #region Database Actions
        /// <summary>
        /// Load and bind the constituency info to the controls on the form and handle navigation
        /// </summary>
        private void LoadDonorInfo()
        {

            string sqlAccountByID = $"SELECT (SELECT KeyName FROM Account WHERE Account.AccountId = Gift.AccountId) AS DonorName, GiftId, GiftDate, " +
                                    $"ReceivedAmount, GiftNote, GiftType, Approach, Campaign, Fund FROM Gift WHERE Gift.AccountId = {currentGiftId}";
            string sqlNav = $@"
                SELECT 
                (
                    SELECT TOP(1) AccountId  FROM Account ORDER BY KeyName
                ) AS FirstAccountId,
                q.PreviousAccountId,
                q.NextAccountId,
                (
                    SELECT TOP(1) AccountId FROM Account ORDER BY KeyName DESC
                ) as LastAccountId,
                q.RowNumber
                FROM
                (
                    SELECT AccountId, KeyName,
                    LEAD(AccountId) OVER(ORDER BY KeyName) AS NextAccountId,
                    LAG(AccountId) OVER(ORDER BY KeyName) AS PreviousAccountId,
                    ROW_NUMBER() OVER(ORDER BY KeyName) AS 'RowNumber'
                    FROM Account
                ) AS q
                WHERE q.AccountId = {currentGiftId}
                ORDER BY q.KeyName";

            string sqlGiftCount = "SELECT COUNT(GiftId) AS GiftCount FROM Gift";
            sqlNav = DataAccess.SQLCleaner(sqlNav);

            string[] sqlStatements = new string[] { sqlAccountByID, sqlNav, sqlDonorCount };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow selectedDonor = ds.Tables[0].Rows[0];

                txtAccountId.Text = selectedDonor["AccountId"].ToString();
                cboConstituencyType.SelectedValue = Convert.ToInt32(selectedDonor["ConstituencyTypeId"]);
                txtTitle.Text = selectedDonor["Title"].ToString();
                txtFirstName.Text = selectedDonor["FirstName"].ToString();
                txtMidName.Text = selectedDonor["MiddleName"].ToString();
                txtLastName.Text = selectedDonor["LastName"].ToString();
                txtOrgName.Text = selectedDonor["OrganizationName"].ToString();
                txtSuffix.Text = selectedDonor["Suffix"].ToString();
                txtAddress.Text = selectedDonor["StreetAddress"].ToString();
                txtCity.Text = selectedDonor["City"].ToString();
                txtProvince.Text = selectedDonor["Province"].ToString();
                txtCountry.Text = selectedDonor["Country"].ToString();
                txtPostalCode.Text = selectedDonor["PostalCode"].ToString();
                txtGender.Text = selectedDonor["Gender"].ToString();
                txtEmail.Text = selectedDonor["Email"].ToString();
                txtBirthdate.Text = selectedDonor["BirthDate"] == DBNull.Value ? "" : Convert.ToDateTime(selectedDonor["BirthDate"]).ToShortDateString();
                txtPhonenumber.Text = selectedDonor["PhoneNumber"].ToString();
                txtDateAdded.Text = Convert.ToDateTime(selectedDonor["DateAdded"]).ToShortDateString();
                chkIsActive.Checked = !Convert.ToBoolean(selectedDonor["IsInactive"]);

                firstAccountId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstAccountId"]);
                previousAccountId = ds.Tables[1].Rows[0]["PreviousAccountId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousAccountId"]) : (int?)null;
                nextAccountId = ds.Tables[1].Rows[0]["NextAccountId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextAccountId"]) : (int?)null;
                lastAccountId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastAccountId"]);
                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalDonorCount = Convert.ToInt32(ds.Tables[2].Rows[0]["DonorCount"]);

                myParent.toolStripStatusLabel1.Text = $"Displaying constituent {currentRecord} of {totalDonorCount}";
                UtilityHelper.ControlState(panelDonor.Controls, true);
                txtAccountId.Enabled = false;
            }
            else
            {
                MessageBox.Show("The constituents no longer exists");
                LoadFirstDonor();
            }

        }
        #endregion

        #region Utility Methods

        #endregion


        private void ShowNewForm(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Display.ShowChildForm(control, myParent, this);
        }

    }
}
