using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId
{
    public class GetPlayerByAppUserIdQuery : IRequest<PlayerDTO>
    {
        public Guid ApplicationUserId { get; set; }
    }
}
