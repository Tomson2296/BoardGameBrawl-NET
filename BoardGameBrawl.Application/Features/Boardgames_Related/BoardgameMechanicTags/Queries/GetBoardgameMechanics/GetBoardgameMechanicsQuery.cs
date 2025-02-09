using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBoardgameMechanics
{
    public class GetBoardgameMechanicsQuery : IRequest<IList<BoardgameMechanicDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
