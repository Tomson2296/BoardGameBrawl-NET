using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Modify_MainAppContext_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "dbo",
                table: "Players",
                newName: "PlayerName");

            migrationBuilder.AddColumn<string>(
                name: "BoardgameName",
                schema: "dbo",
                table: "PlayerPreferences",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerPreferences",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddresseeName",
                schema: "dbo",
                table: "PlayerFriends",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequesterName",
                schema: "dbo",
                table: "PlayerFriends",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BoardgameName",
                schema: "dbo",
                table: "PlayerFavouriteBoardgames",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerFavouriteBoardgames",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerCollections",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                schema: "dbo",
                table: "GroupParticipants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                schema: "dbo",
                table: "GroupParticipants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BoardgameName",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BoardgameName",
                schema: "dbo",
                table: "BoardgameDomainTags",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DomainName",
                schema: "dbo",
                table: "BoardgameDomainTags",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BoardgameName",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardgameName",
                schema: "dbo",
                table: "PlayerPreferences");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerPreferences");

            migrationBuilder.DropColumn(
                name: "AddresseeName",
                schema: "dbo",
                table: "PlayerFriends");

            migrationBuilder.DropColumn(
                name: "RequesterName",
                schema: "dbo",
                table: "PlayerFriends");

            migrationBuilder.DropColumn(
                name: "BoardgameName",
                schema: "dbo",
                table: "PlayerFavouriteBoardgames");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerFavouriteBoardgames");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerCollections");

            migrationBuilder.DropColumn(
                name: "GroupName",
                schema: "dbo",
                table: "GroupParticipants");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                schema: "dbo",
                table: "GroupParticipants");

            migrationBuilder.DropColumn(
                name: "BoardgameName",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropColumn(
                name: "MechanicName",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropColumn(
                name: "BoardgameName",
                schema: "dbo",
                table: "BoardgameDomainTags");

            migrationBuilder.DropColumn(
                name: "DomainName",
                schema: "dbo",
                table: "BoardgameDomainTags");

            migrationBuilder.DropColumn(
                name: "BoardgameName",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.RenameColumn(
                name: "PlayerName",
                schema: "dbo",
                table: "Players",
                newName: "UserName");
        }
    }
}
