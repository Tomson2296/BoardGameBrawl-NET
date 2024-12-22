using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Services;
using BoardGameBrawl.Identity.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity.Managers
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore store, 
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
            ApplicationLookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, 
            ILogger<RoleManager<ApplicationRole>> logger) : 
            base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
