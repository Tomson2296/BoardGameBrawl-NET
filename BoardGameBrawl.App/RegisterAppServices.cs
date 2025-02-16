#nullable disable
using BoardGameBrawl.Persistence;
using BoardGameBrawl.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BoardGameBrawl.Application;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Application.Services;
using BoardGameBrawl.Persistence.Stores;
using System.Net;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace BoardGameBrawl.App
{
    public static class RegisterAppServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSignalR();

            // Add services to the container.
            builder.Services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.RootDirectory = "/Main/Pages";
                });

            builder.Services.AddDbContext<MainAppDBContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("MainAppDBConnection"),
                           b => b.MigrationsAssembly(typeof(MainAppDBContext).Assembly.GetName().Name)));

            builder.Services.AddDbContext<IdentityAppDBContext>(options =>
                             options.UseSqlServer(configuration.GetConnectionString("IdentityAppDBConnection"),
                             b => b.MigrationsAssembly(typeof(IdentityAppDBContext).Assembly.GetName().Name)));

            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true; 

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.User.RequireUniqueEmail = true;

                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(120);
            })
                .AddEntityFrameworkStores<IdentityAppDBContext>()
                .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>()
                .AddUserStore<ApplicationUserStore>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
                .AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                })
                .AddCookie(options =>
                {
                    options.Cookie.Name = "ApplicationCookie";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = false;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;

                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;

                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                });

            builder.Services.AddHttpClient("BoardGameGeekClient")
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("https://boardgamegeek.com/");
                    client.DefaultRequestHeaders.Add("Accept", "application/xml");
                    client.Timeout = TimeSpan.FromSeconds(45);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new SocketsHttpHandler
                    {
                        // Preventing Connection Pooling
                        MaxConnectionsPerServer = 20,
                        PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),
                        // Force DNS Refresh
                        PooledConnectionLifetime = TimeSpan.FromMinutes(15),
                        AutomaticDecompression = DecompressionMethods.All,
                        UseCookies = false
                    };
                })
                .SetHandlerLifetime(Timeout.InfiniteTimeSpan)
                .AddPolicyHandler(GetRetryPolicy());

            builder.Services.RegisterPersistenceServices();

            builder.Services.RegisterApplicationServices();

            builder.Services.RegisterInfraServices();

            return builder;
        }

        private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            // Retry policy based on BoardGameGeek XML API v2 community guidelines
            return HttpPolicyExtensions
             .HandleTransientHttpError()
             .OrResult(msg => msg.StatusCode == HttpStatusCode.Accepted)
             .WaitAndRetryAsync(3, retryAttempt =>
                 TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
