using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserEmailStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserEmailStore<ApplicationUser>
    {
        private readonly IdentityAppDBContext context = context;

        public async Task<ApplicationUser?> FindByEmailAsync(string normalizedEmail,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(normalizedEmail);

            return await context.Users.SingleOrDefaultAsync(u => u.NormalizedEmail!.Equals(normalizedEmail), cancellationToken);
        }

        public async Task<string?> GetEmailAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.EmailConfirmed);
        }

        public async Task<string?> GetNormalizedEmailAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.NormalizedEmail);
        }

        public async Task SetEmailAsync(ApplicationUser user, string? email,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(email);

            user.Email = email;
            await Task.FromResult<object>(null!);
        }

       public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            user.EmailConfirmed = confirmed;
            await Task.FromResult<object>(null!);
        }

        public async Task SetNormalizedEmailAsync(ApplicationUser user, string? normalizedEmail,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(normalizedEmail);

            user.NormalizedEmail = normalizedEmail;
            await Task.FromResult<object>(null!);
        }
    }
}
