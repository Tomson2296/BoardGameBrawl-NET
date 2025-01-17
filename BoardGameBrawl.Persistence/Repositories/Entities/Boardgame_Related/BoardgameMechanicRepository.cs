using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameMechanicsRepository : GenericRepository<BoardgameMechanic>, IBoardgameMechanicsRepository
    {
        public BoardgameMechanicsRepository(MainAppDBContext context) : base(context)
        { }

        // getter methods //

        public async Task<string?> GetMechanicNameAsync(BoardgameMechanic mechanic,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(mechanic);

            return await Task.FromResult(mechanic.Mechanic);
        }

        // setter methods //

        public Task SetMechanicNameAsync(BoardgameMechanic mechanic,
            string? mechanicName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(mechanic);

            if (string.IsNullOrWhiteSpace(mechanicName))
            {
                throw new ArgumentException("Mechanic name cannot be null or whitespace.", nameof(mechanicName));
            }

            mechanic.Mechanic = mechanicName;
            return Task.CompletedTask;
        }
    }
}
