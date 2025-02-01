using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Persistence.Extensions
{
    public static class UserManagerExtensionMethods
    {
        // custom UserManager extension methods //

        public static async Task<bool> CheckIfUserHasCreatedPlayerAccountAsync(this UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> applicationUserStore,
            ApplicationUser applicationUser,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(userManager);
            ArgumentNullException.ThrowIfNull(applicationUserStore);
            ArgumentNullException.ThrowIfNull(applicationUser);

            return await applicationUserStore.GetUserIsPlayerCreatedAsync(applicationUser, cancellationToken).ConfigureAwait(false);
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
