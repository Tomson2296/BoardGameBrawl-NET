﻿// <auto-generated />
using System;
using BoardGameBrawl.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations.MainApp
{
    [DbContext(typeof(MainAppDBContext))]
    partial class MainAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BGGId")
                        .HasColumnType("int");

                    b.Property<float>("BGGWeight")
                        .HasColumnType("real");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("MaxPlayers")
                        .HasColumnType("tinyint");

                    b.Property<short>("MaximumPlayingTime")
                        .HasColumnType("smallint");

                    b.Property<byte>("MinPlayers")
                        .HasColumnType("tinyint");

                    b.Property<short>("MinimumPlayingTime")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<short>("PlayingTime")
                        .HasColumnType("smallint");

                    b.Property<short>("YearPublished")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("BGGId")
                        .IsUnique()
                        .HasDatabaseName("BGGIdIndex");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("BoardgameNameIndex");

                    b.ToTable("Boardgames", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Category")
                        .IsUnique()
                        .HasDatabaseName("BoardgameCategoryIndex");

                    b.ToTable("BoardgameCategories", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameCategoryTag", b =>
                {
                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BoardgameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BoardgameCategoryTags", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameMechanic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mechanic")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Mechanic")
                        .IsUnique()
                        .HasDatabaseName("BoardgameMechanicIndex");

                    b.ToTable("BoardgameMechanics", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameMechanicTag", b =>
                {
                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MechanicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BoardgameId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("BoardgameMechanicTags", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Group_Related.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupDescription")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<byte[]>("GroupMiniature")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupName")
                        .IsUnique()
                        .HasDatabaseName("GroupNameIndex");

                    b.ToTable("Groups", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Group_Related.GroupParticipant", b =>
                {
                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.HasKey("GroupId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GroupParticipants", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Match_Related.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BoardgameId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MatchDate_Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("MatchDate_Ended")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MatchDate_Started")
                        .HasColumnType("datetime2");

                    b.Property<string>("MatchProgress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Participants")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardgameId");

                    b.ToTable("Matches", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Match_Related.MatchRule", b =>
                {
                    b.Property<Guid>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RuleDecider")
                        .HasColumnType("bit");

                    b.Property<string>("RuleDescription")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("RuleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RuleId");

                    b.HasIndex("BoardgameId");

                    b.ToTable("MatchRules", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BGGUsername")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("UserAvatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserDescription")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasDatabaseName("ApplicationUserIdIndex");

                    b.HasIndex("BGGUsername")
                        .IsUnique()
                        .HasDatabaseName("BGGUsernameIndex")
                        .HasFilter("[BGGUsername] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("UserEmailIndex");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Players", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BoardgameCollection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique()
                        .HasDatabaseName("PlayerIndex");

                    b.ToTable("PlayerCollections", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerFavouriteBG", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayerId", "BoardgameId");

                    b.HasIndex("BoardgameId");

                    b.ToTable("PlayerFavouriteBoardgames", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerFriend", b =>
                {
                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddresseeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FriendshipDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequesterId", "AddresseeId");

                    b.HasIndex("AddresseeId");

                    b.ToTable("PlayerFriends", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerRreference", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.HasKey("PlayerId", "BoardgameId");

                    b.HasIndex("BoardgameId");

                    b.ToTable("PlayerPreferences", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Tournament_Related.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("MaxNumberOfPlayers")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("TournamentDate_Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("TournamentDate_Ended")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TournamentDate_Started")
                        .HasColumnType("datetime2");

                    b.Property<string>("TournamentName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TournamentParticipants")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TournnamentProgress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardgameId");

                    b.ToTable("Tournaments", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Tournament_Related.TournamentMatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BoardgameId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MatchDate_Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("MatchDate_Ended")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MatchDate_Started")
                        .HasColumnType("datetime2");

                    b.Property<short>("MatchNumber")
                        .HasColumnType("smallint");

                    b.Property<string>("MatchProgress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Participants")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TournamentId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BoardgameId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentMatches", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameCategoryTag", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", "Boardgame")
                        .WithMany("BoardgameCategoryTags")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameCategory", "BoardgameCategory")
                        .WithMany("BoardgameCategoryTags")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("BoardgameCategory");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameMechanicTag", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", "Boardgame")
                        .WithMany("BoardgameMechanicTags")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameMechanic", "BoardgameMechanic")
                        .WithMany("BoardgameMechanicTags")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("BoardgameMechanic");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Group_Related.GroupParticipant", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Group_Related.Group", "Group")
                        .WithMany("GroupParticipants")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Player_Related.Player", "Player")
                        .WithMany("GroupParticipants")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Match_Related.Match", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", null)
                        .WithMany("Matches")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Match_Related.MatchRule", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", null)
                        .WithMany("BoardgameRules")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerCollection", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Player_Related.Player", "Player")
                        .WithOne("PlayerCollection")
                        .HasForeignKey("BoardGameBrawl.Domain.Entities.Player_Related.PlayerCollection", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerFavouriteBG", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", "Boardgame")
                        .WithMany("PlayerFavouriteBGs")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Player_Related.Player", "Player")
                        .WithMany("PlayerFavouriteBGs")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerFriend", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Player_Related.Player", "Addressee")
                        .WithMany("FriendOfFriendships")
                        .HasForeignKey("AddresseeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Player_Related.Player", "Requester")
                        .WithMany("Friendships")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Addressee");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.PlayerRreference", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", "Boardgame")
                        .WithMany("UserRatings")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Player_Related.Player", "Player")
                        .WithMany("PlayerRatings")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Tournament_Related.Tournament", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", null)
                        .WithMany("Tournaments")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Tournament_Related.TournamentMatch", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", null)
                        .WithMany("TournamentMatches")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Tournament_Related.Tournament", null)
                        .WithMany("TournamentMatches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.Boardgame", b =>
                {
                    b.Navigation("BoardgameCategoryTags");

                    b.Navigation("BoardgameMechanicTags");

                    b.Navigation("BoardgameRules");

                    b.Navigation("Matches");

                    b.Navigation("PlayerFavouriteBGs");

                    b.Navigation("TournamentMatches");

                    b.Navigation("Tournaments");

                    b.Navigation("UserRatings");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameCategory", b =>
                {
                    b.Navigation("BoardgameCategoryTags");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame_Related.BoardgameMechanic", b =>
                {
                    b.Navigation("BoardgameMechanicTags");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Group_Related.Group", b =>
                {
                    b.Navigation("GroupParticipants");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Player_Related.Player", b =>
                {
                    b.Navigation("FriendOfFriendships");

                    b.Navigation("Friendships");

                    b.Navigation("GroupParticipants");

                    b.Navigation("PlayerCollection");

                    b.Navigation("PlayerFavouriteBGs");

                    b.Navigation("PlayerRatings");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Tournament_Related.Tournament", b =>
                {
                    b.Navigation("TournamentMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
