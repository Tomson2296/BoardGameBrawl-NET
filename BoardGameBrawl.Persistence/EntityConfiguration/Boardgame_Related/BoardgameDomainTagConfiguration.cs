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
    internal class BoardgameDomainTagConfiguration : IEntityTypeConfiguration<BoardgameDomainTag>
    {
        public void Configure(EntityTypeBuilder<BoardgameDomainTag> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.DomainId });

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.BoardgameDomainTags)
                .HasForeignKey(e => e.BoardgameId);

            entity.HasOne(e => e.Domain)
                .WithMany(c => c.BoardgameDomainTags)
                .HasForeignKey(e => e.DomainId);

            entity.Property(e => e.BoardgameName)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.DomainName)
                .HasMaxLength(256)
                .IsRequired();

            entity.ToTable("BoardgameDomainTags");
        }
    }
}
