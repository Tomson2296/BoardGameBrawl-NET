using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByUsername;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Value_objects;
using BoardGameBrawl.Infrastructure.Services.BGGService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Player.Pages
{
    public class UserBGGCollectionModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        private readonly IBGGService _BGGAPIService;

        public UserBGGCollectionModel(UserManager<ApplicationUser> userManager,
            IMediator mediator,
            IBGGService bGGAPIService)
        {
            _userManager = userManager;
            _mediator = mediator;
            _BGGAPIService = bGGAPIService;
        }

        [BindProperty(SupportsGet = true)]
        public string? Username { get; set; }

        public BoardgameCollectionResponse? UserBoardGameCollection { get; set; }

        public PlayerDTO? TargetPlayer { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var query = new GetPlayerByUsernameQuery { Username = Username };
            TargetPlayer = await _mediator.Send(query);

            if (TargetPlayer.BGGUsername != null)
            {
                UserBoardGameCollection = await _BGGAPIService.GetUserBGGCollectionInfoAsync(TargetPlayer.BGGUsername);
            }

            return Page();
        }
    }
}