using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Managers;
using BoardGameBrawl.Identity.Services;
using BoardGameBrawl.Identity.Stores;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Identity
{
    public static class RegisterIdentityServices
    {
        public static Task<IServiceCollection> RegisterCustomIdentityServices(this IServiceCollection services)
        {
            // Register Custom Identity Services

            services.TryAddScoped<ILookupNormalizer, ApplicationLookupNormalizer>();

            // Register Custom Identity Stores

            services.TryAddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.TryAddScoped<IUserEmailStore<ApplicationUser>, ApplicationUserEmailStore>();
            services.TryAddScoped<IUserClaimStore<ApplicationUser>, ApplicationUserClaimStore>();
            services.TryAddScoped<IUserPasswordStore<ApplicationUser>, ApplicationUserPasswordStore>();
            services.TryAddScoped<IUserRoleStore<ApplicationUser>, ApplicationUserRoleStore>();
            services.TryAddScoped<IUserSecurityStampStore<ApplicationUser>, ApplicationUserSecurityStampStore>();
            services.TryAddScoped<IUserConfirmation<ApplicationUser>, ApplicationUserConfirmationStore>();
            services.TryAddScoped<IUserLoginStore<ApplicationUser>, ApplicationUserLoginStore>();
            services.TryAddScoped<IUserLockoutStore<ApplicationUser>, ApplicationUserLockoutStore>();

            services.TryAddScoped<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
            services.TryAddScoped<IRoleClaimStore<ApplicationRole>, ApplicationRoleClaimStore>();

            return Task.FromResult(services);   
        }
    }
}
