using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Modify_PlayersTable_Remove_UserLastLogin_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLastLogin",
                schema: "dbo",
                table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UserLastLogin",
                schema: "dbo",
                table: "Players",
                type: "datetime2",
                nullable: true);
        }
    }
}
