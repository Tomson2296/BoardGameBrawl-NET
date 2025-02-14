using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.ClearDay
{
    public class ClearDayCommand : IRequest<Unit>
    {
        public Guid playerId { get; set; }

        public DayOfWeek day { get; set; }
    }
}
