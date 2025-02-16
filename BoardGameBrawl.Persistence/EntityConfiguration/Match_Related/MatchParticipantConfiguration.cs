using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Match_Related
{
    internal class MatchParticipantConfiguration : IEntityTypeConfiguration<MatchParticipant>
    {
        public void Configure(EntityTypeBuilder<MatchParticipant> entity)
        {
            entity.HasKey(e => new { e.MatchId, e.PlayerId });

            entity.HasOne(e => e.Match)
               .WithMany(m => m.MatchParticipants)
               .HasForeignKey(e => e.MatchId);

            entity.HasOne(e => e.Player)
                .WithMany(p => p.MatchesParticipating)
                .HasForeignKey(e => e.PlayerId);

            entity.Property(e => e.MatchPlayerRole)
                .HasConversion<MatchPlayerRoleTypeConverter>();

            entity.ToTable("MatchParticipants");
        }
    }
}
