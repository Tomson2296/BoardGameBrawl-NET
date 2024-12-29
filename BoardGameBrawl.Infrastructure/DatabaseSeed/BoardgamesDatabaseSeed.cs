using BoardGameBrawl.Identity;
using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Infrastructure.DatabaseSeed
{
    public class BoardgamesDatabaseSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IdentityAppDBContext _context;

        public BoardgamesDatabaseSeed(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IdentityAppDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedDatabaseAsync(MainAppDBContext context)
        {
            await _context.Database.EnsureCreatedAsync();



            await _context.SaveChangesAsync();
        }
    }
}
