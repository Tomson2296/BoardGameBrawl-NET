using BoardGameBrawl.Domain.Entities.Tournament_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Tournament_Related
{
    internal class TournamentMatchParticipantConfiguration : IEntityTypeConfiguration<TournamentMatchParticipant>
    {
        public void Configure(EntityTypeBuilder<TournamentMatchParticipant> entity)
        {
            entity.HasKey(e => new { e.MatchId, e.PlayerId });

            entity.HasOne(e => e.Match)
               .WithMany(m => m.TournamentMatchParticipants)
               .HasForeignKey(e => e.MatchId);

            entity.HasOne(e => e.Player)
                .WithMany(p => p.TournamentMatchesParticipating)
                .HasForeignKey(e => e.PlayerId);

            entity.Property(e => e.MatchPlayerRole)
                .HasConversion<MatchPlayerRoleTypeConverter>();

            entity.ToTable("TournamentMatchParticipants");
        }
    }
}
