using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Remove_SoftDeletion_Feature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "UserRatings");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "MatchRules");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "MatchRules");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "GroupParticipants");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "GroupParticipants");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameMechanics");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameMechanics");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameCategories");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "UserRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "UserRatings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "MatchRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "MatchRules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "Boardgames",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "Boardgames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameMechanics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameMechanics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                schema: "dbo",
                table: "BoardgameCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                schema: "dbo",
                table: "BoardgameCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
