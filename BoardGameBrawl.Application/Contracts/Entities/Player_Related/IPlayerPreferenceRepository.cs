using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerPreferenceRepository : IGenericRepository<PlayerPreference>, IAuditableRepository<PlayerPreference>
    {
        // refined methods //
        
        Task<bool> Exists(Guid playerId,
            Guid boardgameId, CancellationToken cancellationToken = default);


        // getter methods //

        Task<PlayerPreferenceDTO> GetPlayerPreferenceAsync (Guid playerId, 
            Guid boardgameId,
            CancellationToken cancellationToken = default);

        Task<IList<PlayerPreferenceDTO>> GetAllPlayerPreferencesAsync(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<IList<CompositePlayerBoardgamePreferencesDTO>> GetCompositePlayerBoardgamePreferences(Guid playerId,
            CancellationToken cancellationToken = default);

        Task<IList<PlayerPreferenceDTO>> GetAllBoardgamePrefencesChosenByPlayersAsync(Guid boardgameId,
            CancellationToken cancellationToken = default);

        Task<IList<CompositeBoardgamePreferencesByPlayersDTO>> GetBoardgamePreferencesByPlayers (Guid boardgameId,
          CancellationToken cancellationToken = default);


        // setter methods //

        Task SetPlayerPreferenceAboutBoardgameAsync(Guid playerId,
            Guid boardgameId, byte rating,
            CancellationToken cancellationToken = default);
    }
}
