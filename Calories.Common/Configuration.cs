using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calories.Common
{
    public static partial class Configuration
    {
        internal static IConfigurationRoot configuration;

        static Configuration()
        {
            try
            {
                //string basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string basePath = Directory.GetCurrentDirectory();
                var configBuilder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("mysql.json", optional: true);

                configuration = configBuilder.Build();
            }
            catch( FileNotFoundException e)
            {
                throw new Exception(e.FileName);
            }
        }

        internal static string getConfiguration(string key)
        {
            return configuration[key];
        }

    }
}
