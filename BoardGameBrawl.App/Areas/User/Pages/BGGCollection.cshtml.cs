#nullable disable
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.User.Pages
{
    public class BGGCollectionModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IBGGAPIService _BGGAPIService;

        public BGGCollectionModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public BoardGameCollection UserBoardGameCollection { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //if (ApplicationUser.BGGUsername != null)
            //{
            //    UserBoardGameCollection = await _BGGAPIService.GetUserBGGCollectionInfo(ApplicationUser.BGGUsername);
            //}

            return Page();
        }
    }
}
