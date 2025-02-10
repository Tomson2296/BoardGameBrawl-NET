using BoardGameBrawl.Domain.Entities.Player_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class PlayerPreferenceConfiguration : IEntityTypeConfiguration<PlayerPreference>
    {
        public void Configure(EntityTypeBuilder<PlayerPreference> entity)
        {
            entity.HasKey(e => new { e.PlayerId, e.BoardgameId });

            entity.HasOne(e => e.Player)
               .WithMany(u => u.PlayerRatings)
               .HasForeignKey(e => e.PlayerId);

            entity.Property(e => e.PlayerName)
               .HasMaxLength(256)
               .IsRequired();

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.UserRatings)
                .HasForeignKey(e => e.BoardgameId);

            entity.Property(e => e.BoardgameName)
               .HasMaxLength(256)
               .IsRequired();

            entity.Property(e => e.Rating)
               .IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("PlayerPreferences");
        }
    }
}
