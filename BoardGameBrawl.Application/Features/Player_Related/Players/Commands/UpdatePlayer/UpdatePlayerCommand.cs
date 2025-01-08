#nullable disable
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.UpdateUser
{
    public class UpdatePlayerCommand : IRequest<Unit>
    {
        public PlayerDTO PlayerDTO { get; set; }
    }
}
