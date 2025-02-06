using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer.GetBatchOfPlayers
{
    public class GetBatchOfPlayersQuery : IRequest<IList<PlayerDTO>>
    {
        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
