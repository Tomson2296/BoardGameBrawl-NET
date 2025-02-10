#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.CheckIfBoardgameModeratorExists
{
    public class CheckIfBoardgameModeratorExistsQuery : IRequest<bool>
    {
        public Guid ModeratorId { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
