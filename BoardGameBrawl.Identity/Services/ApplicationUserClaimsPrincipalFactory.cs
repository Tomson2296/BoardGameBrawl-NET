using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Services
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
