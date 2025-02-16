using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameConfiguration : IEntityTypeConfiguration<Boardgame>
    {
        public void Configure(EntityTypeBuilder<Boardgame> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasIndex(e => e.Name)
                .HasDatabaseName("BoardgameNameIndex")
                .IsUnique();

            entity.HasIndex(e => e.BGGId)
                .HasDatabaseName("BGGIdIndex")
                .IsUnique();

            entity.Property(e => e.Image)
                .HasColumnType("varbinary(max)")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(4096)
                .IsRequired();

            // Each Boardgame have one ruleset correlated with boardgame

            entity.HasOne(e => e.BoardgameRuleSet)
                .WithOne()
                .HasForeignKey<MatchRuleSet>(rs => rs.BoardgameId)
                .OnDelete(DeleteBehavior.Cascade);

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("Boardgames");
        }
    }
}
