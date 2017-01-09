using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FileExporter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ErrorControlSystem.ExceptionHandler.Engine.Start(new Connection(UsersManagements.ConnectionString));

            var formsTypes = GetAllForms().ToArray();
            Application.Run(GetRequestedForm(args, formsTypes) ?? (formsTypes.Count() > 1 ? new MainForm() : (BaseForm)Activator.CreateInstance(formsTypes[0])));
        }

        private static BaseForm GetRequestedForm(string[] args, IEnumerable<Type> formsTypes)
        {
            var formIndex = args.ToList().FindIndex(param => param.ToLower() == "/f");
            if (formIndex >= 0 && formIndex + 1 < args.Count())
            {
                string formName = args[formIndex + 1].ToLower();
                var form = formsTypes.SingleOrDefault(t => t.Name.ToLower() == formName);

                if (form != null)
                    return (BaseForm)Activator.CreateInstance(form);
            }

            return null;
        }

        public static IEnumerable<Type> GetAllForms()
        {
            var baseFormType = typeof(BaseForm);
            return baseFormType.Assembly.GetTypes()
                .Where(t => baseFormType.IsAssignableFrom(t) &&
                t.Namespace == "FileExporter.PluginForms" &&
                t != baseFormType &&
                t != typeof(MainForm));
        }
    }
}
