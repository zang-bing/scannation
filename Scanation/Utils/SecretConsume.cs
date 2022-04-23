/*using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Scanation.Utils
{
    internal class SecretConsume
    {
        ConfigurationBuilder _builder = null;
        public string AWSAccessKey
        {
            get
            {
                string returnString = string.Empty;
                try
                {
                    IConfigurationRoot configuration = _builder.Build();
                    returnString = configuration.GetConnectionString("AWSAccessKey");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return returnString;
            }
        }
        public string AWSSecretKey
        {
            get
            {
                string returnString = string.Empty;
                try
                {
                    IConfigurationRoot configuration = _builder.Build();
                    returnString = configuration.GetConnectionString("AWSSecretKey");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return returnString;
            }
        }
        public void SecretConsumer()
        {
            this._builder = (ConfigurationBuilder)new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSecrets.json", optional: false, reloadOnChange: true);
        }
    }
}
*/