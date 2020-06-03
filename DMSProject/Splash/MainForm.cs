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


        private void ShowNewForm(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem toolStripMenu = (ToolStripMenuItem)sender;
                Display.ShowChildForm(toolStripMenu, this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }

        private void ShowNewFormToolBtn(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton stripButton = (ToolStripButton)sender;
                Display.ShowChildForm(stripButton, this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
        }


    }

}
