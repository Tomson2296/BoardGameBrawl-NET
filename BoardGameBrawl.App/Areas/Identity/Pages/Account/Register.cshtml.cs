﻿#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using BoardGameBrawl.Identity;
using BoardGameBrawl.Identity.Entities;
using BoardGameBrawl.Identity.Managers;
using BoardGameBrawl.Identity.Stores;
using BoardGameBrawl.Infrastructure.EmailSender;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.WebUtilities;
using System.Runtime.InteropServices;
using System.Security.Claims;
using BoardGameBrawl.Identity.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _userEmailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMailKitEmailSender _emailSender;
        private readonly IApplicationPasswordHasher<ApplicationUser> _passwordHasher;

        public RegisterModel(SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager, 
            IUserStore<ApplicationUser> userStore, 
            IUserEmailStore<ApplicationUser> userEmailStore, 
            ILogger<RegisterModel> logger, 
            IMailKitEmailSender emailSender,
            IApplicationPasswordHasher<ApplicationUser> passwordHasher)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _userEmailStore = userEmailStore;
            _logger = logger;
            _emailSender = emailSender;
            _passwordHasher = passwordHasher;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                ApplicationUser user = CreateUser();
                DateOnly creationDate = DateOnly.FromDateTime(DateTime.UtcNow);

                await _userStore.SetUserNameAsync(user, Input.Username, CancellationToken.None);
                await _userEmailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                await _userStore.SetUserCreatedDateAsync(user, creationDate);

                string passwordHash = _passwordHasher.HashPassword(user, Input.Password);
                await _userStore.SetUserPasswordHashAsync(user, passwordHash);
                
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //Add newly created user to basic role "User" and add list of basic claims about user
                    await _userManager.AddToRoleAsync(user, "User");
                    List<Claim> userClaims =
                       [
                        new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new (ClaimTypes.Name, user.UserName),
                        new (ClaimTypes.Role, "User"),
                        new (ClaimTypes.Email, user.Email)
                       ];
                    await _userManager.AddClaimsAsync(user, userClaims);

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: true);
                        return LocalRedirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser )}'. " +
                    $"Ensure that '{nameof(ApplicationUser )}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
