using Microsoft.EntityFrameworkCore.Migrations;

namespace Calories.Database.Migrations
{
    public partial class IngredientSizeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeTypeID",
                table: "Ingredients",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_SizeTypeID",
                table: "Ingredients",
                column: "SizeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_SizeTypes_SizeTypeID",
                table: "Ingredients",
                column: "SizeTypeID",
                principalTable: "SizeTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_SizeTypes_SizeTypeID",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_SizeTypeID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "SizeTypeID",
                table: "Ingredients");
        }
    }
}
