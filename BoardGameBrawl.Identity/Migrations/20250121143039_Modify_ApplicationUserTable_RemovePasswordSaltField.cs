using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Modify_ApplicationUserTable_RemovePasswordSaltField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "dbo",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
