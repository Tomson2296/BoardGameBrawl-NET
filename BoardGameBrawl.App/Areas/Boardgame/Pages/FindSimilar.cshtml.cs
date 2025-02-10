using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategoryTags.Queries.GetBatchOfBoardgamesByCategory;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Queries.GetBatchOfBoardgamesByDomain;
using BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanicTags.Queries.GetBatchOfBoardgamesByMechanic;
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
        public int PageNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Value { get; set; }


        public int PreviousNumber { get; set; }

        public int NextNumber { get; set; }

        public int PageSize { get; set; } = 20;
   

        public IList<NavBoardgameDTO>? SimilarBoardgames { get; set; }

        public int ElementsCount { get; set; }


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
                var searchBoardgamesWithSameDomain = new GetBatchOfBoardgamesByDomainQuery { DomainId = Value, Size = PageSize, Skip = PageNumber * PageSize };
                SimilarBoardgames = await _mediator.Send(searchBoardgamesWithSameDomain);
                ElementsCount = SimilarBoardgames.Count;
                PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
                NextNumber = PageNumber + 1;
            }
            else if (Type == "Category")
            {
                var searchBoardgamesWithSameCategory = new GetBatchOfBoardgamesByCategoryQuery { CategoryId = Value, Size = PageSize, Skip = PageNumber * PageSize };
                SimilarBoardgames = await _mediator.Send(searchBoardgamesWithSameCategory);
                ElementsCount = SimilarBoardgames.Count;
                PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
                NextNumber = PageNumber + 1;
            }
            else
            {
                var searchBoardgamesWithSameMechanic = new GetBatchOfBoardgamesByMechanicQuery { MechanicId = Value, Size = PageSize, Skip = PageNumber * PageSize };
                SimilarBoardgames = await _mediator.Send(searchBoardgamesWithSameMechanic);
                ElementsCount = SimilarBoardgames.Count;
                PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
                NextNumber = PageNumber + 1;
            }

            return Page();
        }
    }
}
