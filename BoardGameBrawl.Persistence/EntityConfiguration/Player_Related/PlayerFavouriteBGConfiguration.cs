using BoardGameBrawl.Domain.Entities.Player_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class PlayerFavouriteBGConfiguration : IEntityTypeConfiguration<PlayerFavouriteBG>
    {
        public void Configure(EntityTypeBuilder<PlayerFavouriteBG> entity)
        {
            // Composite primary key
            entity.HasKey(pf => new { pf.PlayerId, pf.BoardgameId });

            entity.HasOne(e => e.Player)
               .WithMany(e => e.PlayerFavouriteBGs)
               .HasForeignKey(e => e.PlayerId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.PlayerName)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasOne(e => e.Boardgame)
                .WithMany(e => e.PlayerFavouriteBGs)
                .HasForeignKey(e => e.BoardgameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.BoardgameName)
                .HasMaxLength(256)
                .IsRequired();

            entity.ToTable("PlayerFavouriteBoardgames");
        }
    }
}
