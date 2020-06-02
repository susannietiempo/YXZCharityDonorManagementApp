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
    }
}
