using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.Repositories.Common;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Player_Related
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(MainAppDBContext context) : base(context)
        {

        }

        public async Task<string?> GetBGGUsernameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.BGGUsername);
        }

        public async Task<string?> GetEmailAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.Email);
        }

        public async Task<string?> GetFirstNameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.FirstName);
        }

        public async Task<string?> GetLastNameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.LastName);
        }

        public async Task<byte[]?> GetUserAvatarAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.UserAvatar);
        }

        public async Task<string?> GetUserDescriptionAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.UserDescription);
        }

        public async Task<string?> GetUsernameAsync(Player player, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(player);

            return await Task.FromResult(player.UserName);
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

            player.UserName = userName;
            return Task.CompletedTask;
        }
    }
}
