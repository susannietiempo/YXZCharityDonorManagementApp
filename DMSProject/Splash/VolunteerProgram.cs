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
    public partial class VolunteerProgram : Form
    {
        #region Fields

        private int currentRecord;
        private int currentProgramId;
        private int firstProgramId;
        private int lastProgramId;
        private int? previousProgramId;
        private int? nextProgramId;
        private int totalProgramCount;
        private MainForm myParent;

        #endregion

        #region Constructors
        public VolunteerProgram()
        {
            InitializeComponent();
        }
        public VolunteerProgram(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        #endregion


        #region Methods



        private void VolunteerProgram_Load(object sender, EventArgs e)
        {
            LoadFirstProgram();
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
                btnCancel.Cursor = Cursors.Hand;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtProgId.Enabled = false;
                txtProgId.BackColor = Color.LightGray;

                UtilityHelper.ControlState(panelVolProg.Controls, false);
                UtilityHelper.ClearControls(panelVolProg.Controls);
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);

                UtilityHelper.ToolStripDisplay(myParent, "Add Volunteer Program... ", Color.Black);

                LoadProgramInfo();

                txtProgStart.Text = DateTime.Today.ToShortDateString();
                txtProgEnd.Text = DateTime.Today.ToShortDateString();

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
                btnCancel.Cursor = Cursors.Hand;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtProgId.Enabled = false;
                txtProgId.BackColor = Color.LightGray;
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);
                UtilityHelper.ToolStripDisplay(myParent, "Edit Volunteer Program...", Color.Black);
                UtilityHelper.ControlState(panelVolProg.Controls, false);
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
                        if (txtProgId.Text == string.Empty)
                        {
                            CreateProgram();
                        }
                        else
                        {
                            SaveProgramChanges();
                        }
                    }
                }

                else
                {
                    if (btnSaveDelete.Text == "Delete")
                    {
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;
                        if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            DeleteProgram();
                        }
                    }
                }
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
                if (MessageBox.Show("Are you sure you want to cancel?", "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LoadProgramInfo();
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnSaveDelete.Text = "Delete";
                    btnSaveDelete.BackColor = Color.IndianRed;
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
                        currentProgramId = firstProgramId;
                        myParent.toolStripStatusLabel1.Text = "The first volunteer program is currently displayed";
                        break;
                    case "btnLast":
                        currentProgramId = lastProgramId;
                        myParent.toolStripStatusLabel1.Text = "The last  volunteer program is currently displayed";
                        break;
                    case "btnPrevious":
                        currentProgramId = previousProgramId.Value;
                        if (currentRecord - 1 == 1)
                            myParent.toolStripStatusLabel1.Text = "The first  volunteer program is currently displayed";
                        break;
                    case "btnNext":
                        currentProgramId = nextProgramId.Value;
                        if (currentRecord == totalProgramCount - 1)
                            myParent.toolStripStatusLabel1.Text = "The last  volunteer program is currently displayed";
                        break;
                }

                LoadProgramInfo();
                UtilityHelper.NextPreviousButtonManagement(btnPrevious, btnNext, previousProgramId, nextProgramId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                string txtBoxName = txt.Tag.ToString();
                string errMsg = null;

                if (txt.Text == string.Empty)
                {
                    errMsg = $"{txtBoxName} is required.";
                    e.Cancel = true;
                }

                if (txt.Name == "txtStart" || txt.Name == "txtEnd")
                {
                    if (!IsDate(txt.Text))
                    {
                        errMsg = $"{txtBoxName} is not a valid date. (Format: yyyy-mm-dd)";
                        e.Cancel = true;
                    }
                }

                if (txt.Name == "txtHeadCount")
                {
                    if (!IsNumeric(txt.Text))
                    {
                        errMsg = $"{txtBoxName} is not numeric ";
                        e.Cancel = true;
                    }
                }

                errProvider.SetError(txt, errMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }


        } //txt_Validating end method
        #endregion

        #region Database Actions


        /// <summary>
        /// Load the first volunteer program in the table. Ordering the gifts by giftdate
        /// </summary>
        private void LoadFirstProgram()
        {
            currentProgramId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) ProgramId FROM VolunteerProgram ORDER BY ProgramName"));
            LoadProgramInfo();
        }


        /// <summary>
        /// Load and bind the program info to the controls on the form and handle navigation
        /// </summary>
        /// 
        private void LoadProgramInfo()
        {

            string sqlGiftById = $"SELECT * FROM VolunteerProgram WHERE ProgramId = {currentProgramId}";
            string sqlNav = $@"
              SELECT 
                (
                    SELECT TOP(1) ProgramId  FROM VolunteerProgram ORDER BY ProgramName
                ) AS FirstProgramId ,
                q.PreviousProgramId ,
                q.NextProgramId,
                (
                    SELECT TOP(1) ProgramId FROM VolunteerProgram ORDER BY ProgramName
                ) as LastProgramId,
                q.RowNumber
                FROM
                (
                    SELECT ProgramId, ProgramName,
                    LEAD(ProgramId) OVER(ORDER BY ProgramName) AS NextProgramId,
                    LAG(ProgramId) OVER(ORDER BY ProgramName) AS PreviousProgramId,
                    ROW_NUMBER() OVER(ORDER BY ProgramName) AS 'RowNumber'
                    FROM VolunteerProgram
                ) AS q
                WHERE q.ProgramId = {currentProgramId}
                ORDER BY ProgramName
             ";

            string sqlGiftCount = "SELECT COUNT(ProgramId) AS ProgramCount FROM VolunteerProgram";
            sqlNav = DataAccess.SQLCleaner(sqlNav);

            string[] sqlStatements = new string[] { sqlGiftById, sqlNav, sqlGiftCount };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow selectedProgram = ds.Tables[0].Rows[0];

                txtProgId.Text = selectedProgram["ProgramId"].ToString();
                txtProgName.Text = selectedProgram["ProgramName"].ToString();
                txtProgDescription.Text = selectedProgram["ProgramDescription"].ToString();
                txtProgHeadCount.Text = selectedProgram["TargetHeadCount"].ToString();
                txtProgTargetFund.Text = selectedProgram["TargetFund"].ToString();
                txtProgStart.Text = Convert.ToDateTime(selectedProgram["ProgramStartDate"]).ToShortDateString();
                txtProgEnd.Text = Convert.ToDateTime(selectedProgram["ProgramEndDate"]).ToShortDateString();
                chkIsActive.Checked = Convert.ToBoolean(selectedProgram["IsActive"]);



                firstProgramId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstProgramId"]);
                previousProgramId = ds.Tables[1].Rows[0]["PreviousProgramId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousProgramId"]) : (int?)null;
                nextProgramId = ds.Tables[1].Rows[0]["NextProgramId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextProgramId"]) : (int?)null;
                lastProgramId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastProgramId"]);
                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalProgramCount = Convert.ToInt32(ds.Tables[2].Rows[0]["ProgramCount"]);
                UtilityHelper.ToolStripDisplay(myParent, $"Displaying program { currentRecord} of { totalProgramCount}", Color.Black);
                UtilityHelper.ControlState(panelVolProg.Controls, true);
                txtProgId.Enabled = false;
            }
            else
            {
                MessageBox.Show("The program no longer exists");
                LoadFirstProgram();
            }

        }


        /// <summary>
        /// Create the new gift record to the database. 
        /// </summary>
        private void CreateProgram()
        {
            string sqlInsertGift = $@"
                        INSERT INTO VolunteerProgram (ProgramName, ProgramDescription, ProgramStartDate, ProgramEndDate, TargetHeadCount, TargetFund,  IsActive )
                        VALUES
                        (
                           '{DataAccess.SQLFix(txtProgName.Text.Trim())}',
                           '{DataAccess.SQLFix(txtProgDescription.Text.Trim())}',
                           '{Convert.ToDateTime(txtProgStart.Text.Trim())}',
                           '{Convert.ToDateTime(txtProgEnd.Text.Trim())}',
                           '{DataAccess.SQLFix(txtProgHeadCount.Text.Trim())}',
                           '{DataAccess.SQLFix(txtProgTargetFund.Text.Trim())}',
                            { (chkIsActive.Checked ? 1 : 0) }
                    )";

            sqlInsertGift = DataAccess.SQLCleaner(sqlInsertGift);
            int rowsAffected = DataAccess.SendData(sqlInsertGift);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Gift was added succesfully!", "Gift was not added. Please try again!");
            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
            LoadFirstProgram();

        } //end create method

        /// <summary>
        /// Saves the updates in the gift form information to the record in the database.
        /// </summary>
        private void SaveProgramChanges()
        {
            string sqlUpdateGift = $@"
                         UPDATE VolunteerProgram
                         SET
                            ProgramName = '{DataAccess.SQLFix(txtProgName.Text.Trim())}',
                            ProgramDescription = '{DataAccess.SQLFix(txtProgDescription.Text.Trim())}',
                            TargetHeadCount = '{DataAccess.SQLFix(txtProgHeadCount.Text.Trim())}',
                            ProgramStartDate = '{Convert.ToDateTime(txtProgStart.Text.Trim())}',
                            ProgramEndDate = '{Convert.ToDateTime(txtProgEnd.Text.Trim())}',
                            TargetFund = '{DataAccess.SQLFix(txtProgTargetFund.Text.Trim())}',
                            IsActive = { (chkIsActive.Checked ? 1 : 0) }
                            WHERE ProgramId = {Convert.ToInt32(txtProgId.Text)}
                ";

            sqlUpdateGift = DataAccess.SQLCleaner(sqlUpdateGift);
            int rowsAffected = DataAccess.SendData(sqlUpdateGift);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Program was updated succesfully!", "Program was not updated. Please try again");
            LoadProgramInfo();

            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
        }

        private void DeleteProgram()
        {
            string sqlDelete = $"DELETE FROM VolunteerProgram WHERE ProgramId = {Convert.ToInt32(txtProgId.Text)}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            UtilityHelper.ActionStatusMessage(rowsAffected, "Program was deleted succesfully!", "Program was not deleted. Please try again");
            LoadProgramInfo();

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


    }
}
