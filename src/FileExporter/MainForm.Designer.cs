namespace FileExporter
{
    partial class MainForm
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
            this.flpMainForm = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpMainForm
            // 
            this.flpMainForm.AutoScroll = true;
            this.flpMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMainForm.Location = new System.Drawing.Point(0, 0);
            this.flpMainForm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.flpMainForm.Name = "flpMainForm";
            this.flpMainForm.Size = new System.Drawing.Size(371, 245);
            this.flpMainForm.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 245);
            this.Controls.Add(this.flpMainForm);
            this.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MainForm";
            this.Text = "فرم خروج فایل";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMainForm;

    }
}

