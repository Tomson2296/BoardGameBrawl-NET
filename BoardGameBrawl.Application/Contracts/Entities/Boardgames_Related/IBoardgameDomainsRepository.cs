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
    public interface IBoardgameDomainsRepository : IGenericRepository<BoardgameDomain> , IAuditableRepository<BoardgameDomain>
    {
        // refined methods //

        Task<bool> Exists(BoardgameDomain boardgameDomain,
            CancellationToken cancellationToken = default);

        // getter methods //

        Task<Guid> GetBoardgameDomainIdAsync(string? domainName,
           CancellationToken cancellationToken = default);

        Task<BoardgameDomainDTO?> GetBoardgameDomainByNameAsync(string? domainName,
            CancellationToken cancellationToken = default);

        Task<string?> GetDomainNameAsync(BoardgameDomain domain,
           CancellationToken cancellationToken = default);

        // basic fields setter methods //

        Task SetDomainNameAsync(BoardgameDomain domain,
            string? domainName, CancellationToken cancellationToken = default);
    }
}
