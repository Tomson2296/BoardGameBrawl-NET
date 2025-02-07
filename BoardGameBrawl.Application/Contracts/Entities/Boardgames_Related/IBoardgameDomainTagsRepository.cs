using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameDomainTagsRepository : IGenericRepository<BoardgameDomainTag>
    {
        Task<BoardgameDomainTag?> GetEntity(Guid boardgameId,
           Guid domainId,
           CancellationToken cancellationToken = default);

        Task<bool> Exists(Guid boardgameId,
          Guid domainId,
          CancellationToken cancellationToken = default);

    }
}
