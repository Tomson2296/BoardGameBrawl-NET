using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserStore(IdentityAppDBContext context) : IUserStore<ApplicationUser>
    {
        private readonly IdentityAppDBContext _context = context;

        public async Task<IdentityResult> CreateAsync(ApplicationUser user,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (!_context.Users.Contains(user))
            {
                await _context.Users.AddAsync(user, cancellationToken);
                var affectedRows = await _context.SaveChangesAsync(cancellationToken);
                return affectedRows > 0
                        ? IdentityResult.Success
                        : IdentityResult.Failed(new IdentityError() { Description = $"Could not create user {user.Id}." });
            }
            else
            {
                return IdentityResult.Failed(new IdentityError() { Description = $"User {user.Id} already exists in database - creation process failed." });
            }
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            var userInDB = await _context.Users.FindAsync(user, cancellationToken);

            if (userInDB == null)
            {
                return IdentityResult.Failed(new IdentityError() { Description = $"Could not find user to deletion process: {user.Id}." });
            }
            else
            {
                _context.Users.Remove(userInDB);
                var affectedRows = await _context.SaveChangesAsync(cancellationToken);
                return affectedRows > 0
                ? IdentityResult.Success
                        : IdentityResult.Failed(new IdentityError() { Description = $"Could not delete user: {user.Id}." });
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ApplicationUser?> FindByIdAsync(string? userId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(userId);

            if (!Guid.TryParse(userId, out Guid idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(userId));
            }

            return await _context.Users.SingleOrDefaultAsync(u => u.Id.Equals(Guid.Parse(userId)), cancellationToken);
        }

        public async Task<ApplicationUser?> FindByNameAsync(string normalizedUserName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(normalizedUserName);

            return await _context.Users.SingleOrDefaultAsync(u => u.NormalizedUserName!.Equals(normalizedUserName), cancellationToken);
        }

        public async Task<string?> GetNormalizedUserNameAsync(ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.NormalizedUserName);
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.Id.ToString());
        }

        public async Task<string?> GetUserNameAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.UserName);
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(normalizedName);

            user.NormalizedUserName = normalizedName;
            await Task.FromResult<object>(null!);
        }

        public async Task SetUserNameAsync(ApplicationUser user, string? userName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(userName);

            user.UserName = userName;
            await Task.FromResult<object>(null!);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            _context.Users.Update(user);
            var affectedRows = await _context.SaveChangesAsync(cancellationToken);
            return affectedRows > 0
            ? IdentityResult.Success
                    : IdentityResult.Failed(new IdentityError() { Description = $"Could not update user: {user.Id}." });
        }
    }
}
