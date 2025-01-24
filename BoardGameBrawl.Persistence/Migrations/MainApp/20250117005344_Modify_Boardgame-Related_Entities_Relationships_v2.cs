using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Modify_BoardgameRelated_Entities_Relationships_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_BoardgameMechanicTags_MechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags");

            migrationBuilder.DropIndex(
                name: "IX_BoardgameCategoryTags_CategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags");

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
    }
}
