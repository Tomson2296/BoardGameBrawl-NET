using AutoMapper;
using BoardGameBrawl.Application.Profiles;
using BoardGameBrawl.Application.Services;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BoardGameBrawl.Application
{
    public static class RegisterApplicationLayerServices
    {
        public static Task<IServiceCollection> RegisterApplicationServices(this IServiceCollection services)
        {
            // Add Automapper framework to aplication

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var AutomapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<ApplicationUserMappingProfile>();
                cfg.AddProfile<PlayerMappingProfile>();
                cfg.AddProfile<BoardgameMappingProfile>();
                cfg.AddProfile<GroupMappingProfile>();
            });
            AutomapperConfig.AssertConfigurationIsValid();
            AutomapperConfig.CreateMapper();

            // Add Mediatr framework to application

            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register Custom Identity Services
            
            services.AddScoped<ILookupNormalizer, ApplicationLookupNormalizer>();
            //services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IPasswordHasher<ApplicationUser>, ApplicationPasswordHasher>();

            return Task.FromResult(services);
        }
    }
}
