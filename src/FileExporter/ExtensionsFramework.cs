using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FileExporter
{
    public static class ExtensionsFramework
    {
        public static void SetHeaderNames(this DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderText = Properties.Resources.ResourceManager.GetString(col.Name.ToLower());
            }
        }
    }
}
