using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Persistence.Extensions
{
    public static class ApplicationUserStoreExtensionMethods
    {
        // getter methods //
        
        public static Task<DateOnly?> GetUserCreatedDateAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserCreatedDate);
        }

        public static Task<DateOnly?> GetUserLastLoginAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserLastLogin);
        }

        public static Task<bool> GetUserIsPlayerCreatedAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.IsPlayerCreated);
        }


        // setter methods //

        public static Task SetUserCreatedDateAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, DateOnly UserCreatedDate,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(UserCreatedDate);

            user.UserCreatedDate = UserCreatedDate;
            return Task.CompletedTask;
        }

        public static Task SetUserLastLoginAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, DateOnly? UserLastLogin,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(UserLastLogin);

            user.UserLastLogin = UserLastLogin;
            return Task.CompletedTask;
        }

        public static Task SetUserIsPlayerAccountCreatedAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user, bool playerCreated,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(playerCreated);

            user.IsPlayerCreated = playerCreated;
            return Task.CompletedTask;
        }
    }
}
