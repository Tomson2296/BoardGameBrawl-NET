using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgame
{
    public class GetBoardgameQuery : IRequest<BoardgameDTO>
    {
        public Guid Id { get; set; }
    }
}
