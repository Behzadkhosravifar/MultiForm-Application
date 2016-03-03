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
    }
}
