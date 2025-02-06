#nullable disable

using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Admin.Pages
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

        public IList<string> CurrentRoles { get; set; }

        public IList<string> AvailableRoles { get; set; }

        public ApplicationUser TargetUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToPage("ManageUsers");
            }

            TargetUser = await _userManager.FindByIdAsync(Id);

            if (TargetUser == null)
            {
                return NotFound();
            }

            CurrentRoles = await _userManager.GetRolesAsync(user);

            AvailableRoles = _roleManager.Roles.Select(r => r.Name)
                .Where(r => !CurrentRoles.Contains(r)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteFromListAsync(string role)
        {
            ApplicationRole idRole = await _roleManager.FindByNameAsync(role);
            var result = await _roleManager.DeleteAsync(idRole);

            if (result.Succeeded)
            {
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

            var result = await _roleManager.CreateAsync(newRole);
            if (result.Succeeded)
            {
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
            var result = await _userManager.RemoveFromRoleAsync(user, role);

            if (result.Succeeded)
            {
                StatusMessage = "User has been removed from chosen role successfully";
                return RedirectToPage();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    StatusMessage = "Error - User has not been removed from chosen role";
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
                var result = await _userManager.AddToRoleAsync(user, role);
               
                if (result.Succeeded)
                {
                    StatusMessage = "User has been added to chosen role successfully";
                    return RedirectToPage();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        StatusMessage = "Error - User has not been added to chosen role";
                        ModelState.AddModelError(string.Empty, error.Description);
                        return Page();
                    }
                }
            }
            return Page();
        }
    }
}
