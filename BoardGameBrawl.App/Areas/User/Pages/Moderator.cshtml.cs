#nullable disable
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.User.Pages
{
    public class ModeratorPageModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ModeratorPageModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public IList<BoardgameModel> Boardgames { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //Boardgames = await GetListofBoardgames(ApplicationUser);
            
            return Page();
        }

        //private async Task<IList<BoardgameModel>> GetListofBoardgames(ApplicationUser applicationUser)
        //{
        //    IList<Claim> Claims = await _userManager.GetClaimsAsync(applicationUser);
        //    IList<Claim> ModerationClaims = Claims.Where(c => c.Type == "BoardGameModerationPermission").ToList();

        //    List<BoardgameModel> result = new List<BoardgameModel>();
        //    foreach (var item in ModerationClaims)
        //    {
        //        BoardgameModel boardgame = await _boardgameStore.FindBoardGameByBGGIdAsync(int.Parse(item.Value));
        //        result.Add(boardgame);
        //    }
        //    return result;
        //}
    }
}