﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoManager;
using Newtonsoft.Json;
using System.Data.OleDb;

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
        public static DataTable DynamicsArrayToDataTable(this IEnumerable<dynamic> items)
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
                FileName = $"{name}_{GetPersianDate()}_{id ?? Math.Abs(DateTime.Now.GetHashCode()).ToString()}.dbi",
                DefaultExt = ".dbi",
                Title = $"Save {name.SplitWords()} file",
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
                FileName = $"{name}_{GetPersianDate()}_id.dbi",
                DefaultExt = ".dbi",
                Title = $"Read {name.SplitWords()} file",
                Filter = "Text files|*.txt|Excel files|*.xls|Json Serialization|*.dbi|All files (*.*)|*.*",
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

        public static async Task<DataTable> ReadXlsFileAsync(this string path)
        {
            if (string.IsNullOrEmpty(path)) return new DataTable();

            var dt = new DataTable();

            string con =
                  $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path};" +
                  @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                await connection.OpenAsync();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }

            return dt;
        }

        public static string GetPersianDate()
        {
            return GetPersianDate(DateTime.Now);
        }

        public static string GetPersianDate(this DateTime date)
        {
            var jc = new PersianCalendar();
            return $"{jc.GetYear(date):0000}.{jc.GetMonth(date):00}.{jc.GetDayOfMonth(date):00}";
        }

        public static long GetPersianDateNumber(this DateTime date)
        {
            var jc = new PersianCalendar();
            return
                long.Parse($"{jc.GetYear(date):0000}{jc.GetMonth(date):00}{jc.GetDayOfMonth(date):00}{jc.GetHour(date):00}{jc.GetMinute(date):00}{jc.GetSecond(date):00}{jc.GetMilliseconds(date):000}");
        }

        public static string SplitWords(this string sentence)
        {
            return sentence.Aggregate("", (current, ch) => current + (char.IsLower(ch) ? ch.ToString() : " " + ch));
        }

        public static string ToXml(this DataTable dt, string name)
        {
            using (var s = new System.IO.MemoryStream())
            {
                dt.TableName = name;
                dt.WriteXml(s);
                return System.Text.Encoding.UTF8.GetString(s.ToArray());
            }
        }
    }
}