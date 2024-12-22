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
    internal class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> entity)
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

            entity.ToTable("Matches");
        }
    }
}
