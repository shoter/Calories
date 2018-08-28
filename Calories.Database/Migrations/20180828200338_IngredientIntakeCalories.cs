using Microsoft.EntityFrameworkCore.Migrations;

namespace Calories.Database.Migrations
{
    public partial class IngredientIntakeCalories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Calories",
                table: "IngredientIntakes",
                type: "decimal(9,3)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "IngredientIntakes");
        }
    }
}
