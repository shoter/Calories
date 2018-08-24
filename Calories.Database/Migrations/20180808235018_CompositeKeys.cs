using Microsoft.EntityFrameworkCore.Migrations;

namespace Calories.Database.Migrations
{
    public partial class CompositeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes",
                columns: new[] { "ID", "IngredientID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes",
                column: "ID");
        }
    }
}
