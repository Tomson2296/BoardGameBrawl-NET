using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameCategoryTagConfiguration : IEntityTypeConfiguration<BoardgameCategoryTag>
    {
        public void Configure(EntityTypeBuilder<BoardgameCategoryTag> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.CategoryId });

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.BoardgameCategoryTags)
                .HasForeignKey(e => e.BoardgameId);

            entity.HasOne(e => e.BoardgameCategory)
                .WithMany(c => c.BoardgameCategoryTags)
                .HasForeignKey(e => e.CategoryId);

            entity.ToTable("BoardgameCategoryTags");
        }
    }
}
