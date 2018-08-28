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
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<ExerciseTypeRule> ExerciseTypeRules { get; set; }
        public DbSet<SizeType> SizeTypes { get; set; }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ingredient>()
                .HasIndex(i => i.Name)
                .IsUnique();

            builder.Entity<IngredientIntake>()
                .HasKey(i => new { i.ID, i.Date });

            builder.Entity<ExerciseType>()
                .HasIndex(i => i.Name)
                .IsUnique();
        }
    }
}
