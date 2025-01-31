using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.IdentityApp
{
    /// <inheritdoc />
    public partial class Modify_ApplicationUser_Add_IsUserCreated_Field : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
               name: "IsPlayerCreated",
               schema: "dbo",
               table: "Users",
               type: "bit",
               defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "IsPlayerCreated",
               schema: "dbo",
               table: "Users");
        }
    }
}
