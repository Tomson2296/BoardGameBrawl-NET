using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationRoleStore(IdentityAppDBContext context) : IRoleStore<ApplicationRole>
    {
        private readonly IdentityAppDBContext _context = context;

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ApplicationRole?> FindByIdAsync(string roleId, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleId);

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
            ArgumentNullException.ThrowIfNullOrWhiteSpace(normalizedRoleName);

            return await _context!.Roles.SingleOrDefaultAsync(u => u.NormalizedName!.Equals(normalizedRoleName), cancellationToken);
        }

        public async Task<string?> GetNormalizedRoleNameAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return await Task.FromResult(role.NormalizedName);
        }

        public async Task<string> GetRoleIdAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return await Task.FromResult(role.Id.ToString());
        }

        public async Task<string?> GetRoleNameAsync(ApplicationRole role, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return await Task.FromResult(role.Name);
        }

        public async Task SetNormalizedRoleNameAsync(ApplicationRole role, string? normalizedName, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(normalizedName);

            role.NormalizedName = normalizedName;
            await Task.FromResult<object>(null!);
        }

        public async Task SetRoleNameAsync(ApplicationRole role, string? roleName, 
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(roleName);

            role.Name = roleName;
            await Task.FromResult<object>(null!);
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
