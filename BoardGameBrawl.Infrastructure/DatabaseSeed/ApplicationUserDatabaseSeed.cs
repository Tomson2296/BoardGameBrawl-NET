using BoardGameBrawl.Identity;
using BoardGameBrawl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class ApplicationUserDatabaseSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IdentityAppDBContext _DBContext;

        public ApplicationUserDatabaseSeed(
            UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationRole> _roleManager,
            IdentityAppDBContext dBContext)
        {
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._DBContext = dBContext;
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
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(admin);
            await _userManager.AddPasswordAsync(admin, "Admin123!");

            if (await _DBContext.Roles.AnyAsync(r => r.Name!.Equals("Administrator")))
            {
                return;
            }
            else
            {
                var role1 = Activator.CreateInstance<ApplicationRole>();
                role1.Name = "Administrator";

                var role2 = Activator.CreateInstance<ApplicationRole>();
                role2.Name = "Moderator";

                var role3 = Activator.CreateInstance<ApplicationRole>();
                role3.Name = "Host";

                var role4 = Activator.CreateInstance<ApplicationRole>();
                role4.Name = "User";

                await _roleManager.CreateAsync(role1);
                await _roleManager.CreateAsync(role2);
                await _roleManager.CreateAsync(role3);
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
                    string line = reader.ReadLine();
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
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(entry);
                    await _userManager.AddPasswordAsync(entry, "Zaq1@WSX");
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