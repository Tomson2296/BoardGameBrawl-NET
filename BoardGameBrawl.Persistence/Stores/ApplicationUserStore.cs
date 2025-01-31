using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BoardGameBrawl.Persistence.Stores
{
    public class ApplicationUserStore : IApplicationUserStore<ApplicationUser>
    {
        private readonly IdentityAppDBContext _context;
        public ApplicationUserStore(IdentityAppDBContext context)
        {
            _context = context;
        }
        
        public async Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims,
              CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(claims);

            foreach (var claim in claims)
            {
                var claimInDb = await _context.UserClaims.FirstOrDefaultAsync(uc => uc.UserId == user.Id &&
                    uc.ClaimType!.Equals(claim.Type) && uc.ClaimValue!.Equals(claim.Value), cancellationToken);

                if (claimInDb == null)
                {
                    var instance = new ApplicationUserClaim()
                    {
                        UserId = user.Id,
                        ClaimType = claim.Type,
                        ClaimValue = claim.Value
                    };

                    await _context.UserClaims.AddAsync(instance, cancellationToken);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(login);

            var userLoginInDB = await _context.UserLogins.FindAsync(login.LoginProvider, login.ProviderKey, cancellationToken);

            if (userLoginInDB == null)
            {
                var newUserLoginCredentials = new ApplicationUserLogin()
                {
                    LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey,
                    ProviderDisplayName = login.ProviderDisplayName,
                    UserId = user.Id
                };

                await _context.UserLogins.AddAsync(newUserLoginCredentials, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AddToRoleAsync(ApplicationUser user, string roleName,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(roleName));
            }

            var roleEntity = await _context.Roles.FirstOrDefaultAsync(r => r.Name!.Equals(roleName), cancellationToken);

            if (roleEntity != null)
            {
                var newUserRole = new ApplicationUserRole() { UserId = user.Id, RoleId = roleEntity.Id };
                await _context.UserRoles.AddAsync(newUserRole, cancellationToken);
            }
        }

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

        private bool _disposed = false; 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _context.Dispose();
                }
                // Mark as disposed.
                _disposed = true; 
            }
        }

        public async Task<ApplicationUser?> FindByEmailAsync(string normalizedEmail,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(normalizedEmail))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(normalizedEmail));
            }

            return await _context.Users.SingleOrDefaultAsync(u => u.NormalizedEmail!.Equals(normalizedEmail), cancellationToken);
        }

        public async Task<ApplicationUser?> FindByIdAsync(string? userId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("UserId cannot be null or whitespace.", nameof(userId));
            }

            if (!Guid.TryParse(userId, out Guid idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(userId));
            }

            return await _context.Users.SingleOrDefaultAsync(u => u.Id.Equals(Guid.Parse(userId)), cancellationToken);
        }

        public async Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(loginProvider))
            {
                throw new ArgumentException("LoginProvider cannot be null or whitespace.", nameof(loginProvider));
            }

            if (string.IsNullOrWhiteSpace(providerKey))
            {
                throw new ArgumentException("ProviderKey cannot be null or whitespace.", nameof(providerKey));
            }

            var query = from userLogin in _context.UserLogins
                        where userLogin.LoginProvider.Equals(loginProvider)
                        where userLogin.ProviderKey.Equals(providerKey)
                        join user in _context.Users on userLogin.UserId equals user.Id
                        select user;

            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<ApplicationUser?> FindByNameAsync(string normalizedUserName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            if (string.IsNullOrWhiteSpace(normalizedUserName))
            {
                throw new ArgumentException("UserName cannot be null or whitespace.", nameof(normalizedUserName));
            }

            return await _context.Users.SingleOrDefaultAsync(u => u.NormalizedUserName!.Equals(normalizedUserName), cancellationToken);
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.AccessFailedCount);
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user,
              CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await _context.UserClaims
                .Where(uc => uc.UserId == user.Id)
                .Select(s => s.ToClaim())
                .ToListAsync(cancellationToken);
        }

        public Task<string?> GetEmailAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.EmailConfirmed);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.LockoutEnd);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            var appUserLogin = await _context.UserLogins
                .Where(ul => ul.UserId == user.Id)
                .Select(ul => new UserLoginInfo(ul.LoginProvider, ul.ProviderKey, ul.ProviderDisplayName))
                .ToListAsync(cancellationToken);

            return appUserLogin;
        }

        public Task<string?> GetNormalizedEmailAsync(ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string?> GetNormalizedUserNameAsync(ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string?> GetPasswordHashAsync(ApplicationUser user,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.PasswordHash);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            var query = from userRole in _context.UserRoles
                        where userRole.UserId.Equals(user.Id)
                        join role in _context.Roles on userRole.RoleId equals role.Id
                        select role.Name;

            return await query.ToListAsync(cancellationToken);
        }

        public Task<string?> GetSecurityStampAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.SecurityStamp);
        }
        
        public Task<string> GetUserIdAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.Id.ToString());
        }

        public Task<string?> GetUserNameAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(user.UserName);
        }

        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(claim);

            var users = from user in _context.Users
                        where _context.UserClaims.Any(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value)
                        select user;
            return await users.ToListAsync(cancellationToken);
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleName);

            var query = from user in _context.Users
                        join role in _context.Roles on user.Id equals role.Id
                        where role.Name == roleName
                        select user;

            return await query.ToListAsync(cancellationToken);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            user.AccessFailedCount += 1;
            return Task.FromResult(user.AccessFailedCount);
        }

        public async Task<bool> IsConfirmedAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            ArgumentNullException.ThrowIfNull(manager);
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(await manager.IsEmailConfirmedAsync(user));
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(roleName));
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name!.Equals(roleName), cancellationToken);

            if (role != null)
            {
                var userId = user.Id;
                var roleId = role.Id;
                return await _context.UserRoles.AnyAsync(ur => ur.RoleId.Equals(roleId) && ur.UserId.Equals(userId), cancellationToken);
            }
            return false;
        }

        public async Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(claims);

            foreach (var claim in claims)
            {
                var claimDb =
                    await _context.UserClaims.SingleOrDefaultAsync(
                            uc => uc.ClaimType == claim.Type && uc.ClaimValue == claim.Value && uc.UserId == user.Id, cancellationToken);

                if (claimDb != null)
                {
                    _context.UserClaims.Remove(claimDb);
                }

            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(roleName));
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, cancellationToken);
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(r => r.UserId == user.Id && r.RoleId == role!.Id, cancellationToken);

            _context.UserRoles.Remove(userRole!);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(loginProvider))
            {
                throw new ArgumentException("LoginProvider cannot be null or whitespace.", nameof(loginProvider));
            }
            if (string.IsNullOrWhiteSpace(providerKey))
            {
                throw new ArgumentException("ProviderKey cannot be null or whitespace.", nameof(providerKey));
            }

            var userLoginInDB = await _context.UserLogins.FindAsync(loginProvider, providerKey, cancellationToken);

            if (userLoginInDB != null)
            {
                _context.UserLogins.Remove(userLoginInDB);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(claim);
            ArgumentNullException.ThrowIfNull(newClaim);

            var instance = await _context.UserClaims.SingleOrDefaultAsync(
                            uc => uc.ClaimType!.Equals(claim.Type) && uc.ClaimValue!.Equals(claim.Value) && uc.UserId == user.Id,
                            cancellationToken);

            if (instance != null)
            {
                var newInstace = new ApplicationUserClaim()
                {
                    UserId = user.Id,
                    ClaimType = newClaim.Type,
                    ClaimValue = newClaim.Value
                };

                _context.UserClaims.Remove(instance);

                await _context.UserClaims.AddAsync(newInstace, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public Task ResetAccessFailedCountAsync(ApplicationUser user,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            user.AccessFailedCount = 0;
            return Task.CompletedTask;
        }

        public Task SetEmailAsync(ApplicationUser user, string? email,
              CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }

            user.Email = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(confirmed);

            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(enabled);

            user.LockoutEnabled = enabled;
            return Task.CompletedTask;
        }

        public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(lockoutEnd);

            user.LockoutEnd = lockoutEnd;
            return Task.CompletedTask;
        }

        public Task SetNormalizedEmailAsync(ApplicationUser user, string? normalizedEmail,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            
            if (string.IsNullOrWhiteSpace(normalizedEmail))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(normalizedEmail));
            }

            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            
            if (string.IsNullOrWhiteSpace(normalizedName))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(normalizedName));
            }

            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
           
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("Password hash cannot be null or whitespace.", nameof(passwordHash));
            }

            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            
            if (string.IsNullOrWhiteSpace(stamp))
            {
                throw new ArgumentException("Stamp cannot be null or whitespace.", nameof(stamp));
            }

            user.SecurityStamp = stamp;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(ApplicationUser user, string? userName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(userName));
            }

            user.UserName = userName;
            return Task.CompletedTask;
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
