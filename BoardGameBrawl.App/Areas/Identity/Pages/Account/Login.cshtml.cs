#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Application.Services;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> userStore,
            IPasswordHasher<ApplicationUser> passwordHasher,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                //Verify if user exists in database
                ApplicationUser = await _userManager.FindByEmailAsync(Input.Email);
                if (ApplicationUser == null)
                {
                    ModelState.AddModelError(string.Empty, "User cannot be found.");
                    return Page();
                }

                string hashedPassword = await _userStore.GetPasswordHashAsync(ApplicationUser, CancellationToken.None);
                PasswordVerificationResult isPasswordCorrect = _passwordHasher.VerifyHashedPassword(ApplicationUser, hashedPassword, Input.Password);
                if(isPasswordCorrect == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password. Try again.");
                    return Page();
                }

                await _signInManager.SignInAsync(ApplicationUser, Input.RememberMe, returnUrl);
                _logger.LogInformation("User logged in.");
                return LocalRedirect(returnUrl);
                
                //if (result.Succeeded)
                //{
                //    _logger.LogInformation("User logged in.");
                //    return LocalRedirect(returnUrl);
                //}
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}
