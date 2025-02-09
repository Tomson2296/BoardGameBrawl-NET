using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
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
        // custom methods //

        Task<bool> Exists(Guid boardgameId,
          Guid domainId,
          CancellationToken cancellationToken = default);


        // getter methods //

        Task<BoardgameDomainTag?> GetEntity(Guid boardgameId,
          Guid domainId,
          CancellationToken cancellationToken = default);

        Task<IList<BoardgameDomainDTO>> GetBoardgameDomainsByBoardgameIdAsync(Guid boardgameId,
           CancellationToken cancellationToken = default);


        Task<IList<NavBoardgameDTO>> GetBoardgamesByDomainAsync (Guid domainId,
            CancellationToken cancellationToken = default);

        Task<IList<NavBoardgameDTO>> GetBatchOfBoardgamesByDomainAsync(Guid domainId,
            int size, int skip = 0, CancellationToken cancellationToken = default);
    }
}
