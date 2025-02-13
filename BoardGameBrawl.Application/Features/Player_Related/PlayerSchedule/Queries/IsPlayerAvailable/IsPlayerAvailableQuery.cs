using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.IsPlayerAvailable
{
    public class IsPlayerAvailableQuery : IRequest<bool>
    {
        public Guid PlayerId { get; set; }

        public DayOfWeek day { get; set; }

        public TimeSpan startTime { get; set; }

        public TimeSpan endTime { get; set; }
    }
}
