using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash
{
    public static class Validation
    {

        //public static void TextBoxValidation(CancelEventArgs e, ErrorProvider errProvider, TextBox txt)
        //{
            
        //    string txtBoxName = txt.Tag.ToString();
        //    string errMsg = null;

        //    if (txt.Text == string.Empty)
        //    {
        //        errMsg = $"{txtBoxName} is required.";
        //        e.Cancel = true;
        //    }

        //    if (txt.Name == "txtBirthdate" || txt.Name == "txtDateAdded")
        //    {
        //        if (!IsDate(txt.Text))
        //        {
        //            errMsg = $"{txtBoxName} is not a valid date. (Format: yyyy-mm-dd)";
        //            e.Cancel = true;
        //        }
        //    }


        //    errProvider.SetError(txt, errMsg);
        //}
    }
}
