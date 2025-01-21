using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerPreferenceByBoardgame
{
    public class GetPlayerPreferenceByBoardgameQuery : IRequest<PlayerPreferenceDTO>
    {
        public Guid PlayerId { get; set; }
        public Guid BoardgameId { get; set; }
    }
}
