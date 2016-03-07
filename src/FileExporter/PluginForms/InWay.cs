using System;
using Dapper;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoManager;
using BlurMessageBox;
using Newtonsoft.Json;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace FileExporter.PluginForms
{
    public partial class InWay : BaseForm
    {
        
        private bool _inProcess = false;



        public InWay()
        {
            InitializeComponent();
        }


        private async void btnShow_Click(object sender, System.EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lock (SyncObj)
                {
                    if (_inProcess) return;
                    _inProcess = true;
                }

                if (!ValidateInputs()) return;

                var parameters = new { OldInvoiceId = txtInvoiceId.Value, InvoiceTypeID = 4, RunDate = "2" };
                //
                var source =
                    await
                        Program.SaleCore.SqlConn.ExecuteReaderAsync("sp_GetOldSaleInvoiceDetails", parameters,
                            commandType: CommandType.StoredProcedure);
                SourceTable = new DataTable();
                SourceTable.Load(source);
                SetGridData();

                //
                dgvMain.SetHeaderNames();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, ex.Source, Buttons.OK, Icons.Error, AnimateStyle.SlideDown);
            }
            finally
            {
                Cursor = Cursors.Default;
                _inProcess = false;
            }
        }
        private async void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (SyncObj)
                {
                    if (_inProcess) return;
                    _inProcess = true;
                }

                if (!ValidateInputs()) return;

                var data = JsonConvert.SerializeObject(SourceTable, Formatting.Indented);

                await SaveAsync(data, true);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, ex.Source, Buttons.OK, Icons.Error, AnimateStyle.SlideDown);
            }
            finally
            {
                _inProcess = false;
            }
        }
        private async void btnOpenJson_Click(object sender, EventArgs e)
        {
            try
            {
                lock (SyncObj)
                {
                    if (_inProcess) return;
                    _inProcess = true;
                }

                var ofd = new OpenFileDialog
                {
                    FileName = "inWay.jsn",
                    DefaultExt = ".jsn",
                    Title = "خواندن فایل توراهی",
                    Filter = "Text files|*.txt|Json Serialization|*.jsn|All files (*.*)|*.*",
                    FilterIndex = 2
                };

                var result = ofd.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    SourceTable = await ReadAsync(ofd.FileName);
                    SetGridData();
                }

                //
                dgvMain.SetHeaderNames();
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, ex.Source, Buttons.OK, Icons.Error, AnimateStyle.SlideDown);
            }
            finally
            {
                _inProcess = false;
            }
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtInvoiceId.Value))
            {
                MsgBox.Show("لطفا شماره فاکتور را وارد فرمائید", "شماره فاکتور خالی", Buttons.OK, Icons.Error,
                    AnimateStyle.SlideDown);
                txtInvoiceId.Focus();

                return false;
            }

            return true;
        }
        private void SetGridData()
        {
            dgvMain.DataSource = SourceTable;
            var count = SourceTable.Rows.Count;
            gbInWays.Text = string.Format("جزئیات توراهی (تعداد: {0})", count);
        }

        private async Task SaveAsync(string data, bool isEncrypt = false)
        {
            if (isEncrypt)
            {
                data = "#" + data.Encrypt();
            }


            SaveFileDialog sfd = new SaveFileDialog
            {

                FileName = string.Format("inWay_{0}_{1}.jsn", GetPersianDate(), txtInvoiceId.Value),
                DefaultExt = ".jsn",
                Title = "ذخیره فایل توراهی",
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
        public async Task<DataTable> ReadAsync(string path)
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

        public string GetPersianDate()
        {
            DateTime date = DateTime.Now;
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));

            var result = persianDate.ToString("yyyy.MM.dd");

            return result;
        }
    }
}