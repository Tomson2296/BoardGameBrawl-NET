using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroup;
using BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetBatchOfGroupParticipants;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Group.Pages
{
    public class GroupParticipantsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public GroupParticipantsModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string? GroupName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;


        public GroupDTO? TargetGroup { get; set; }

        public IList<NavPlayerDTO>? GroupParticipants { get; set; }


        public int PreviousNumber { get; set; }

        public int NextNumber { get; set; }

        public int PageSize { get; set; } = 20;

        public int ElementsCount { get; set; }


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

            // get groupParticipants
            int skipValue = (PageNumber - 1) * PageSize;
            var getBatchOfGroupParticipants = new GetBatchOfGroupParticipantsQuery { GroupId = TargetGroup.Id, Size = PageSize, Skip = skipValue };
            GroupParticipants = await _mediator.Send(getBatchOfGroupParticipants);

            ElementsCount = GroupParticipants.Count;
            PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
            NextNumber = PageNumber + 1;

            return Page();
        }
    }
}
