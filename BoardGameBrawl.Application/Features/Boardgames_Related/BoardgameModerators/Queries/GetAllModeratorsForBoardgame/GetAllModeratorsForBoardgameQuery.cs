using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.GetAllModeratorsForBoardgame
{
    public class GetAllModeratorsForBoardgameQuery : IRequest<IList<NavPlayerDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
