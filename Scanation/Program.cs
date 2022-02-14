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
            var protocol = "scannation";

            var list = Registry.CurrentUser.GetSubKeyNames().ToList();
            if (!list.Contains(protocol))
            {
                var key = Registry.CurrentUser.CreateSubKey(protocol);

                key.SetValue("", $"URL:{protocol} Protocol");
                key.SetValue("URL Protocol", "");
                var subKey = key.CreateSubKey("shell\\open\\command");
                var execPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                subKey.SetValue("", $"{execPath} %1");
                subKey.Close();
                key.Close();
            }

            // scannation://qiita.com/kojimadev?orderId=7410c8557a92939ef69&token=097809709klhxlvkdlvkdlsjv
            var orderId = "";
            var token = "";
            if (args.Any())
            {
                var url = args[0].Replace("scannation://", "");
                var pattenId = @"/id=[\d]*/g";
                var pattenName = @"/name=[\d]*/g";

                Match foundId = Regex.Match(url, pattenId, RegexOptions.IgnoreCase);
                Match foundName = Regex.Match(url, pattenName, RegexOptions.IgnoreCase);

                orderId = foundId.Value.ToString();
                token = foundName.Value.ToString();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Scanation(orderId, token));
        }
    }
}
