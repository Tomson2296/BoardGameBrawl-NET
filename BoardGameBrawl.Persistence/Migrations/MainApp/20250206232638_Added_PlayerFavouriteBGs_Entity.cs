using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Added_PlayerFavouriteBGs_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCollection_Players_PlayerId",
                schema: "dbo",
                table: "PlayerCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerCollection",
                schema: "dbo",
                table: "PlayerCollection");

            migrationBuilder.RenameTable(
                name: "PlayerCollection",
                schema: "dbo",
                newName: "PlayerCollections",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerCollection_PlayerId",
                schema: "dbo",
                table: "PlayerCollections",
                newName: "PlayerIndex");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerCollections",
                schema: "dbo",
                table: "PlayerCollections",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PlayerFavouriteBoardgames",
                schema: "dbo",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFavouriteBoardgames", x => new { x.PlayerId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_PlayerFavouriteBoardgames_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerFavouriteBoardgames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFavouriteBoardgames_BoardgameId",
                schema: "dbo",
                table: "PlayerFavouriteBoardgames",
                column: "BoardgameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCollections_Players_PlayerId",
                schema: "dbo",
                table: "PlayerCollections",
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
                name: "FK_PlayerCollections_Players_PlayerId",
                schema: "dbo",
                table: "PlayerCollections");

            migrationBuilder.DropTable(
                name: "PlayerFavouriteBoardgames",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerCollections",
                schema: "dbo",
                table: "PlayerCollections");

            migrationBuilder.RenameTable(
                name: "PlayerCollections",
                schema: "dbo",
                newName: "PlayerCollection",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "PlayerIndex",
                schema: "dbo",
                table: "PlayerCollection",
                newName: "IX_PlayerCollection_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerCollection",
                schema: "dbo",
                table: "PlayerCollection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCollection_Players_PlayerId",
                schema: "dbo",
                table: "PlayerCollection",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
