#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Queries.CheckIfBoardgameDomainExists
{
    public class CheckIfBoardgameDomainExistsQuery : IRequest<bool>
    {
        public BoardgameDomainDTO BoardgameDomainDTO { get; set; }
    }
}
