using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserLockoutStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserLockoutStore<ApplicationUser>
    {
        public async Task<int> GetAccessFailedCountAsync(ApplicationUser user, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.AccessFailedCount);
        }

        public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.LockoutEnabled);
        }

        public async Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.LockoutEnd);
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            user.AccessFailedCount += 1;
            return await Task.FromResult(user.AccessFailedCount);
        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            user.AccessFailedCount = 0;
            await Task.FromResult<object>(null!);
        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(enabled);

            user.LockoutEnabled = enabled;
            await Task.FromResult<object>(null!);
        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(lockoutEnd);

            user.LockoutEnd = lockoutEnd;
            await Task.FromResult<object>(null!);
        }
    }
}
