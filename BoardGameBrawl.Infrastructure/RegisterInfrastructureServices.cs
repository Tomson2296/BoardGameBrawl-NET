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
            services.TryAddTransient<IImageStream, ImageStream>();

            services.TryAddScoped<IMailKitEmailSender, MailKitEmailSender>();

            services.TryAddScoped<ApplicationUserDatabaseSeed>();

            services.TryAddScoped<BoardgamesDatabaseSeed>();

            return Task.FromResult(services);
        }
    }
}
