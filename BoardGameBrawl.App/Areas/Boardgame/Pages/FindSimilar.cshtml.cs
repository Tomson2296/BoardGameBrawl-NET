using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBoardgamesByCategory;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBoardgameeByDomain;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBoardgamesByMechanic;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Boardgame.Pages
{
    public class FindSimilarModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public FindSimilarModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string? Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Value { get; set; }

        public int PageSize { get; set; } = 20;

        public int PageNumber { get; set; }

        public IList<NavBoardgameDTO>? SimilarBoardgames { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (string.IsNullOrEmpty(Type) && Value.Equals(default))
            {
                return RedirectToPage("Index", routeValues: new { Areas = "Boardgame" } );
            }

            if (Type == "Domain")
            {
                var searchBoardgamesWithSameDomain = new GetBoardgamesByDomainQuery { DomainId = Value };
                SimilarBoardgames = await _mediator.Send(searchBoardgamesWithSameDomain);
            }
            else if (Type == "Category")
            {
                var searchBoardgamesWithSameCategory = new GetBoardgamesByCategoryQuery { CategoryId = Value };
                SimilarBoardgames = await _mediator.Send(searchBoardgamesWithSameCategory);
            }
            else
            {
                var searchBoardgamesWithSameMechanic = new GetBoardgamesByMechanicQuery { MechanicId = Value };
                SimilarBoardgames = await _mediator.Send(searchBoardgamesWithSameMechanic);
            }

            return Page();
        }
    }
}
