using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroup;
using BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetGroupAdmins;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Group.Pages
{
    public class GroupAdminsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public GroupAdminsModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string? GroupName { get; set; }

        public GroupDTO? TargetGroup { get; set; }

        public IList<NavPlayerDTO>? GroupAdmins { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // get group info
            var getGroupQuery = new GetGroupQuery { GroupName = GroupName };
            TargetGroup = await _mediator.Send(getGroupQuery);

            // get group admins
            var getAdmins = new GetGroupAdminsQuery { GroupId = TargetGroup.Id };
            GroupAdmins = await _mediator.Send(getAdmins);

            return Page();
        }
    }
}
