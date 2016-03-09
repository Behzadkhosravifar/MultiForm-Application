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

                await data.SaveAsync("inWay", txtInvoiceId.Value, true);
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
                    SourceTable = await ofd.FileName.ReadAsync();
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
    }
}