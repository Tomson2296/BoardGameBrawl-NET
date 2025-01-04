using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Boardgame_Table_Remove_ImageFilePath_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingDateTime",
                schema: "dbo",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                schema: "dbo",
                table: "Boardgames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RatingDateTime",
                schema: "dbo",
                table: "UserRatings",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                schema: "dbo",
                table: "Boardgames",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);
        }
    }
}
