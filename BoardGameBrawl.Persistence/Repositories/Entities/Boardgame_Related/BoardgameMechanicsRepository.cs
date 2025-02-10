using AutoMapper;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameMechanicsRepository : GenericRepository<BoardgameMechanic>, IBoardgameMechanicsRepository
    {
        private readonly IMapper _mapper;
        public BoardgameMechanicsRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // refined methods //

        public async Task<bool> Exists(BoardgameMechanic boardgameMechanic,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameMechanic);

            // Check ChangeTracker if entity exists in waiting list to be added

            bool isTracked = Context.ChangeTracker
            .Entries<BoardgameMechanic>()
            .Any(e => e.Entity.Mechanic == boardgameMechanic.Mechanic);

            if (isTracked)
            {
                return true;
            }
            else
            {
                var mechanicObj = await Context.BoardgameMechanics
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Mechanic == boardgameMechanic.Mechanic, cancellationToken);

                if (mechanicObj != null)
                    return true;
                else
                    return false;
            }
        }

        // getter methods //

        public async Task<BoardgameMechanicDTO?> GetBoardgameMechanicByNameAsync(string? mechanicName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(mechanicName))
            {
                throw new ArgumentException("Mechanic name cannot be null or whitespace.", nameof(mechanicName));
            }

            var mechanicObj = await Context.BoardgameMechanics
                .FirstOrDefaultAsync(e => e.Mechanic == mechanicName, cancellationToken);

            if (mechanicObj != null)
                return _mapper.Map<BoardgameMechanicDTO>(_mapper.ConfigurationProvider);
            else
                throw new ApplicationException("Entity has not been found");
        }

        public async Task<Guid> GetBoardgameMechanicIdAsync(string? mechanicName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(mechanicName))
            {
                throw new ArgumentException("Mechanic name cannot be null or whitespace.", nameof(mechanicName));
            }

            // Check ChangeTracker if entity exists in waiting list to be added
            // If found - get an ID of that entity

            bool isTracked = Context.ChangeTracker
           .Entries<BoardgameMechanic>()
           .Any(e => e.Entity.Mechanic == mechanicName);

            if (isTracked)
            {
                var entity = Context.ChangeTracker
                               .Entries<BoardgameMechanic>()
                               .FirstOrDefault(e => e.Entity.Mechanic == mechanicName);
                return entity!.Entity.Id;
            }

            var mechanicObj = await Context.BoardgameMechanics
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Mechanic == mechanicName, cancellationToken);

            if (mechanicObj != null)
                return mechanicObj.Id;
            else
                throw new ApplicationException("Entity has not been found");
        }


        public Task<string?> GetMechanicNameAsync(BoardgameMechanic mechanic,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(mechanic);

            return Task.FromResult(mechanic.Mechanic);
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
