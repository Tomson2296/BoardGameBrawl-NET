#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.PlayerFriends.Queries.GetPlayerFriendships;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.AppUser.Pages
{
    public class FriendsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public FriendsModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public PlayerDTO TargetPlayer { get; set; }

        public IList<NavPlayerDTO> PlayerFriends { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            TargetPlayer = await _mediator.Send(query);

            // get player's friendshipList
            var getPlayerFriendships = new GetPlayerFriendshipsQuery { PlayerId = TargetPlayer.Id };
            PlayerFriends = await _mediator.Send(getPlayerFriendships);

            return Page();
        }
    }
}