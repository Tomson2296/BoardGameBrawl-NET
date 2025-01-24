using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class UserPreferencesTable_changingTableName_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Boardgames_BoardgameId",
                schema: "dbo",
                table: "UserPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Players_PlayerId",
                schema: "dbo",
                table: "UserPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPreferences",
                schema: "dbo",
                table: "UserPreferences");

            migrationBuilder.RenameTable(
                name: "UserPreferences",
                schema: "dbo",
                newName: "PlayerPreferences",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_BoardgameId",
                schema: "dbo",
                table: "PlayerPreferences",
                newName: "IX_PlayerPreferences_BoardgameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerPreferences",
                schema: "dbo",
                table: "PlayerPreferences",
                columns: new[] { "PlayerId", "BoardgameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPreferences_Boardgames_BoardgameId",
                schema: "dbo",
                table: "PlayerPreferences",
                column: "BoardgameId",
                principalSchema: "dbo",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPreferences_Players_PlayerId",
                schema: "dbo",
                table: "PlayerPreferences",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPreferences_Boardgames_BoardgameId",
                schema: "dbo",
                table: "PlayerPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPreferences_Players_PlayerId",
                schema: "dbo",
                table: "PlayerPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerPreferences",
                schema: "dbo",
                table: "PlayerPreferences");

            migrationBuilder.RenameTable(
                name: "PlayerPreferences",
                schema: "dbo",
                newName: "UserPreferences",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerPreferences_BoardgameId",
                schema: "dbo",
                table: "UserPreferences",
                newName: "IX_UserPreferences_BoardgameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPreferences",
                schema: "dbo",
                table: "UserPreferences",
                columns: new[] { "PlayerId", "BoardgameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Boardgames_BoardgameId",
                schema: "dbo",
                table: "UserPreferences",
                column: "BoardgameId",
                principalSchema: "dbo",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Players_PlayerId",
                schema: "dbo",
                table: "UserPreferences",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
