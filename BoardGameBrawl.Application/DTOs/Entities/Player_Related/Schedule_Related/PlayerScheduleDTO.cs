#nullable disable
using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related
{
    [AutoMap(typeof(PlayerSchedule))]
    public class PlayerScheduleDTO
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public ICollection<DailyAvailabilityDTO> DailyAvailabilities { get; set; }
    }
}
