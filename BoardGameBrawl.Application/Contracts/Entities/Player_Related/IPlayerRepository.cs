using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {

        // getter methods // 

        public Task<string?> GetUsernameAsync(Player player,
            CancellationToken cancellationToken = default);

        public Task<string?> GetEmailAsync(Player player,
            CancellationToken cancellationToken = default);

        public Task<string?> GetFirstNameAsync(Player player,
            CancellationToken cancellationToken = default);

        public Task<string?> GetLastNameAsync(Player player,
           CancellationToken cancellationToken = default);

        public Task<string?> GetBGGUsernameAsync(Player player,
           CancellationToken cancellationToken = default);

        public Task<string?> GetUserDescriptionAsync(Player player,
           CancellationToken cancellationToken = default);

        public Task<byte[]?> GetUserAvatarAsync(Player player,
          CancellationToken cancellationToken = default);

        public Task<DateTime> GetUserLastLoginAsync(Player player,
          CancellationToken cancellationToken = default);


        // setter methods //

        public Task SetUsernameAsync(Player player,
            string? userName,
            CancellationToken cancellationToken = default);

        public Task SetEmailAsync(Player player,
           string? email,
           CancellationToken cancellationToken = default);

        public Task SetFirstNameAsync(Player player,
            string? firstName,
            CancellationToken cancellationToken = default);

        public Task SetLastNameAsync(Player player,
           string? lastName,
           CancellationToken cancellationToken = default);

        public Task SetBGGUsernameAsync(Player player,
           string? BGGUsername,
           CancellationToken cancellationToken = default);

        public Task SetUserDescriptionAsync(Player player,
           string? desc,
           CancellationToken cancellationToken = default);

        public Task SetUserAvatarAsync(Player player,
          byte[]? avatar,
          CancellationToken cancellationToken = default);

        public Task SetUserLastLoginAsync(Player player,
          DateTime lastLogin,
          CancellationToken cancellationToken = default);

    }
}
