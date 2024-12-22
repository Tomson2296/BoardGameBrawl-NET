using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Stores
{
    public class ApplicationUserConfirmationStore(IdentityAppDBContext context) : ApplicationUserStore(context), IUserConfirmation<ApplicationUser>
    {
        public async Task<bool> IsConfirmedAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            ArgumentNullException.ThrowIfNull(manager);
            ArgumentNullException.ThrowIfNull(user);

            return await Task.FromResult(user.EmailConfirmed);
        }
    }
}
