using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace Scanation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var protocol = @"Software\HiroSyasin\Scanation";

            var list = Registry.CurrentUser.GetSubKeyNames().ToList();

            var arg = "scannation://lh3.googleusercontent.com/LBZbzy9NXoY_0vQQOkDQnVSzu27am8yxvcsxOk0CPhfnr7uraTv-9ONUje1b7zcK0bTqTbI1_pY2hVzXu4aGbSQ9";
            var url = arg.Replace("scannation://", "");

            if (KeyExists(Registry.CurrentUser, @"Software\HiroSyasin"))
            {
                var key = Registry.CurrentUser.CreateSubKey(protocol);

                key.SetValue("", $"URL:{protocol} Protocol");
                key.SetValue("URL Protocol", "");
                var subKey = key.CreateSubKey(@"shell\open\command");
                var execPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                subKey.SetValue("", $"{execPath} %1");
                subKey.Close();
                key.Close();

                    

                if (args.Any())
                {
                    var urls = args[0].Split('?')[1].Split('&');
                    var orderId = urls[0].Replace("id=", "");
                    var name = urls[1].Replace("name=", "");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Scanation(orderId, name, url));
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Scanation(url));
            } else
            {
                MessageBox.Show("Regitry is not defined ...!");
            }
        }

        static bool KeyExists(RegistryKey baseKey, string subKeyName)
        {
            RegistryKey ret = baseKey.OpenSubKey(subKeyName);

            return ret != null;
        }
    }
}
