using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.RemoveSchedule
{
    public class RemoveScheduleCommand : IRequest<BaseCommandResponse>
    {
        public Guid PlayerId { get; set; }
    }
}
