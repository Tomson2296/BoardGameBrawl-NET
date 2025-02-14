#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameByBGGId;
using BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Commands.AddPlayerFavouriteBG;
using BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Commands.DeletePlayerFavouriteBG;
using BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.CheckIfPlayerFavouriteBGExists;
using BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Commands.AddPlayerPreference;
using BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Commands.UpdatePlayerPreference;
using BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.CheckIfPlayerPreferenceExists;
using BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetPlayerPreferenceByBoardgame;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Boardgame.Pages
{
    public class FavouritesModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public FavouritesModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int BoardgameId { get; set; }

        [BindProperty]
        public byte Rating { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public BoardgameDTO TargetBoardgame { get; set; }

        public bool IfPlayerVoted { get; set; }

        public bool IfBoardgameFavourite { get; set; }

        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // get player profile
            var getPlayerProfileCQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await _mediator.Send(getPlayerProfileCQuery);

            // get boardgame 
            var getBoardgameQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            TargetBoardgame = await _mediator.Send(getBoardgameQuery);

            // check if player already voted
            var playerPreferenceCheck = new CheckIfPlayerPreferenceExistsQuery { PlayerId = playerProfile.Id, BoardgameId = TargetBoardgame.Id };
            IfPlayerVoted = await _mediator.Send(playerPreferenceCheck);

            // check if user likes boardgame 
            var playerFavouriteCheck = new CheckIfPlayerFavouriteBGExistsQuery { PlayerId = playerProfile.Id, BoardgameId = TargetBoardgame.Id };
            IfBoardgameFavourite = await _mediator.Send(playerFavouriteCheck);

            return Page();
        }

        public async Task<IActionResult> OnPostAddToFavouritesAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var getPlayerProfileCQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await _mediator.Send(getPlayerProfileCQuery);

            var getBoardgameQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            TargetBoardgame = await _mediator.Send(getBoardgameQuery);

            PlayerFavouriteBGDTO newPlayerFavourite = new()
            {
                PlayerId = playerProfile.Id,
                PlayerName = playerProfile.PlayerName,
                BoardgameId = TargetBoardgame.Id,
                BoardgameName = TargetBoardgame.Name
            };

            var createNewPlayerPreferenceCommand = new AddPlayerFavouriteBGCommand { PlayerFavouriteBGDTO = newPlayerFavourite };
            var result = await _mediator.Send(createNewPlayerPreferenceCommand);

            if (!result.Success)
            {
                ModelState.AddModelError("Command", result.Message);
                StatusMessage = "Error: " + result.Message;
                return Page();
            }

            StatusMessage = "Added new player favourite boardgame successfully";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromFavouritesAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var getPlayerProfileCQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await _mediator.Send(getPlayerProfileCQuery);

            var getBoardgameQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            TargetBoardgame = await _mediator.Send(getBoardgameQuery);

            var deletePlayerFavouriteCommand = new DeletePlayerFavouriteBGCommand { PlayerId = playerProfile.Id, BoardgameId = TargetBoardgame.Id };
            var result = await _mediator.Send(deletePlayerFavouriteCommand);

            if (!result.Success)
            {
                ModelState.AddModelError("Command", result.Message);
                StatusMessage = "Error: " + result.Message;
                return Page();
            }

            StatusMessage = "Boardgame removed from player's favourites successfully";
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostSubmitRatingAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var getPlayerProfileCQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await _mediator.Send(getPlayerProfileCQuery);

            var getBoardgameQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            TargetBoardgame = await _mediator.Send(getBoardgameQuery);

            // check if player already voted
            var playerPreferenceCheck = new CheckIfPlayerPreferenceExistsQuery { PlayerId = playerProfile.Id, BoardgameId = TargetBoardgame.Id };
            IfPlayerVoted = await _mediator.Send(playerPreferenceCheck);

            if (IfPlayerVoted == false)
            {
                // if false - create new player preference

                PlayerPreferenceDTO playerPreferenceDTO = new()
                {
                    PlayerId = playerProfile.Id,
                    PlayerName = playerProfile.PlayerName,
                    BoardgameId = TargetBoardgame.Id,
                    BoardgameName = TargetBoardgame.Name,
                    Rating = Rating
                };

                var createNewPlayerPreferenceCommand = new AddPlayerPreferenceCommand { PlayerPreferenceDTO = playerPreferenceDTO };
                var result = await _mediator.Send(createNewPlayerPreferenceCommand);

                if (!result.Success)
                {
                    ModelState.AddModelError("Command", result.Message);
                    StatusMessage = "Error: " + result.Message;
                    return Page();
                }

                StatusMessage = "Added new player preference successfully. Thank you for voting!";
                return RedirectToPage();
            }
            else
            {
                // if true - update player preference

                var getPlayerPreferenceQuery = new GetPlayerPreferenceQuery { PlayerId = playerProfile.Id, BoardgameId = TargetBoardgame.Id };
                var playerPreference = await _mediator.Send(getPlayerPreferenceQuery);

                var updatePlayerPreferenceCommand = new UpdatePlayerPreferenceCommand { PlayerPreferenceDTO = playerPreference };
                var result = await _mediator.Send(updatePlayerPreferenceCommand);

                if (!result.Success)
                {
                    ModelState.AddModelError("Command", result.Message);
                    StatusMessage = "Error: " + result.Message;
                    return Page();
                }

                StatusMessage = "Updated player preference successfully. Thank you for voting!";
                return RedirectToPage();
            }
        }
    }
}
