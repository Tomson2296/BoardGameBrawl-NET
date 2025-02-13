using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Added_PlayerSchedule_Feature_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerSchedule",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSchedule_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyAvailability",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    PlayerScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyAvailability_PlayerSchedule_PlayerScheduleId",
                        column: x => x.PlayerScheduleId,
                        principalSchema: "dbo",
                        principalTable: "PlayerSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DailyAvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlot_DailyAvailability_DailyAvailabilityId",
                        column: x => x.DailyAvailabilityId,
                        principalSchema: "dbo",
                        principalTable: "DailyAvailability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "AddresseeNameIndex",
                schema: "dbo",
                table: "PlayerFriends",
                column: "AddresseeName");

            migrationBuilder.CreateIndex(
                name: "RequesterNameIndex",
                schema: "dbo",
                table: "PlayerFriends",
                column: "RequesterName");

            migrationBuilder.CreateIndex(
                name: "IX_DailyAvailability_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailability",
                column: "PlayerScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSchedule_PlayerId",
                schema: "dbo",
                table: "PlayerSchedule",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlot",
                column: "DailyAvailabilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlot",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DailyAvailability",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerSchedule",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "AddresseeNameIndex",
                schema: "dbo",
                table: "PlayerFriends");

            migrationBuilder.DropIndex(
                name: "RequesterNameIndex",
                schema: "dbo",
                table: "PlayerFriends");
        }
    }
}
