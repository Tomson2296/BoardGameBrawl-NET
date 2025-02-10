using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
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
        private readonly IMapper _mapper;
        public PlayerCollectionRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<bool> CheckIfExistsByPlayerId(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            var exists = await Context.PlayerCollections.AnyAsync(pc => pc.PlayerId == playerId, cancellationToken);
            return exists;
        }

        public async Task<PlayerCollectionDTO?> GetPlayerCollectionByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(Id);

            var playerCollection = await Context.PlayerCollections.SingleOrDefaultAsync(pc => pc.Id == Id, cancellationToken);

            if (playerCollection != null)
                return _mapper.Map<PlayerCollectionDTO>(_mapper.ConfigurationProvider);
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<PlayerCollectionDTO?> GetPlayerCollectionByPlayerIdAsync(Guid playerId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(playerId);

            var playerCollection = await Context.PlayerCollections.SingleOrDefaultAsync(pc => pc.PlayerId == playerId, cancellationToken);

            if (playerCollection != null)
                return _mapper.Map<PlayerCollectionDTO>(_mapper.ConfigurationProvider);
            else
                throw new ApplicationException("Entity has not been found");
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
