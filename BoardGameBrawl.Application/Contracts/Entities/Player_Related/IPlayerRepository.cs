using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System.Globalization;

namespace BoardGameBrawl.Application.Contracts.Entities.Player_Related
{
    public interface IPlayerRepository : IGenericRepository<Player>, IAuditableRepository<Player>
    {
        // custom PlayerRepository methods //

        Task<IList<NavPlayerDTO>> GetFilteredBatchOfPlayersAsync(string filter, int size, int skip = 0, CancellationToken cancellationToken = default);

        Task<Player?> GetPlayerByApplicationUserIdAsync(Guid applicationUserId,
            CancellationToken cancellationToken = default);

        Task<PlayerDTO?> GetPlayerByUserNameAsync(string username,
            CancellationToken cancellationToken = default);


        // getter methods // 

        Task<Guid> GetApplicationUserIdAsync(Player player,
            CancellationToken cancellationToken = default);

        Task<string> GetUsernameAsync(Player player,
            CancellationToken cancellationToken = default);

        Task<string> GetEmailAsync(Player player,
            CancellationToken cancellationToken = default);

        Task<string?> GetFirstNameAsync(Player player,
            CancellationToken cancellationToken = default);

        Task<string?> GetLastNameAsync(Player player,
           CancellationToken cancellationToken = default);

        Task<string?> GetBGGUsernameAsync(Player player,
           CancellationToken cancellationToken = default);

        Task<string?> GetUserDescriptionAsync(Player player,
           CancellationToken cancellationToken = default);

        Task<byte[]?> GetUserAvatarAsync(Player player,
          CancellationToken cancellationToken = default);


        // setter methods //
        Task SetApplicationUserIdAsync(Player player,
            Guid applicationUserId,
            CancellationToken cancellationToken = default);

        Task SetUsernameAsync(Player player,
            string? userName,
            CancellationToken cancellationToken = default);

        Task SetEmailAsync(Player player,
           string? email,
           CancellationToken cancellationToken = default);

        Task SetFirstNameAsync(Player player,
            string? firstName,
            CancellationToken cancellationToken = default);

        Task SetLastNameAsync(Player player,
           string? lastName,
           CancellationToken cancellationToken = default);

        Task SetBGGUsernameAsync(Player player,
           string? BGGUsername,
           CancellationToken cancellationToken = default);

        Task SetUserDescriptionAsync(Player player,
           string? desc,
           CancellationToken cancellationToken = default);

        Task SetUserAvatarAsync(Player player,
          byte[]? avatar,
          CancellationToken cancellationToken = default);
    }
}
