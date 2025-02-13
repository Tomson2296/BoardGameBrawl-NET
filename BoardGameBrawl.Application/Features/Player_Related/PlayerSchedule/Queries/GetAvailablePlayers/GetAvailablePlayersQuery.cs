using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.GetAvailablePlayers
{
    public class GetAvailablePlayersQuery : IRequest<IEnumerable<NavPlayerDTO>>
    {
        public DayOfWeek day { get; set; }

        public TimeSpan startTime { get; set; }

        public TimeSpan endTime { get; set; }
    }
}
