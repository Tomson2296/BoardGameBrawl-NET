using BoardGameBrawl.Infrastructure.DatabaseSeed;
using BoardGameBrawl.Infrastructure.EmailSender;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

            return Task.FromResult(services);
        }
    }
}
