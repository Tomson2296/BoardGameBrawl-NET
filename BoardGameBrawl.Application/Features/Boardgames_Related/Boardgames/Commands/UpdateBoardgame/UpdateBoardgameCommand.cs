#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.UpdateBoardgame
{
    public class UpdateBoardgameCommand : IRequest<Unit>
    {
        public BoardgameDTO BoardgameDTO { get; set; }    
    }
}
