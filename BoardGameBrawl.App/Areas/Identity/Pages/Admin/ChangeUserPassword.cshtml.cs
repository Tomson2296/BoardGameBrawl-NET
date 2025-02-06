#nullable disable
using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Infrastructure.EmailSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
{
    public class ChangeUserPasswordModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailKitEmailSender _mailKitService;

        public ChangeUserPasswordModel(UserManager<ApplicationUser> userManager,
            IMailKitEmailSender mailKitService)
        {
            _userManager = userManager;
            _mailKitService = mailKitService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public PasswordInput Input { get; set; }

        public ApplicationUser TargetUser { get; set; }

        public class PasswordInput
        {
            [DataType(DataType.Password)]
            [Required]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Required]
            [Compare(nameof(NewPassword))]
            public string ConfirmationPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToPage("./Passwords", new { PageNumber = 1 });
            }

            TargetUser = await _userManager.FindByIdAsync(Id);

            if (TargetUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                TargetUser = await _userManager.FindByIdAsync(Id);
                if (await _userManager.HasPasswordAsync(TargetUser))
                {
                    await _userManager.RemovePasswordAsync(TargetUser);
                }

                IdentityResult result =
                    await _userManager.AddPasswordAsync(TargetUser, Input.NewPassword);

                if (result.Succeeded)
                {
                    await _mailKitService.SendEmailAsync(TargetUser.Email, "Message from site Administration. Your password has been changed." +
                        "Please, sign-up to aplication using password sent in that message. You can later change it in your profile panel. " +
                        "Thank you.", Input.NewPassword);
                    
                    return RedirectToPage("./Passwords", new { PageNumber = 1 });
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
