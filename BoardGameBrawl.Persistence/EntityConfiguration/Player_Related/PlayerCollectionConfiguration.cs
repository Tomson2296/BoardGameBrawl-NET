#nullable disable
using BoardGameBrawl.Domain.Entities.Player_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                    v => JsonConvert.DeserializeObject<IList<int>>(v),
                    new ValueComparer<IList<int>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

            entity.ToTable("PlayerCollections");
        }
    }
}