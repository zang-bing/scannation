using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

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
                var protocol = @"Software\Classes\Scanation";
                var programPath = Path.Combine(
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                    System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

                var list = Registry.CurrentUser.GetSubKeyNames().ToList();

                var arg = "scanation://www.lavender.com.vn/wp-content/uploads/bi-quyet-chup-anh-gia-dinh-5-nguoi-dep-nhat-055.jpg";
                var url = arg.Replace("scanation://", "");

                
                RegisterURLProtocol("scanation", programPath);
#if DEBUG
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Scanation(url));
#else
                if (args.Any())
                {
                    var urls = args[0].Split('?')[1].Split('&');
                    var orderId = urls[0].Replace("id=", "");
                    var name = urls[1].Replace("name=", "");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Scanation(orderId, name, url));
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
