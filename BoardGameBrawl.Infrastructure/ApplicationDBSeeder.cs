using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Infrastructure.DatabaseSeed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure
{
    public static class ApplicationDBSeeder
    {
        public static async Task<IServiceProvider> SeedSQLDatabases(this IServiceProvider services)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));

            try
            {
                await using(var scope = services.CreateAsyncScope())
                {
                    var dbContext = services.GetRequiredService<IdentityDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    var appUserSeed = services.GetRequiredService<ApplicationUserDatabaseSeed>();
                    await appUserSeed.SeedDatabaseAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured during the process of seeding sql database: " + ex.Message);
            }

            return services;
        }
    }
}
