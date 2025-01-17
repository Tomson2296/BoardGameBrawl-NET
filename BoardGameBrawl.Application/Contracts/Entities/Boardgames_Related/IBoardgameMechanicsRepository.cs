using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related
{
    public interface IBoardgameMechanicsRepository : IGenericRepository<BoardgameMechanic>, IAuditableRepository<BoardgameMechanic>
    {
        // basic fields getter methods //

        Task<string?> GetMechanicNameAsync(BoardgameMechanic mechanic,
           CancellationToken cancellationToken = default);

        // basic fields setter methods //

        Task SetMechanicNameAsync(BoardgameMechanic mechanic,
            string? mechanicName, CancellationToken cancellationToken = default);
    }
}
