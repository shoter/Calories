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
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "IngredientIntakes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIntakes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IngredientIntakes_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIntakes_IngredientID",
                table: "IngredientIntakes",
                column: "IngredientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientIntakes");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
