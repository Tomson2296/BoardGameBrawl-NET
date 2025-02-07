using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameDomainTagsRepository : GenericRepository<BoardgameDomainTag>, IBoardgameDomainTagsRepository
    {
        public BoardgameDomainTagsRepository(MainAppDBContext context) : base(context)
        {

        }

        public async Task<bool> Exists(Guid boardgameId,
            Guid domainId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(domainId);

            var entity = await Context.Set<BoardgameDomainTag>().FindAsync(new[] { boardgameId, domainId }, cancellationToken);
            return entity != null;
        }

        public async Task<BoardgameDomainTag?> GetEntity(Guid boardgameId,
            Guid domainId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(domainId);

            return await _context.Set<BoardgameDomainTag>().FindAsync(new[] { boardgameId, domainId }, cancellationToken);
        }
    }
}
