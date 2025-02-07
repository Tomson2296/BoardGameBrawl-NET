#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.CheckIfBoardgameMechanicExists
{
    public class CheckIfBoardgameMechanicExistsQuery : IRequest<bool>
    {
        public BoardgameMechanicDTO BoardgameMechanicDTO { get; set; }
    }
}
