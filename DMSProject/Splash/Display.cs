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
                    childForm = new VolunteersHome(myParent);
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
                case "volunteerhome":
                    childForm = new VolunteersHome(myParent);
                    break;
                case "reportshome":
                    childForm = new ReportsHome(myParent);
                    break;
                case "reportassn":
                    childForm = new ReportsProgramDonor(myParent);
                    break;
                case "reportgift":
                    childForm = new ReportDonorGift(myParent);
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

        public static void ShowChildForm(ToolStripMenuItem toolStrip, MainForm myParent)
        {
            Form childForm = null;

            switch (toolStrip.Tag)
            {
                case "donors":
                    childForm = new Donor(myParent);
                    break;
                case "gifts":
                    childForm = new Gift(myParent);
                    break;
                case "volunteers":
                    childForm = new VolunteersHome(myParent);
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
                case "volunteerhome":
                    childForm = new VolunteersHome(myParent);
                    break;
                case "reportshome":
                    childForm = new ReportsHome(myParent);
                    break;
                case "reportassn":
                    childForm = new ReportsProgramDonor(myParent);
                    break;
                case "reportgift":
                    childForm = new ReportsProgramDonor(myParent);
                    break;
                case "about":
                    childForm = new About(myParent);
                    break;
                case "users":
                    childForm = new Users(myParent);
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
            childForm.MdiParent = myParent;
            childForm.Show();

        }

        public static void ShowChildForm(ToolStripButton toolStripBtn, MainForm myParent)
        {
            Form childForm = null;

            switch (toolStripBtn.Tag)
            {
                case "donors":
                    childForm = new Donor(myParent);
                    break;
                case "gifts":
                    childForm = new Gift(myParent);
                    break;
                case "volunteers":
                    childForm = new VolunteersHome(myParent);
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
                case "volunteerhome":
                    childForm = new VolunteersHome(myParent);
                    break;
                case "reportshome":
                    childForm = new ReportsHome(myParent);
                    break;
                case "reportassn":
                    childForm = new ReportsProgramDonor(myParent);
                    break;
                case "reportgift":
                    childForm = new ReportsProgramDonor(myParent);
                    break;
                case "about":
                    childForm = new About(myParent);
                    break;
                case "users":
                    childForm = new Users(myParent);
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
            childForm.MdiParent = myParent;
            childForm.Show();

        }
    }
}
