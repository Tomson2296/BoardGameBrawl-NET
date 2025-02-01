using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetBatchOfPlayers
{
    public class GetBatchOfPlayersQuery : IRequest<ICollection<PlayerDTO>>
    {
        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
