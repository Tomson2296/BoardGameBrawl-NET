using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerPreferenceRepository : IGenericRepository<PlayerRreference>
    {
        // refined methods //

        Task<bool> Exists(Guid playerId,
            Guid boardgameId, CancellationToken cancellationToken = default);


        // getter methods //

        Task<byte> GetPlayerPreferenceByBoardgameIdAsync(Guid playerId, 
            Guid boardgameId,
            CancellationToken cancellationToken = default);

        Task<Dictionary<Guid, byte>> GetAllPlayerPreferencesAsync(Guid playerId,
            CancellationToken cancellationToken = default);


        // setter methods //

        Task SetPlayerPreferenceAboutBoardgameAsync(Guid playerId,
            Guid boardgameId, byte rating,
            CancellationToken cancellationToken = default);
    }
}
