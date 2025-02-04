using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
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
            UsersCount = await _userManager.GetNumberOfUsersCountAsync();

            UsersUnconfirmed = await _userManager.GetNumberOfUsersUnconfirmedCountAsync();

            return Page();
        }
    }
}
