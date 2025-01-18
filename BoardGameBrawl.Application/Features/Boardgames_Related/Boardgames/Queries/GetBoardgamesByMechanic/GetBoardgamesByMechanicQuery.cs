using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgamesByMechanic
{
    public class GetBoardgamesByMechanicQuery : IRequest<ICollection<BoardgameDTO>>
    {
        public Guid MechanicId { get; set; }
    }
}
