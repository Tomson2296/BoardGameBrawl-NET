using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveTimeSlot
{
    public class RemoveTimeSlotCommand : IRequest<BaseCommandResponse>
    {
        public int TimeSlotId { get; set; }
    }
}
