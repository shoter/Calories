using Calories.Common;
using Calories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calories.Database
{
    public class CaloriesContext : DbContext
    {
        public CaloriesContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientIntake> IngredientIntakes { get; set; }
        public DbSet<Weight> Weights { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                return;
            }

            throw new Exception(Configuration.Database.ConnectionString);

            optionsBuilder.UseSqlServer(Configuration.Database.ConnectionString);
        }
    }
}
