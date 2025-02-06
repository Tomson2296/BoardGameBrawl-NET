using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Application.Contracts.Entities.Identity_Related
{
    public interface IApplicationUserCommandService : IDisposable
    {
        Task RemoveExternalLoginAsync(ApplicationUserLogin userLogin,
            CancellationToken cancellationToken = default);  
    }
}
