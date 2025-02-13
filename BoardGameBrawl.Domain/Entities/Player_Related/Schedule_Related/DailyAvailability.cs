using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related
{
    public class DailyAvailability
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; } 

        public ICollection<TimeSlot>? TimeSlots { get; set; }

        public Guid PlayerScheduleId { get; set; }

        [ForeignKey(nameof(PlayerScheduleId))]
        public PlayerSchedule? PlayerSchedule { get; set; }

    }
}
