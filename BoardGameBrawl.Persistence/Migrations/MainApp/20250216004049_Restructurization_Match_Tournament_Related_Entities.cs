using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    /// <inheritdoc />
    public partial class Restructurization_Match_Tournament_Related_Entities : Migration
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
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameDomains",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardgameMechanics",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mechanic = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    MinAge = table.Column<byte>(type: "tinyint", nullable: false),
                    MinPlayers = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxPlayers = table.Column<byte>(type: "tinyint", nullable: false),
                    PlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    MinimumPlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    MaximumPlayingTime = table.Column<short>(type: "smallint", nullable: false),
                    AverageBGGWeight = table.Column<float>(type: "real", nullable: false),
                    AverageRating = table.Column<float>(type: "real", nullable: false),
                    BayesRating = table.Column<float>(type: "real", nullable: false),
                    Owned = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BGGUsername = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserDescription = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    UserAvatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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
                name: "BoardgameDomainTags",
                schema: "dbo",
                columns: table => new
                {
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DomainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "BoardgameMechanicTags",
                schema: "dbo",
                columns: table => new
                {
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MechanicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MechanicName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate_Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    MatchDate_Started = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MatchDate_Ended = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VictoryConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalMatchDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRules", x => x.Id);
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
                    TournamentName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    TournnamentProgress = table.Column<int>(type: "int", nullable: false),
                    TournamentDate_Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TournamentDate_Started = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TournamentDate_Ended = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MaxNumberOfPlayers = table.Column<short>(type: "smallint", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
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
                name: "BoardgameModerators",
                schema: "dbo",
                columns: table => new
                {
                    ModeratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModeratorName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BoardgameName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardgameModerators", x => new { x.BoardgameId, x.ModeratorId });
                    table.ForeignKey(
                        name: "FK_BoardgameModerators_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardgameModerators_Players_ModeratorId",
                        column: x => x.ModeratorId,
                        principalSchema: "dbo",
                        principalTable: "Players",
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
                    GroupName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                name: "PlayerCollections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BoardgameCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCollectionCreated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCollections_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerFavouriteBoardgames",
                schema: "dbo",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BoardgameName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFavouriteBoardgames", x => new { x.PlayerId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_PlayerFavouriteBoardgames_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerFavouriteBoardgames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerFriends",
                schema: "dbo",
                columns: table => new
                {
                    RequesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddresseeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AddresseeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FriendshipDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFriends", x => new { x.RequesterId, x.AddresseeId });
                    table.ForeignKey(
                        name: "FK_PlayerFriends_Players_AddresseeId",
                        column: x => x.AddresseeId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerFriends_Players_RequesterId",
                        column: x => x.RequesterId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPreferences",
                schema: "dbo",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BoardgameName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
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
                name: "PlayerRatings",
                schema: "dbo",
                columns: table => new
                {
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EloRating = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRatings", x => new { x.BoardgameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_PlayerRatings_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerRatings_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSchedules",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSchedules_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchParticipants",
                schema: "dbo",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchPlayerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchParticipants", x => new { x.MatchId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_MatchParticipants_Matches_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "dbo",
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchParticipants_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchResults",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MatchRuleSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppliedVictoryConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppliedAdditionMatchDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerScores = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchResults_MatchRules_MatchRuleSetId",
                        column: x => x.MatchRuleSetId,
                        principalSchema: "dbo",
                        principalTable: "MatchRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MatchResults_Players_WinnerId",
                        column: x => x.WinnerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TournamentMatches",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardgameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchProgress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchDate_Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    MatchDate_Started = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MatchDate_Ended = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    MatchNumber = table.Column<short>(type: "smallint", nullable: false),
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Boardgames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalSchema: "dbo",
                        principalTable: "Boardgames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentMatches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TournamentParticipants",
                schema: "dbo",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TournamentUserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentParticipants", x => new { x.TournamentId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_TournamentParticipants_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentParticipants_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyAvailabilities",
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
                    table.PrimaryKey("PK_DailyAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyAvailabilities_PlayerSchedules_PlayerScheduleId",
                        column: x => x.PlayerScheduleId,
                        principalSchema: "dbo",
                        principalTable: "PlayerSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentMatchParticipants",
                schema: "dbo",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchPlayerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentMatchParticipants", x => new { x.MatchId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_TournamentMatchParticipants_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "dbo",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentMatchParticipants_TournamentMatches_MatchId",
                        column: x => x.MatchId,
                        principalSchema: "dbo",
                        principalTable: "TournamentMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
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
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_DailyAvailabilities_DailyAvailabilityId",
                        column: x => x.DailyAvailabilityId,
                        principalSchema: "dbo",
                        principalTable: "DailyAvailabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_BoardgameModerators_ModeratorId",
                schema: "dbo",
                table: "BoardgameModerators",
                column: "ModeratorId");

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
                name: "IX_DailyAvailabilities_PlayerScheduleId",
                schema: "dbo",
                table: "DailyAvailabilities",
                column: "PlayerScheduleId");

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
                name: "IX_MatchParticipants_PlayerId",
                schema: "dbo",
                table: "MatchParticipants",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchId",
                schema: "dbo",
                table: "MatchResults",
                column: "MatchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchRuleSetId",
                schema: "dbo",
                table: "MatchResults",
                column: "MatchRuleSetId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_WinnerId",
                schema: "dbo",
                table: "MatchResults",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRules_BoardgameId",
                schema: "dbo",
                table: "MatchRules",
                column: "BoardgameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PlayerIndex",
                schema: "dbo",
                table: "PlayerCollections",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFavouriteBoardgames_BoardgameId",
                schema: "dbo",
                table: "PlayerFavouriteBoardgames",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "AddresseeNameIndex",
                schema: "dbo",
                table: "PlayerFriends",
                column: "AddresseeName");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFriends_AddresseeId",
                schema: "dbo",
                table: "PlayerFriends",
                column: "AddresseeId");

            migrationBuilder.CreateIndex(
                name: "RequesterNameIndex",
                schema: "dbo",
                table: "PlayerFriends",
                column: "RequesterName");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPreferences_BoardgameId",
                schema: "dbo",
                table: "PlayerPreferences",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRatings_PlayerId",
                schema: "dbo",
                table: "PlayerRatings",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "ApplicationUserIdIndex",
                schema: "dbo",
                table: "Players",
                column: "ApplicationUserId",
                unique: true);

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
                column: "PlayerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PlayerIndex",
                schema: "dbo",
                table: "PlayerSchedules",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_DailyAvailabilityId",
                schema: "dbo",
                table: "TimeSlots",
                column: "DailyAvailabilityId");

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
                name: "IX_TournamentMatchParticipants_PlayerId",
                schema: "dbo",
                table: "TournamentMatchParticipants",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentParticipants_PlayerId",
                schema: "dbo",
                table: "TournamentParticipants",
                column: "PlayerId");

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
                name: "BoardgameDomainTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameMechanicTags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameModerators",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GroupParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MatchParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MatchResults",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerCollections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerFavouriteBoardgames",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerFriends",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerPreferences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerRatings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TimeSlots",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentMatchParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentParticipants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameDomains",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BoardgameMechanics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Matches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MatchRules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DailyAvailabilities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentMatches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlayerSchedules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tournaments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Boardgames",
                schema: "dbo");
        }
    }
}
