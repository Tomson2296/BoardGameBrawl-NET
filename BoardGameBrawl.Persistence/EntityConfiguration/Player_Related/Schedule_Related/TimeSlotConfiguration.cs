using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related.Schedule_Related
{
    internal class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.DailyAvailability)
                .WithMany(e => e.TimeSlots)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.ToTable("TimeSlots");
        }
    }
}
