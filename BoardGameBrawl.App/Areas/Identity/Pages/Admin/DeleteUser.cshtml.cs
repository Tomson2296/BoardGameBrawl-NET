#nullable disable

using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
{
    public class DeleteUserModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public bool IsAdmin { get; set; }
        
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
                return RedirectToPage("./ListUsers");
            }

            TargetUser = await _userManager.FindByIdAsync(Id);

            if (TargetUser == null)
            {
                return NotFound();
            }

            IsAdmin = await _userManager.IsInRoleAsync(TargetUser, "Administrator");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Id) && ModelState.IsValid)
            {
                TargetUser = await _userManager.FindByIdAsync(Id);
                IdentityResult result = await _userManager.DeleteAsync(TargetUser);

                if (result.Succeeded)
                {
                    return RedirectToPage("ManageUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return Page();
            }
            return Page();
        }
    }
}
