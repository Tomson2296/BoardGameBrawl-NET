#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddPlayer
{
    public class AddPlayerCommand : IRequest<BaseCommandResponse>
    {
        public PlayerDTO PlayerDTO { get; set; }
    }
}
