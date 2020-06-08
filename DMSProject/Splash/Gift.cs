using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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


        private void Gift_Load(object sender, EventArgs e)
        {
            LoadDonorName();
            LoadFirstGift();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                errProvider.Clear();
                btnCancelReset.Text = "Cancel";
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtGiftId.Enabled = false;
                txtGiftId.BackColor = Color.LightGray;

                UtilityHelper.ControlState(panelGift.Controls, false);
                UtilityHelper.ClearControls(panelGift.Controls);
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);

                UtilityHelper.ToolStripDisplay(myParent, "Action Required: Please select a donor to proceed!", Color.DarkRed);

                LoadDonorName();
                cboDonorName.Focus();

                txtDate.Text = DateTime.Today.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)

        {
            try
            {
                btnCancelReset.Text = "Cancel";
                errProvider.Clear();
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtGiftId.Enabled = false;
                txtGiftId.BackColor = Color.LightGray;
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);
                cboDonorName.Focus();
                UtilityHelper.ToolStripDisplay(myParent, "Edit Gift...", Color.Black);
                UtilityHelper.ControlState(panelGift.Controls, false);
                errProvider.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Handles the save and delete delet events. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSaveDelete.Text == "Save")
                {
                    UtilityHelper.ProgressBar(myParent);
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (txtGiftId.Text == string.Empty)
                        {
                            CreateGift();
                        }
                        else
                        {
                            SaveGiftChanges();
                        }
                    }
                }

                else
                {
                    if (btnSaveDelete.Text == "Delete")
                    {
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        if (MessageBox.Show("Are you sure you want to delete this gift?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            DeleteGift();
                        }
                    }
                }

                errProvider.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            ButtonReset();

            myParent.prgBar.Value = 0;
            myParent.statusStrip.Refresh();
        }

        /// <summary>
        /// Cancel an add, edit, or delete action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnCancelReset.Text == "Reset")
                {
                    txtSearch.Text = "";
                    dgvGiftDetails.DataSource = null;
                    LoadDonorName();
                    LoadFirstGift();
                    LoadAccountInfo();

                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to cancel?", "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadGiftInfo();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnSaveDelete.Text = "Delete";
                        btnSaveDelete.BackColor = Color.IndianRed;
                        btnCancelReset.Text = "Reset";
                        errProvider.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
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
                        currentGiftId = firstGiftId;
                        myParent.toolStripStatusLabel1.Text = "The first gift is currently displayed";
                        break;
                    case "btnLast":
                        currentGiftId = lastGiftId;
                        myParent.toolStripStatusLabel1.Text = "The last gift is currently displayed";
                        break;
                    case "btnPrevious":
                        currentGiftId = previousGiftId.Value;
                        if (currentRecord - 1 == 1)
                            myParent.toolStripStatusLabel1.Text = "The first gift is currently displayed";
                        break;
                    case "btnNext":
                        currentGiftId = nextGiftId.Value;
                        if (currentRecord == totalGiftCount - 1)
                            myParent.toolStripStatusLabel1.Text = "The last gift is currently displayed";
                        break;
                }

                LoadGiftInfo();
                UtilityHelper.NextPreviousButtonManagement(btnPrevious, btnNext, previousGiftId, nextGiftId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Handles the error provider actions for textboxes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    //Implment business rule 002
                    // A gift record can have one of the following gift types: Cash, In - Kind, Cheque, Pledge, PAD, Credit Card, EFT.

                    if (txt.Name == "txtGiftType")
                    {
                        string giftType = txtGiftType.Text.Trim();
                        List<string> validGiftType = new List<string> { "Cash", "In - Kind", "Cheque", "Pledge", "PAD", "Credit Card", "EFT" };

                        if (!validGiftType.Contains(giftType))
                        {
                            errMsg = $"{txtBoxName} should be Cash, In - Kind, Cheque, Pledge, PAD, Credit Card, EFT only";
                            e.Cancel = true;
                        }
                    }
                    if (txt.Name == "txtDate")
                    {
                        if (!IsDate(txt.Text))
                        {
                            errMsg = $"{txtBoxName} is not a valid date. (Format: yyyy-mm-dd)";
                            e.Cancel = true;
                        }
                    }

                    if (txt.Name == "txtReceivedAmount")
                    {
                        if (!IsNumeric(decimal.Parse(txt.Text, NumberStyles.AllowCurrencySymbol | NumberStyles.Number).ToString()))
                        {
                            errMsg = $"{txtBoxName} is not numeric ";
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

        private void cboDonorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UtilityHelper.EnableControl(panelGift.Controls, true);
                txtGiftId.Enabled = false;

                if (cboDonorName.SelectedIndex == 0)
                {
                    UtilityHelper.EnableControl(panelGift.Controls, false);
                    cboDonorName.Enabled = true;
                    cboDonorName.Focus();
                }
                else
                {
                    UtilityHelper.ToolStripDisplay(myParent, "Add gift...", Color.Black);
                    if (btnAdd.Visible)
                    {
                        UtilityHelper.ControlState(panelGift.Controls, true);

                    }
                    else
                    {
                        UtilityHelper.ControlState(panelGift.Controls, false);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        } //end method


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
                    int accountId = Convert.ToInt32(currDonorRow.Cells[0].Value);
                    string sql = $"SELECT GiftId, GiftDate, ReceivedAmount, GiftType, Fund FROM Gift WHERE AccountId = {accountId} ORDER BY GiftDate DESC";

                    dgvGiftDetails.DataSource = DataAccess.GetData(sql);
                    dgvGiftDetails.AutoResizeColumns();
                    dgvGiftDetails.Columns[0].Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        private void dgvGiftDetails_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvGiftDetails.CurrentRow == null)
                {
                    return;
                }
                if (dgvGiftDetails.CurrentRow.Selected)
                {
                    DataGridViewRow currGiftRow = dgvGiftDetails.CurrentRow;
                    currentGiftId = Convert.ToInt32(currGiftRow.Cells[0].Value);

                    LoadGiftInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Database Actions

        /// <summary>
        /// Loads the donor information to the datagridvuew
        /// </summary>
        private void LoadAccountInfo()
        {
            dgvDonors.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName, City, PostalCode FROM Account ORDER BY KeyName");
            dgvDonors.AutoResizeColumns();
            dgvDonors.Columns[0].Visible = false;
        }

        /// <summary>
        /// Load account information to the data grid view for accounts.
        /// </summary>
        /// <param name="text"></param>
        private void LoadAccountInfo(string text)
        {
            dgvDonors.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName, City, PostalCode FROM Account WHERE KeyName LIKE '%' + '{text}' + '%' ORDER BY KeyName");
            dgvDonors.AutoResizeColumns();
            dgvDonors.Columns[0].Visible = false;
        }

        private void LoadDonorName()
        {
            DataTable dt = DataAccess.GetData("SELECT AccountId, KeyName  FROM Account ORDER BY KeyName");
            UIUtilities.FillListControl(cboDonorName, "KeyName", "AccountId", dt, true, "--Select a donor--");
        }

        /// <summary>
        /// Load the first gift in the table. Ordering the gifts by giftdate
        /// </summary>
        private void LoadFirstGift()
        {
            currentGiftId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) GiftId FROM Gift ORDER BY GiftDate DESC"));
            LoadGiftInfo();
        }


        /// <summary>
        /// Load and bind the gift info to the controls on the form and handle navigation
        /// </summary>
        /// 
        private void LoadGiftInfo()
        {

            string sqlGiftById = $"SELECT (SELECT KeyName FROM Account WHERE Account.AccountId = Gift.AccountId) AS DonorName, GiftId, GiftDate, " +
                                    $"ReceivedAmount, GiftNote, GiftType, Approach, Campaign, Fund, AccountId FROM Gift WHERE GiftId = {currentGiftId}";
            string sqlNav = $@"
             SELECT 
                (
                    SELECT TOP(1) GiftId  FROM Gift ORDER BY GiftDate DESC
                ) AS FirstGiftId,
                q.PreviousGiftId,
                q.NextGiftId,
                (
                    SELECT TOP(1) GiftId FROM Gift ORDER BY GiftDate 
                ) as LastGiftId,
                q.RowNumber
                FROM
                (
                    SELECT GiftId, GiftDate,
                    LEAD(GiftId) OVER(ORDER BY GiftDate DESC) AS NextGiftId,
                    LAG(GiftId) OVER(ORDER BY GiftDate DESC) AS PreviousGiftId,
                    ROW_NUMBER() OVER(ORDER BY GiftDate DESC) AS 'RowNumber'
                    FROM Gift
                ) AS q
                WHERE q.GiftId = {currentGiftId}
                ORDER BY q.GiftDate
             ";

            string sqlGiftCount = "SELECT COUNT(GiftId) AS GiftCount FROM Gift";
            sqlNav = DataAccess.SQLCleaner(sqlNav);

            string[] sqlStatements = new string[] { sqlGiftById, sqlNav, sqlGiftCount };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow selectedGift = ds.Tables[0].Rows[0];

                txtGiftId.Text = selectedGift["GiftId"].ToString();
                cboDonorName.SelectedValue = Convert.ToInt32(selectedGift["AccountId"]);
                txtReceivedAmount.Text = Convert.ToDecimal(selectedGift["ReceivedAmount"]).ToString("c");
                txtGiftNote.Text = selectedGift["GiftNote"].ToString();
                txtGiftType.Text = selectedGift["GiftType"].ToString();
                txtApproach.Text = selectedGift["Approach"].ToString();
                txtCampaign.Text = selectedGift["Campaign"].ToString();
                txtFund.Text = selectedGift["Fund"].ToString();
                txtDate.Text = Convert.ToDateTime(selectedGift["GiftDate"]).ToShortDateString();


                firstGiftId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstGiftId"]);
                previousGiftId = ds.Tables[1].Rows[0]["PreviousGiftId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousGiftId"]) : (int?)null;
                nextGiftId = ds.Tables[1].Rows[0]["NextGiftId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextGiftId"]) : (int?)null;
                lastGiftId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastGiftId"]);
                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalGiftCount = Convert.ToInt32(ds.Tables[2].Rows[0]["GiftCount"]);
                UtilityHelper.ToolStripDisplay(myParent, $"Displaying gift { currentRecord} of { totalGiftCount}", Color.Black);
                UtilityHelper.ControlState(panelGift.Controls, true);
                txtGiftId.Enabled = false;
            }
            else
            {
                MessageBox.Show("The gift no longer exists");
                LoadFirstGift();
            }

        }


        /// <summary>
        /// Create the new gift record to the database. 
        /// </summary>
        private void CreateGift()
        {
            string sqlInsertGift = $@"
                        INSERT INTO Gift (ReceivedAmount, GiftNote, GiftType, Approach, GiftDate, Campaign, Fund,  AccountId )
                        VALUES
                        (
                           {Convert.ToDecimal(txtReceivedAmount.Text.Trim())},
                           '{DataAccess.SQLFix(txtGiftNote.Text.Trim())}',
                           '{DataAccess.SQLFix(txtGiftType.Text.Trim())}',
                           '{DataAccess.SQLFix(txtApproach.Text.Trim())}',
                           '{Convert.ToDateTime(txtDate.Text.Trim())}',
                           '{DataAccess.SQLFix(txtCampaign.Text.Trim())}',
                           '{DataAccess.SQLFix(txtFund.Text.Trim())}',
                           {cboDonorName.SelectedValue}
                    )";

            sqlInsertGift = DataAccess.SQLCleaner(sqlInsertGift);
            int rowsAffected = DataAccess.SendData(sqlInsertGift);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Gift was added succesfully!", "Gift was not added. Please try again!");
            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
            LoadGiftInfo();

        } //end create method

        /// <summary>
        /// Saves the updates in the gift form information to the record in the database.
        /// </summary>
        private void SaveGiftChanges()
        {
            decimal amount = Convert.ToDecimal((txtReceivedAmount.Text.Trim().Replace("$", "")));
            string sqlUpdateGift = $@"
                         UPDATE Gift
                         SET
                            ReceivedAmount = {amount},
                            GiftNote = '{DataAccess.SQLFix(txtGiftNote.Text.Trim())}',
                            GiftType = '{DataAccess.SQLFix(txtGiftType.Text.Trim())}',
                            Approach = '{DataAccess.SQLFix(txtApproach.Text.Trim())}',
                            GiftDate = '{Convert.ToDateTime(txtDate.Text.Trim())}',
                            Campaign = '{DataAccess.SQLFix(txtCampaign.Text.Trim())}',
                            Fund = '{DataAccess.SQLFix(txtFund.Text.Trim())}',
                            AccountId = {cboDonorName.SelectedValue}
                            WHERE GiftId = {Convert.ToInt32(txtGiftId.Text)}
                ";

            sqlUpdateGift = DataAccess.SQLCleaner(sqlUpdateGift);
            int rowsAffected = DataAccess.SendData(sqlUpdateGift);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Gift was updated succesfully!", "Gift was not updated. Please try again");
            LoadGiftInfo();

            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
        }

        private void DeleteGift()
        {
            string sqlDelete = $"DELETE FROM Gift WHERE GiftId = {Convert.ToInt32(txtGiftId.Text)}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Gift was deleted succesfully!", "Gift was not deleted. Please try again");
            LoadGiftInfo();
            LoadAccountInfo();

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

        private bool IsNumeric(string value)
        {
            return Decimal.TryParse(value, out decimal a);
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



        #endregion

        #region Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearch.Text;

            LoadAccountInfo(text);
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Enabled = true;
            txtSearch.ReadOnly = false;
        }

        #endregion

        private void labelLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                myParent.Close();
            }
        }
    }
}
