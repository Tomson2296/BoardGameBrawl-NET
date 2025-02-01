using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BoardgameCategories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameMechanics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mechanic = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameMechanics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boardgames",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BGGId = table.Column<int>(type: "int", nullable: false),
                    YearPublished = table.Column<short>(type: "smallint", nullable: false),
                    MinPlayers = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxPlayers = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    MinimumPlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    MaximumPlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    BGGWeight = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardgames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    GroupDescription = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    GroupMiniature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

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
                    UserDescription = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    UserAvatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameCategoryTags",
                schema: "dbo",
                columns: table => new
                {
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameCategoryTags", x => new { x.BoardgameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BoardgameCategoryTags_BoardgameCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "BoardgameCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameCategoryTags_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameMechanicTags",
                schema: "dbo",
                columns: table => new
                {
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MechanicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameMechanicTags", x => new { x.BoardgameId, x.MechanicId });
                    table.ForeignKey(
                        name: "FK_BoardgameMechanicTags_BoardgameMechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalSchema: "dbo",
                        principalTable: "BoardgameMechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameMechanicTags_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate_Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MatchDate_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchDate_Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Participants = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchRules",
                schema: "dbo",
                columns: table => new
                {
                    RuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleDescription = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    RuleDecider = table.Column<bool>(type: "bit", nullable: false),
                    RuleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRules", x => x.RuleId);
                    table.ForeignKey(
                        name: "FK_MatchRules_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TournnamentProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TournamentDate_Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TournamentDate_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentDate_Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    MaxNumberOfPlayers = table.Column<short>(type: "smallint", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentParticipants = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupParticipants",
                schema: "dbo",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupParticipants", x => new { x.GroupId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_GroupParticipants_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupParticipants_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPreferences",
                schema: "dbo",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPreferences", x => new { x.PlayerId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_PlayerPreferences_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPreferences_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentMatches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate_Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    MatchDate_Started = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatchDate_Ended = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Participants = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchNumber = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "BoardgameCategoryIndex",
                schema: "dbo",
                table: "BoardgameCategories",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameCategoryTags_CategoryId",
                schema: "dbo",
                table: "BoardgameCategoryTags",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "BoardgameMechanicIndex",
                schema: "dbo",
                table: "BoardgameMechanics",
                column: "Mechanic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardgameMechanicTags_MechanicId",
                schema: "dbo",
                table: "BoardgameMechanicTags",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "BGGIdIndex",
                schema: "dbo",
                table: "Boardgames",
                column: "BGGId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "BoardgameNameIndex",
                schema: "dbo",
                table: "Boardgames",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupParticipants_PlayerId",
                schema: "dbo",
                table: "GroupParticipants",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "GroupNameIndex",
                schema: "dbo",
                table: "Groups",
                column: "GroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BoardgameId",
                schema: "dbo",
                table: "Matches",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRules_BoardgameId",
                schema: "dbo",
                table: "MatchRules",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPreferences_BoardgameId",
                schema: "dbo",
                table: "PlayerPreferences",
                column: "BoardgameId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TournamentMatches_BoardgameId",
                schema: "dbo",
                table: "TournamentMatches",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentMatches_TournamentId",
                schema: "dbo",
                table: "TournamentMatches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_BoardgameId",
                schema: "dbo",
                table: "Tournaments",
                column: "BoardgameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardgameCategoryTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameMechanicTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GroupParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Matches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MatchRules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerPreferences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentMatches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameMechanics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tournaments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Boardgames",
                schema: "dbo");
        }
    }
}
