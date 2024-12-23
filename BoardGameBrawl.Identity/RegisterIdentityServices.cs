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

            // Register Custom Identity Stores
            services.AddScoped<ApplicationUserStore>();
            services.AddScoped<ApplicationRoleStore>();
           
            //services.AddScoped<ApplicationUserRoleStore>();
            //services.AddScoped<ApplicationUserClaimStore>();
            //services.AddScoped<ApplicationUserConfirmationStore>();
            //services.AddScoped<ApplicationUserEmailStore>();
            //services.AddScoped<ApplicationUserLockoutStore>();
            //services.AddScoped<ApplicationUserLoginStore>();
            //services.AddScoped<ApplicationUserPasswordStore>();
            //services.AddScoped<ApplicationUserSecurityStampStore>();
           
            //services.AddScoped<ApplicationRoleClaimStore>();

            return Task.FromResult(services);   
        }
    }
}
