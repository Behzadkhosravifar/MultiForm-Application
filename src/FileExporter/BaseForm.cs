using System;
using System.Data;
using System.Windows.Forms;

namespace FileExporter
{
    public class BaseForm : System.Windows.Forms.Form, IVisualForm, IDisposable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected DataTable SourceTable;
        protected readonly object SyncObj = new object();

        public BaseForm()
        {
            Application.Idle += OnLoaded;
        }

        protected virtual void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("B Nazanin", 9F);
            this.Name = "BaseForm";
            this.ResumeLayout(false);
        }


        ~BaseForm()
        {
            Dispose();
        }

        // Public implementation of Dispose pattern callable by consumers.
        public new void Dispose()
        {
            if (IsDisposed)
                return; 

            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
            GC.Collect();

            base.Dispose();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                // Dispose stuff here
                if (SourceTable != null)
                {
                    SourceTable.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
