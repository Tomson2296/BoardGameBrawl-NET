using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerCollectionRepository : IGenericRepository<PlayerCollection>, IAuditableRepository<PlayerCollection>
    {
        // refined methods //

        Task<bool> CheckIfExistsByPlayerId(Guid playerId, CancellationToken cancellationToken = default);


        // getter methods //

        Task<PlayerCollection?> GetPlayerCollectionByIdAsync(Guid Id,
            CancellationToken cancellationToken = default);

        Task<PlayerCollection?> GetPlayerCollectionByPlayerIdAsync(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<bool> GetIsCollectionCreatedAsync(PlayerCollection collection,
           CancellationToken cancellationToken = default);


        // setter methods //

        Task SetIsCollectionCreatedAsync(PlayerCollection collection, bool isCreated,
          CancellationToken cancellationToken = default);
    }
}
