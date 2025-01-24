using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.IdentityApp
{
    /// <inheritdoc />
    public partial class Modify_ApplicationUser_Table_AddPasswordSalt_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                schema: "dbo",
                table: "Users",
                type: "date",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                schema: "dbo",
                table: "Users",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");
        }
    }
}
