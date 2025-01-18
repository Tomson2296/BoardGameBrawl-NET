using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameMechanics
{
    public class GetBoardgameMechanicsQuery : IRequest<ICollection<BoardgameMechanicDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
