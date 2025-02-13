using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Rollback_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyAvailability_PlayerSchedule_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailability");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSchedule_Players_PlayerId",
                schema: "dbo",
                table: "PlayerSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlot_DailyAvailability_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlot",
                schema: "dbo",
                table: "TimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerSchedule",
                schema: "dbo",
                table: "PlayerSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyAvailability",
                schema: "dbo",
                table: "DailyAvailability");

            migrationBuilder.RenameTable(
                name: "TimeSlot",
                schema: "dbo",
                newName: "TimeSlots",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PlayerSchedule",
                schema: "dbo",
                newName: "PlayerSchedules",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "DailyAvailability",
                schema: "dbo",
                newName: "DailyAvailabilities",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSlot_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlots",
                newName: "IX_TimeSlots_DailyAvailabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerSchedule_PlayerId",
                schema: "dbo",
                table: "PlayerSchedules",
                newName: "PlayerIndex");

            migrationBuilder.RenameIndex(
                name: "IX_DailyAvailability_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailabilities",
                newName: "IX_DailyAvailabilities_PlayerScheduleId");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerSchedules",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlots",
                schema: "dbo",
                table: "TimeSlots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerSchedules",
                schema: "dbo",
                table: "PlayerSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyAvailabilities",
                schema: "dbo",
                table: "DailyAvailabilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyAvailabilities_PlayerSchedules_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailabilities",
                column: "PlayerScheduleId",
                principalSchema: "dbo",
                principalTable: "PlayerSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSchedules_Players_PlayerId",
                schema: "dbo",
                table: "PlayerSchedules",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_DailyAvailabilities_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlots",
                column: "DailyAvailabilityId",
                principalSchema: "dbo",
                principalTable: "DailyAvailabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyAvailabilities_PlayerSchedules_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSchedules_Players_PlayerId",
                schema: "dbo",
                table: "PlayerSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_DailyAvailabilities_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlots",
                schema: "dbo",
                table: "TimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerSchedules",
                schema: "dbo",
                table: "PlayerSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyAvailabilities",
                schema: "dbo",
                table: "DailyAvailabilities");

            migrationBuilder.RenameTable(
                name: "TimeSlots",
                schema: "dbo",
                newName: "TimeSlot",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PlayerSchedules",
                schema: "dbo",
                newName: "PlayerSchedule",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "DailyAvailabilities",
                schema: "dbo",
                newName: "DailyAvailability",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TimeSlots_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlot",
                newName: "IX_TimeSlot_DailyAvailabilityId");

            migrationBuilder.RenameIndex(
                name: "PlayerIndex",
                schema: "dbo",
                table: "PlayerSchedule",
                newName: "IX_PlayerSchedule_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyAvailabilities_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailability",
                newName: "IX_DailyAvailability_PlayerScheduleId");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerName",
                schema: "dbo",
                table: "PlayerSchedule",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlot",
                schema: "dbo",
                table: "TimeSlot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerSchedule",
                schema: "dbo",
                table: "PlayerSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyAvailability",
                schema: "dbo",
                table: "DailyAvailability",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyAvailability_PlayerSchedule_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailability",
                column: "PlayerScheduleId",
                principalSchema: "dbo",
                principalTable: "PlayerSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSchedule_Players_PlayerId",
                schema: "dbo",
                table: "PlayerSchedule",
                column: "PlayerId",
                principalSchema: "dbo",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlot_DailyAvailability_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlot",
                column: "DailyAvailabilityId",
                principalSchema: "dbo",
                principalTable: "DailyAvailability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
