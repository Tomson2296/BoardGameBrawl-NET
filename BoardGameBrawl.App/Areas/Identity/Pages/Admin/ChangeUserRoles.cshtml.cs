#nullable disable

using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
{
    public class ChangeUserRolesModel : AdminPageModel
    {
        public UserManager<ApplicationUser> _userManager;
        public RoleManager<ApplicationRole> _roleManager;

        public ChangeUserRolesModel(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IList<string> CurrentRoles { get; set; } = new List<string>();

        public IList<string> AvailableRoles { get; set; } = new List<string>();

        private async Task SetRolesLists()
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            
            CurrentRoles = await _userManager.GetRolesAsync(user);
            
            AvailableRoles = _roleManager.Roles.Select(r => r.Name)
                .Where(r => !CurrentRoles.Contains(r)).ToList();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToPage("ManageUsers");
            }
            await SetRolesLists();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteFromListAsync(string role)
        {
            ApplicationRole idRole = await _roleManager.FindByNameAsync(role);
            IdentityResult result = await _roleManager.DeleteAsync(idRole);

            if (result.Succeeded)
            {
                await SetRolesLists();
                return RedirectToPage();
            }
            else
            {
                foreach (var error in result.Errors)
                {
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
                await SetRolesLists();
                return RedirectToPage();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteUserFromRoleAsync(string role)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            IdentityResult result = await _userManager.RemoveFromRoleAsync(user, role);

            if (result.Succeeded)
            {
                await SetRolesLists();
                return RedirectToPage();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return Page();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddUserToRoleAsync(string role)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);

            if (!await _userManager.IsInRoleAsync(user, role))
            {
                IdentityResult result = await _userManager.AddToRoleAsync(user, role);
               
                if (result.Succeeded)
                {
                    await SetRolesLists();
                    return RedirectToPage();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        return Page();
                    }
                }
            }
            return Page();
        }
    }
}
