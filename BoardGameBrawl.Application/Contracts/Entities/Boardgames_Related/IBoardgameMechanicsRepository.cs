using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameMechanicsRepository : IGenericRepository<BoardgameMechanic>, IAuditableRepository<BoardgameMechanic>
    {
        // refined methods //
        Task<bool> Exists(BoardgameMechanic boardgameMechanic,
           CancellationToken cancellationToken = default);

        // basic fields getter methods //

        Task<Guid> GetBoardgameMechanicIdAsync(string? mechanicName,
            CancellationToken cancellationToken = default);

        Task<BoardgameMechanic?> GetBoardgameMechanicByNameAsync(string? mechanicName,
           CancellationToken cancellationToken = default);
        
        Task<string?> GetMechanicNameAsync(BoardgameMechanic mechanic,
           CancellationToken cancellationToken = default);

        // basic fields setter methods //

        Task SetMechanicNameAsync(BoardgameMechanic mechanic,
            string? mechanicName, CancellationToken cancellationToken = default);
    }
}
