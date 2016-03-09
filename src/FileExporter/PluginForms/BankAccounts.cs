using System;
using System.Windows.Forms;
using BlurMessageBox;
using Dapper;
using Newtonsoft.Json;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace FileExporter.PluginForms
{
    public partial class BankAccounts : BaseForm
    {
        public BankAccounts()
        {
            InitializeComponent();
        }

        protected override async void OnLoaded(object sender, EventArgs e)
        {
            base.OnLoaded(sender, e);

            try
            {
                Cursor = Cursors.WaitCursor;

                //
                var source =
                    await
                        Program.SaleMarkaz.SqlConn.QueryAsync("Select * from bank_register");

                SourceTable = source.ToDataTable();
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
            }
        }

        private void SetGridData()
        {
            dgvMain.DataSource = SourceTable;
            var count = SourceTable.Rows.Count;
            gbInWays.Text = string.Format("حسابهای بانکی (تعداد: {0})", count);
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var data = JsonConvert.SerializeObject(SourceTable, Formatting.Indented);

                await data.SaveAsync("bankAccounts", null, true);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message, ex.Source, Buttons.OK, Icons.Error, AnimateStyle.SlideDown);
            }
        }

        private async void btnOpenJson_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog
                {
                    FileName = "bankAccounts.jsn",
                    DefaultExt = ".jsn",
                    Title = "خواندن فایل حسابهای بانکی",
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
        }

    }
}
