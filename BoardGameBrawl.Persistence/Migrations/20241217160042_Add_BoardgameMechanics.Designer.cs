﻿// <auto-generated />
using System;
using BoardGameBrawl.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameBrawl.Persistence.Migrations
{
    [DbContext(typeof(MainAppDBContext))]
    [Migration("20241217160042_Add_BoardgameMechanics")]
    partial class Add_BoardgameMechanics
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BGGUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserAvatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UserLastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.ToView("AppUser", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BGGId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFilePath")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<short>("PlayingTime")
                        .HasColumnType("smallint");

                    b.Property<string>("ThumbnailFilePath")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<short>("YearPublished")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("BGGId")
                        .IsUnique()
                        .HasDatabaseName("BGGIdIndex");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("BoardgameNameIndex")
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Boardgames", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BoardgameCategories", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameCategoryTag", b =>
                {
                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("BoardgameId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BoardgameCategoryTags", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameMechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

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

                    b.ToTable("BoardgameMechanics", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameMechanicTag", b =>
                {
                    b.Property<Guid>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("BoardgameId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("BoardgameMechanicTags", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupDescription")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<byte[]>("GroupMiniature")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.GroupParticipants", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupParticipants", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.MatchRule", b =>
                {
                    b.Property<Guid>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoardgameID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

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

                    b.HasIndex("BoardgameID");

                    b.ToTable("MatchRules", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.UserRatings", b =>
                {
                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BoardgameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDeleted")
                        .HasColumnType("bit");

                    b.Property<short?>("Rating")
                        .IsRequired()
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("RatingDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("AppUserId", "BoardgameId");

                    b.HasIndex("BoardgameId");

                    b.ToTable("UserRatings", "dbo");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameCategoryTag", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame", "Boardgame")
                        .WithMany("BoardgameCategoryTags")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.BoardgameCategory", "BoardgameCategory")
                        .WithMany("BoardgameCategoryTags")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("BoardgameCategory");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameMechanicTag", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame", "Boardgame")
                        .WithMany("BoardgameMechanicTags")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.BoardgameMechanic", "BoardgameMechanic")
                        .WithMany("BoardgameMechanicTags")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boardgame");

                    b.Navigation("BoardgameMechanic");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.GroupParticipants", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Group", "Group")
                        .WithMany("GroupParticipants")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.AppUser", "User")
                        .WithMany("GroupParticipants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.MatchRule", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame", null)
                        .WithMany("BoardgameRules")
                        .HasForeignKey("BoardgameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.UserRatings", b =>
                {
                    b.HasOne("BoardGameBrawl.Domain.Entities.AppUser", "AppUser")
                        .WithMany("UserRatings")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameBrawl.Domain.Entities.Boardgame", "Boardgame")
                        .WithMany("UserRatings")
                        .HasForeignKey("BoardgameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Boardgame");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("GroupParticipants");

                    b.Navigation("UserRatings");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Boardgame", b =>
                {
                    b.Navigation("BoardgameCategoryTags");

                    b.Navigation("BoardgameMechanicTags");

                    b.Navigation("BoardgameRules");

                    b.Navigation("UserRatings");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameCategory", b =>
                {
                    b.Navigation("BoardgameCategoryTags");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.BoardgameMechanic", b =>
                {
                    b.Navigation("BoardgameMechanicTags");
                });

            modelBuilder.Entity("BoardGameBrawl.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
