using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    public class BoardgameModeratorConfiguration : IEntityTypeConfiguration<BoardgameModerator>
    {
        public void Configure(EntityTypeBuilder<BoardgameModerator> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.ModeratorId });

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.BoardgameModerators)
                .HasForeignKey(e => e.BoardgameId);

            entity.Property(e => e.BoardgameName)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasOne(e => e.Moderator)
                .WithMany(m => m.BoardgameModerators)
                .HasForeignKey(e => e.ModeratorId);

            entity.Property(e => e.ModeratorName)
               .HasMaxLength(256)
               .IsRequired();

            entity.ToTable("BoardgameModerators");
        }
    }
}
