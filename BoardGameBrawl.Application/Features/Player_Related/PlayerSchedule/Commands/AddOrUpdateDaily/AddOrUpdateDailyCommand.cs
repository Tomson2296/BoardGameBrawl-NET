#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateDaily
{
    public class AddOrUpdateDailyCommand : IRequest<BaseCommandResponse>
    {
        public Guid playerId { get; set; }

        public DailyAvailabilityDTO DailyAvailabilityDTO { get; set; }
    }
}
