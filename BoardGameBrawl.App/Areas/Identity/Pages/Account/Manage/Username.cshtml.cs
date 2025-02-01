#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account.Manage
{
    public class UsernameModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;

        public UsernameModel(UserManager<ApplicationUser> userManager, 
           SignInManager<ApplicationUser> signInManager,
           IApplicationUserStore<ApplicationUser> userStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "New username")]
            public string NewUsername { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var username = await _userStore.GetUserNameAsync(user, CancellationToken.None);
            Username = username;

            Input = new InputModel
            {
                NewUsername = username,
            };
        }

        public async Task<IActionResult> OnPostChangeUsernameAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var usernameExists = await _userManager.ChangeApplicationUsernameAsync(_userStore, user, Input.NewUsername);
            if (usernameExists)
            {
                StatusMessage = "Error: Username already exists in database.";
                return RedirectToPage();
            }
            else
            {
                await _userStore.SetUserNameAsync(user, Input.NewUsername, CancellationToken.None);
                await _userManager.UpdateAsync(user);

                // change user claim 
                var existingClaims = await _userManager.GetClaimsAsync(user);
                var usernameClaim = existingClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                if (usernameClaim == null)
                {
                    StatusMessage = "Error: Claim has not been found";
                    return RedirectToPage();
                }
                else
                {
                    Claim newClaim = new(ClaimTypes.Name, Input.NewUsername);
                    await _userManager.ReplaceClaimAsync(user, usernameClaim, newClaim);

                    StatusMessage = "Username has been changed";
                    await _signInManager.RefreshSignInAsync(user);
                    return RedirectToPage();
                }
            }
        }
    }
}
