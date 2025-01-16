using BoardGameBrawl.Identity;
using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Services;
using BoardGameBrawl.Identity.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class ApplicationUserDatabaseSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IApplicationPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IdentityAppDBContext _DBContext;

        public ApplicationUserDatabaseSeed(UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager,
            IUserStore<ApplicationUser> userStore,
            IApplicationPasswordHasher<ApplicationUser> passwordHasher, 
            IdentityAppDBContext dBContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _passwordHasher = passwordHasher;
            _DBContext = dBContext;
        }

        public async Task SeedDatabaseAsync()
        {
            await _DBContext.Database.EnsureCreatedAsync();

            if (await _DBContext.Users.AnyAsync(u => u.UserName!.Equals("admin")))
            {
                return;
            }

            ApplicationUser admin = new()
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserCreatedDate = DateOnly.FromDateTime(DateTime.UtcNow)
            };
            await _userManager.CreateAsync(admin);
           
            string[] passwordCredentials = _passwordHasher.HashPasswordExtended(admin, "Admin123!");
            await _userStore.SetUserPasswordSaltAsync(admin, passwordCredentials[0]);
            await _userStore.SetUserPasswordHashAsync(admin, passwordCredentials[1]);

            if (await _DBContext.Roles.AnyAsync(r => r.Name!.Equals("Administrator")))
            {
                return;
            }
            else
            {
                var role1 = Activator.CreateInstance<ApplicationRole>();
                await _roleManager.SetRoleNameAsync(role1, "Administrator");
                await _roleManager.CreateAsync(role1);

                var role2 = Activator.CreateInstance<ApplicationRole>();
                await _roleManager.SetRoleNameAsync(role2, "Moderator");
                await _roleManager.CreateAsync(role2);

                var role3 = Activator.CreateInstance<ApplicationRole>();
                await _roleManager.SetRoleNameAsync(role3, "Host");
                await _roleManager.CreateAsync(role3);

                var role4 = Activator.CreateInstance<ApplicationRole>();
                await _roleManager.SetRoleNameAsync(role4, "User");
                await _roleManager.CreateAsync(role4);

                // Add all roles to Admin account

                await _userManager.AddToRoleAsync(admin, "Administrator");
                await _userManager.AddToRoleAsync(admin, "Moderator");
                await _userManager.AddToRoleAsync(admin, "Host");
                await _userManager.AddToRoleAsync(admin, "User");

                List<Claim> adminClaims =
                [
                    new (ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new (ClaimTypes.Name, "admin"),
                    new (ClaimTypes.Email, "admin@admin.com"),
                    new (ClaimTypes.Role, "Administrator"),
                    new (ClaimTypes.Role, "Moderator"),
                    new (ClaimTypes.Role, "Host"),
                    new (ClaimTypes.Role, "User")
                ];

                await _userManager.AddClaimsAsync(admin, adminClaims);
            }

            string catalog = Directory.GetCurrentDirectory().ToString();
            string filePath = catalog + "\\Resources\\user_data.csv";
            Console.WriteLine(filePath);

            bool firstLine = true;

            using (StreamReader reader = new(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    string[] values = line!.Split(',');

                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    string Username = values[0];
                    string FirstName = values[1];
                    string LastName = values[2];
                    string Email = values[3];

                    ApplicationUser entry = new()
                    {
                        Id = Guid.NewGuid(),
                        UserName = Username,
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email,
                        EmailConfirmed = true,
                        UserCreatedDate = DateOnly.FromDateTime(DateTime.UtcNow)
                    };
                    await _userManager.CreateAsync(entry);

                    passwordCredentials = _passwordHasher.HashPasswordExtended(entry, "Zaq1@WSX");
                    await _userStore.SetUserPasswordSaltAsync(entry, passwordCredentials[0]);
                    await _userStore.SetUserPasswordHashAsync(entry, passwordCredentials[1]);
                   
                    await _userManager.AddToRoleAsync(entry, "User");

                    List<Claim> userClaims =
                    [
                        new (ClaimTypes.NameIdentifier, entry.Id.ToString()),
                        new (ClaimTypes.Name, entry.UserName),
                        new (ClaimTypes.Role, "User"),
                        new (ClaimTypes.Email, entry.Email)
                    ];
                    await _userManager.AddClaimsAsync(entry, userClaims);
                }
            }

            await _DBContext.SaveChangesAsync();
        }
    }
}