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

namespace BoardGameBrawl.App
{
    public static class RegisterAppServices
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddHttpContextAccessor();

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
                    client.Timeout = TimeSpan.FromSeconds(30);
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new SocketsHttpHandler
                    {
                        // Preventing Connection Pooling
                        MaxConnectionsPerServer = 100,
                        PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1),
                        // Force DNS Refresh
                        PooledConnectionLifetime = TimeSpan.FromMinutes(5),
                        AutomaticDecompression = DecompressionMethods.All,
                        UseCookies = false
                    };
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            builder.Services.RegisterPersistenceServices();

            builder.Services.RegisterApplicationServices();

            builder.Services.RegisterInfraServices();

            return builder;
        }
    }
}
