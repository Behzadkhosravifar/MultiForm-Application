using System;
using System.Drawing;

namespace FileExporter
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public delegate void OnAppButtonClick(object sender, EventArgs e);

        public void AddPlugin(BaseForm form)
        {
            var button = new System.Windows.Forms.Button();
            // 
            // button
            // 
            button.Location = new System.Drawing.Point(3, 3);
            button.Name = "button_" + form.Name;
            button.Size = new System.Drawing.Size(135, 135);
            button.TabIndex = 1;
            button.Text = form.Text;
            button.Image = form.Icon.ToBitmap();
            button.Click += (s, e) => form.ShowDialog(this);
            button.Enabled = form.Enabled;
            button.TextAlign = ContentAlignment.BottomCenter;
            button.UseVisualStyleBackColor = true;
            //
            // MainForm
            //
            this.flpMainForm.Controls.Add(button);
        }


        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);

            var forms = Program.GetAllForms();
            foreach (var form in forms)
            {
                var baseform = (BaseForm)Activator.CreateInstance(form);

                AddPlugin(baseform);
            }
        }
    }
}
