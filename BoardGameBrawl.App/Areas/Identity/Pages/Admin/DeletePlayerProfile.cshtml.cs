#nullable disable

using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Commands.RemoveUser;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayer;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Admin
{
    public class DeletePlayerProfileModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;
        private readonly IMediator _mediator;
        
        public DeletePlayerProfileModel(UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> userStore,
            IMediator mediator)
        {
            _userManager = userManager;
            _userStore = userStore;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public PlayerDTO TargetPlayerProfile { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerQuery { Id = Id };
            TargetPlayerProfile = await _mediator.Send(query);

            if (TargetPlayerProfile == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            try
            {
                var query = new GetPlayerQuery { Id = Id };
                TargetPlayerProfile = await _mediator.Send(query);

                // Use MediatR to Send the Command
                var command = new RemovePlayerCommand { Id = Id };
                var response = await _mediator.Send(command);

                if (!response.Success)
                {
                    StatusMessage = "Error - Player profile has not been removed" + response.Message;
                    return RedirectToPage("./PlayerProfiles", new { PageNumber = 1 });
                }
                else
                {
                    ApplicationUser TargetAppUser = await _userManager.FindByIdAsync(TargetPlayerProfile.ApplicationUserId.ToString());
                    await _userStore.SetUserIsPlayerAccountCreatedAsync(TargetAppUser, false);
                    await _userStore.UpdateAsync(TargetAppUser, CancellationToken.None);
                    
                    StatusMessage = "Player profile has been removed";
                    return RedirectToPage("./PlayerProfiles", new { PageNumber = 1 });
                }
            }
            catch (Exception ex)
            {
                StatusMessage = "Error - An unexpected error occurred while removing the player profile" + ex.Message;
                return RedirectToPage("./PlayerProfiles", new { PageNumber = 1 });
            }
        }
    }
}
