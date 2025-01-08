#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.UpdateBoardgame
{
    public class UpdateBoardgameCommand : IRequest<Unit>
    {
        public BoardgameDTO BoardgameDTO { get; set; }    
    }
}
