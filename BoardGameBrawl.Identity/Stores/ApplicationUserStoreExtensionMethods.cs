using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Identity.Stores
{
    public static class ApplicationUserStoreExtensionMethods
    {
        // custom ApplicationUser getter methods //
        
        public async static Task<string?> GetFirstNameAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.FirstName);
        }

        public async static Task<string?> GetLastNameAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.LastName);
        }

        public async static Task<string?> GetBGGUsernameAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.BGGUsername);
        }

        public async static Task<string?> GetUserDescriptionAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserDescription);
        }

        public async static Task<DateOnly?> GetUserCreatedDateAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserCreatedDate);
        }

        public async static Task<DateOnly?> GetUserLastLoginAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserLastLogin);
        }

        public async static Task<byte[]?> GetUserAvatarAsync(this IUserStore<ApplicationUser> ApplicationUserStore,
           ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserAvatar);
        }

        public async static Task<string?> GetUserPasswordHash(this IUserStore<ApplicationUser> ApplicationUserStore,
          ApplicationUser user,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.PasswordHash);
        }


        // setter methods //


        public static Task SetFirstNamelAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
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

        public static Task SetLastNameAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
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

        public static Task SetBGGUsernameAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
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

        public static Task SetUserDescriptionAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
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

        public static Task SetUserCreatedDateAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, DateOnly UserCreatedDate,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(UserCreatedDate);

            user.UserCreatedDate = UserCreatedDate;
            return Task.CompletedTask;
        }

        public static Task SetUserLastLoginAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, DateOnly? UserLastLogin,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(UserLastLogin);

            user.UserLastLogin = UserLastLogin;
            return Task.CompletedTask;
        }

        public static Task SetUserAvatarAsync(this IUserStore<ApplicationUser> ApplicationUserStore, 
            ApplicationUser user, byte[]? UserAvatar,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(UserAvatar);

            user.UserAvatar = UserAvatar;
            return Task.CompletedTask;
        }

        public static Task SetUserPasswordHashAsync(this IUserStore<ApplicationUser> ApplicationUserStore,
          ApplicationUser user, string? passwordHash,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("PasswordHash cannot be null or whitespace.", nameof(passwordHash));
            }

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }
    }
}
