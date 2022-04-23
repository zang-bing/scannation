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
        static void RegisterURLProtocol(string protocolName, string applicationPath)
        {
            try
            {
                if (KeyExists(Registry.CurrentUser, @"Software\HiroSyasin"))
                {
                    // Create new key for desired URL protocol
                    var keyTest = Registry.CurrentUser.OpenSubKey("Software", true)?.OpenSubKey("Classes", true);
                    var key = keyTest?.CreateSubKey(protocolName);
                    key?.SetValue("URL Protocol", protocolName);
                    //key.CreateSubKey(@"shell\open\command").SetValue("", "\"" + applicationPath + "\"");
                    key?.CreateSubKey(@"shell\open\command")?.SetValue("", "\"" + applicationPath + "\" \"%1\"");
                    MessageBox.Show("Protocol created");
                    return;
                }

                MessageBox.Show("Registry is not defined");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var protocol = @"Software\Classes\Scanapp";
                var programPath = Path.Combine(
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                    System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                var list = Registry.CurrentUser.GetSubKeyNames().ToList();

                RegisterURLProtocol("scanapp", programPath);
#if DEBUG
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
#else
                if (args.Any())
                {
                    var url = args[0].Replace("scanapp://", "");

                    MatchCollection mcId = Regex.Matches(args[0], @"\bid=.*&n");
                    var id = mcId[0].ToString().Replace("id=", "").Replace("&n", "");

                    MatchCollection mcName = Regex.Matches(args[0], @"\b&name=.*&t");
                    var name = mcName[0].ToString().Replace("&name=", "").Replace("&t", "");

                    MatchCollection mcToken = Regex.Matches(args[0], @"\b&token=.*");
                    var token = mcToken[0].ToString().Replace("&token=", "");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Scanation(id, name, token, url));
                }

#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static bool KeyExists(RegistryKey baseKey, string subKeyName)
        {
            RegistryKey ret = baseKey.OpenSubKey(subKeyName);

            return ret != null;
        }
    }
}
