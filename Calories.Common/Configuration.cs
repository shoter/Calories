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
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = configBuilder.Build();
        }

        internal static string getConfiguration(string key)
        {
            return configuration[key];
        }

    }
}
