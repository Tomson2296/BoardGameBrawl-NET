#nullable disable
using BoardGameBrawl.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.User.Pages
{
    public class GroupsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupsModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public IEnumerable<GroupInfoDTO> Groups { get; set; } = new List<GroupInfoDTO>();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //Groups = await _groupParticipantStore.GetUserGroupsParticipationListAsync(ApplicationUser);
            return Page();
        }
    }
}