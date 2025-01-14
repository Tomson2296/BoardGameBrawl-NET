using BoardGameBrawl.Infrastructure.DatabaseSeed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameBrawl.Infrastructure
{
    public static class ApplicationDBSeeder
    {
        public static async void SeedSQLDatabases(this IApplicationBuilder app)
        {
            try
            {
                using(var scope = app.ApplicationServices.CreateScope())
                {
                    //var dbContext = services.GetRequiredService<IdentityDbContext>();
                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    
                    var serviceProvider = scope.ServiceProvider;
                    var appUserSeed = serviceProvider.GetRequiredService<ApplicationUserDatabaseSeed>();
                    await appUserSeed.SeedDatabaseAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured during the process of seeding sql database: " + ex.Message);
            }
        }
    }
}
