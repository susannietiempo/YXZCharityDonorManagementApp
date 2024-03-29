﻿using System;
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
    public partial class ReportsProgramDonor : Form
    {

        private MainForm myParent;

        #region Constructors
        public ReportsProgramDonor()
        {
            InitializeComponent();
        }

        public ReportsProgramDonor(MainForm p)
        {
            InitializeComponent();

            myParent = p;
        }

        #endregion 

        #region Events
        private void ReportsProgramDonor_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProgram();
                LoadVolunteerName();
                LoadAccountInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

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

        //load gift
        private void dgvDonors_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVolunteers.CurrentRow == null)
                {
                    return;
                }
                if (dgvVolunteers.CurrentRow.Selected)
                {
                    DataGridViewRow currDonorRow = dgvVolunteers.CurrentRow;
                    int accountId = Convert.ToInt32(currDonorRow.Cells[0].Value);
                    string sql = $"SELECT ProgramName AS [Program Name], HoursCompleted, HoursSignedUp FROM  VolunteerAssignment INNER JOIN VolunteerProgram ON VolunteerProgram.ProgramId = VolunteerAssignment.ProgramId WHERE AccountId = {accountId}";

                    dgvAssignments.DataSource = DataAccess.GetData(sql);
                    dgvAssignments.AutoResizeColumns();

                    txtRemainingHours.Text = Convert.ToInt32(DataAccess.GetValue($"SELECT HoursSignedUp - HoursCompleted FROM VolunteerAssignment WHERE AccountId = {accountId}")).ToString();
                    txtVolHours.Text = Convert.ToInt32(DataAccess.GetValue($"SELECT SUM(HoursCompleted) AS TotalHours FROM VolunteerAssignment WHERE AccountId = {accountId}")).ToString();
                    txtTotalProgJoined.Text = Convert.ToInt32(DataAccess.GetValue($"SELECT Count(ProgramId) AS TotalHours FROM VolunteerAssignment WHERE AccountId = {accountId}")).ToString();
                    txtDonorName.Text = currDonorRow.Cells[1].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        private void cboProgram_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                if (cboProgram.SelectedIndex != 0)
                {
                    int id = Convert.ToInt32(cboProgram.SelectedValue);
                    string type = cboProgram.Text;
                    LoadDonorName(id, type);

                    string sql = $@"SELECT AccountId, KeyName, StreetAddress, City, Province, Country 
                                          FROM Account 
                                          WHERE AccountId IN 
                                             (SELECT AccountId FROM VolunteerAssignment 
                                             WHERE ProgramId = { id}) 
                                          ORDER BY KeyName";

                    sql = DataAccess.SQLCleaner(sql);
                    dgvVolunteers.DataSource = DataAccess.GetData(sql);
                    dgvVolunteers.AutoResizeColumns();
                    dgvVolunteers.Columns[0].Visible = false;

                    txtVolCount.Text = dgvVolunteers.RowCount.ToString();
                }
                else
                {
                    LoadVolunteerName();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        private void cboDonorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboVolName.SelectedIndex != 0)
                {
                    int id = Convert.ToInt32(cboVolName.SelectedValue);
                    string type = cboVolName.Text;
                    dgvVolunteers.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName, StreetAddress, City, Province, Country FROM Account WHERE AccountId = {id}");
                    dgvVolunteers.AutoResizeColumns();
                    dgvVolunteers.Columns[0].Visible = false;

                    txtVolCount.Text = dgvVolunteers.RowCount.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProgram();
                LoadVolunteerName();
                LoadAccountInfo();
                txtDonorName.Text = null;
                txtRemainingHours.Text = null;
                txtTotalProgJoined.Text = null;
                txtVolHours.Text = null;
                dgvAssignments = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Retrieve Data
        private void LoadProgram()
        {
            DataTable dt = DataAccess.GetData("SELECT ProgramId, ProgramName  FROM VolunteerProgram ORDER BY ProgramName");
            UIUtilities.FillListControl(cboProgram, "ProgramName", "ProgramId", dt, true, "-- All programs --"); //good
        }

        private void LoadVolunteerName()
        {
            DataTable dt = DataAccess.GetData("SELECT DISTINCT Account.AccountId, KeyName   FROM Account INNER JOIN VolunteerAssignment On Account.AccountId  = VolunteerAssignment.AccountId  ORDER BY KeyName");
            UIUtilities.FillListControl(cboVolName, "KeyName", "AccountId", dt, true, "-- All volunteers --"); //good
        }
        private void LoadDonorName(int id, string type)
        {
            DataTable dt = DataAccess.GetData($"SELECT DISTINCT Account.AccountId, KeyName   FROM Account INNER JOIN VolunteerAssignment On Account.AccountId  = VolunteerAssignment.AccountId  AND ProgramId = {id} ORDER BY KeyName ");
            UIUtilities.FillListControl(cboVolName, "KeyName", "AccountId", dt, true, $"-- All {type} volunteers --");
        }

        private void LoadAccountInfo()
        {
            dgvVolunteers.DataSource = DataAccess.GetData($"SELECT DISTINCT Account.AccountId, KeyName, StreetAddress, City, Province, Country  FROM Account INNER JOIN VolunteerAssignment On Account.AccountId  = VolunteerAssignment.AccountId  ORDER BY KeyName");
            //dgvVolunteers.AutoResizeColumns();
            dgvVolunteers.Columns[0].Visible = false;

            txtVolCount.Text = dgvVolunteers.RowCount.ToString();
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
