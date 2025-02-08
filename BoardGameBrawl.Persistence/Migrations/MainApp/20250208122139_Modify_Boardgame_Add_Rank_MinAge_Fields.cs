using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Modify_Boardgame_Add_Rank_MinAge_Fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MinAge",
                schema: "dbo",
                table: "Boardgames",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                schema: "dbo",
                table: "Boardgames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinAge",
                schema: "dbo",
                table: "Boardgames");

            migrationBuilder.DropColumn(
                name: "Rank",
                schema: "dbo",
                table: "Boardgames");
        }
    }
}
