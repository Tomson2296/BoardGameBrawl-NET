using BoardGameBrawl.Persistence.ValueConverters;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGameBrawl.Domain.Entities.Tournament_Related;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Tournament_Related
{
    internal class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TournamentName)
                .HasMaxLength(256); 

            entity.Property(e => e.Description)
                .HasMaxLength(1024); 

            entity.Property(e => e.TournnamentProgress)
                .IsRequired();

            // Date properties
            entity.Property(e => e.TournamentDate_Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(); 

            entity.Property(e => e.TournamentDate_Started)
                .IsRequired(false);

            entity.Property(e => e.TournamentDate_Ended)
                .IsRequired(false);

            entity.Property(e => e.MaxNumberOfPlayers)
                .IsRequired();

            entity.HasOne(e => e.Boardgame)
                  .WithMany(b => b.Tournaments) 
                  .HasForeignKey(e => e.BoardgameId)
                  .IsRequired();

            // One-to-many with TournamentParticipants
            entity.HasMany(e => e.TournamentParticipants)
                  .WithOne(tp => tp.Tournament)
                  .HasForeignKey(tp => tp.TournamentId)
                  .OnDelete(DeleteBehavior.Cascade);

            // One-to-many with TournamentMatches
            entity.HasMany(e => e.TournamentMatches)
                  .WithOne(tm => tm.Tournament)
                  .HasForeignKey(tm => tm.TournamentId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.ToTable("Tournaments");
        }
    }
}
