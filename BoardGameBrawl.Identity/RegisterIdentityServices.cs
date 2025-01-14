using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Services;
using BoardGameBrawl.Identity.Stores;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<ILookupNormalizer, ApplicationLookupNormalizer>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IPasswordHasher<ApplicationUser>, ApplicationPasswordHasher>();

            // Register Custom Identity Stores
            services.AddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserEmailStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserClaimStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserConfirmation<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserLockoutStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserLoginStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserPasswordStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserRoleStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<IUserSecurityStampStore<ApplicationUser>, ApplicationUserStore>();

            services.AddScoped<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
            services.AddScoped<IRoleClaimStore<ApplicationRole>, ApplicationRoleStore>();
           
            return Task.FromResult(services);   
        }
    }
}
