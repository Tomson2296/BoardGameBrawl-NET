using BoardGameBrawl.Infrastructure.DatabaseSeed;
using BoardGameBrawl.Infrastructure.EmailSender;
using BoardGameBrawl.Infrastructure.Services.BGGService;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameBrawl.Infrastructure
{
    public static class RegisterInfrastructureServices
    {
        public static Task<IServiceCollection> RegisterInfraServices(this IServiceCollection services)
        {
            services.AddScoped<IImageStream, ImageStream>();

            services.AddScoped<IMailKitEmailSender, MailKitEmailSender>();

            services.AddScoped<ApplicationUserDatabaseSeed>();

            services.AddScoped<BoardgamesDatabaseSeed>();

            // Register BGGService
            services.AddTransient<IBGGService, BGGService>();
         
            return Task.FromResult(services);
        }
    }
}
