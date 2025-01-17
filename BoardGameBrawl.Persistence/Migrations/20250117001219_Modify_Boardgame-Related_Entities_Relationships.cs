using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Modify_BoardgameRelated_Entities_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameCategoryTags_BoardgameCategories_CategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameMechanicTags_BoardgameMechanics_MechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropIndex(
                name: "BoardgameNameIndex",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropIndex(
                name: "IX_BoardgameMechanicTags_MechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropIndex(
                name: "IX_BoardgameCategoryTags_CategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Boardgames",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "dbo",
                table: "Boardgames",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Boardgames",
                type: "nvarchar(max)",
                maxLength: 4098,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BoardgameMechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BoardgameCategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "BoardgameNameIndex",
                schema: "dbo",
                table: "Boardgames",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameMechanicTags_BoardgameMechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                column: "BoardgameMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCategoryTags_BoardgameCategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                column: "BoardgameCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameCategoryTags_BoardgameCategories_BoardgameCategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                column: "BoardgameCategoryId",
                principalSchema: "dbo",
                principalTable: "BoardgameCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameMechanicTags_BoardgameMechanics_BoardgameMechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                column: "BoardgameMechanicId",
                principalSchema: "dbo",
                principalTable: "BoardgameMechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameCategoryTags_BoardgameCategories_BoardgameCategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameMechanicTags_BoardgameMechanics_BoardgameMechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropIndex(
                name: "BoardgameNameIndex",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropIndex(
                name: "IX_BoardgameMechanicTags_BoardgameMechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropIndex(
                name: "IX_BoardgameCategoryTags_BoardgameCategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.DropColumn(
                name: "BoardgameMechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropColumn(
                name: "BoardgameCategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Boardgames",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                schema: "dbo",
                table: "Boardgames",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Boardgames",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 4098);

            migrationBuilder.CreateIndex(
                name: "BoardgameNameIndex",
                schema: "dbo",
                table: "Boardgames",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameMechanicTags_MechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCategoryTags_CategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameCategoryTags_BoardgameCategories_CategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "BoardgameCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameMechanicTags_BoardgameMechanics_MechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                column: "MechanicId",
                principalSchema: "dbo",
                principalTable: "BoardgameMechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
