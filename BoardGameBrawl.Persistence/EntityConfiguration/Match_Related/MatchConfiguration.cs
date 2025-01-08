using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Match_Related
{
    internal class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.MatchProgress)
                .HasConversion<MatchProgressTypeConverter>()
                .IsRequired();

            entity.Property(e => e.Participants)
                .HasJsonConversion()
                .IsRequired();

            // Property Constraints
            entity.Property(e => e.MatchDate_Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            entity.Property(e => e.NumberOfPlayers)
                 .IsRequired();

            entity.ToTable("Matches");
        }
    }
}
