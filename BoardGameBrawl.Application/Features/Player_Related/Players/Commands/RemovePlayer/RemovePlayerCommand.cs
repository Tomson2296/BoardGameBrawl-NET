#nullable disable
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.RemoveUser
{
    public class RemovePlayerCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
