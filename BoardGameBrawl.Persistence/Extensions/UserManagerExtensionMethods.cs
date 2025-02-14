using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.Persistence.Extensions
{
    public static class UserManagerExtensionMethods
    {
        // custom UserManager extension methods //

        public static async Task<IList<ApplicationUser>> GetAllApplicationUsers(this UserManager<ApplicationUser> userManager)
        {
            ArgumentNullException.ThrowIfNull(userManager);
            return await userManager.Users.ToListAsync();
        }

        public static Task<int> GetNumberOfUsersCountAsync(this UserManager<ApplicationUser> userManager,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);
            
            return Task.FromResult(userManager.Users.Count());
        }

        public static Task<int> GetNumberOfUsersUnconfirmedCountAsync(this UserManager<ApplicationUser> userManager,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);
            
            return Task.FromResult(userManager.Users.Where(u => u.EmailConfirmed == false).Count());
        }

        public static Task<int> GetNumberOfUsersLockedOutCountAsync(this UserManager<ApplicationUser> userManager,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);

            return Task.FromResult(userManager.Users.Where(u => u.AccessFailedCount == 5).Count());
        }

        public static async Task<bool> CheckIfUserProfileCanBeCreatedAsync(this UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> applicationUserStore,
            ApplicationUser applicationUser,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);
            ArgumentNullException.ThrowIfNull(applicationUserStore);
            ArgumentNullException.ThrowIfNull(applicationUser);

            var isUsernameTaken = await applicationUserStore.CheckIfUsernameAlreadyTakenAsync(applicationUser.UserName).ConfigureAwait(false);
            if (isUsernameTaken == false)
            {
                return false;
            }

            var isEmailTaken = await applicationUserStore.CheckIfEmailAlreadyTakenAsync(applicationUser.Email).ConfigureAwait(false);
            if (isEmailTaken == false)
            {
                return false;   
            }

            return true;
        }

        public static async Task<bool> CheckIfUserHasCreatedPlayerAccountAsync(this UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> applicationUserStore,
            ApplicationUser applicationUser,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);
            ArgumentNullException.ThrowIfNull(applicationUserStore);
            ArgumentNullException.ThrowIfNull(applicationUser);

            return await applicationUserStore.GetUserIsPlayerCreatedAsync(applicationUser, cancellationToken)
                .ConfigureAwait(false);
        }

        public static async Task<bool> ChangeApplicationUsernameAsync(this UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> applicationUserStore,
            ApplicationUser applicationUser,
            string newUsername,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);
            ArgumentNullException.ThrowIfNull(applicationUserStore);
            ArgumentNullException.ThrowIfNull(applicationUser);

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(newUsername));
            }

            var ifUsernameExists = await applicationUserStore.CheckApplicationUsernameExistsAsync(applicationUser, newUsername, cancellationToken)
                .ConfigureAwait(false);

            return ifUsernameExists;
        }
    }
}
