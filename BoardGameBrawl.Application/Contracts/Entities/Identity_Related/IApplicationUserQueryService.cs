using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Application.Contracts.Entities.Identity_Related
{
    public interface IApplicationUserQueryService : IDisposable
    {
        Task<ViewUserDTO> GetUserPropertiesAsync(
        Guid applicationUserId,
        CancellationToken cancellationToken = default);


        Task<ICollection<NavUserDTO>> GetFilteredUsersByUsernameAsync(
        int pageSize,
        int pageNumber,
        string? filter = "",
        CancellationToken cancellationToken = default);


        Task<IList<NavUserDTO>> GetFilteredUsersByAppRoleAsync(
        int pageSize,
        int pageNumber,
        Guid roleId,
        CancellationToken cancellationToken = default);


        Task<ApplicationUserLogin> GetExternalLoginData(
        string? loginProvider,
        string? providerKey,
        Guid userId,
        CancellationToken cancellationToken = default);


        Task<IList<ApplicationUserLogin>> GetExternalLoginsByUserIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default);


        Task<IList<ApplicationUserLogin>> GetListOfAllExternalLoginsAsync(
        int pageSize,
        int pageNumber,
        CancellationToken cancellationToken = default);
    }
}
