using AutoMapper;
using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Profiles;
using BoardGameBrawl.Identity.Services;
using BoardGameBrawl.Identity.Stores;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BoardGameBrawl.Identity
{
    public static class RegisterIdentityServices
    {
        public static Task<IServiceCollection> RegisterCustomIdentityServices(this IServiceCollection services)
        {
            // Add Automapper for mapping Identity entities
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var AutomapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<IdentityMappingProfile>();
            });
            AutomapperConfig.AssertConfigurationIsValid();
            AutomapperConfig.CreateMapper();

            // Register Custom Identity Services
            services.AddScoped<ILookupNormalizer, ApplicationLookupNormalizer>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IApplicationPasswordHasher<ApplicationUser>, ApplicationPasswordHasher>();

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
