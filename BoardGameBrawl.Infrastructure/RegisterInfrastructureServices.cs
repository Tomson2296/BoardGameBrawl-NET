using BoardGameBrawl.Infrastructure.EmailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure
{
    public static class RegisterInfrastructureServices
    {
        public static Task<IServiceCollection> RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEmailSender, MailKitEmailSender>();

            return Task.FromResult(services);
        }
    }
}
