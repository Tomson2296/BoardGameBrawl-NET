using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related.Schedule_Related
{
    internal class PlayerScheduleConfiguration : IEntityTypeConfiguration<PlayerSchedule>
    {
        public void Configure(EntityTypeBuilder<PlayerSchedule> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Player)
                .WithOne(e => e.PlayerSchedule)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.PlayerId)
                .HasDatabaseName("PlayerIndex")
                .IsUnique();

            entity.HasMany(e => e.DailyAvailabilities)
                .WithOne(e => e.PlayerSchedule)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.ToTable("PlayerSchedules");
        }
    }
}
