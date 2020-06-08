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
    public partial class VolunteerAssignment : Form
    {
        #region Field
        MainForm myParent;

        private int currentProgramId = 0;
        private int currentAccountId = 0;

        private int firstProgramId = 0;
        private int firstAccountId = 0;

        private int lastProgramId = 0;
        private int lastAccountId = 0;

        private int? nextProgramId = 0;
        private int? nextAccountId = 0;

        private int? previousProgramId = 0;
        private int? previousAccountId = 0;


        #endregion

        #region Constructor
        public VolunteerAssignment()
        {
            InitializeComponent();
        }

        public VolunteerAssignment(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }
        #endregion


        #region Events
        private void ShowNewForm(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Display.ShowChildForm(control, myParent, this);
        }

        private void VolunteerAssignment_Load(object sender, EventArgs e)
        {
            LoadDonorName();
            LoadVolunteerProgram();
            LoadFirstAssignment();
            LoadAssignmentDataGrid();
            cboDonorName.Enabled = false;
            cboVolunterProgram.Enabled = false;
            txtCurrentHours.ReadOnly = true;
            txtSignedUpHours.ReadOnly = true;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                errProvider.Clear();
                btnCancelReset.Text = "Cancel";
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Add";
                btnSaveDelete.BackColor = Color.SeaGreen;

                UtilityHelper.ControlState(panelAssignment.Controls, false);
                UtilityHelper.ClearControls(panelAssignment.Controls);
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);

                LoadApplicableDonorName();
                LoadActiveVolunteerProgram();
                cboDonorName.Focus();

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
               
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);
                
                UtilityHelper.ToolStripDisplay(myParent, "Edit Assignment...", Color.Black);
                UtilityHelper.ControlState(panelAssignment.Controls, false);
                
                //ensure that only the valid options per business rule 5 are implemented

                //LoadApplicableDonorName();
                //LoadActiveVolunteerProgram();

                //cboDonorName.SelectedValue = currentAccountId;
                //cboVolunterProgram.SelectedValue = currentProgramId;

                txtSignedUpHours.Focus();

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
                if (btnSaveDelete.Text == "Add")
                {
                    UtilityHelper.ProgressBar(myParent);
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                            CreateAssignment();
                    }
                }
                if (btnSaveDelete.Text == "Save")
                {
                    UtilityHelper.ProgressBar(myParent);
                    if (ValidateChildren(ValidationConstraints.Enabled))
                    {
                        SaveAssnChanges();
                    }
                }
                else
                {
                    if (btnSaveDelete.Text == "Delete")
                    {
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        if (MessageBox.Show("Are you sure you want to delete this Assignment?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            DeleteAssignment();
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

            LoadFirstAssignment();
            
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
                    dgvAssn.DataSource = null;
                    LoadDonorName();
                    LoadFirstAssignment();
                    LoadAssignmentDataGrid();
                    cboDonorName.Enabled = false;
                    cboVolunterProgram.Enabled = false;
                    txtCurrentHours.ReadOnly = true;
                    txtSignedUpHours.ReadOnly = true;
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to cancel?", "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        LoadAssignmentDetails();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnSaveDelete.Text = "Delete";
                        btnSaveDelete.BackColor = Color.IndianRed;
                        btnCancelReset.Text = "Reset";
                        errProvider.Clear();
                        cboDonorName.Enabled = false;
                        cboVolunterProgram.Enabled = false;
                        txtCurrentHours.ReadOnly = true;
                        txtSignedUpHours.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        private void dgvdgvAssn_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAssn.CurrentRow == null)
                {
                    return;
                }
                if (dgvAssn.CurrentRow.Selected)
                {
                    DataGridViewRow currGiftRow = dgvAssn.CurrentRow;
                    currentProgramId = Convert.ToInt32(currGiftRow.Cells[0].Value);
                    currentAccountId = Convert.ToInt32(currGiftRow.Cells[1].Value);

                    LoadAssignmentDetails();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        #endregion



        #region Database Actions

        private void LoadDonorName()

        {
            DataTable dt = DataAccess.GetData("SELECT AccountId, KeyName  FROM Account ORDER BY KeyName");
            UIUtilities.FillListControl(cboDonorName, "KeyName", "AccountId", dt, true, "--Select a constituent--");
        }
        private void LoadVolunteerProgram()
        {
            DataTable dt = DataAccess.GetData("SELECT ProgramId, ProgramName  FROM VolunteerProgram ORDER BY ProgramName");
            UIUtilities.FillListControl(cboVolunterProgram, "ProgramName", "ProgramId", dt, true, "--Select a program--");
        }

        //Implement Business Rule 7
        // Constituents must be added to active programs (3 max). Only load active programs in the combobox during add event.
        private void LoadActiveVolunteerProgram()
        {
            DataTable dt = DataAccess.GetData("SELECT ProgramId, ProgramName  FROM VolunteerProgram WHERE IsActive = 'true' ORDER BY ProgramName");
            UIUtilities.FillListControl(cboVolunterProgram, "ProgramName", "ProgramId", dt, true, "--Select a program--");
        }

        //Implement Business Rule 7
        //A constituent can only be assigned 3 active programs.
        //Only load constituents with less than 3 assignments on active programs

        private void LoadApplicableDonorName()

        {
            string sql = $@"
            SELECT AccountId, KeyName 
            FROM Account 
            WHERE AccountId NOT IN 
            (
	            SELECT AccountID
	            FROM 
		            (
		            SELECT AccountID, 
		            Count(AccountId) AS 'NumAssn' 
		            FROM 
		            (
		            SELECT AccountId 
                    FROM VolunteerAssignment 
                    WHERE ProgramID IN 
                        (
                         SELECT ProgramId  
                         FROM VolunteerProgram 
                            WHERE IsActive = 'true') ) AS p
		            GROUP BY AccountID) AS q
	            WHERE q.NumAssn >= 3
            )
            ";
            sql = DataAccess.SQLCleaner(sql);
            DataTable dt = DataAccess.GetData(sql);
            UIUtilities.FillListControl(cboDonorName, "KeyName", "AccountId", dt, true, "--Select a constituent--");
        }

        private void LoadFirstAssignment()
        {
            DataTable firstAssignment = DataAccess.GetData("SELECT TOP (1) ProgramId, AccountId FROM VolunteerAssignment");


            if (firstAssignment.Rows.Count > 0)
            {
                currentProgramId = Convert.ToInt32(firstAssignment.Rows[0]["ProgramId"]);
                currentAccountId = Convert.ToInt32(firstAssignment.Rows[0]["AccountId"]);

                firstProgramId = currentProgramId;
                firstAccountId = currentAccountId;

                LoadAssignmentDetails();

                UtilityHelper.NextPreviousButtonManagement(btnPrevious, btnNext, previousAccountId, nextAccountId);
            }
        }//end  first load


        private void LoadAssignmentDataGrid()
        {
            dgvAssn.DataSource = DataAccess.GetData($@"SELECT 
                                                            VolunteerAssignment.ProgramId,
                                                            VolunteerAssignment.AccountId,
	                                                        ProgramName,
	                                                        KeyName,
	                                                        HoursCompleted,
	                                                        HoursSignedUp
                                                     FROM VolunteerAssignment
                                                     INNER JOIN VolunteerProgram
                                                     ON VolunteerAssignment.ProgramId = VolunteerProgram.ProgramId
                                                     INNER JOIN Account
                                                     ON VolunteerAssignment.AccountId = Account.AccountId");
            dgvAssn.AutoResizeColumns();
            dgvAssn.Columns[0].Visible = false;
            dgvAssn.Columns[1].Visible = false;
        }

        private void LoadAssignmentDataGrid(string text)
        {
            dgvAssn.DataSource = DataAccess.GetData($@"SELECT 
                                                            VolunteerAssignment.ProgramId,
                                                            VolunteerAssignment.AccountId,
	                                                        ProgramName,
	                                                        KeyName,
	                                                        HoursCompleted,
	                                                        HoursSignedUp
                                                     FROM VolunteerAssignment
                                                     INNER JOIN VolunteerProgram
                                                     ON VolunteerAssignment.ProgramId = VolunteerProgram.ProgramId
                                                     INNER JOIN Account
                                                     ON VolunteerAssignment.AccountId = Account.AccountId
                                                     WHERE KeyName LIKE '%' + '{text}' + '%' OR ProgramName LIKE '%' + '{text}' + '%'   
                                                    ");
            dgvAssn.AutoResizeColumns();
            dgvAssn.Columns[0].Visible = false;
            dgvAssn.Columns[1].Visible = false;
        }
        private void LoadAssignmentDetails()
        {
            errProvider.Clear();

            string[] sqlStatements = new string[]
            {
                $"SELECT * FROM VolunteerAssignment WHERE AccountId = {currentAccountId} AND ProgramId = {currentProgramId}",
                $@"
                   SELECT 
                    (
                        SELECT TOP(1) ProgramId as FirstProgramId FROM VolunteerAssignment 
                    ) as FirstProgramId,
                    (
                        SELECT TOP(1) AccountId as FirstAccountId FROM VolunteerAssignment 
                    ) as FirstAccountId,
                    q.PreviousProgramId,
                    q.PreviousAccountId,
                    q.NextProgramId,
                    q.NextAccountId,
                    (
                        SELECT TOP(1) ProgramId AS LastProgramId FROM VolunteerAssignment ORDER BY ProgramId Desc
                    ) as LastProgramId,
                    (
                         SELECT TOP(1) AccountId as LastAccountId  FROM VolunteerAssignment ORDER BY ProgramId Desc
                    ) as LastAccountId 
                    
                    FROM
                    (
                        SELECT ProgramId, AccountId, 
	                    LEAD(ProgramId) OVER(ORDER BY ProgramId) AS NextProgramId,
	                    LEAD(AccountId) OVER(ORDER BY ProgramId) AS NextAccountId,  
	                    LAG(ProgramId) OVER(ORDER BY ProgramId) AS PreviousProgramId,
	                    LAG(AccountId) OVER(ORDER BY ProgramId) AS PreviousAccountId,
                        ROW_NUMBER() OVER(ORDER BY ProgramId) AS 'RowNumber'
                   FROM VolunteerAssignment
                    ) AS q
                    WHERE q.ProgramId = {currentProgramId}  AND q.AccountId = {currentAccountId} 
                    ORDER BY q.ProgramId, q.AccountId"
            };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);
            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow selectedAssignment = ds.Tables[0].Rows[0];

                cboDonorName.SelectedValue = selectedAssignment["AccountId"];
                cboVolunterProgram.SelectedValue = selectedAssignment["ProgramId"];


                firstAccountId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstAccountId"]);
                firstProgramId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstProgramId"]);

                //check if its dbnull with turnary, otherwise will set to null
                previousAccountId = ds.Tables[1].Rows[0]["PreviousAccountId"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["PreviousAccountId"]) : (int?)null;
                previousProgramId = ds.Tables[1].Rows[0]["PreviousProgramId"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["PreviousProgramId"]) : (int?)null;

                nextAccountId = ds.Tables[1].Rows[0]["NextAccountId"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["NextAccountId"]) : (int?)null;
                nextProgramId = ds.Tables[1].Rows[0]["NextProgramId"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["NextProgramId"]) : (int?)null;


                lastAccountId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastAccountId"]);
                lastProgramId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastProgramId"]);

                txtSignedUpHours.Text = (selectedAssignment["HoursSignedUp"]).ToString();
                txtCurrentHours.Text = (selectedAssignment["HoursCompleted"]).ToString();
            }
            else
            {
               // myParent.toolStripStatusLabel1.Text = "Status";
                MessageBox.Show("The assignment no longer exists ");
                LoadFirstAssignment();

            }
        }

        /// <summary>
        /// Create the new gift record to the database. 
        /// </summary>
        private void CreateAssignment()
        {
            //Implement br #5 = Each constituent can participate in multiple programs. 
            //Each program will have maximum number of participants. 
            //Once the maximum number of participants is reached, no other volunteer can be added. 

            int targetHeadCount = (int)DataAccess.GetValue($"SELECT TargetHeadCount FROM VolunteerProgram WHERE ProgramId = { currentProgramId}");
            int currentHeadCount = (int)DataAccess.GetValue($"SELECT COUNT(AccountId) FROM VolunteerAssignment WHERE ProgramId = { currentProgramId}");

            if (currentHeadCount <= targetHeadCount)
            {
                string sqlInsertAssn = $@"
                        INSERT INTO VolunteerAssignment (ProgramId, AccountId, HoursCompleted, HoursSignedUp )
                        VALUES
                        (
                            {cboVolunterProgram.SelectedValue},
                            {cboDonorName.SelectedValue},
                            {Convert.ToDecimal(txtCurrentHours.Text.Trim())},
                            {Convert.ToInt32(txtSignedUpHours.Text.Trim())}
                    )";

                sqlInsertAssn = DataAccess.SQLCleaner(sqlInsertAssn);
                int rowsAffected = DataAccess.SendData(sqlInsertAssn);

                UtilityHelper.ActionStatusMessage(rowsAffected, "Assignment was added succesfully!", "Assignment was not added. Please try again!");
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
                LoadAssignmentDataGrid();
                LoadAssignmentDetails();
            }
            else
            {
                MessageBox.Show("The volunteer cant be added to the program. The maximum number of volunteers for the program is reached.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        } //end create method

        /// <summary>
        /// Saves the updates in the assignment form information to the record in the database.
        /// </summary>
        private void SaveAssnChanges()
        {
            int targetHeadCount = (int)DataAccess.GetValue($"SELECT TargetHeadCount FROM VolunteerProgram WHERE ProgramId = { currentProgramId}");
            int currentHeadCount = (int)DataAccess.GetValue($"SELECt COUNT(AccountId) FROM VolunteerAssignment WHERE ProgramId = { currentProgramId}");


            if (currentHeadCount <= targetHeadCount)
            {
                string sqlUpdateAssn = $@"
                         UPDATE VolunteerAssignment
                         SET
                           ProgramId ={cboVolunterProgram.SelectedValue}
                           AccountId =  {cboDonorName.SelectedValue}
                           HoursCompleted =  {Convert.ToDecimal(txtCurrentHours.Text.Trim())},
                           HoursSignedUp ={Convert.ToInt32(txtSignedUpHours.Text.Trim())}
                    )";

                sqlUpdateAssn = DataAccess.SQLCleaner(sqlUpdateAssn);
                int rowsAffected = DataAccess.SendData(sqlUpdateAssn);

                UtilityHelper.ActionStatusMessage(rowsAffected, "Assignment was updated succesfully!", "Assignment was not updated. Please try again!");
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
               

                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
            }
            else
            {
                MessageBox.Show("The volunteer cant be added to the program. The maximum number of volunteers for the program is reached.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Navigation button handling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigation_Handler(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Name)
            {
                case "btnFirst":
                    currentAccountId = firstAccountId;
                    currentProgramId = firstProgramId;
                    break;
                case "btnLast":
                    currentAccountId = lastAccountId;
                    currentProgramId = lastProgramId;
                    break;
                case "btnPrevious":
                    //nullable has to do .Value
                    currentAccountId = previousAccountId.Value;
                    currentProgramId = previousProgramId.Value;
                    break;
                case "btnNext":
                    currentAccountId = nextAccountId.Value;
                    currentProgramId = nextProgramId.Value;
                    break;
            }

            LoadAssignmentDetails();
            UtilityHelper.NextPreviousButtonManagement(btnPrevious, btnNext, previousProgramId, nextProgramId);
        }

        private void DeleteAssignment()
        {
            string sqlDelete = $"DELETE FROM VolunteerAssignment WHERE ProgramId = {currentProgramId} AND AccountId = {currentAccountId}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Volunteer Assignment was deleted succesfully!", "Volunteer Assignment  was not deleted. Please try again");
            LoadAssignmentDetails();
            LoadAssignmentDataGrid();

            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
        }


        #endregion

        #region Utilities





        #endregion

        #region Validation

        private bool IsNumeric(string value)
        {
            return Decimal.TryParse(value, out decimal a);
        }

        private void cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string cmbName = cmb.Tag.ToString();

            string errMsg = null;
            bool failedValidation = false;

            if (cmb.SelectedIndex == -1 || String.IsNullOrEmpty(cmb.SelectedValue.ToString()))
            {
                errMsg = $"{cmbName} is required";
                failedValidation = true;
            }

            e.Cancel = failedValidation;
            errProvider.SetError(cmb, errMsg);
        }

        /// <summary>
        /// TextBox Validating event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

                    if (txt.Name == "txtCurrentHours")
                    {
                        if (!IsNumeric(txtCurrentHours.Text.Trim()))
                        {
                            errMsg = $"{txtBoxName} is not numeric ";
                            e.Cancel = true;
                        }
                    }
                    if (txt.Name == "txtSignedUpHours")
                    {
                        if (!IsNumeric(txtSignedUpHours.Text.Trim()))
                        {
                            errMsg = $"{txtBoxName} is not numeric ";
                            e.Cancel = true;
                        }
                    }

                    if (txt.Name == "txtSignedUpHours")
                    {
                        int.TryParse(txtSignedUpHours.Text.Trim(), out int signedUpHours);
                        double.TryParse(txtCurrentHours.Text.Trim(), out double currHours);
                        if (currHours >= signedUpHours)
                        {
                            errMsg = $"{txtBoxName} you can't add hours over the signed up hours ";
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
        }

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

            LoadAssignmentDataGrid(text);
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
