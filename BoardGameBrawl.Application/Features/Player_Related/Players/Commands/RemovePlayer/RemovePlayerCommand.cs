#nullable disable
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.RemoveUser
{
    public class RemovePlayerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
