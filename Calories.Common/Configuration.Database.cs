using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calories.Common
{
    public static partial class Configuration
    {
        public static class Database
        {
            public static string ConnectionString { get; private set; }

            static Database()
            {
                ConnectionString = getSetting("connectionString");
            }

            private static string getSetting(string key) 
            {
                return Configuration.getConfiguration($"database:{key}");
            }

        }
    }
}
