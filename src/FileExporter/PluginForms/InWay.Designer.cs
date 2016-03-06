namespace FileExporter.PluginForms
{
    partial class InWay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InWay));
            this.btnShow = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbInWays = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnOpenJson = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtInvoiceId = new Windows.Forms.HintTextBox(this.components);
            this.panelMain.SuspendLayout();
            this.gbInWays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShow.Location = new System.Drawing.Point(613, 29);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(120, 36);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "نمایش توراهی";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gbInWays);
            this.panelMain.Controls.Add(this.gbFilter);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelMain.Size = new System.Drawing.Size(938, 464);
            this.panelMain.TabIndex = 3;
            // 
            // gbInWays
            // 
            this.gbInWays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInWays.Controls.Add(this.dgvMain);
            this.gbInWays.Location = new System.Drawing.Point(12, 89);
            this.gbInWays.Name = "gbInWays";
            this.gbInWays.Size = new System.Drawing.Size(914, 363);
            this.gbInWays.TabIndex = 4;
            this.gbInWays.TabStop = false;
            this.gbInWays.Text = "جزئیات توراهی";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.GridColor = System.Drawing.SystemColors.Control;
            this.dgvMain.Location = new System.Drawing.Point(3, 25);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidth = 25;
            this.dgvMain.RowTemplate.Height = 35;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(908, 335);
            this.dgvMain.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.btnOpenJson);
            this.gbFilter.Controls.Add(this.btnExport);
            this.gbFilter.Controls.Add(this.txtInvoiceId);
            this.gbFilter.Controls.Add(this.btnShow);
            this.gbFilter.Location = new System.Drawing.Point(12, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(914, 80);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "انتخاب توراهی";
            // 
            // btnOpenJson
            // 
            this.btnOpenJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenJson.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOpenJson.Location = new System.Drawing.Point(149, 29);
            this.btnOpenJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenJson.Name = "btnOpenJson";
            this.btnOpenJson.Size = new System.Drawing.Size(120, 36);
            this.btnOpenJson.TabIndex = 3;
            this.btnOpenJson.Text = "خواندن فایل";
            this.btnOpenJson.UseVisualStyleBackColor = true;
            this.btnOpenJson.Click += new System.EventHandler(this.btnOpenJson_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExport.Location = new System.Drawing.Point(21, 29);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 36);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "خروج فایل";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtInvoiceId
            // 
            this.txtInvoiceId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceId.EnterToTab = true;
            this.txtInvoiceId.ForeColor = System.Drawing.Color.Gray;
            this.txtInvoiceId.HintColor = System.Drawing.Color.Gray;
            this.txtInvoiceId.HintValue = "شماره فاکتور";
            this.txtInvoiceId.IsNumerical = true;
            this.txtInvoiceId.Location = new System.Drawing.Point(740, 33);
            this.txtInvoiceId.Name = "txtInvoiceId";
            this.txtInvoiceId.Size = new System.Drawing.Size(168, 29);
            this.txtInvoiceId.TabIndex = 0;
            this.txtInvoiceId.Text = "شماره فاکتور";
            this.txtInvoiceId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInvoiceId.TextForeColor = System.Drawing.Color.Black;
            this.txtInvoiceId.Value = "";
            // 
            // InWay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 464);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InWay";
            this.RightToLeftLayout = true;
            this.Text = "توراهی";
            this.panelMain.ResumeLayout(false);
            this.gbInWays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.GroupBox gbInWays;
        private System.Windows.Forms.DataGridView dgvMain;
        private Windows.Forms.HintTextBox txtInvoiceId;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnOpenJson;
    }
}