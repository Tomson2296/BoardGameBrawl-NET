using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Change_Relationship_Configurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRules_Boardgames_BoardgameID",
                schema: "dbo",
                table: "MatchRules");

            migrationBuilder.RenameColumn(
                name: "BoardgameID",
                schema: "dbo",
                table: "MatchRules",
                newName: "BoardgameId");

            migrationBuilder.RenameIndex(
                name: "IX_MatchRules_BoardgameID",
                schema: "dbo",
                table: "MatchRules",
                newName: "IX_MatchRules_BoardgameId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRules_Boardgames_BoardgameId",
                schema: "dbo",
                table: "MatchRules",
                column: "BoardgameId",
                principalSchema: "dbo",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRules_Boardgames_BoardgameId",
                schema: "dbo",
                table: "MatchRules");

            migrationBuilder.RenameColumn(
                name: "BoardgameId",
                schema: "dbo",
                table: "MatchRules",
                newName: "BoardgameID");

            migrationBuilder.RenameIndex(
                name: "IX_MatchRules_BoardgameId",
                schema: "dbo",
                table: "MatchRules",
                newName: "IX_MatchRules_BoardgameID");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRules_Boardgames_BoardgameID",
                schema: "dbo",
                table: "MatchRules",
                column: "BoardgameID",
                principalSchema: "dbo",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
