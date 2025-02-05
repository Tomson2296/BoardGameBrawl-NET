#nullable disable
using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
{
    public class ChangeUserClaimsModel : AdminPageModel
    {
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _singInManager;
        
        public ChangeUserClaimsModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        
        public ApplicationUser TargetUser { get; set; }

        public IList<Claim> Claims { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToPage("ManageUsers");
            }

            TargetUser = await _userManager.FindByIdAsync(Id);
            Claims = await _userManager.GetClaimsAsync(TargetUser);
            return Page();
        }

        public async Task<IActionResult> OnPostEditClaim([Required] string type,
            [Required] string value, [Required] string oldValue)
        {
            TargetUser = await _userManager.FindByIdAsync(Id);
            
            if (ModelState.IsValid)
            {
                var claimNew = new Claim(type, value);
                var claimOld = new Claim(type, oldValue);
                var result = await _userManager.ReplaceClaimAsync(TargetUser, claimOld, claimNew);

                if (result.Succeeded)
                {
                    StatusMessage = "Claim has been successfully edited.";
                    Claims = await _userManager.GetClaimsAsync(TargetUser);
                    return RedirectToPage();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        StatusMessage = "Error: Claim has not been edited. Try Again.";
                        ModelState.AddModelError(string.Empty, error.Description);
                        return Page();
                    }
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteClaim([Required] string type,
            [Required] string value)
        {
            TargetUser = await _userManager.FindByIdAsync(Id);
            if (ModelState.IsValid)
            {
                var claim = new Claim(type, value);
                var result = await _userManager.RemoveClaimAsync(TargetUser, claim);

                if (result.Succeeded)
                {
                    StatusMessage = "Claim has been successfully deleted.";
                    Claims = await _userManager.GetClaimsAsync(TargetUser);
                    return RedirectToPage();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        StatusMessage = "Error - Claim has not been deleted. Try Again.";
                        ModelState.AddModelError(string.Empty, error.Description);
                        return Page();
                    }
                }
            }
            return Page();
        }
    }
}
