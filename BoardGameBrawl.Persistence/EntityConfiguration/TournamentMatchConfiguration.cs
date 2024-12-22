using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration
{
    internal class TournamentMatchConfiguration : IEntityTypeConfiguration<TournamentMatch>
    {
        public void Configure(EntityTypeBuilder<TournamentMatch> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.MatchProgress)
                .HasConversion<MatchProgressTypeConverter>()
                .IsRequired();

            entity.Property(e => e.Participants)
                .HasJsonConversion<Dictionary<string, MatchUserRoles>>()
                .IsRequired();

            // Property Constraints
            entity.Property(e => e.MatchDate_Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            entity.Property(e => e.NumberOfPlayers)
                .IsRequired();

            entity.Property(e => e.MatchNumber)
                .IsRequired();

            entity.ToTable("TournamentMatches");
        }
    }
}
