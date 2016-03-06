using System;
using System.Windows.Forms;

namespace FileExporter
{
    public class BaseForm : System.Windows.Forms.Form, IVisualForm
    {
        public BaseForm()
        {
            Application.Idle += OnLoad;
        }

        protected virtual void OnLoad(object sender, EventArgs e)
        {
            Application.Idle -= OnLoad;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("B Nazanin", 9F);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
