using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related
{
    [AutoMap(typeof(TimeSlot))]
    public class TimeSlotDTO
    {
        public int Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int DailyAvailabilityId { get; set; }
    }
}
