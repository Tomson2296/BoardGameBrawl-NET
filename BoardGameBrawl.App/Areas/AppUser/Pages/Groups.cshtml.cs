#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetAllGroupsByPlayer;
using BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByAppUserId;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.AppUser.Pages
{
    public class GroupsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public GroupsModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public PlayerDTO TargetPlayer { get; set; }

        public IList<NavGroupDTO> PlayerGroups { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var getPlayerQuery = new GetPlayerByAppUserIdQuery { ApplicationUserId = user.Id };
            TargetPlayer = await _mediator.Send(getPlayerQuery);

            //get player's groups
            var getGroupsQuery = new GetAllGroupsByPlayerQuery { PlayerId = TargetPlayer.Id };
            PlayerGroups = await _mediator.Send(getGroupsQuery);

            return Page();
        }
    }
}