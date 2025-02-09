using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameeByDomain
{
    public class GetBoardgamesByDomainQuery : IRequest<IList<NavBoardgameDTO>>
    {
        public Guid DomainId { get; set; }
    }
}
