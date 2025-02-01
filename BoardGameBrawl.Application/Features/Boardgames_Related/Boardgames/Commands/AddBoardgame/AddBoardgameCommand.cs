#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.AddBoardgame
{
    public class AddBoardgameCommand : IRequest<BaseCommandResponse>
    {
        public BoardgameDTO BoardgameDTO { get; set; }
    }
}
