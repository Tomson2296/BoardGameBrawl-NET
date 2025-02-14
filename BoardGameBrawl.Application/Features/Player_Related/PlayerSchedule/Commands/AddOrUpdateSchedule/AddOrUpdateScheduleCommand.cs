#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Commands.AddOrUpdateSchedule
{
    public class AddOrUpdateScheduleCommand : IRequest<BaseCommandResponse>
    {
        public PlayerScheduleDTO PlayerScheduleDTO { get; set; }
    }
}
