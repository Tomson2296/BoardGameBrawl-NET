using BoardGameBrawl.Identity;
using BoardGameBrawl.Infrastructure.DatabaseSeed;
using BoardGameBrawl.Infrastructure.EmailSender;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure
{
    public static class RegisterInfrastructureServices
    {
        public static Task<IServiceCollection> RegisterInfraServices(this IServiceCollection services)
        {
            services.TryAddTransient<IMailKitEmailSender, MailKitEmailSender>();

            services.TryAddTransient<ApplicationUserDatabaseSeed>();

            services.TryAddTransient<BoardgamesDatabaseSeed>();

            return Task.FromResult(services);
        }
    }
}
