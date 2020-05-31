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

                Form childForm = new HomeForm(this);
                childForm.MdiParent = this;
                childForm.Show();

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


        private void ShowNewForm(object sender, EventArgs e)
        {

            Form childForm = null;
            PictureBox m = (PictureBox)sender;

            switch (m.Tag)
            {
                case "donors":
                    childForm = new Donor(this);
                    break;
                case "gifts":
                    childForm = new Gift(this);
                    break;
                case "volunteers":
                    childForm = new Volunteers(this);
                    break;
                case "home":
                    childForm = new Volunteers(this);
                    break;
            }

            if (childForm != null)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType() == childForm.GetType())
                    {
                        f.Activate();
                        return;
                    }
                }
            }

            childForm.MdiParent = this;
            childForm.Show();
        
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }


        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

      }

}
