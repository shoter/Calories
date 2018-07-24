using Calories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calories.Database
{
    public class CaloriesContextFactory : IDesignTimeDbContextFactory<CaloriesContext>
    {
        public CaloriesContext CreateDbContext(string[] args)
        {
            string connectionString = Configuration.Database.ConnectionString;

            var builder = new DbContextOptionsBuilder<CaloriesContext>();
            builder.UseSqlServer(connectionString);

            return new CaloriesContext(builder.Options);
        }
    }
}
