using System;
using System.Data;
using System.Windows.Forms;

namespace Splash
{
    public partial class ReportDonorGift : Form
    {
        private MainForm myParent;

        #region Constructors
        public ReportDonorGift()
        {
            InitializeComponent();
        }

        public ReportDonorGift(MainForm p)
        {
            InitializeComponent();

            myParent = p;
        }

        #endregion 

        #region Events
        private void ReportsHome_Load(object sender, EventArgs e)
        {
            LoadConstituencyType();
            LoadDonorName();
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

        //load gift
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
                    string sql = $"SELECT GiftId, GiftDate, ReceivedAmount, GiftType, Approach, Campaign, Fund, GiftNote FROM Gift WHERE AccountId = {accountId} ORDER BY GiftDate DESC";

                    dgvGiftDetails.DataSource = DataAccess.GetData(sql);
                    dgvGiftDetails.AutoResizeColumns();
                    dgvGiftDetails.Columns[0].Visible = false;


                    txtGiftAmt.Text = Convert.ToDecimal(DataAccess.GetValue($"SELECT SUM(ReceivedAmount) FROM Gift WHERE AccountId = {accountId}")).ToString("c");
                    txtRecentGift.Text = Convert.ToDecimal(DataAccess.GetValue($"SELECT Top (1) ReceivedAmount FROM Gift WHERE AccountId = {accountId} ORDER BY GiftDate DESC")).ToString("c");
                    txtTotalGiftNum.Text = Convert.ToDecimal(DataAccess.GetValue($"SELECT COUNT(GiftId) FROM Gift WHERE AccountId = {accountId}")).ToString();
                    txtDonorName.Text = currDonorRow.Cells[1].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        private void cboConstituencyType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboConstituencyType.SelectedIndex != 0)
                {
                    int id = Convert.ToInt32(cboConstituencyType.SelectedValue);
                    string type = cboConstituencyType.Text;
                    LoadDonorName(id, type);

                    string sql = $"SELECT AccountId, KeyName, StreetAddress, City, Province, Country FROM Account WHERE ConstituencyTypeId = {id}";
                    dgvDonors.DataSource = DataAccess.GetData(sql);

                    txtDonorCount.Text = dgvDonors.RowCount.ToString();
                }
                else
                {
                    LoadDonorName();
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
                if (cboDonorName.SelectedIndex != 0)
                {
                    int id = Convert.ToInt32(cboDonorName.SelectedValue);
                    string type = cboDonorName.Text;
                    dgvDonors.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName, StreetAddress, City, Province, Country FROM Account WHERE AccountId = {id}");
                    dgvDonors.AutoResizeColumns();
                    dgvDonors.Columns[0].Visible = false;

                    txtDonorCount.Text = dgvDonors.RowCount.ToString();

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
                LoadConstituencyType();
                LoadDonorName();
                LoadAccountInfo();
                dgvGiftDetails.DataSource = null;
                txtDonorName.Text = null;
                txtGiftAmt.Text = null;
                txtRecentGift.Text = null;
                txtTotalGiftNum.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

        }

        #endregion

        #region Retrieve Data
        private void LoadConstituencyType()
        {
            DataTable dt = DataAccess.GetData("SELECT ConstituencyTypeId, ConstituencyTypeName  FROM ConstituencyType ORDER BY ConstituencyTypeName");
            UIUtilities.FillListControl(cboConstituencyType, "ConstituencyTypeName", "ConstituencyTypeId", dt, true, "-- All constituency type --");
        }

        private void LoadDonorName()
        {
            DataTable dt = DataAccess.GetData("SELECT AccountId, KeyName  FROM Account ORDER BY KeyName");
            UIUtilities.FillListControl(cboDonorName, "KeyName", "AccountId", dt, true, "-- All donors --");
        }
        private void LoadDonorName(int id, string type)
        {
            DataTable dt = DataAccess.GetData($"SELECT AccountId, KeyName  FROM Account WHERE ConstituencyTypeId = {id} ORDER BY KeyName ");
            UIUtilities.FillListControl(cboDonorName, "KeyName", "AccountId", dt, true, $"-- All {type} donors --");
        }

        private void LoadAccountInfo()
        {
            dgvDonors.DataSource = DataAccess.GetData($"SELECT AccountId, KeyName, StreetAddress, City, Province, Country FROM Account");
            dgvDonors.AutoResizeColumns();
            dgvDonors.Columns[0].Visible = false;

            txtDonorCount.Text = dgvDonors.RowCount.ToString();
        }

        #endregion
    }
}
