namespace FileExporter.PluginForms
{
    partial class BankAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankAccounts));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnOpenJson = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbInWays = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.gbFilter.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.gbInWays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilter.Controls.Add(this.btnOpenJson);
            this.gbFilter.Controls.Add(this.btnExport);
            this.gbFilter.Location = new System.Drawing.Point(12, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(674, 70);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            // 
            // btnOpenJson
            // 
            this.btnOpenJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenJson.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnOpenJson.Location = new System.Drawing.Point(410, 20);
            this.btnOpenJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenJson.Name = "btnOpenJson";
            this.btnOpenJson.Size = new System.Drawing.Size(120, 36);
            this.btnOpenJson.TabIndex = 3;
            this.btnOpenJson.Text = "خواندن فایل";
            this.btnOpenJson.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExport.Location = new System.Drawing.Point(538, 20);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 36);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "خروج فایل";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.gbInWays);
            this.panelMain.Controls.Add(this.gbFilter);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelMain.Size = new System.Drawing.Size(698, 553);
            this.panelMain.TabIndex = 4;
            // 
            // gbInWays
            // 
            this.gbInWays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInWays.Controls.Add(this.dgvMain);
            this.gbInWays.Location = new System.Drawing.Point(12, 79);
            this.gbInWays.Name = "gbInWays";
            this.gbInWays.Size = new System.Drawing.Size(674, 462);
            this.gbInWays.TabIndex = 4;
            this.gbInWays.TabStop = false;
            this.gbInWays.Text = "حساب های بانکی";
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
            this.dgvMain.Location = new System.Drawing.Point(3, 16);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidth = 25;
            this.dgvMain.RowTemplate.Height = 35;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(668, 443);
            this.dgvMain.TabIndex = 0;
            // 
            // BankAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 553);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BankAccounts";
            this.Text = "حسابهای بانکی";
            this.gbFilter.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.gbInWays.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnOpenJson;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox gbInWays;
        private System.Windows.Forms.DataGridView dgvMain;
    }
}