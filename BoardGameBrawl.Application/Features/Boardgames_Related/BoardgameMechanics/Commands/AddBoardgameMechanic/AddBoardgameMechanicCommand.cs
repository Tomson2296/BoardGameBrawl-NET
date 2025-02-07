#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Commands.AddBoardgameMechanic
{
    public class AddBoardgameMechanicCommand : IRequest<BaseCommandResponse>
    {
        public BoardgameMechanicDTO BoardgameMechanicDTO { get; set; }
    }
}
