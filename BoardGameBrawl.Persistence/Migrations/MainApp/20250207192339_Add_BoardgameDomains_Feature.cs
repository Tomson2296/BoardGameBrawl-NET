using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Add_BoardgameDomains_Feature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BGGWeight",
                schema: "dbo",
                table: "Boardgames",
                newName: "BayesRating");

            migrationBuilder.AddColumn<float>(
                name: "AverageBGGWeight",
                schema: "dbo",
                table: "Boardgames",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AverageRating",
                schema: "dbo",
                table: "Boardgames",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Owned",
                schema: "dbo",
                table: "Boardgames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BoardgameDomains",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameDomainTags",
                schema: "dbo",
                columns: table => new
                {
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameDomainTags", x => new { x.BoardgameId, x.DomainId });
                    table.ForeignKey(
                        name: "FK_BoardgameDomainTags_BoardgameDomains_DomainId",
                        column: x => x.DomainId,
                        principalSchema: "dbo",
                        principalTable: "BoardgameDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameDomainTags_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "DomainIndex",
                schema: "dbo",
                table: "BoardgameDomains",
                column: "Domain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameDomainTags_DomainId",
                schema: "dbo",
                table: "BoardgameDomainTags",
                column: "DomainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardgameDomainTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameDomains",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "AverageBGGWeight",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "Owned",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.RenameColumn(
                name: "BayesRating",
                schema: "dbo",
                table: "Boardgames",
                newName: "BGGWeight");
        }
    }
}
