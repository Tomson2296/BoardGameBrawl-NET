using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetDailyAvailabilityByDay
{
    public class GetDailyAvailabilityQuery : IRequest<DailyAvailabilityDTO>
    {
        public Guid PlayerId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
    }
}
