using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Persistence.Extensions
{
    public static class ApplicationUserStoreExtensionMethods
    {
        // custom extension methods //





        // getter methods //
        
        public async static Task<string?> GetFirstNameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.FirstName);
        }

        public async static Task<string?> GetLastNameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.LastName);
        }

        public async static Task<string?> GetBGGUsernameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.BGGUsername);
        }

        public async static Task<string?> GetUserDescriptionAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserDescription);
        }

        public async static Task<DateOnly?> GetUserCreatedDateAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserCreatedDate);
        }

        public async static Task<DateOnly?> GetUserLastLoginAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserLastLogin);
        }

        public async static Task<byte[]?> GetUserAvatarAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserAvatar);
        }


        // setter methods //


        public static Task SetFirstNamelAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, string? firstName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }

            user.FirstName = firstName;
            return Task.CompletedTask;
        }

        public static Task SetLastNameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, string? lastName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or whitespace.", nameof(lastName));
            }

            user.LastName = lastName;
            return Task.CompletedTask;
        }

        public static Task SetBGGUsernameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, string? BGGUsername,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(BGGUsername))
            {
                throw new ArgumentException("BGGUsername cannot be null or whitespace.", nameof(BGGUsername));
            }

            user.BGGUsername = BGGUsername;
            return Task.CompletedTask;
        }

        public static Task SetUserDescriptionAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, string? UserDescription,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(UserDescription))
            {
                throw new ArgumentException("User description cannot be null or whitespace.", nameof(UserDescription));
            }

            user.UserDescription = UserDescription;
            return Task.CompletedTask;
        }

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

        public static Task SetUserAvatarAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, byte[]? UserAvatar,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(UserAvatar);

            user.UserAvatar = UserAvatar;
            return Task.CompletedTask;
        }
    }
}
