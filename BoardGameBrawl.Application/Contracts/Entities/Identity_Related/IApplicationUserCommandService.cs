namespace BoardGameBrawl.Application.Contracts.Entities.Identity_Related
{
    public interface IApplicationUserCommandService : IDisposable
    {
        Task<bool> RemoveExternalLoginAsync(string? LoginProvider,
            string? ProviderKey,
            Guid userId, 
            CancellationToken cancellationToken = default);  
    }
}
