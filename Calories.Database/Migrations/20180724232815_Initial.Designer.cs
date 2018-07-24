﻿// <auto-generated />
using System;
using Calories.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Calories.Database.Migrations
{
    [DbContext(typeof(CaloriesContext))]
    [Migration("20180724232815_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Calories.Data.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Calcium")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal>("Calories")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Carbonhydrates")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Copper")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Fat")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Iron")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Jod")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Magnes")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Mangan")
                        .HasColumnType("decimal(14,8)");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<decimal?>("Phosphor")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Potas")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Proteins")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Roughage")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal?>("Sodium")
                        .HasColumnType("decimal(14,8)");

                    b.Property<decimal?>("Zinc")
                        .HasColumnType("decimal(14,8)");

                    b.HasKey("ID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Calories.Data.IngredientIntake", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("IngredientID");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ID");

                    b.HasIndex("IngredientID");

                    b.ToTable("IngredientIntakes");
                });

            modelBuilder.Entity("Calories.Data.IngredientIntake", b =>
                {
                    b.HasOne("Calories.Data.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
