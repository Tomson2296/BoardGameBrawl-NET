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

            entity.Property(e => e.BoardgameName)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasOne(e => e.Mechanic)
                .WithMany(m => m.BoardgameMechanicTags)
                .HasForeignKey(e => e.MechanicId);

            entity.Property(e => e.MechanicName)
                .HasMaxLength(256)
                .IsRequired();

            entity.ToTable("BoardgameMechanicTags");
        }
    }
}
