using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calories.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SizeTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExerciseTypeID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CountedCalories = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseTypes_ExerciseTypeID",
                        column: x => x.ExerciseTypeID,
                        principalTable: "ExerciseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeRules",
                columns: table => new
                {
                    ExerciseTypeID = table.Column<int>(nullable: false),
                    CaloriesModifier = table.Column<decimal>(type: "decimal(10,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeRules", x => x.ExerciseTypeID);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeRules_ExerciseTypes_ExerciseTypeID",
                        column: x => x.ExerciseTypeID,
                        principalTable: "ExerciseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    SizeTypeID = table.Column<int>(nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Proteins = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Carbonhydrates = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Roughage = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Magnes = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Potas = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Calcium = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Phosphor = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Iron = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Zinc = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Copper = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Mangan = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Sodium = table.Column<decimal>(type: "decimal(14,8)", nullable: true),
                    Jod = table.Column<decimal>(type: "decimal(14,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredients_SizeTypes_SizeTypeID",
                        column: x => x.SizeTypeID,
                        principalTable: "SizeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientIntakes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    IngredientID = table.Column<int>(nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(9,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIntakes", x => new { x.ID, x.Date });
                    table.ForeignKey(
                        name: "FK_IngredientIntakes_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseTypeID",
                table: "Exercises",
                column: "ExerciseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypes_Name",
                table: "ExerciseTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIntakes_IngredientID",
                table: "IngredientIntakes",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_SizeTypeID",
                table: "Ingredients",
                column: "SizeTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseTypeRules");

            migrationBuilder.DropTable(
                name: "IngredientIntakes");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "ExerciseTypes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "SizeTypes");
        }
    }
}
