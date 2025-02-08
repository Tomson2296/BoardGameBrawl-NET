#nullable disable

using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Commands.UpdateUser;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account.Manage
{
    public class PlayerProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;
        private readonly IMediator _mediator;

        public PlayerProfileModel(UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> userStore,
            IMediator mediator)
        {
            _userManager = userManager;
            _userStore = userStore;
            _mediator = mediator;
        }

        [TempData]
        public string StatusMessage { get; set; } 

        public bool IfProfileCreated { get; set; }

        [BindProperty]
        public Guid ApplicationUserId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Id")]
            public Guid Id { get; set; }

            [Display(Name = "Username")]
            public string UserName { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Display(Name = "BGGUsername")]
            public string BGGUsername { get; set; }

            [Display(Name = "UserDescription")]
            public string UserDescription { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ApplicationUserId = user.Id;
            IfProfileCreated = await _userManager.CheckIfUserHasCreatedPlayerAccountAsync(_userStore, user);
            if (IfProfileCreated)
            {
                await LoadPlayerProfileAsync(user);
            }
            return Page();
        }

        private async Task LoadPlayerProfileAsync(ApplicationUser user)
        {
            // Use MediatR to Send the Command
            var command = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await _mediator.Send(command);

            Input = new InputModel
            {
                Id = playerProfile.Id,
                UserName = playerProfile.PlayerName,
                Email = playerProfile.Email,
                FirstName = playerProfile.FirstName,
                LastName = playerProfile.LastName,
                BGGUsername = playerProfile.BGGUsername,
                UserDescription = playerProfile.UserDescription,
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadPlayerProfileAsync(user);
                return Page();
            }

            // create new PlayerDTO object
            PlayerDTO playerDTO = new()
            {
                Id = Input.Id,
                ApplicationUserId = user.Id,
                PlayerName = Input.UserName,
                Email = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                BGGUsername = Input.BGGUsername,
                UserDescription = Input.UserDescription
            };

            // create UpdatePlayer command object and perform update
            var command = new UpdatePlayerCommand { PlayerDTO = playerDTO };
            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                ModelState.AddModelError("Command", response.Message);
                StatusMessage = "Error: " + response.Message;
                return Page();
            }
            else
            {
                StatusMessage = "Player Profile Updated Successfully";
                return RedirectToPage();
            }
        }
    }
}
