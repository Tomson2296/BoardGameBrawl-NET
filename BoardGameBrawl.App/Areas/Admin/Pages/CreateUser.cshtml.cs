#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class CreateUserModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;
        private readonly ILogger<CreateUserModel> _logger;
        
        public CreateUserModel(UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> userStore,
            ILogger<CreateUserModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = CreateUser();
                var creationDate = DateOnly.FromDateTime(DateTime.Now);

                // Set obligatory data about new user - Username, Email, Password
                await _userStore.SetUserNameAsync(user, Input.Username, CancellationToken.None);
                await _userStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                // Check if set Username and Email already exists in database 
                var ifUserCanBeCreated = await _userManager.CheckIfUserProfileCanBeCreatedAsync(_userStore, user);
                if (ifUserCanBeCreated == false)
                {
                    StatusMessage = "Error during cration process. Username or Email already exists in database.";
                    return Page();
                }

                var hashedPassword = _userManager.PasswordHasher.HashPassword(user, Input.Password);
                await _userManager.AddPasswordAsync(user, hashedPassword);

                // Set creation Time 
                await _userStore.SetUserCreatedDateAsync(user, creationDate);

                // Set email confirmation to true and try to create user
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created.");

                    // Adding newly created user to User role in application 
                    await _userManager.AddToRoleAsync(user, "User");
                    _logger.LogInformation($"Default credentials to account {user.UserName} - (Role : User) has been added.");

                    // Adding default claims to the User
                    List<Claim> userClaims =
                       [
                        new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new (ClaimTypes.Name, user.UserName),
                        new (ClaimTypes.Role, "User"),
                        new (ClaimTypes.Email, user.Email)
                       ];
                    await _userManager.AddClaimsAsync(user, userClaims);
                    _logger.LogInformation($"Default claims for account {user.UserName} has been added.");

                    StatusMessage = "User has been created successfully";
                    return RedirectToPage();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        StatusMessage = "Error during cration process. Try again.";
                        return Page();
                    }
                }
            }
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
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'.");
            }
        }
    }
}
