using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Value_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Match_Related
{
    internal class MatchRuleSetConfiguration : IEntityTypeConfiguration<MatchRuleSet>
    {
        public void Configure(EntityTypeBuilder<MatchRuleSet> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(r => r.VictoryConditions)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<VictoryConditions>(v, (JsonSerializerOptions?)null)
            )
            .HasColumnType("nvarchar(max)");

            entity.Property(r => r.AdditionalMatchDetails)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<AdditionalMatchDetails>(v, (JsonSerializerOptions?)null)
            )
            .HasColumnType("nvarchar(max)");

            entity.HasOne(e => e.Boardgame)
                .WithOne(b => b.BoardgameRuleSet)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("MatchRules");
        }
    }
}
