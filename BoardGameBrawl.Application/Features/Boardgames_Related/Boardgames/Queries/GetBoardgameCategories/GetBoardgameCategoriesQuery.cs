using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameCategories
{
    public class GetBoardgameCategoriesQuery : IRequest<ICollection<BoardgameCategoryDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
