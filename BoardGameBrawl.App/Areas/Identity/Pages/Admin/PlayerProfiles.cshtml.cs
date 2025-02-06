#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetBatchOfNavPlayers;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Admin
{
    public class PlayerProfilesModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public PlayerProfilesModel(UserManager<ApplicationUser> userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IList<NavPlayerDTO> PlayerProfiles { get; set; }

        
        public int PageSize { get; set; } = 20;
        
        public int TotalProfilesNumber { get; set; }

        public int PreviousNumber { get; set; }

        public int NextNumber { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var query = new GetBatchOfNavPlayersQuery { Size = PageSize, Skip = 0 };
            PlayerProfiles = await _mediator.Send(query);
            
            TotalProfilesNumber = PlayerProfiles.Count;
            PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
            NextNumber = PageNumber + 1;

            return Page();
        }
    }
}
