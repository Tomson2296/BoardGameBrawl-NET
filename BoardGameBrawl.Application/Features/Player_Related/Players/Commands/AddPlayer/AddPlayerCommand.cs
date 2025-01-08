using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddUser
{
    public class AddPlayerCommand : IRequest
    {
        public AddPlayerDTO? AddPlayerDTO { get; set; }
    }
}
