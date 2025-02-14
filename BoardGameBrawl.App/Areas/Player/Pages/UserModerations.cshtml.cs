using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.GetAllPlayerModerations;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByUsername;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Player.Pages
{
    public class UserModerationsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public UserModerationsModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string? UserName { get; set; }

        public PlayerDTO? TargetPlayer { get; set; }

        public IList<NavBoardgameDTO>? NavBoardgameDTOs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerByUsernameQuery { Username = UserName };
            TargetPlayer = await _mediator.Send(query);

            // get boardgames where player is moderator 
            var getPlayerModerations = new GetAllPlayerModerationsQuery { ModeratorId = TargetPlayer.Id };
            NavBoardgameDTOs = await _mediator.Send(getPlayerModerations);

            return Page();
        }
    }
}
