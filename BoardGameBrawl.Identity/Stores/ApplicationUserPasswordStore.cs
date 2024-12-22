using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserPasswordStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserPasswordStore<ApplicationUser>
    {
        public async Task<string?> GetPasswordHashAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(passwordHash);

            user.PasswordHash = passwordHash;
            await Task.FromResult<object>(null!);
        }
    }
}
