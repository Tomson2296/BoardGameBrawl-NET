#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Commands.RemoveUser;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account.Manage
{
    public class RemovePlayerProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;
        private readonly IMediator _mediator;
        private readonly ILogger<RemovePlayerProfileModel> _logger;

        public RemovePlayerProfileModel(UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> userStore,
            IMediator mediator,
            ILogger<RemovePlayerProfileModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _mediator = mediator;
            _logger = logger;
        }

        public Guid PlayerProfileId { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid Id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            PlayerProfileId = Id;
            return Page();
        }

        public async Task<IActionResult> OnPostRemovePlayerProfileAsync(Guid Id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            PlayerProfileId = Id;

            // Use MediatR to Send the Command
            var command = new RemovePlayerCommand { Id = PlayerProfileId };
            var response = await _mediator.Send(command);

            if (!response.Success)
            {
                ModelState.AddModelError("Command", response.Message);
                StatusMessage = "Error: " + response.Message;
                return Page();
            }
            else
            {
                await _userStore.SetUserIsPlayerAccountCreatedAsync(user, false, CancellationToken.None);
                await _userStore.UpdateAsync(user, CancellationToken.None);
                StatusMessage = "Player profile has been removed";
                return RedirectToPage();
            }
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Account/Manage/PlayerProfile", new { area = "Identity" });
        }
    }
}
