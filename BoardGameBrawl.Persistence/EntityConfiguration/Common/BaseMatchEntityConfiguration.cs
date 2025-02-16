using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Common
{
    internal class BaseMatchEntityConfiguration : IEntityTypeConfiguration<BaseMatchEntity>
    {
        public void Configure(EntityTypeBuilder<BaseMatchEntity> entity)
        {
            entity.UseTpcMappingStrategy();

            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.Matches)
                .HasForeignKey(e => e.BoardgameId)
                .IsRequired();

            entity.Property(e => e.MatchProgress)
                .HasConversion<MatchProgressTypeConverter>()
                .IsRequired();

            // Property Constraints
            entity.Property(e => e.MatchDate_Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            entity.Property(e => e.MatchDate_Started)
                .IsRequired(false);

            entity.Property(e => e.MatchDate_Ended)
                .IsRequired(false);

            entity.Property(e => e.NumberOfPlayers)
                .IsRequired();

            entity.HasOne(e => e.MatchResult)
                .WithOne(r => r.Match)
                .HasForeignKey<MatchResult>(mr => mr.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
