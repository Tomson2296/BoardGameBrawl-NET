#nullable disable

using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
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

        public class ViewUserModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
        }

        [TempData]
        public string StatusMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostDeleteFromListAsync(string role)
        {
            ApplicationRole idRole = await _roleManager.FindByNameAsync(role);
            IdentityResult result = await _roleManager.DeleteAsync(idRole);

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
