using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash
{
    public partial class Donor : Form
    {

        #region Fields

        private int currentRecord;
        private int currentAccountId;
        private int firstAccountId;
        private int lastAccountId;
        private int? previousAccountId;
        private int? nextAccountId;
        private int totalDonorCount;
        private MainForm myParent;

        #endregion

        #region Constructors
        public Donor()
        {
            InitializeComponent();
        }
        public Donor(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        #endregion

        #region Events

        private void Donor_Load(object sender, EventArgs e)
        {
            LoadConstituencyType();
            LoadFirstDonor();
            LoadAccountInfo();

        }

        /// <summary>
        /// Handles the ShowNewForm event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewForm(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                Display.ShowChildForm(control, myParent, this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Adds a new gift record to the database. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewRecord(object sender, EventArgs e)
        {
            try
            {
                //create a method for this
                btnCancelReset.Text = "Cancel";
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtAccountId.Enabled = false;
                txtAccountId.BackColor = Color.LightGray;

                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);
                txtTitle.Focus();
                UtilityHelper.ControlState(panelDonor.Controls, false);
                UtilityHelper.ClearControls(panelDonor.Controls);
                myParent.toolStripStatusLabel1.Text = "Action Required: Please select a constituency type to proceed!";
                myParent.toolStripStatusLabel1.ForeColor = Color.DarkRed;

                LoadConstituencyType();
                txtDateAdded.Text = DateTime.Today.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
           
        }

        private void btnSaveDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSaveDelete.Text == "Save")
                {
                    UtilityHelper.ProgressBar(myParent);
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (txtAccountId.Text == string.Empty)
                        {
                            CreateAccount();
                        }
                        else
                        {
                            SaveProductChanges();
                        }
                    }
                }

                else
                {
                    if (btnSaveDelete.Text == "Delete")
                    {
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            DeleteDonor();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }


            btnSaveDelete.Text = "Delete";
            btnCancelReset.Text = "Reset";
            btnSaveDelete.BackColor = Color.IndianRed;

            ButtonReset();

            myParent.prgBar.Value = 0;
            myParent.statusStrip.Refresh();
        }
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (btnCancelReset.Text == "Reset")
                {
                    txtSearch.Text = "";
                    LoadConstituencyType();
                    LoadFirstDonor();
                    LoadAccountInfo();

                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to cancel?", "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadDonorInfo();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnSaveDelete.Text = "Delete";
                        btnCancelReset.Text = "Reset";
                        btnSaveDelete.BackColor = Color.IndianRed;
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        private void cboConstituencyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UtilityHelper.EnableControl(panelDonor.Controls, true);
                txtAccountId.Enabled = false;

                if (cboConstituencyType.SelectedIndex == 0)
                {
                    UtilityHelper.EnableControl(panelDonor.Controls, false);
                    cboConstituencyType.Enabled = true;
                    cboConstituencyType.Focus();
                }

                if (cboConstituencyType.SelectedIndex == 1)
                {

                    txtOrgName.Enabled = false;
                    txtOrgName.BackColor = Color.DarkGray;
                    txtTitle.Focus();
                    myParent.toolStripStatusLabel1.ForeColor = Color.Black;
                    myParent.toolStripStatusLabel1.Text = "Adding constituency";

                }
                if (cboConstituencyType.SelectedIndex == 2)
                {
                    txtTitle.Enabled = false;
                    txtTitle.BackColor = Color.DarkGray;
                    txtSuffix.Enabled = false;
                    txtSuffix.BackColor = Color.DarkGray;
                    txtFirstName.Enabled = false;
                    txtFirstName.BackColor = Color.DarkGray;
                    txtMidName.Enabled = false;
                    txtMidName.BackColor = Color.DarkGray;
                    txtLastName.Enabled = false;
                    txtLastName.BackColor = Color.DarkGray;
                    txtGender.Enabled = false;
                    txtGender.BackColor = Color.DarkGray;
                    txtBirthdate.Enabled = false;
                    txtBirthdate.BackColor = Color.DarkGray;
                    txtOrgName.Focus();
                    myParent.toolStripStatusLabel1.ForeColor = Color.Black;
                    myParent.toolStripStatusLabel1.Text = "Adding constituency";
                }

                if (btnAdd.Visible)
                {
                    UtilityHelper.ControlState(panelDonor.Controls, true);
                }
                else
                {
                    UtilityHelper.ControlState(panelDonor.Controls, false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        } //end method


        private void txt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                string txtBoxName = txt.Tag.ToString();
                string errMsg = null;

                if (!txt.Enabled || txt.ReadOnly)
                {
                    errProvider.Clear();
                }
                else
                {
                    if (txt.Text == string.Empty)
                    {
                        errMsg = $"{txtBoxName} is required.";
                        e.Cancel = true;
                    }

                    if (txt.Name == "txtBirthdate" || txt.Name == "txtDateAdded")
                    {
                        if (!IsDate(txt.Text))
                        {
                            errMsg = $"{txtBoxName} is not a valid date. (Format: yyyy-mm-dd)";
                            e.Cancel = true;
                        }
                    }

                    errProvider.SetError(txt, errMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }



        } //txt_Validating end method

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnCancelReset.Text = "Cancel";
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtAccountId.Enabled = false;
                txtAccountId.BackColor = Color.LightGray;
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);
                txtTitle.Focus();
                myParent.toolStripStatusLabel1.Text = "Edit Constituent";
                UtilityHelper.ControlState(panelDonor.Controls, false);

                if (cboConstituencyType.SelectedIndex == 1)
                {
                    txtOrgName.Enabled = false;
                    txtOrgName.BackColor = Color.DarkGray;
                    txtTitle.Focus();
                }
                if (cboConstituencyType.SelectedIndex == 2)
                {
                    txtTitle.Enabled = false;
                    txtTitle.BackColor = Color.DarkGray;
                    txtSuffix.Enabled = false;
                    txtSuffix.BackColor = Color.DarkGray;
                    txtFirstName.Enabled = false;
                    txtFirstName.BackColor = Color.DarkGray;
                    txtMidName.Enabled = false;
                    txtMidName.BackColor = Color.DarkGray;
                    txtLastName.Enabled = false;
                    txtLastName.BackColor = Color.DarkGray;
                    txtGender.Enabled = false;
                    txtGender.BackColor = Color.DarkGray;
                    txtBirthdate.Enabled = false;
                    txtBirthdate.BackColor = Color.DarkGray;
                    txtOrgName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        } //end btnEdit_Click method

        private void dgvDonors_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDonors.CurrentRow == null)
                {
                    return;
                }

                if (dgvDonors.CurrentRow.Selected)
                {
                    DataGridViewRow currDonorRow = dgvDonors.CurrentRow;

                    currentAccountId = Convert.ToInt32(currDonorRow.Cells[0].Value);

                    LoadDonorInfo();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        private void labelLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                myParent.Close();
            }
        }

        #endregion

        #region Database Actions
        /// <summary>
        /// Lads the data on the constituency combobox.
        /// </summary>
        private void LoadConstituencyType()
        {
            DataTable dt = DataAccess.GetData("SELECT ConstituencyTypeId, ConstituencyTypeName  FROM ConstituencyType ORDER BY ConstituencyTypeName");
            UIUtilities.FillListControl(cboConstituencyType, "ConstituencyTypeName", "ConstituencyTypeId", dt, true, "Select constituency type");
        }

        /// <summary>
        /// Load and bind the constituency info to the controls on the form and handle navigation
        /// </summary>
        private void LoadDonorInfo()
        {

            string sqlAccountByID = $"SELECT * FROM Account WHERE AccountId = {currentAccountId}";
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
                WHERE q.AccountId = {currentAccountId}
                ORDER BY q.KeyName";

            string sqlDonorCount = "SELECT COUNT(AccountId) AS DonorCount FROM Account";
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
                myParent.toolStripStatusLabel1.ForeColor = Color.Black;
                UtilityHelper.ControlState(panelDonor.Controls, true);
                txtAccountId.Enabled = false;

            }
            else
            {
                MessageBox.Show("The constituents no longer exists");
                LoadFirstDonor();
            }

        }



        /// <summary>
        /// Load the first donor in the table. Ordering the donors by KeyName
        /// </summary>
        private void LoadFirstDonor()
        {
            currentAccountId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) AccountId FROM Account ORDER BY KeyName"));
            LoadDonorInfo();
        }

        private void LoadAccountInfo()
        {
            dgvDonors.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName FROM Account ORDER BY KeyName");
            dgvDonors.AutoResizeColumns();
        }

        private void LoadAccountInfo(string text)
        {
            dgvDonors.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName FROM Account WHERE KeyName LIKE '%' + '{text}' + '%' ORDER BY KeyName");
            dgvDonors.AutoResizeColumns();
        }


        /// <summary>
        /// Saves the updates in the donor form information to the record in teh database.
        /// </summary>
        private void SaveProductChanges()
        {

            DateTime? dbo = DateTime.TryParse(txtBirthdate.Text.Trim(), out DateTime d) ? (DateTime?)d : null;
            string keyName = (String.IsNullOrEmpty(txtOrgName.Text.Trim())) ? $"{txtLastName.Text.Trim()}, {txtFirstName.Text.Trim()} {txtMidName.Text.Trim()}" : txtOrgName.Text.Trim();
            string sqlUpdateAccount;
            if (Convert.ToInt32(cboConstituencyType.SelectedValue) == 1)
            {
                sqlUpdateAccount = $@"
                         UPDATE Account
                         SET
                            Title = '{DataAccess.SQLFix(txtTitle.Text.Trim())}',
                            FirstName = '{DataAccess.SQLFix(txtFirstName.Text.Trim())}',
                            MiddleName = '{DataAccess.SQLFix(txtMidName.Text.Trim())}',
                            LastName = '{DataAccess.SQLFix(txtLastName.Text.Trim())}',
                            KeyName = '{DataAccess.SQLFix(keyName)}',
                            Suffix = '{DataAccess.SQLFix(txtSuffix.Text.Trim())}',
                            StreetAddress = '{DataAccess.SQLFix(txtAddress.Text.Trim())}',
                            Gender = '{DataAccess.SQLFix(txtGender.Text.Trim())}',
                            Email = '{DataAccess.SQLFix(txtEmail.Text.Trim())}',
                            Birthdate = '{dbo}',
                            PhoneNumber = '{DataAccess.SQLFix(txtPhonenumber.Text.Trim())}',
                            ConstituencyTypeId = '{cboConstituencyType.SelectedValue}',
                            IsInactive = { (chkIsActive.Checked ? 0 : 1) },
                            DateAdded = '{Convert.ToDateTime(txtDateAdded.Text.Trim())}',
                            City = '{DataAccess.SQLFix(txtCity.Text.Trim())}',
                            Province = '{DataAccess.SQLFix(txtProvince.Text.Trim())}',
                            Country = '{DataAccess.SQLFix(txtCountry.Text.Trim())}',
                            PostalCode = '{DataAccess.SQLFix(txtPostalCode.Text.Trim())}'
                            WHERE AccountId = {Convert.ToInt32(txtAccountId.Text)}
                ";
            }
            else
            {
                sqlUpdateAccount = $@"
                         UPDATE Account
                         SET
                            OrganizationName = '{DataAccess.SQLFix(txtOrgName.Text.Trim())}',
                            KeyName =  '{DataAccess.SQLFix(keyName)}',
                            StreetAddress = '{DataAccess.SQLFix(txtAddress.Text.Trim())}',
                            Email = '{DataAccess.SQLFix(txtEmail.Text.Trim())}',
                            PhoneNumber = '{DataAccess.SQLFix(txtPhonenumber.Text.Trim())}',
                            ConstituencyTypeId =  '{cboConstituencyType.SelectedValue}',
                            IsInactive = {(chkIsActive.Checked ? 0 : 1)}, 
                            DateAdded = '{Convert.ToDateTime(txtDateAdded.Text.Trim())}',
                            City = '{DataAccess.SQLFix(txtCity.Text.Trim())}',
                            Province = '{DataAccess.SQLFix(txtProvince.Text.Trim())}',
                            Country = '{DataAccess.SQLFix(txtCountry.Text.Trim())}',
                            PostalCode = '{DataAccess.SQLFix(txtPostalCode.Text.Trim())}'
                            WHERE AccountId = {Convert.ToInt32(txtAccountId.Text)}
                ";
            }

            sqlUpdateAccount = DataAccess.SQLCleaner(sqlUpdateAccount);
            int rowsAffected = DataAccess.SendData(sqlUpdateAccount);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Constituent was updated succesfully!", "Constituent was not updated. Please try again");
            LoadDonorInfo();

            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
        }

        /// <summary>
        /// Create the new donor account to the database. 
        /// </summary>
        private void CreateAccount()
        {
            DateTime? dbo = DateTime.TryParse(txtBirthdate.Text.Trim(), out DateTime d) ? (DateTime?)d : null;
            string keyName = (String.IsNullOrEmpty(txtOrgName.Text.Trim())) ? $"{txtLastName.Text.Trim()}, {txtFirstName.Text.Trim()} {txtMidName.Text.Trim()}" : txtOrgName.Text.Trim();
            string sqlInsertAccount;
            if (Convert.ToInt32(cboConstituencyType.SelectedValue) == 1)
            {
                sqlInsertAccount = $@"
                         INSERT INTO Account
                          (
                            Title,
                            FirstName,
                            MiddleName,
                            LastName,
                            KeyName,
                            Suffix,
                            StreetAddress,
                            Gender,
                            Email,
                            Birthdate,
                            PhoneNumber,
                            ConstituencyTypeId,
                            IsInactive,
                            DateAdded,
                            City,
                            Province,
                            Country,
                            PostalCode
                           )
                         VALUES
                          (
                                '{DataAccess.SQLFix(txtTitle.Text.Trim())}',
                                '{DataAccess.SQLFix(txtFirstName.Text.Trim())}',
                                '{DataAccess.SQLFix(txtMidName.Text.Trim())}',
                                '{DataAccess.SQLFix(txtLastName.Text.Trim())}',
                                 '{DataAccess.SQLFix(keyName)}',
                                '{DataAccess.SQLFix(txtSuffix.Text.Trim())}',
                                '{DataAccess.SQLFix(txtAddress.Text.Trim())}',
                                '{DataAccess.SQLFix(txtGender.Text.Trim())}',
                                '{DataAccess.SQLFix(txtEmail.Text.Trim())}',
                                 '{dbo}',  
                                '{DataAccess.SQLFix(txtPhonenumber.Text.Trim())}',
                                '{cboConstituencyType.SelectedValue}',
                                 {(chkIsActive.Checked ? 0 : 1)},  
                                '{Convert.ToDateTime(txtDateAdded.Text.Trim())}',
                                '{DataAccess.SQLFix(txtCity.Text.Trim())}',
                                '{DataAccess.SQLFix(txtProvince.Text.Trim())}',
                                '{DataAccess.SQLFix(txtCountry.Text.Trim())}',
                                '{DataAccess.SQLFix(txtPostalCode.Text.Trim())}'
                    )";
            }
            else
            {
                sqlInsertAccount = $@"
                         INSERT INTO Account
                          (
                            OrganizationName,
                            KeyName,
                            StreetAddress,
                            Email,
                            PhoneNumber,
                            ConstituencyTypeId,
                            IsInactive,
                            DateAdded,
                            City,
                            Province,
                            Country,
                            PostalCode
                           )
                         VALUES
                          (
                                '{DataAccess.SQLFix(txtOrgName.Text.Trim())}',
                                 '{DataAccess.SQLFix(keyName)}',
                                '{DataAccess.SQLFix(txtAddress.Text.Trim())}',
                                '{DataAccess.SQLFix(txtEmail.Text.Trim())}',
                                '{DataAccess.SQLFix(txtPhonenumber.Text.Trim())}',
                                '{cboConstituencyType.SelectedValue}',
                                 {(chkIsActive.Checked ? 0 : 1)},  
                                '{Convert.ToDateTime(txtDateAdded.Text.Trim())}',
                                '{DataAccess.SQLFix(txtCity.Text.Trim())}',
                                '{DataAccess.SQLFix(txtProvince.Text.Trim())}',
                                '{DataAccess.SQLFix(txtCountry.Text.Trim())}',
                                '{DataAccess.SQLFix(txtPostalCode.Text.Trim())}'
                    )";
            }

            sqlInsertAccount = DataAccess.SQLCleaner(sqlInsertAccount);
            int rowsAffected = DataAccess.SendData(sqlInsertAccount);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Constituent was added succesfully!", "Constituent was not added. Please try again!");
            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
            LoadDonorInfo();

        } //end create method

        /// <summary>
        /// Handles the delete SQL action.
        /// </summary>
        private void DeleteDonor()
        {
            //Business Rule: A Constituent Record can only be deleted if there is no associated give or volunteer assignment.

            string sqlDonorGiftNum = $"SELECT COUNT(*) FROM Gift WHERE AccountId = {Convert.ToInt32(txtAccountId.Text)}";
            string sqlDonorVolunteerNum = $"SELECT COUNT(*) FROM VolunteerAssignment  WHERE AccountId = {Convert.ToInt32(txtAccountId.Text)}";

            if ((Convert.ToInt32(DataAccess.GetValue(sqlDonorGiftNum)) == 0 && Convert.ToInt32(DataAccess.GetValue(sqlDonorVolunteerNum)) == 0))
            {
                string sqlDelete = $"DELETE FROM Account WHERE AccountId = {Convert.ToInt32(txtAccountId.Text)}";

                int rowsAffected = DataAccess.SendData(sqlDelete);
              
                UtilityHelper.ActionStatusMessage(rowsAffected, "Constituent was deleted succesfully!", "Constituent was not deleted. Please try again");
                LoadFirstDonor();
            }
            else
            {
                MessageBox.Show("Constituent can't be deleted due to previous volunteer or gift history.", "Failed", MessageBoxButtons.OK);
            }

            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Validates if a string is in a  valid date format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsDate(string value)
        {
            return DateTime.TryParse(value, out DateTime a);
        }


        /// <summary>
        /// Resets the CRUD buttons to default state. 
        /// </summary>

        private void ButtonReset()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnSaveDelete.Text = "Delete";
            btnSaveDelete.BackColor = Color.IndianRed;
        }


        /// <summary>
        /// Handle navigation button interaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                myParent.toolStripStatusLabel1.Text = string.Empty;

                switch (b.Name)
                {
                    case "btnFirst":
                        currentAccountId = firstAccountId;
                        myParent.toolStripStatusLabel1.Text = "The first constituent is currently displayed";
                        break;
                    case "btnLast":
                        currentAccountId = lastAccountId;
                        myParent.toolStripStatusLabel1.Text = "The last constituent is currently displayed";
                        break;
                    case "btnPrevious":
                        currentAccountId = previousAccountId.Value;
                        if (currentRecord - 1 == 1)
                            myParent.toolStripStatusLabel1.Text = "The first constituent is currently displayed";
                        break;
                    case "btnNext":
                        currentAccountId = nextAccountId.Value;
                        if (currentRecord == totalDonorCount - 1)
                            myParent.toolStripStatusLabel1.Text = "The last constituent is currently displayed";
                        break;
                }

                LoadDonorInfo();
                UtilityHelper.NextPreviousButtonManagement(btnPrevious, btnNext, previousAccountId, nextAccountId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                string text = txtSearch.Text;

                LoadAccountInfo(text);

            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Enabled = true;
            txtSearch.ReadOnly = false;
        }

        #endregion

      
    }
}
