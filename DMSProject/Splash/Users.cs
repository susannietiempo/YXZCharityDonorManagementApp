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
        MainForm myParent;
        public Users()
        {
            InitializeComponent();
        }

        public Users(MainForm p)
        {
            InitializeComponent();
            myParent = p;
        }
    }
}
