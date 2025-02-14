using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetAllPlayerfavouriteBGs;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByUsername;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Player.Pages
{
    public class UserBoardgameFavouritesModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public UserBoardgameFavouritesModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string? UserName { get; set; }

        public PlayerDTO? TargetPlayer { get; set; }

        public IList<NavBoardgameDTO>? UserFavouriteBGs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerByUsernameQuery { Username = UserName };
            TargetPlayer = await _mediator.Send(query);

            // get all player's favourite boardgames 
            var playerFav = new GetAllPlayerFavouriteBGsQuery { PlayerId = TargetPlayer.Id };
            UserFavouriteBGs = await _mediator.Send(playerFav);

            return Page();
        }
    }
}
