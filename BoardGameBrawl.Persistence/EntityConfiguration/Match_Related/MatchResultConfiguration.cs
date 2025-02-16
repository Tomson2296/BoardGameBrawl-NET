#nullable disable
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Value_Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Match_Related
{
    internal class MatchResultConfiguration : IEntityTypeConfiguration<MatchResult>
    {
        public void Configure(EntityTypeBuilder<MatchResult> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Winner)
                .WithMany(p => p.MatchesWinning)
                .HasForeignKey(e => e.WinnerId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.MatchRuleSet)
                .WithMany(mr => mr.MatchesWithRuleSetUsed)
                .HasForeignKey(e => e.MatchRuleSetId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(mr => mr.AppliedVictoryConditions)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<VictoryConditions>(v, (JsonSerializerOptions)null)
                )
                .HasColumnType("nvarchar(max)");

            entity.Property(mr => mr.AppliedAdditionMatchDetails)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<AdditionalMatchDetails>(v, (JsonSerializerOptions)null)
                )
                .HasColumnType("nvarchar(max)");

            entity.Property(mr => mr.PlayerScores)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<PlayerResult>>(v, (JsonSerializerOptions)null),
                     new ValueComparer<List<PlayerResult>>(
                    // Compares two lists for equality by their JSON representation
                    (l1, l2) => JsonSerializer.Serialize(l1, (JsonSerializerOptions)null)
                                 == JsonSerializer.Serialize(l2, (JsonSerializerOptions)null),

                    // Generates a hash code based on the JSON string
                    l => JsonSerializer.Serialize(l, (JsonSerializerOptions)null).GetHashCode(),

                    // Creates a snapshot by serializing and deserializing the list
                    l => JsonSerializer.Deserialize<List<PlayerResult>>(
                        JsonSerializer.Serialize(l, (JsonSerializerOptions)null), (JsonSerializerOptions)null)
                   ))
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.Summary)
                .HasMaxLength(2048)
                .IsRequired(false);

            entity.ToTable("MatchResults");
        }
    }
}
