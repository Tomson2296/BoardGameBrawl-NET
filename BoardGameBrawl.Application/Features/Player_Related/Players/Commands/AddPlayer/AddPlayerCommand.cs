using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddUser
{
    public class AddPlayerCommand : IRequest<BaseCommandResponse>
    {
        public AddPlayerDTO? AddPlayerDTO { get; set; }
    }
}
