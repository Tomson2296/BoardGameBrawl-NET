using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;

namespace BoardGameBrawl.Application.Contracts.Entities.Identity_Related
{
    public interface IApplicationUserQueryService
    {
        Task<ICollection<NavUserDTO>> GetFilteredUsersByUsernameAsync(
        int pageSize,
        int pageNumber,
        string? filter = "",
        CancellationToken cancellationToken = default);
    }
}
