#nullable disable
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.AppUser.Pages
{
    public class FriendsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public FriendsModel(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;
        }

        //public IEnumerable<BasicUserInfoDTO> FindFriends { get; set; } = new List<BasicUserInfoDTO>();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //FindFriends = await _userFriendStore.GetUserFriendsAsync(user.Id);
            return Page();
        }
    }
}