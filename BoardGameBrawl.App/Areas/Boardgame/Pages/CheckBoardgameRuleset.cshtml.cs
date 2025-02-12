#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameByBGGId;
using BoardGameBrawl.Application.Features.Match_Related.MatchRules.Commands.DeleteMatchRule;
using BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRule;
using BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRuleset;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace BoardGameBrawl.App.Areas.Boardgame.Pages
{
    public class CheckBoardgameRulesetModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public CheckBoardgameRulesetModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int BoardgameId { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public BoardgameDTO TargetBoardgame { get; set; }

        public IList<MatchRuleDTO> MatchRuleDTOs { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // get boardgame
            var getBoardgame = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            TargetBoardgame = await _mediator.Send(getBoardgame);

            // get boardgame ruleset
            var getRuleset = new GetMatchRulesetQuery { BoardgameId = TargetBoardgame.Id };
            MatchRuleDTOs = await _mediator.Send(getRuleset);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveRuleFromRulesetAsync(Guid value)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // get matchRule
            var getMatchRule = new GetMatchRuleQuery { Id = value };
            var matchRuleDTO = await _mediator.Send(getMatchRule);

            // remove rule from ruleset
            var removeMatchRule = new DeleteMatchRuleCommand { MatchRuleDTO = matchRuleDTO };
            var result = await _mediator.Send(removeMatchRule);

            if (!result.Success)
            {
                ModelState.AddModelError("Command", result.Message!);
                StatusMessage = "Error: " + result.Message;
                return Page();
            }

            StatusMessage = "Match rule removed successfully";
            return RedirectToPage();
        }
    }
}
