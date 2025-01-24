using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Add_Tournament_Features : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate_Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MatchDate_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchDate_Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Participants = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TournnamentProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentDate_Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TournamentDate_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentDate_Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    MaxNumberOfPlayers = table.Column<short>(type: "smallint", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentParticipants = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentMatches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate_Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MatchDate_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchDate_Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Participants = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchNumber = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BoardgameId",
                schema: "dbo",
                table: "Matches",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentMatches_BoardgameId",
                schema: "dbo",
                table: "TournamentMatches",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentMatches_TournamentId",
                schema: "dbo",
                table: "TournamentMatches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_BoardgameId",
                schema: "dbo",
                table: "Tournaments",
                column: "BoardgameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentMatches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tournaments",
                schema: "dbo");
        }
    }
}
