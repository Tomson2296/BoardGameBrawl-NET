using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Match_Related
{
    internal class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> entity)
        {
            entity.HasMany(e => e.MatchParticipants)
                .WithOne(p => p.Match)
                .IsRequired();

            entity.ToTable("Matches");
        }
    }
}
