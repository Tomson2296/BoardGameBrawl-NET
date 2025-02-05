#nullable disable
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Admin
{
    public class PlayerProfilesModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public PlayerProfilesModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }



        public void OnGet()
        {
        }
    }
}
