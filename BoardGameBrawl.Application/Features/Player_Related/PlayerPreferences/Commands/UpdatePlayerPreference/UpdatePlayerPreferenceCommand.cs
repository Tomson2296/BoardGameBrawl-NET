#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Commands.UpdatePlayerPreference
{
    public class UpdatePlayerPreferenceCommand : IRequest<BaseCommandResponse>
    {
        public PlayerPreferenceDTO PlayerPreferenceDTO { get; set; }
    }
}
