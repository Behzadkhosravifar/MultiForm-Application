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
        
        public static string GetSaveFilePath(string name, string id)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = string.Format("{0}_{1}_{2}.dbi", name, GetPersianDate(), id ?? Math.Abs(DateTime.Now.GetHashCode()).ToString()),
                DefaultExt = ".dbi",
                Title = string.Format("Save {0} file", name.SplitWords()),
                Filter = "Text files|*.txt|Json Serialization|*.dbi|All files (*.*)|*.*",
                FilterIndex = 2
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }

            return null;
        }

        public static string GetOpenFilePath(string name)
        {
            var ofd = new OpenFileDialog
            {
                FileName = string.Format("{0}_{1}_id.dbi", name, GetPersianDate()),
                DefaultExt = ".dbi",
                Title = string.Format("Read {0} file", name.SplitWords()),
                Filter = "Text files|*.txt|Json Serialization|*.dbi|All files (*.*)|*.*",
                FilterIndex = 2
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }

            return null;
        }

        public static async Task SaveJsonAsync(this string data, string path, bool isEncrypt = false)
        {
            if (isEncrypt)
            {
                data = "#" + data.Encrypt();
            }

            if (string.IsNullOrEmpty(path)) return;

            using (StreamWriter sw = new StreamWriter(path))
                await sw.WriteAsync(data);

        }

        public static async Task<DataTable> ReadJsonFileAsync(this string path)
        {
            if (string.IsNullOrEmpty(path)) return new DataTable();

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

        public static string SplitWords(this string sentence)
        {
            return sentence.Aggregate("", (current, ch) => current + (char.IsLower(ch) ? ch.ToString() : " " + ch));
        }
    }
}