using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Value_objects;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerCollectionRepository : GenericRepository<PlayerCollection>, IPlayerCollectionRepository
    {
        public PlayerCollectionRepository(MainAppDBContext context) : base(context)
        {
        }

        public async Task<bool> CheckIfExistsByPlayerId(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            var exists = await Context.PlayerCollections.AnyAsync(pc => pc.PlayerId == playerId, cancellationToken);
            return exists;

        }

        public async Task<PlayerCollection?> GetPlayerCollectionByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(Id);

            return await Context.PlayerCollections.SingleOrDefaultAsync(pc => pc.Id == Id, cancellationToken);
        }

        public async Task<PlayerCollection?> GetPlayerCollectionByPlayerIdAsync(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            return await Context.PlayerCollections.SingleOrDefaultAsync(pc => pc.PlayerId == playerId, cancellationToken);
        }

        public Task<bool> GetIsCollectionCreatedAsync(PlayerCollection collection, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(collection);

            return Task.FromResult(collection.IsCollectionCreated);
        }

        public Task SetIsCollectionCreatedAsync(PlayerCollection collection, bool isCreated, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(collection);
            ArgumentNullException.ThrowIfNull(isCreated);

            collection.IsCollectionCreated = isCreated;
            return Task.CompletedTask;
        }
    }
}
