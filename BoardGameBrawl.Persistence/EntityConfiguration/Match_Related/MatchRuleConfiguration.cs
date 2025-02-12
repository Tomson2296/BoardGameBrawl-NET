using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Match_Related
{
    internal class MatchRuleConfiguration : IEntityTypeConfiguration<MatchRule>
    {
        public void Configure(EntityTypeBuilder<MatchRule> entity)
        {
            entity.HasKey(e => e.RuleId);

            entity.Property(e => e.RuleDescription)
                .HasMaxLength(512)
                .IsRequired();

            entity.Property(e => e.RuleDecider)
                .IsRequired();

            entity.Property(e => e.RuleType)
                .HasConversion<MatchRuleTypeConverter>()
                .IsRequired();

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.BoardgameRules)
                .IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("MatchRules");
        }
    }
}
