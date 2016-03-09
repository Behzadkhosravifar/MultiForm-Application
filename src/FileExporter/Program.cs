using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ErrorControlSystem.DbConnectionManager;
using ConnectionManager = AdoManager.ConnectionManager;

namespace FileExporter
{
    static class Program
    {
        public static ConnectionManager Sale, SaleCore, SaleMarkaz, UsersManagements;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set Database Connection from [app.config]
            SetConnections();

            ErrorControlSystem.ExceptionHandler.Engine.Start(new Connection(UsersManagements.ConnectionString));

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

        private static void SetConnections()
        {
            // Set Database Connection from [app.config] ---------------------------------------------------------------------
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName) + ".config";
            var data = File.ReadAllText(path);
            ConnectionManager.LoadFromXml(data);
            ConnectionManager.SetToDefaultConnection("SaleCore"); // local

            Sale = ConnectionManager.Find("Sale");
            SaleCore = ConnectionManager.Find("SaleCore");
            SaleMarkaz = ConnectionManager.Find("SaleMarkaz");
            UsersManagements = ConnectionManager.Find("UM");
            // ---------------------------------------------------------------------------------------------------------------
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
