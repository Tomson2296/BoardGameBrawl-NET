using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetFilteredBatchOfBoardgames;
using BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetFilteredBatchOfGroups;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetFilteredBatchOfPlayers;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Main.Pages
{
    public class FinderModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator mediator;

        public FinderModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            this.mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string? Filter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        
        public IList<NavBoardgameDTO>? Boardgames { get; set; }

        public IList<NavPlayerDTO>? Players { get; set; } 

        public IList<NavGroupDTO>? Groups { get; set; }

        public int PageSize { get; set; } = 50;


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!string.IsNullOrEmpty(Category))
            {
                var skip = (PageNumber - 1) * PageSize;

                if (Category == "Boardgame")
                {
                    var boardgamesQuery = new GetFilteredBatchOfBoardgamesQuery { Filter = Filter, Size = PageSize, Skip = skip };
                    Boardgames = await mediator.Send(boardgamesQuery);
                }
                else if (Category == "Player")
                {
                    var playersQuery = new GetFilteredBatchOfPlayersQuery { Filter = Filter, Size = PageSize, Skip = skip };
                    Players = await mediator.Send(playersQuery);
                }
                else if (Category == "Group")
                {
                    var groupsQuery = new GetFilteredBatchOfGroupsQuery { Filter = Filter, Size = PageSize, Skip = skip };
                    Groups = await mediator.Send(groupsQuery);
                }
                else
                {
                    //
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Finder", new { Filter, Category, PageNumber = 1 });
        }
    }
}
