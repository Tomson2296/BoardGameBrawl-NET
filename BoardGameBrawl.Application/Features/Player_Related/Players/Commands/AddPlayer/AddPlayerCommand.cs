using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddPlayer
{
    public class AddPlayerCommand : IRequest
    {
        public AddPlayerDTO? AddPlayerDTO { get; set; }
    }
}
