using System;
using System.Windows.Forms;
using BlurMessageBox;
using Dapper;
using Newtonsoft.Json;

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

                var path = ExtensionsFramework.GetSaveFilePath("BankAccounts", null);

                await data.SaveJsonAsync(path, true);
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
                var path = ExtensionsFramework.GetOpenFilePath("BankAccounts");

                SourceTable = await path.ReadJsonFileAsync();
                SetGridData();

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