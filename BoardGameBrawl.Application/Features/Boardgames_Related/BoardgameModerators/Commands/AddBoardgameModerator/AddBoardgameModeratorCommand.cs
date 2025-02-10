#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Commands.AddBoardgameModerator
{
    public class AddBoardgameModeratorCommand : IRequest<BaseCommandResponse>
    {
        public BoardgameModeratorDTO BoardgameModeratorDTO { get; set; }
    }
}
