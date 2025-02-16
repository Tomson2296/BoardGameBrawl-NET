#nullable disable
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddDefaultTImeSlot
{
    public class AddDefaultTimeSlotCommand : IRequest<BaseCommandResponse>
    {
        public Guid playerId { get; set; }

        public DayOfWeek day { get; set; }

        public TimeSlotDTO timeSlot { get; set; }
    }
}
