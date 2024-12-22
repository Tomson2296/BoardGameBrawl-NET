using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserSecurityStampStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserSecurityStampStore<ApplicationUser>
    {
        public async Task<string?> GetSecurityStampAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.SecurityStamp);
        }

        public async Task SetSecurityStampAsync(ApplicationUser user, string stamp,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(stamp);

            user.SecurityStamp = stamp;
            await Task.FromResult<object>(null!);
        }
    }
}
