using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Tournament_Related;
using BoardGameBrawl.Persistence.Extensions;
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
    internal class TournamentMatchConfiguration : IEntityTypeConfiguration<TournamentMatch>
    {
        public void Configure(EntityTypeBuilder<TournamentMatch> entity)
        {
            entity.HasMany(e => e.TournamentMatchParticipants)
                .WithOne(p => p.Match)
                .IsRequired();

            entity.Property(e => e.MatchNumber)
                  .IsRequired();

            // Relationship with Tournament (principal)
            entity.HasOne(e => e.Tournament)
                  .WithMany(t => t.TournamentMatches)
                  .HasForeignKey(e => e.TournamentId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.ToTable("TournamentMatches");
        }
    }
}
