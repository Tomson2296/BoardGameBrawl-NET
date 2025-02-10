#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetBoardgameByBGGId;
using BoardGameBrawl.Application.Features.Match_Related.MatchRules.Queries.GetMatchRuleset;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Entities.Match_Related;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.App.Areas.Boardgame.Pages
{
    public class ModifyRulesetModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMediator mediator;

        public ModifyRulesetModel(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int BoardgameId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Rule Description")]
            [Required]
            [MaxLength(512)]
            public string RuleDescription { get; set; }

            [Display(Name = "Rule Decider")]
            [Required]
            public bool RuleDecider { get; set; }

            [Required]
            public RuleType RuleType { get; set; }
        }

        [TempData]
        public string StatusMessage { get; set; }

        public BoardgameDTO BoardgameDTO { get; set; }

        public IList<MatchRuleDTO> MatchRuleDTOs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var getBoardgameByBGGIdQuery = new GetBoardgameByBGGIdQuery { BGGId = BoardgameId };
            BoardgameDTO = await mediator.Send(getBoardgameByBGGIdQuery);

            var getMatchRulesetQuery = new GetMatchRulesetQuery { BoardgameId = BoardgameDTO.Id };
            MatchRuleDTOs = await mediator.Send(getMatchRulesetQuery);

            return Page();
        }
    }
}
