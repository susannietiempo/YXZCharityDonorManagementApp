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
        MainForm myParent;

        public VolunteerProgram()
        {
            InitializeComponent();
        }
        public VolunteerProgram(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Display.ShowChildForm(control, myParent, this);
        }
    }
}
