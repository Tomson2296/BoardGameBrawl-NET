#nullable disable
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.AppUser.Pages
{
    public class BoardgameFavouritesModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BoardgameFavouritesModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public List<string> BoardgameFavouritesList { get; set; } = new List<string>();

        //[BindProperty]
        //public IEnumerable<BoardgameModel> BoardgameFavourites { get; set; } = new List<BoardgameModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //BoardgameFavouritesList = await _userManager.GetUserFavouriteBoardGamesAsync(ApplicationUser);
            //if (BoardgameFavouritesList == null)
            //{
            //    return Page();
            //}
            //else
            //{
            //    BoardgameFavourites = await GetUserFavouriteBoardgames();
            //    return Page();
            //}

            return Page();
        }

        //private async Task<IEnumerable<BoardgameModel>> GetUserFavouriteBoardgames()
        //{
        //    List<BoardgameModel> result = new List<BoardgameModel>();
        //    foreach (var boardgameID in BoardgameFavouritesList)
        //    {
        //        result.Add(await _boardgameStore.FindBoardGameByBGGIdAsync(int.Parse(boardgameID)));
        //    }
        //    return result;
        //}
    }
}
