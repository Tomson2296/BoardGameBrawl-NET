using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Add_Player_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserId",
                schema: "dbo",
                table: "UserRatings",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dbo",
                table: "GroupParticipants",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupParticipants_UserId",
                schema: "dbo",
                table: "GroupParticipants",
                newName: "IX_GroupParticipants_PlayerId");

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BGGUsername = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    UserAvatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserLastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "BGGUsernameIndex",
                schema: "dbo",
                table: "Players",
                column: "BGGUsername",
                unique: true,
                filter: "[BGGUsername] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserEmailIndex",
                schema: "dbo",
                table: "Players",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Players",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupParticipants_Players_PlayerId",
                schema: "dbo",
                table: "GroupParticipants",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Players_PlayerId",
                schema: "dbo",
                table: "UserRatings",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupParticipants_Players_PlayerId",
                schema: "dbo",
                table: "GroupParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Players_PlayerId",
                schema: "dbo",
                table: "UserRatings");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                schema: "dbo",
                table: "UserRatings",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                schema: "dbo",
                table: "GroupParticipants",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupParticipants_PlayerId",
                schema: "dbo",
                table: "GroupParticipants",
                newName: "IX_GroupParticipants_UserId");
        }
    }
}
