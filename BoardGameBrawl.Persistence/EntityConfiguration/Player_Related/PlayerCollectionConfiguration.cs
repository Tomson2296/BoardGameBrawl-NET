using BoardGameBrawl.Domain.Entities.Player_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class PlayerCollectionConfiguration : IEntityTypeConfiguration<PlayerCollection>
    {
        public void Configure(EntityTypeBuilder<PlayerCollection> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Player)
                .WithOne(e => e.PlayerCollection)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.PlayerId)
                .HasDatabaseName("PlayerIndex")
                .IsUnique();

            entity.Property(e => e.BoardgameCollection)
                .HasConversion(
                     v => JsonConvert.SerializeObject(v),
                     v => JsonConvert.DeserializeObject<IList<int>>(v));

            entity.ToTable("UserCollections");
        }
    }
}