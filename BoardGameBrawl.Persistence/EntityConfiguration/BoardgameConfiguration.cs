using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration
{
    internal class BoardgameConfiguration : IEntityTypeConfiguration<Boardgame>
    {
        public void Configure(EntityTypeBuilder<Boardgame> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.HasIndex(e => e.Name).HasDatabaseName("BoardgameNameIndex").IsUnique();

            entity.HasIndex(e => e.BGGId).HasDatabaseName("BGGIdIndex").IsUnique();

            entity.Property(e => e.ThumbnailFilePath).HasMaxLength(512);

            entity.Property(e => e.ImageFilePath).HasMaxLength(512);

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

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("Boardgames");
        }
    }
}
