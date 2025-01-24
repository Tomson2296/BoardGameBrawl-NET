using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BoardGameBrawl.Application.Services
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity principal = await base.GenerateClaimsAsync(user);

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                principal.AddClaim(new Claim("FirstName", user.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                principal.AddClaim(new Claim("LastName", user.LastName));
            }

            if (!string.IsNullOrWhiteSpace(user.BGGUsername))
            {
                principal.AddClaim(new Claim("BGGUsername", user.BGGUsername));
            }

            return principal;
        }
    }
}
