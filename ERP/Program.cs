using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls.UI.Localization;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            RadGridLocalizationProvider _oldProvider = RadGridLocalizationProvider.CurrentProvider;
            RadGridLocalizationProvider.CurrentProvider = new ChineseRadGridLocalizationProvider();

            Login login = new Login();


            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
