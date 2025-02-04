#nullable disable

using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
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

            [Phone]
            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }   

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string BGGUsername { get; set; }
            
            public string UserDescription { get; set; }
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
                var user = CreateUser();
                var creationDate = DateOnly.FromDateTime(DateTime.Now);

                // Set obligatory data about new user - Username, Email, Password
                await _userStore.SetUserNameAsync(user, Input.Username, CancellationToken.None);
                await _userStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                await _userManager.AddPasswordAsync(user, Input.Password);

                // Set creation Time 
                await _userStore.SetUserCreatedDateAsync(user, creationDate);

                // set email
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, Input.Password);

                // create deafult instance of userSchedule
                //UserSchedule userSchedule = CreateUserSchedule();
                //await _userScheduleStore.SetUserByAsync(userSchedule, user);
                //await _userScheduleStore.CreateScheduleAsync(userSchedule);
                //_logger.LogInformation("Default UserSchedule has been added to account.");

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new user.");

                    // Adding newly created user to User role in application 
                    await _userManager.AddToRoleAsync(user, "User");
                    _logger.LogInformation("Default credentials to account (Role : User) has been added to account.");

                    StatusMessage = "User has been created successfully";
                    return Page();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    StatusMessage = "Error during cration process. Try again.";
                    return Page();
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
        //private UserSchedule CreateUserSchedule()
        //{
            //try
            //{
                //return Activator.CreateInstance<UserSchedule>();
            //}
            //catch
            //{
                //throw new InvalidOperationException($"Can't create an instance of '{nameof(UserSchedule)}'.");
            //}
        //}
    }
}
