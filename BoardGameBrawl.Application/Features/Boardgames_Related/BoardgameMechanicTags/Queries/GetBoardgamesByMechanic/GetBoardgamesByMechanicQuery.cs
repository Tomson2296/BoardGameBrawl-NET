using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBoardgamesByMechanic
{
    public class GetBoardgamesByMechanicQuery : IRequest<IList<NavBoardgameDTO>>
    {
        public Guid MechanicId { get; set; }
    }
}
