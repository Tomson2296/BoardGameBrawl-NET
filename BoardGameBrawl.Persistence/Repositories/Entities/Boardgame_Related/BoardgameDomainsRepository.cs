using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameDomainsRepository : GenericRepository<BoardgameDomain>, IBoardgameDomainsRepository
    {
        public BoardgameDomainsRepository(MainAppDBContext context) : base(context)
        {

        }

        public async Task<bool> Exists(BoardgameDomain boardgameDomain,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameDomain);

            // Check ChangeTracker if entity exists in waiting list to be added

            bool isTracked = Context.ChangeTracker
            .Entries<BoardgameDomain>()
            .Any(e => e.Entity.Domain == boardgameDomain.Domain);

            if (isTracked)
            {
                return true;
            }
            else
            {
                var domainObj = await Context.BoardgameDomains
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Domain == boardgameDomain.Domain, cancellationToken);

                if (domainObj != null)
                    return true;
                else
                    return false;
            }
        }

        public async Task<Guid> GetBoardgameDomainIdAsync(string? domainName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new ArgumentException("Domain name cannot be null or whitespace.", nameof(domainName));
            }

            // Check ChangeTracker if entity exists in waiting list to be added
            // If found - get an ID of that entity

            bool isTracked = Context.ChangeTracker
           .Entries<BoardgameDomain>()
           .Any(e => e.Entity.Domain == domainName);

            if (isTracked)
            {
                var entity = Context.ChangeTracker
                               .Entries<BoardgameDomain>()
                               .FirstOrDefault(e => e.Entity.Domain == domainName);
                return entity!.Entity.Id;
            }

            var domainObj = await Context.BoardgameDomains
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Domain == domainName, cancellationToken);

            if (domainObj != null)
                return domainObj.Id;
            else
                throw new ApplicationException("Entity has not been found");

        }
    }
}
