using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_AdditionalIndexes_BoardgameCategory_BoardgameMechanic_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "BoardgameMechanicIndex",
                schema: "dbo",
                table: "BoardgameMechanics",
                column: "Mechanic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BoardgameCategoryIndex",
                schema: "dbo",
                table: "BoardgameCategories",
                column: "Category",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "BoardgameMechanicIndex",
                schema: "dbo",
                table: "BoardgameMechanics");

            migrationBuilder.DropIndex(
                name: "BoardgameCategoryIndex",
                schema: "dbo",
                table: "BoardgameCategories");
        }
    }
}
