using System;
using System.Data;
using System.Windows.Forms;

namespace Splash
{
    public static class UIUtilities
    {

        public static void FillListControl(ListControl control, string displayMember, string valueMember, DataTable dt, bool insertBlank = false, string defaultText = "")
        {
            if (insertBlank)
            {
                DataRow row = dt.NewRow();
                row[valueMember] = DBNull.Value;
                row[displayMember] = defaultText;
                dt.Rows.InsertAt(row, 0);
            }


            control.DisplayMember = displayMember;
            control.ValueMember = valueMember;
            control.DataSource = dt;

        }
    }
}
