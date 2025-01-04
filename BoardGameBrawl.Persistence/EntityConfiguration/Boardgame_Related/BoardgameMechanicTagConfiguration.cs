using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameMechanicTagConfigutaion : IEntityTypeConfiguration<BoardgameMechanicTag>
    {
        public void Configure(EntityTypeBuilder<BoardgameMechanicTag> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.MechanicId });

            entity.HasOne(e => e.Boardgame)
               .WithMany(b => b.BoardgameMechanicTags)
               .HasForeignKey(e => e.BoardgameId);

            entity.HasOne(e => e.BoardgameMechanic)
                .WithMany(m => m.BoardgameMechanicTags)
                .HasForeignKey(e => e.MechanicId);

            entity.ToTable("BoardgameMechanicTags");
        }
    }
}
