using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationRoleClaimStore(IdentityAppDBContext context) : ApplicationRoleStore(context), IRoleClaimStore<ApplicationRole>
    {

        private readonly IdentityAppDBContext context = context;

        public async Task AddClaimAsync(ApplicationRole role, Claim claim,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);
            ArgumentNullException.ThrowIfNull(claim);

            var claimInDb = await context.RoleClaims.FindAsync(claim, cancellationToken);

            if (claimInDb == null)
            {
                var instance = new ApplicationRoleClaim()
                {
                    RoleId = role.Id,
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value
                };
                
                await context.RoleClaims.AddAsync(instance, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationRole role,
           CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);

            return await context.RoleClaims.Where(c => c.RoleId == role.Id)
                .Select(c => c.ToClaim())
                .ToListAsync(cancellationToken);
        }

        public async Task RemoveClaimAsync(ApplicationRole role, Claim claim,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(role);
            ArgumentNullException.ThrowIfNull(claim);

            var claimToRemove = await context.RoleClaims.SingleOrDefaultAsync(c =>
                c.RoleId == role.Id && c.ClaimValue == claim.Value && c.ClaimType == claim.Type, cancellationToken);

            if (claimToRemove != default)
            {
                context.RoleClaims.Remove(claimToRemove);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
