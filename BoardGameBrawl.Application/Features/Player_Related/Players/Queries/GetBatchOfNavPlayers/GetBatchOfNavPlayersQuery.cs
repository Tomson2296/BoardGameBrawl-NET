using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetBatchOfNavPlayers
{
    public class GetBatchOfNavPlayersQuery : IRequest<IList<NavPlayerDTO>>
    {
        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
