using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBoardgamesByCategory
{
    public class GetBoardgamesByCategoryQuery : IRequest<IList<NavBoardgameDTO>>
    {
        public Guid CategoryId { get; set; }
    }
}
