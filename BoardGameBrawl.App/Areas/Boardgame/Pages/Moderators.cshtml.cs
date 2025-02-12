using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Commands.AddBoardgameModerator;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Commands.DeleteBoardgameModerator;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.CheckIfBoardgameModeratorExists;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Queries.GetAllModeratorsForBoardgame;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameByBGGId;
using BoardGameBrawl.Application.Features.Common.Concrete.Queries.CountEntities;
using BoardGameBrawl.Application.Features.Common.Concrete.Queries.CountEntities.BoardgameModerators;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Boardgame.Pages
{
    public class ModeratorsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMediator mediator;
        private readonly IUnitOfWork unitOfWork;

        public ModeratorsModel(UserManager<ApplicationUser> userManager, IMediator mediator, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;
        }

        [BindProperty(SupportsGet = true)]
        public int BoardgameId { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        public BoardgameDTO? BoardgameDTO { get; set; }

        public IList<NavPlayerDTO>? BoardgameModerators { get; set; }

        public int ModeratorsCount { get; set; }

        public bool IfPlayerModerating { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            // getting player and boardgame data

            var getPlayerProfileQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await mediator.Send(getPlayerProfileQuery);

            var getBoardgameByBGGIdQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            BoardgameDTO = await mediator.Send(getBoardgameByBGGIdQuery);

            // counting exisitng moderators

            var countQuery = new ConcreteCountEntitiesQuery();
            var boardgameModeratorsQueryHandler = new CountBoardgameModeratorsQueryHandler(unitOfWork);
            ModeratorsCount = await boardgameModeratorsQueryHandler.Handle(countQuery, CancellationToken.None);

            if (ModeratorsCount != 0)
            {
                var getAllModeratorsQuery = new GetAllModeratorsForBoardgameQuery { BoardgameId = BoardgameDTO.Id };
                BoardgameModerators = await mediator.Send(getAllModeratorsQuery);
            }

            // check if Player is moderator

            var checkIfPLayerModerating = new CheckIfBoardgameModeratorExistsQuery { ModeratorId = playerProfile.Id, BoardgameId = BoardgameDTO.Id };
            IfPlayerModerating = await mediator.Send(checkIfPLayerModerating);

            return Page();
        }

        public async Task<IActionResult> OnPostAddToModeratorsAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var getBoardgameByBGGIdQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            BoardgameDTO = await mediator.Send(getBoardgameByBGGIdQuery);

            var getPlayerProfileQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await mediator.Send(getPlayerProfileQuery);

            // create new boardgame Moderator

            BoardgameModeratorDTO newBoardgameModerator = new()
            {
                ModeratorId = playerProfile.Id,
                ModeratorName = playerProfile.PlayerName,
                BoardgameId = BoardgameDTO.Id,
                BoardgameName = BoardgameDTO.Name
            };

            var addBoardgameModeratorCommand = new AddBoardgameModeratorCommand { BoardgameModeratorDTO = newBoardgameModerator };
            var result = await mediator.Send(addBoardgameModeratorCommand);

            if (!result.Success)
            {
                ModelState.AddModelError("Command", result.Message!);
                StatusMessage = "Error: " + result.Message;
                return Page();
            }

            StatusMessage = "Added new boardgame moderator successfully";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteFromModeratorsAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var getBoardgameByBGGIdQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            BoardgameDTO = await mediator.Send(getBoardgameByBGGIdQuery);

            var getPlayerProfileQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            var playerProfile = await mediator.Send(getPlayerProfileQuery);

            // remove player from moderators

            var removeFromModerators = new DeleteBoardgameModeratorCommand { ModeratorId = playerProfile.Id, BoardgameId = BoardgameDTO.Id };
            var result = await mediator.Send(removeFromModerators);

            if (!result.Success)
            {
                ModelState.AddModelError("Command", result.Message!);
                StatusMessage = "Error: " + result.Message;
                return Page();
            }

            StatusMessage = "Moderator has been deleted successfully";
            return RedirectToPage();
        }

    }
}
