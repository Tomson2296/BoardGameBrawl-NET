using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserRatingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "GroupParticipants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "GroupParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserRatings",
                schema: "dbo",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<short>(type: "smallint", nullable: false),
                    RatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    IsSoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => new { x.AppUserId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_UserRatings_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_BoardgameId",
                schema: "dbo",
                table: "UserRatings",
                column: "BoardgameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRatings",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "GroupParticipants");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "GroupParticipants");
        }
    }
}
