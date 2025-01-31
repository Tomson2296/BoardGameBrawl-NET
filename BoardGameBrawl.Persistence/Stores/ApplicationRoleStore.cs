using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BoardGameBrawl.Persistence.Stores
{
    public class ApplicationRoleStore : IApplicationRoleStore<ApplicationRole>
    {
        private readonly IdentityAppDBContext _context;
        public ApplicationRoleStore(IdentityAppDBContext context)
        {
            _context = context;
        }

        public async Task AddClaimAsync(ApplicationRole role, Claim claim,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);
            ArgumentNullException.ThrowIfNull(claim);

            var claimInDb = await _context.RoleClaims.FindAsync(claim, cancellationToken);

            if (claimInDb == null)
            {
                var instance = new ApplicationRoleClaim()
                {
                    RoleId = role.Id,
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value
                };

                await _context.RoleClaims.AddAsync(instance, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            if (!_context.Roles.Contains(role))
            {
                await _context.Roles.AddAsync(role, cancellationToken);
                var affectedRows = await _context.SaveChangesAsync(cancellationToken);
                return affectedRows > 0
                        ? IdentityResult.Success
                        : IdentityResult.Failed(new IdentityError() { Description = $"Could not create role {role.Id}." });
            }
            else
            {
                return IdentityResult.Failed(new IdentityError() { Description = $"Role {role.Id} already exists in database - creation process failed." });
            }
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            var roleInDB = await _context.Roles.FindAsync(role, cancellationToken);

            if (roleInDB == null)
            {
                return IdentityResult.Failed(new IdentityError() { Description = $"Could not find role to deletion process: {role.Id}." });
            }
            else
            {
                _context.Roles.Remove(roleInDB);
                var affectedRows = await _context.SaveChangesAsync(cancellationToken);
                return affectedRows > 0
                ? IdentityResult.Success
                        : IdentityResult.Failed(new IdentityError() { Description = $"Could not delete role: {role.Id}." });
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

        public async Task<ApplicationRole?> FindByIdAsync(string roleId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(roleId))
            {
                throw new ArgumentException("RoleId cannot be null or whitespace.", nameof(roleId));
            }

            if (!Guid.TryParse(roleId, out Guid idGuid))
            {
                throw new ArgumentException("Not a valid Guid id", nameof(roleId));
            }

            return await _context!.Roles.SingleOrDefaultAsync(u => u.Id.Equals(Guid.Parse(roleId)), cancellationToken);
        }

        public async Task<ApplicationRole?> FindByNameAsync(string normalizedRoleName, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrWhiteSpace(normalizedRoleName))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(normalizedRoleName));
            }

            return await _context!.Roles.SingleOrDefaultAsync(u => u.NormalizedName!.Equals(normalizedRoleName), cancellationToken);
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationRole role,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return await _context.RoleClaims.Where(c => c.RoleId == role.Id)
                .Select(c => c.ToClaim())
                .ToListAsync(cancellationToken);
        }

        public Task<string?> GetNormalizedRoleNameAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return Task.FromResult(role.Id.ToString());
        }

        public Task<string?> GetRoleNameAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return Task.FromResult(role.Name);
        }

        public async Task RemoveClaimAsync(ApplicationRole role, Claim claim,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);
            ArgumentNullException.ThrowIfNull(claim);

            var claimToRemove = await _context.RoleClaims.SingleOrDefaultAsync(c =>
                c.RoleId == role.Id && c.ClaimValue == claim.Value && c.ClaimType == claim.Type, cancellationToken);

            if (claimToRemove != default)
            {
                _context.RoleClaims.Remove(claimToRemove);
                await _context .SaveChangesAsync(cancellationToken);
            }
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string? normalizedName, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            if (string.IsNullOrWhiteSpace(normalizedName))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(normalizedName));
            }

            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(ApplicationRole role, string? roleName, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.", nameof(roleName));
            }

            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            _context.Roles.Update(role);
            var affectedRows = await _context.SaveChangesAsync(cancellationToken);
            return affectedRows > 0
            ? IdentityResult.Success
                    : IdentityResult.Failed(new IdentityError() { Description = $"Could not update role: {role.Id}." });
        }
    }
}
