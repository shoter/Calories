using Microsoft.EntityFrameworkCore.Migrations;

namespace Calories.Database.Migrations
{
    public partial class CompositeKeysDoneGoodFinalyxd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes",
                columns: new[] { "ID", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientIntakes",
                table: "IngredientIntakes",
                columns: new[] { "ID", "IngredientID" });
        }
    }
}
