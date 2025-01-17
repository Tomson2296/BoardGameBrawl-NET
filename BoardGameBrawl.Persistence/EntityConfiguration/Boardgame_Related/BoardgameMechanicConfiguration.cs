using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameMechanicConfiguration : IEntityTypeConfiguration<BoardgameMechanic>
    {
        public void Configure(EntityTypeBuilder<BoardgameMechanic> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Mechanic)
                .HasMaxLength(256)
                .IsRequired();

            //entity.HasMany(e => e.BoardgameMechanicTags)
            //   .WithOne()
            //   .HasForeignKey(t => t.MechanicId)
            //   .IsRequired();

            entity.ToTable("BoardgameMechanics");
        }
    }
}
