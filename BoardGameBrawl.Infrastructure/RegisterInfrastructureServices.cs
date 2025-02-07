using BoardGameBrawl.Infrastructure.DatabaseSeed;
using BoardGameBrawl.Infrastructure.EmailSender;
using BoardGameBrawl.Infrastructure.Services.BGGService;
using BoardGameBrawl.Infrastructure.Services.ImageDownloader;
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

            //Register ImageDownloader Service
            services.AddHttpClient<IImageDownloaderService, ImageDownloaderService>(client =>
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("BoardGameBrawl-NET");
            });
         
            return Task.FromResult(services);
        }
    }
}
