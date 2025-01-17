using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameConfiguration : IEntityTypeConfiguration<Boardgame>
    {
        public void Configure(EntityTypeBuilder<Boardgame> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasIndex(e => e.Name)
                .HasDatabaseName("BoardgameNameIndex")
                .IsUnique();

            entity.HasIndex(e => e.BGGId)
                .HasDatabaseName("BGGIdIndex")
                .IsUnique();

            entity.Property(e => e.Image)
                .HasColumnType("varbinary(max)")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(4098)
                .IsRequired();

            // Each Boardgame have multiple rules associated with them

            entity.HasMany(e => e.BoardgameRules)
                .WithOne()
                .HasForeignKey(t => t.BoardgameId)
                .IsRequired();

            // Each Boardgame may be played in several different matches 

            entity.HasMany(e => e.Matches)
                .WithOne()
                .HasForeignKey(t => t.BoardgameId)
                .IsRequired();

            // Each Boardgame may be played in several different tournaments

            entity.HasMany(e => e.Tournaments)
                .WithOne()
                .HasForeignKey(t => t.BoardgameId)
                .IsRequired();

            // Each Boardgame may be played in several different tournament matches 

            entity.HasMany(e => e.TournamentMatches)
                .WithOne()
                .HasForeignKey(t => t.BoardgameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Configure many-to-many relationship with BoardgameCategories using linked table BoardgameCategoryTags

            //entity.HasMany(e => e.BoardgameCategoryTags)
            //    .WithOne()
            //    .HasForeignKey(t => t.BoardgameId)
            //    .IsRequired();

            // Configure many-to-many relationship with BoardgameMechanics using linked table BoardgamMechanicTags

            //entity.HasMany(e => e.BoardgameMechanicTags)
            //   .WithOne()
            //   .HasForeignKey(t => t.BoardgameId)
            //   .IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("Boardgames");
        }
    }
}
