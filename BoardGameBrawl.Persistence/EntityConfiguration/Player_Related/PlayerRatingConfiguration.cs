using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class PlayerRatingConfiguration : IEntityTypeConfiguration<PlayerRating>
    {
        public void Configure(EntityTypeBuilder<PlayerRating> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.PlayerId });

            entity.HasOne(e => e.Boardgame)
              .WithMany(b => b.PlayerEloRatingsInGame)
              .HasForeignKey(e => e.BoardgameId);

            entity.HasOne(e => e.Player)
                .WithMany(p => p.PlayerEloRatings)
                .HasForeignKey(e => e.PlayerId);

            entity.Property(e => e.EloRating)
                .IsRequired();

            entity.ToTable("PlayerRatings");
        }
    }
}
