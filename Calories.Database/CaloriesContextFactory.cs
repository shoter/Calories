using Calories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calories.Database
{
    public class CaloriesContextFactory : IDesignTimeDbContextFactory<CaloriesContext>
    {
        public CaloriesContext CreateDbContext(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("calories_connectionstring");

            Console.WriteLine($"Connection string : {connectionString}");

            var builder = new DbContextOptionsBuilder<CaloriesContext>();
            builder.UseMySql(connectionString,
                options =>
                {
                    options.ServerVersion(new Version(8, 0, 13), ServerType.MySql);
                });
            return new CaloriesContext(builder.Options);
        }
    }
}
