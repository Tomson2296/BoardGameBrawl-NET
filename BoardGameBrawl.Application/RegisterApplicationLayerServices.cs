using AutoMapper;
using BoardGameBrawl.Application.Profiles;
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
                cfg.AddProfile<MappingProfile>();
            });
            AutomapperConfig.AssertConfigurationIsValid();
            AutomapperConfig.CreateMapper();

            // Add Mediatr framework to application

            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return Task.FromResult(services);
        }
    }
}
