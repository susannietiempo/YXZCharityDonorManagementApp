using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash
{
    /// <summary>
    /// This class consists of all the helper methods that multiple classes in the assembly use. 
    /// </summary>
    public static class UtilityHelper
    {

        /// <summary>
        /// Animate the progress bar
        /// This UI thread blocking, however, this ok for this application
        /// </summary>
        public static void ProgressBar(MainForm myParent)
        {
            myParent.toolStripStatusLabel1.Text = "Processing...";

            myParent.prgBar.Value = 0;
            myParent.statusStrip.Refresh();

            while (myParent.prgBar.Value < myParent.prgBar.Maximum)
            {
                Thread.Sleep(10);
                myParent.prgBar.Value += 1;
            }

            myParent.toolStripStatusLabel1.Text = "Processed";
        }

        /// <summary>
        /// Manages the MessageBox display for CRUD actions
        /// </summary>
        /// <param name="rowsAffected"></param>
        /// <param name="textSuccess"></param>
        /// <param name="textFailure"></param>
        public static void ActionStatusMessage(int rowsAffected, string textSuccess, string textFailure)
        {
            if (rowsAffected == 1)
            {
                MessageBox.Show(textSuccess, "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(textFailure, "Failed", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Helps manage the enable state of our next and previous navigation buttons
        /// Depending on where we are in products we may need to set enable state based on position
        /// navigation through product records
        /// </summary>
        /// 
        public static void NextPreviousButtonManagement(Button btnPrevious, Button btnNext, int? previousId, int? nextId )
        {
            btnPrevious.Enabled = previousId != null;
            btnNext.Enabled = nextId != null;
        }


        /// <summary>
        /// Clears control in a Control Collection. 
        /// </summary>
        /// <param name="controls"></param>
        public static void ClearControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                switch (ctrl)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case CheckBox chk:
                        chk.Checked = false;
                        break;
                    case ComboBox cbo:
                        cbo.SelectedIndex = -1;
                        break;
                }
            }
        }

        /// <summary>
        /// This method enables or disables the controls in a controls collection. 
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="isEnabled"></param>
        public static  void EnableControl(Control.ControlCollection controls, bool isEnabled)
        {
            foreach (Control ctl in controls)
            {
                switch (ctl)
                {
                    case TextBox txt:
                        txt.BackColor = Color.White;
                        txt.Enabled = isEnabled;
                        break;
                    case CheckBox chk:
                        chk.Enabled = isEnabled;
                        break;
                    case ComboBox cbo:
                        cbo.Enabled = isEnabled;
                        break;
                }
            }
        }


        /// <summary>
        /// This method handles the state of the navigation buttons
        /// </summary>
        /// <param name="visibilityState"></param>
        public static void NavigationState(Button first, Button last, Button previous, Button next, bool visibilityState)
        {
            first.Visible = visibilityState;
            last.Visible = visibilityState;
            previous.Visible = visibilityState;
            next.Visible = visibilityState;
        }


        /// <summary>
        /// This method te state of the some properties of the controls in collection of controls
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="isViewOnly"></param>
        public static void ControlState(Control.ControlCollection controls, bool isViewOnly)
        {
            foreach (Control ctl in controls)
            {
                if (isViewOnly == false)
                {
                    switch (ctl)
                    {
                        case TextBox txt:
                            txt.BackColor = Color.White;
                            txt.ReadOnly = isViewOnly;
                            break;
                        case CheckBox chk:
                            chk.Enabled = !isViewOnly;
                            break;
                        case ComboBox cbo:
                            cbo.Enabled = !isViewOnly;
                            break;
                    }
                }
                else
                {
                    switch (ctl)
                    {
                        case TextBox txt:
                            txt.ReadOnly = isViewOnly;
                            if (String.IsNullOrEmpty(txt.Text))
                            {
                                txt.BackColor = Color.LightGray;
                            }
                            else
                            {
                                txt.BackColor = Color.White;

                            }
                            break;
                        case CheckBox chk:
                            chk.Enabled = !isViewOnly;
                            break;
                        case ComboBox cbo:
                            cbo.Enabled = !isViewOnly;
                            break;
                    }
                }
            }
        }

    }
}
