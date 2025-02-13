using AutoMapper;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related
{
    [AutoMap(typeof(DailyAvailability))]
    public class DailyAvailabilityDTO
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public ICollection<TimeSlotDTO>? TimeSlots { get; set; }
    }
}
