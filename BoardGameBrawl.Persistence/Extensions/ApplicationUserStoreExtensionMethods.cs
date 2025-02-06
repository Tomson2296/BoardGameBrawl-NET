using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Extensions
{
    public static class ApplicationUserStoreExtensionMethods
    {
        // custom methods //

        public static async Task<bool> CheckIfUsernameAlreadyTakenAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
          string? username,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            }

            return await ApplicationUserStore.Users.AnyAsync(u => u.UserName!.Equals(username), cancellationToken);
        }

        public static async Task<bool> CheckIfEmailAlreadyTakenAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
          string? email,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }

            return await ApplicationUserStore.Users.AnyAsync(u => u.Email!.Equals(email), cancellationToken);
        }


        // getter methods //

        public static Task<bool> GetUserEmailConfirmedAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
          ApplicationUser user,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.EmailConfirmed);
        }

        public static Task<DateOnly?> GetUserCreatedDateAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserCreatedDate);
        }

        public static Task<DateOnly?> GetUserLastLoginAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserLastLogin);
        }

        public static Task<bool> GetUserIsPlayerCreatedAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.IsPlayerCreated);
        }


        // setter methods //


        public static Task SetUserEmailConfirmedAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user, bool isEmailConfirmed,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
            ArgumentNullException.ThrowIfNull(user);

            user.EmailConfirmed = isEmailConfirmed;
            return Task.CompletedTask;
        }

        public static Task SetUserCreatedDateAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, DateOnly UserCreatedDate,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
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
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
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
            ArgumentNullException.ThrowIfNull(ApplicationUserStore);
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(playerCreated);

            user.IsPlayerCreated = playerCreated;
            return Task.CompletedTask;
        }
    }
}
