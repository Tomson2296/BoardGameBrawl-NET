using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgamesByCategory
{
    public class GetBoardgamesByCategoryQuery : IRequest<ICollection<BoardgameDTO>>
    {
        public Guid CategoryId { get; set; }
    }
}
