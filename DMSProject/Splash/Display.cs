using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash
{
    public static class Display
    {
        /// <summary>
        /// This method will show the child form on the MDI parent form. 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="myParent"></param>
        /// <param name="currentForm"></param>
        public static void ShowChildForm(Control control, MainForm myParent, Form currentForm)
        {
            Form childForm = null;

            switch (control.Tag)
            {
                case "donors":
                    childForm = new Donor(myParent);
                    break;
                case "gifts":
                    childForm = new Gift(myParent);
                    break;
                case "volunteers":
                    childForm = new Volunteers(myParent);
                    break;
                case "home":
                    childForm = new HomeForm(myParent);
                    break;
                case "volunteerassn":
                    childForm = new VolunteerAssignment(myParent);
                    break;
                case "volunteerprog":
                    childForm = new VolunteerProgram(myParent);
                    break;
            }

            if (childForm != null)
            {
                foreach (Form f in myParent.MdiChildren)
                {
                    if (f.GetType() == childForm.GetType())
                    {
                        f.Activate();
                        return;
                    }
                }
            }
            currentForm.Close();
            childForm.MdiParent = myParent;
            childForm.Show();
           
        }
    }
}
