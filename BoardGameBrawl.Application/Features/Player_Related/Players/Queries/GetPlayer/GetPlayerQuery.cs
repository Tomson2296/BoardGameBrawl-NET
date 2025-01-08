using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer
{
    public class GetPlayerQuery : IRequest<PlayerDTO>
    {
        public Guid Id { get; set; }
    }
}
