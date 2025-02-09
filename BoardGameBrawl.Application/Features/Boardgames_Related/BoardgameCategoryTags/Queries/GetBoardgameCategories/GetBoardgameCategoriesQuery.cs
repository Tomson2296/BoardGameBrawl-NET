using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBoardgameCategories
{
    public class GetBoardgameCategoriesQuery : IRequest<IList<BoardgameCategoryDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
