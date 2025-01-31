using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;

namespace BoardGameBrawl.Persistence.Extensions
{
    public static class ApplicationUserStoreExtensionMethods
    {
        // custom extension methods //





        // getter methods //
        
        public static Task<string?> GetFirstNameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.FirstName);
        }

        public static Task<string?> GetLastNameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.LastName);
        }

        public static Task<string?> GetBGGUsernameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.BGGUsername);
        }

        public static Task<string?> GetUserDescriptionAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserDescription);
        }

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

        public static Task<byte[]?> GetUserAvatarAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserAvatar);
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


        public static Task SetFirstNameAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore, 
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

        public static Task SetUserIsPlayerCreatedAsync(this IApplicationUserStore<ApplicationUser> ApplicationUserStore,
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
