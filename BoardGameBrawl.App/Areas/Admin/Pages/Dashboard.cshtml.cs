using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class DashboardModel : AdminPageModel
    {
        public UserManager<ApplicationUser> _userManager;
        
        public DashboardModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public int UsersCount { get; set; } = 0;

        public int UsersUnconfirmed { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            UsersCount = await _userManager.GetNumberOfUsersCountAsync();

            UsersUnconfirmed = await _userManager.GetNumberOfUsersUnconfirmedCountAsync();

            return Page();
        }
    }
}
