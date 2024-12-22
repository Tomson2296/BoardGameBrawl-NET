using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Add_Index_ApplicationUser_BGGUsernameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "BGGUsernameIndex",
                schema: "dbo",
                table: "Users",
                column: "BGGUsername",
                unique: true,
                filter: "[BGGUsername] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "BGGUsernameIndex",
                schema: "dbo",
                table: "Users");
        }
    }
}
