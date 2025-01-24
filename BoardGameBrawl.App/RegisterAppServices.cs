#nullable disable
using BoardGameBrawl.Persistence;
using BoardGameBrawl.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BoardGameBrawl.Application;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Application.Services;
using BoardGameBrawl.Persistence.Stores;

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
                           b => b.MigrationsAssembly(typeof(MainAppDBContext).Assembly.FullName)));

            builder.Services.AddDbContext<IdentityAppDBContext>(options =>
                             options.UseSqlServer(configuration.GetConnectionString("IdentityAppDBConnection"),
                             b => b.MigrationsAssembly(typeof(IdentityAppDBContext).Assembly.FullName)));

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
            
            builder.Services.RegisterPersistenceServices();

            builder.Services.RegisterApplicationServices();

            builder.Services.RegisterInfraServices();

            return builder;
        }
    }
}
