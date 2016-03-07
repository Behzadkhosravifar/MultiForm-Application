using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlurMessageBox;
using Dapper;

namespace FileExporter.PluginForms
{
    public partial class BankAccounts : BaseForm
    {
        public BankAccounts()
        {
            InitializeComponent();
        }

        protected override void OnLoaded(object sender, EventArgs e)
        {
            base.OnLoaded(sender, e);

            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    var parameters = new { OldInvoiceId = txtInvoiceId.Value, InvoiceTypeID = 4, RunDate = "2" };
            //    //
            //    var source =
            //        await
            //            Program.SaleCore.SqlConn.ExecuteReaderAsync("sp_GetOldSaleInvoiceDetails", parameters,
            //                commandType: CommandType.StoredProcedure);
            //    _dt = new DataTable();
            //    _dt.Load(source);
            //    SetGridData();

            //    //
            //    dgvMain.SetHeaderNames();
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.Show(ex.Message, ex.Source, Buttons.OK, Icons.Error, AnimateStyle.SlideDown);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }

        private void SetGridData()
        {
            dgvMain.DataSource = SourceTable;
            var count = SourceTable.Rows.Count;
            gbInWays.Text = string.Format("جزئیات توراهی (تعداد: {0})", count);
        }
    }
}
