using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTables_Groups_GroupsParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GroupDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    GroupMiniature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSoftDeleted = table.Column<bool>(type: "bit", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupParticipants",
                schema: "dbo",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupParticipants", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GroupParticipants_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupParticipants_UserId",
                schema: "dbo",
                table: "GroupParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "GroupNameIndex",
                schema: "dbo",
                table: "Groups",
                column: "GroupName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "dbo");
        }
    }
}
