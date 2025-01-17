using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Modify_ApplicationUser_Table_Ignore_Lockout_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "dbo",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "dbo",
                table: "Users",
                type: "datetimeoffset",
                nullable: true);
        }
    }
}
