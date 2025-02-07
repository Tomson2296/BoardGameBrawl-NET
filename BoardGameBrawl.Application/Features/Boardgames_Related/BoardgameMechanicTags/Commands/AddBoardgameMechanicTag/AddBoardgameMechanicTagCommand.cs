#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Commands.AddBoardgameMechanicTag
{
    public class AddBoardgameMechanicTagCommand : IRequest<BaseCommandResponse>
    {
        public BoardgameMechanicTagDTO BoardgameMechanicTagDTO { get; set; }
    }
}
