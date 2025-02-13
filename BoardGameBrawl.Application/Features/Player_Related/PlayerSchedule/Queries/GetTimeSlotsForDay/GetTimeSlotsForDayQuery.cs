using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetTimeSlotsForDay
{
    public class GetTimeSlotsForDayQuery : IRequest<IEnumerable<TimeSlotDTO>>
    {
        public Guid PlayerId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
    }
}
