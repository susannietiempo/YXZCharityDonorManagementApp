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
    public partial class Users : Form
    {
        #region Fields
        MainForm myParent;
        private int currentRecord;
        private int currentUserId;
        private int firstUsertId;
        private int lastUserId;
        private int? previousUserId;
        private int? nextUserId;
        private int totalUserCount;

        #endregion

        #region Constructors
        public Users()
        {
            InitializeComponent();
        }

        public Users(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        #endregion

        #region Events
        private void Users_Load(object sender, EventArgs e)
        {
            LoadUserInfoDataGrid();
            LoadFirstUser();
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

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow == null)
                {
                    return;
                }
                if (dgvUsers.CurrentRow.Selected)
                {
                    DataGridViewRow currGiftRow = dgvUsers.CurrentRow;
                    currentUserId = Convert.ToInt32(currGiftRow.Cells[0].Value);
                    LoadUserInfo();
                }
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
                btnChangePassword.Visible = false;
                btnCancelReset.Text = "Cancel";
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtUserId.Enabled = false;
                txtUserId.BackColor = Color.LightGray;
                txtConfirmPassword.Visible = true;
                txtPassword.Visible = true;
                lblConfirmPword.Visible = true;
                lblPword.Visible = true;

                UtilityHelper.ControlState(panelUser.Controls, false);
                UtilityHelper.ClearControls(panelUser.Controls);
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);

                UtilityHelper.ToolStripDisplay(myParent, "Adding User...", Color.Black);

                LoadUserInfoDataGrid();

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
                btnChangePassword.Visible = false;
                btnSaveDelete.Text = "Save";
                btnSaveDelete.BackColor = Color.SeaGreen;
                txtUserId.Enabled = false;
                txtUserId.BackColor = Color.LightGray;
                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, false);
                UtilityHelper.ToolStripDisplay(myParent, "Edit User...", Color.Black);
                UtilityHelper.ControlState(panelUser.Controls, false);
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
                        if (txtUserId.Text == string.Empty)
                        {
                            CreateUser();
                        }
                        else
                        {
                            SaveUserChanges();
                            btnChangePassword.Visible = true;
                        }
                    }
                }
                else if (btnSaveDelete.Text == "Save" && !btnChangePassword.Enabled)
                {
                    UtilityHelper.ProgressBar(myParent);

                    int rowsAffected = CreateUpdatePassword();
                    UtilityHelper.ActionStatusMessage(rowsAffected, "Password was updated succesfully!", "Password was not updated. Please try again");
                    LoadUserInfo();

                    btnChangePassword.Visible = true;
                    btnCancelReset.Text = "Reset";
                    btnSaveDelete.Text = "Delete";

                    UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
                }
                else
                {
                    if (btnSaveDelete.Text == "Delete")
                    {
                        btnAdd.Visible = false;
                        btnEdit.Visible = false;

                        if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DeleteUser();
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
                    dgvUsers.DataSource = null;
                    LoadUserInfoDataGrid();
                    LoadFirstUser();
                    LoadUserInfo();

                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to cancel?", "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        LoadUserInfo();
                        btnAdd.Visible = true;
                        btnEdit.Visible = true;
                        btnSaveDelete.Text = "Delete";
                        btnSaveDelete.BackColor = Color.IndianRed;
                        btnCancelReset.Text = "Reset";
                        txtConfirmPassword.Visible = false;
                        txtPassword.Visible = false;
                        lblConfirmPword.Visible = false;
                        lblPword.Visible = false;
                        btnChangePassword.Visible = true;

                        errProvider.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnChangePassword.Visible = false;
            txtConfirmPassword.Visible = true;
            txtPassword.Visible = true;
            txtConfirmPassword.ReadOnly = false;
            txtPassword.ReadOnly = false;
            txtConfirmPassword.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
            lblConfirmPword.Visible = true;
            lblPword.Visible = true;
            btnSaveDelete.Text = "Save";
            btnSaveDelete.BackColor = Color.SeaGreen;
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

                    //Implment business rule 011
                    // A username can only be used once in the databse.

                    if (txt.Name == "txtUserName")
                    {
                        if ((Convert.ToInt32(DataAccess.GetValue($"SELECT COUNT(UserId) FROM [User] WHERE UserName = '{txtUserName.Text.Trim().ToLower()}' AND UserId != {currentUserId}")) != 0))
                        {
                            errMsg = $"{txtBoxName} is already exists. Please use another username.";
                        }
                    }


                    if (txt.Name == "txtPassword")
                    {
                        if ( txtPassword.Text.Length < 6)
                        {
                            errMsg = $"{txtBoxName} should be atlease 6 characters long.";
                        }
                    }

                    if (txt.Name == "txtConfirmPassword")
                    {
                        if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                        {
                            errMsg = $"Password does not match.";
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


        #endregion

        #region Database Actions
        /// <summary>
        /// Loads the user information to the datagridvuew
        /// </summary>

        private void LoadUserInfoDataGrid()
        {
            dgvUsers.DataSource = DataAccess.GetData($"SELECT UserId, FirstName, LastName, UserName FROM [User] ORDER BY LastName");
            dgvUsers.AutoResizeColumns();
            dgvUsers.Columns[0].Visible = false;
        }


        private void LoadUserInfoDataGrid(string text)
        {
            dgvUsers.DataSource = DataAccess.GetData($"SELECT UserId, FirstName, LastName, UserName FROM [User]  WHERE LastName LIKE '%' + '{text}' + '%' OR FirstName LIKE '%' + '{text}' + '%'  ORDER BY LastName");
            dgvUsers.AutoResizeColumns();
            dgvUsers.Columns[0].Visible = false;
        }
        /// <summary>
        /// Load the first user account in the txt boxes
        /// </summary>
        private void LoadFirstUser()
        {
            currentUserId = Convert.ToInt32(DataAccess.GetValue("SELECT TOP (1) UserId FROM [User] ORDER BY LastName"));
            LoadUserInfo();
        }

        /// <summary>
        /// Load and bind the User info to the controls on the form and handle navigation
        /// </summary>
        /// 
        private void LoadUserInfo()
        {

            string sqlUserById = $"SELECT [User].UserId, FirstName, LastName, UserName, [Password] FROM [User] INNER JOIN [LogIn] ON [User].UserId = [LogIn].UserId  WHERE [User].UserId  = {currentUserId}";
            string sqlNav = $@"
             SELECT 
                (
                    SELECT TOP(1) UserId  FROM [User] ORDER BY LastName 
                ) AS FirstUserId,
                q.PreviousUserId,
                q.NextUserId,
                (
                    SELECT TOP(1) UserId FROM [User] ORDER BY LastName  DESC
                ) as LastUserId,
                q.RowNumber
                FROM
                (
                    SELECT UserId, LastName,
                    LEAD(UserId) OVER(ORDER BY LastName) AS NextUserId,
                    LAG(UserId) OVER(ORDER BY LastName) AS PreviousUserId,
                    ROW_NUMBER() OVER(ORDER BY LastName) AS 'RowNumber'
                    FROM [User]
                ) AS q
                WHERE q.UserId = {currentUserId}
                ORDER BY q.LastName
             ";

            string sqlUserCount = "SELECT COUNT(UserId) AS UserCount FROM [User]";
            sqlNav = DataAccess.SQLCleaner(sqlNav);

            string[] sqlStatements = new string[] { sqlUserById, sqlNav, sqlUserCount };

            DataSet ds = new DataSet();
            ds = DataAccess.GetData(sqlStatements);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow selectedGift = ds.Tables[0].Rows[0];

                txtUserId.Text = selectedGift["UserId"].ToString();
                txtFName.Text = selectedGift["FirstName"].ToString();
                txtLName.Text = selectedGift["LastName"].ToString();
                txtUserName.Text = selectedGift["UserName"].ToString();



                firstUsertId = Convert.ToInt32(ds.Tables[1].Rows[0]["FirstUserId"]);
                previousUserId = ds.Tables[1].Rows[0]["PreviousUserId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["PreviousUserId"]) : (int?)null;
                nextUserId = ds.Tables[1].Rows[0]["NextUserId"] != DBNull.Value ? Convert.ToInt32(ds.Tables["Table1"].Rows[0]["NextUserId"]) : (int?)null;
                lastUserId = Convert.ToInt32(ds.Tables[1].Rows[0]["LastUserId"]);
                currentRecord = Convert.ToInt32(ds.Tables[1].Rows[0]["RowNumber"]);

                totalUserCount = Convert.ToInt32(ds.Tables[2].Rows[0]["UserCount"]);
                UtilityHelper.ToolStripDisplay(myParent, $"Displaying user { currentRecord} of { totalUserCount}", Color.Black);
                UtilityHelper.ControlState(panelUser.Controls, true);
                txtUserId.Enabled = false;
            }
            else
            {
                MessageBox.Show("The user no longer exists");
                LoadFirstUser();
            }

        }
        /// <summary>
        /// Create the new user record to the database. 
        /// </summary>
        private void CreateUser()
        {
                string sqlInsertUser = $@"
                        INSERT INTO [User] (UserName, FirstName, LastName)
                        VALUES
                        (
                           '{DataAccess.SQLFix(txtUserName.Text.Trim())}',
                           '{DataAccess.SQLFix(txtFName.Text.Trim())}',
                           '{DataAccess.SQLFix(txtLName.Text.Trim())}'
                    )";

                sqlInsertUser = DataAccess.SQLCleaner(sqlInsertUser);
                int rowsAffected = DataAccess.SendData(sqlInsertUser);

                int rowsAffectedPword;

                if (rowsAffected != 0)
                {
                    currentUserId = Convert.ToInt32(DataAccess.GetValue($"SELECT UserId FROM [User] WHERE UserName = '{txtUserName.Text.Trim().ToLower()}'"));
                    rowsAffectedPword = CreateUpdatePassword();
                    UtilityHelper.ActionStatusMessage(rowsAffectedPword, "User was added succesfully!", "User was not added. Please try again!");
                    LoadUserInfoDataGrid();
                    LoadFirstUser();
                    UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
                    myParent.prgBar.Value = 0;
                    myParent.toolStripStatusLabel1.Text = "";

                }
                else
                {
                    UtilityHelper.ActionStatusMessage(rowsAffected, "", "User was not added. Please try again!");
                    UtilityHelper.ProgessBarOnError(myParent);
                }
            

        }//end create method

        private int CreateUpdatePassword()
        {
            string sqlInsertPassword = $@"
                        INSERT INTO [LogIn] (UserId, Password)
                        VALUES
                        (
                           '{currentUserId}',
                           '{DataAccess.SQLFix(txtConfirmPassword.Text.Trim())}'
                    )";

            sqlInsertPassword = DataAccess.SQLCleaner(sqlInsertPassword);
             int rowsAffected = DataAccess.SendData(sqlInsertPassword);
            return rowsAffected;
        }
        private void DeleteUser()
        {
            string sqlDeletePwd = $"DELETE FROM [LogIn] WHERE UserId = {Convert.ToInt32(txtUserId.Text)}";
            int rowsAffectedPwd = DataAccess.SendData(sqlDeletePwd);
            
            string sqlDelete = $"DELETE FROM [User] WHERE UserId = {Convert.ToInt32(txtUserId.Text)}";
            int rowsAffected = DataAccess.SendData(sqlDelete);

            UtilityHelper.ActionStatusMessage(rowsAffected, "User was deleted succesfully!", "User was not deleted. Please try again");
            LoadFirstUser();
            LoadUserInfoDataGrid();
            UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
        }

        private void SaveUserChanges()
        {
            int countUser = (int) DataAccess.GetValue($"SELECT COUNT(UserId) FROM[User] WHERE UserName = {txtUserName.Text.Trim().ToLower()}");
            if (countUser != 0)
            {

                string sqlUpdateGift = $@"
                         UPDATE [User]
                         SET
                            UserName = '{DataAccess.SQLFix(txtUserName.Text.Trim().ToLower())}',
                            FirstName = '{DataAccess.SQLFix(txtFName.Text.Trim())}',
                            LastName = '{DataAccess.SQLFix(txtLName.Text.Trim())}',
                            WHERE GiftId = {Convert.ToInt32(txtUserId.Text)}
                ";

                sqlUpdateGift = DataAccess.SQLCleaner(sqlUpdateGift);
                int rowsAffected = DataAccess.SendData(sqlUpdateGift);

                UtilityHelper.ActionStatusMessage(rowsAffected, "User was updated succesfully!", "User was not updated. Please try again");
                LoadUserInfo();

                UtilityHelper.NavigationState(btnFirst, btnLast, btnPrevious, btnNext, true);
            }
            else
            {
                MessageBox.Show("The username already exist. Please use another username", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Utility Methods


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
                        currentUserId = firstUsertId;
                        myParent.toolStripStatusLabel1.Text = "The first constituent is currently displayed";
                        break;
                    case "btnLast":
                        currentUserId = lastUserId;
                        myParent.toolStripStatusLabel1.Text = "The last constituent is currently displayed";
                        break;
                    case "btnPrevious":
                        currentUserId = previousUserId.Value;
                        if (currentRecord - 1 == 1)
                            myParent.toolStripStatusLabel1.Text = "The first constituent is currently displayed";
                        break;
                    case "btnNext":
                        currentUserId = nextUserId.Value;
                        if (currentRecord == totalUserCount - 1)
                            myParent.toolStripStatusLabel1.Text = "The last constituent is currently displayed";
                        break;
                }

                LoadUserInfo();
                UtilityHelper.NextPreviousButtonManagement(btnPrevious, btnNext, previousUserId, nextUserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Search  Methods

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearch.Text;

            LoadUserInfoDataGrid(text);
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
