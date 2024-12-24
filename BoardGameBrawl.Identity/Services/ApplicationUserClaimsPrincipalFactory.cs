#nullable disable
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
    public class ApplicationUserClaimsPrincipalfactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public ApplicationUserClaimsPrincipalfactory(UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : 
            base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var identity = (ClaimsIdentity)principal.Identity;

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                identity.AddClaims(new[] {
                    new Claim("FirstName", user.FirstName)
                });
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                identity.AddClaims(new[] {
                    new Claim("LastName", user.LastName)
                });
            }

            if (!string.IsNullOrWhiteSpace(user.BGGUsername))
            {
                identity.AddClaims(new[] {
                    new Claim("BGGUsername", user.BGGUsername)
                });
            }

            return await Task.FromResult(identity);
        }
    }
}
