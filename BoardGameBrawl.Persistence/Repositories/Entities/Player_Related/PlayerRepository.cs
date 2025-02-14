using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        private readonly IMapper _mapper;
        
        public PlayerRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // custom PlayerRepository methods //

        public async Task<bool> CheckIfPlayerExistsByAppId(Guid appUserId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(appUserId);

            return await _context.Players.AnyAsync(u => u.ApplicationUserId == appUserId, cancellationToken);
        }


        public async Task<IList<NavPlayerDTO>> GetFilteredBatchOfPlayersAsync(string filter, int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await Context.Players
                    .Where(p => p.PlayerName.Contains(filter))
                    .OrderBy(p => p.PlayerName)
                    .ProjectTo<NavPlayerDTO>(_mapper.ConfigurationProvider)
                    .Skip(skip)
                    .Take(size)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving a batch of entities.", ex);
            }
        }

        public async Task<Player?> GetPlayerByApplicationUserIdAsync(Guid applicationUserId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(applicationUserId);

            return await Context.Players.SingleOrDefaultAsync(u => u.ApplicationUserId == applicationUserId, cancellationToken);
        }

        public async Task<PlayerDTO?> GetPlayerByUserNameAsync(string username, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            }

            var player = await Context.Players.SingleOrDefaultAsync(u => u.PlayerName == username, cancellationToken);
            if (player != null)
            {
                return _mapper.Map<PlayerDTO>(player);
            }
            else
            {
                throw new ApplicationException("Entity has not been found");
            }
        }


        // getter methods //

        public Task<Guid> GetApplicationUserIdAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.ApplicationUserId);
        }

        public Task<string?> GetBGGUsernameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.BGGUsername);
        }

        public Task<string> GetEmailAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.Email);
        }

        public Task<string?> GetFirstNameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.FirstName);
        }

        public Task<string?> GetLastNameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.LastName);
        }

        public Task<byte[]?> GetUserAvatarAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.UserAvatar);
        }

        public Task<string?> GetUserDescriptionAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.UserDescription);
        }

        public Task<string> GetUsernameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return Task.FromResult(player.PlayerName);
        }


        // setter methods //
        
        
        public Task SetApplicationUserIdAsync(Player player, Guid applicationUserId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);
            ArgumentNullException.ThrowIfNull(applicationUserId);

            player.ApplicationUserId = applicationUserId;
            return Task.CompletedTask;
        }

        public Task SetBGGUsernameAsync(Player player, string? BGGUsername, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            if (string.IsNullOrWhiteSpace(BGGUsername))
            {
                throw new ArgumentException("BGGUsername cannot be null or whitespace.", nameof(BGGUsername));
            }
            
            player.BGGUsername = BGGUsername;
            return Task.CompletedTask;
        }

        public Task SetEmailAsync(Player player, string? email, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }

            player.Email = email;
            return Task.CompletedTask;
        }

        public Task SetFirstNameAsync(Player player, string? firstName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }

            player.FirstName = firstName;
            return Task.CompletedTask;
        }

        public Task SetLastNameAsync(Player player, string? lastName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or whitespace.", nameof(lastName));
            }

            player.LastName = lastName;
            return Task.CompletedTask;
        }

        public Task SetUserAvatarAsync(Player player, byte[]? avatar, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);
            ArgumentNullException.ThrowIfNull(avatar);

            player.UserAvatar = avatar;
            return Task.CompletedTask;
        }

        public Task SetUserDescriptionAsync(Player player, string? desc, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            if (string.IsNullOrWhiteSpace(desc))
            {
                throw new ArgumentException("User description cannot be null or whitespace.", nameof(desc));
            }

            player.UserDescription = desc;
            return Task.CompletedTask;
        }

        public Task SetUsernameAsync(Player player, string? userName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(userName));
            }

            player.PlayerName = userName;
            return Task.CompletedTask;
        }

    }
}
