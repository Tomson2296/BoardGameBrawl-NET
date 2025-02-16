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
    internal class TournamentParticipantConfiguration : IEntityTypeConfiguration<TournamentParticipant>
    {
        public void Configure(EntityTypeBuilder<TournamentParticipant> entity)
        {
            entity.HasKey(e => new { e.TournamentId, e.PlayerId });

            // Relationship with Tournament
            entity.HasOne(e => e.Tournament)
                  .WithMany(t => t.TournamentParticipants)
                  .HasForeignKey(e => e.TournamentId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);

            // Relationship with Player
            entity.HasOne(e => e.Player)
                  .WithMany(p => p.TournamentParticipating) 
                  .HasForeignKey(e => e.PlayerId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade); 

            entity.Property(e => e.TournamentUserRole)
                 .HasConversion<TournamentPlayerRoleConverter>()
                 .IsRequired();

            entity.ToTable("TournamentParticipants");
        }
    }
}
