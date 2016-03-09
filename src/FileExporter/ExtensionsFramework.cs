using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoManager;
using Newtonsoft.Json;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

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
            if (!data.Any()) return null;

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

        public static async Task SaveAsync(this string data, string name, string id, bool isEncrypt = false)
        {
            if (isEncrypt)
            {
                data = "#" + data.Encrypt();
            }

            Microsoft.Win32.SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = string.Format("{0}_{1}_{2}.jsn", name, GetPersianDate(), id ?? Math.Abs(DateTime.Now.GetHashCode()).ToString()),
                DefaultExt = ".jsn",
                Title = "ذخیره فایل",
                Filter = "Text files|*.txt|Json Serialization|*.jsn|All files (*.*)|*.*",
                FilterIndex = 2
            };

            var result = sfd.ShowDialog();
            if (result.HasValue && result.Value)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    await sw.WriteAsync(data);
            }
        }

        public static async Task<DataTable> ReadAsync(this string path)
        {
            Char[] buffer;
            using (StreamReader sr = new StreamReader(path))
            {
                buffer = new Char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }

            var data = new String(buffer);

            if (data.StartsWith("#")) // encrypted data?
            {
                data = data.TrimStart('#').Decrypt();
            }

            var dt = (DataTable)JsonConvert.DeserializeObject(data, typeof(DataTable));

            return dt;
        }

        public static string GetPersianDate()
        {
            var date = DateTime.Now;
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));

            var result = persianDate.ToString("yyyy.MM.dd");

            return result;
        }
    }
}
