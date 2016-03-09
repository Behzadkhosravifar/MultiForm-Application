using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Extension method to convert dynamic data to a DataTable. Useful for databinding.
        /// </summary>
        /// <param name="items"></param>
        /// <returns>A DataTable with the copied dynamic data.</returns>
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }
}
