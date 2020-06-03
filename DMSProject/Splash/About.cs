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
    public partial class About : Form
    {
        MainForm myParent;
        public About()
        {
            InitializeComponent();
        }

        public About(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        private void About_Load(object sender, EventArgs e)
        {
            AssemblyInformation info = new AssemblyInformation();

            txtTitle.Text = info.Title;
            txtDescription.Text = info.Description;
            txtCompany.Text = info.Company;
            txtProduct.Text = info.Product;
            txtCopyright.Text = info.Copyright;
            txtTrademark.Text = info.Trademark;
            txtAssembly.Text = info.AssemblyVersion;
            txtFileVersion.Text = info.FileVersion;
            txtGUID.Text = info.Guid;
            txtNueutral.Text = info.NeutralLanguage;
            txtCOMVisible.Text = info.IsComVisible.ToString();
        }
    }
}
