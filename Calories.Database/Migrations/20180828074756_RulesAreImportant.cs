using Microsoft.EntityFrameworkCore.Migrations;

namespace Calories.Database.Migrations
{
    public partial class RulesAreImportant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTypeRules");
        }
    }
}
