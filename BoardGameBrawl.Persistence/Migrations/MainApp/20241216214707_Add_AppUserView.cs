using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Add_AppUserView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
             @"CREATE VIEW AppUser as " +
             "SELECT Id, UserName, Email, FirstName, LastName, BGGUsername," +
             "UserDescription, UserAvatar, UserLastLogin " +
             "from IdentityAppDb.dbo.Users"
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW AppUser");
        }
    }
}
