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
    public class ApplicationUserClaimStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserClaimStore<ApplicationUser>
    {
        private readonly IdentityAppDBContext context = context;
        public async Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims,
             CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(claims);

            foreach (var claim in claims)
            {
                var claimInDb = await context.UserClaims.FirstOrDefaultAsync(uc => uc.UserId == user.Id &&
                    uc.ClaimType!.Equals(claim.Type) && uc.ClaimValue!.Equals(claim.Value), cancellationToken);

                if (claimInDb == null)
                {
                    var instance = new ApplicationUserClaim()
                    {
                        UserId = user.Id,
                        ClaimType = claim.Type,
                        ClaimValue = claim.Value
                    };
                    
                    await context.UserClaims.AddAsync(instance, cancellationToken);
                }
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user,
              CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);

            return await context.UserClaims
                .Where(uc => uc.UserId == user.Id)
                .Select(s => s.ToClaim())
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(claim);

            var users = from user in context.Users
                        where context.UserClaims.Any(c => c.ClaimType == claim.Type && c.ClaimValue == claim.Value)
                        select user;
            return await users.ToListAsync(cancellationToken);
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
                    await context.UserClaims.SingleOrDefaultAsync(
                            uc => uc.ClaimType == claim.Type && uc.ClaimValue == claim.Value && uc.UserId == user.Id, cancellationToken);

                if (claimDb != null)
                {
                    context.UserClaims.Remove(claimDb);
                }
                    
            }
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(claim);
            ArgumentNullException.ThrowIfNull(newClaim);

            var instance = await context.UserClaims.SingleOrDefaultAsync(
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

                context.UserClaims.Remove(instance);
                
                await context.UserClaims.AddAsync(newInstace, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
