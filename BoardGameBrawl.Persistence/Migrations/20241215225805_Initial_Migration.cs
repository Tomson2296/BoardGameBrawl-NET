using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Boardgames",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BGGId = table.Column<int>(type: "int", nullable: false),
                    YearPublished = table.Column<short>(type: "smallint", nullable: false),
                    MinPlayers = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxPlayers = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    MinimumPlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    MaximumPlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    ThumbnailFilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ImageFilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardgames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchRules",
                schema: "dbo",
                columns: table => new
                {
                    RuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    RuleDecider = table.Column<bool>(type: "bit", nullable: false),
                    RuleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardgameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRules", x => x.RuleId);
                    table.ForeignKey(
                        name: "FK_MatchRules_Boardgames_BoardgameID",
                        column: x => x.BoardgameID,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "BGGIdIndex",
                schema: "dbo",
                table: "Boardgames",
                column: "BGGId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BoardgameNameIndex",
                schema: "dbo",
                table: "Boardgames",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRules_BoardgameID",
                schema: "dbo",
                table: "MatchRules",
                column: "BoardgameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchRules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Boardgames",
                schema: "dbo");
        }
    }
}
