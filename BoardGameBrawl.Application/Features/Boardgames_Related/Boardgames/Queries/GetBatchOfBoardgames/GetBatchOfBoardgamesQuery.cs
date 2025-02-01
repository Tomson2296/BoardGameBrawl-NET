using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBatchOfBoardgames
{
    public class GetBatchOfBoardgamesQuery : IRequest<ICollection<BoardgameDTO>>
    {
        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
