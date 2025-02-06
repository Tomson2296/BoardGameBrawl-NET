#nullable disable

using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class UserRolesModel : AdminPageModel
    {
        public UserManager<ApplicationUser> _userManager;
        public RoleManager<ApplicationRole> _roleManager;
        
        public UserRolesModel(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IDictionary<string, int> Roles { get; set; } = new Dictionary<string, int>();

        public async Task<IActionResult> OnGetAsync()
        {
            await GetApplicationRolesAsync(Roles);
            return Page();
        }

        private async Task GetApplicationRolesAsync(IDictionary<string, int> roles)
        {
            var applicationRoles = await _roleManager.Roles.ToArrayAsync();
            
            foreach (var role in applicationRoles)
            {
                var users = await _userManager.GetUsersInRoleAsync(role.Name);
                roles.Add(role.Name, users.Count);
            }
        }

        public async Task<IActionResult> OnPostDeleteFromListAsync(string role)
        {
            ApplicationRole idRole = await _roleManager.FindByNameAsync(role);
            var result = await _roleManager.DeleteAsync(idRole);

            if (result.Succeeded)
            {
                StatusMessage = "Role has been deleted successfully.";
                return RedirectToPage();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    StatusMessage = "Error - Role has not been deleted. Try again.";
                    ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddToListAsync(string role)
        {
            ApplicationRole newRole = new()
            {
                Name = role
            };

            IdentityResult result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
                StatusMessage = "Role successfully added.";
                return RedirectToPage();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    StatusMessage = "Error - Role have not been added. Try again.";
                    ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }
            }
            return Page();
        }
    }
}
