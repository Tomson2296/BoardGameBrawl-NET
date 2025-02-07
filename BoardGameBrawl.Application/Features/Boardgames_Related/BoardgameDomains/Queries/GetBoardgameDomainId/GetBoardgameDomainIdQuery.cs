#nullable disable
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Queries.GetBoardgameDomainId
{
    public class GetBoardgameDomainIdQuery : IRequest<Guid>
    {
        public string DomainName { get; set; }
    }
}
