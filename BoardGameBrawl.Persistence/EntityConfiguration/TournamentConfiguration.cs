using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.ValueConverters;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration
{
    internal class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TournamentName)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.TournnamentProgress)
                .HasConversion<TournamentProgressTypeConverter>()
                .IsRequired();

            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .IsRequired(false);

            entity.Property(e => e.TournamentParticipants)
                .HasJsonConversion<Dictionary<string, TournamentUserRoles>>()
                .IsRequired();

            entity.Property(e => e.TournamentDate_Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            entity.Property(e => e.MaxNumberOfPlayers)
                .IsRequired();

            // Relationships constrains 

            entity.HasMany(e => e.TournamentMatches)
                .WithOne()
                .HasForeignKey(t => t.TournamentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            entity.ToTable("Tournaments");
        }
    }
}
