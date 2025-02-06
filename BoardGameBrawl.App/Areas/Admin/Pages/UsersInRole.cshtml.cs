#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListUsersInRole;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class UsersInRoleModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMediator _mediator;

        public UsersInRoleModel(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string ChosenRole { get; set; }


        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public IList<NavUserDTO> UsersInRole { get; set; } 

        public ApplicationRole TargetRole { get; set; }

        
        public int PageSize { get; set; } = 20;

        public int TotalUsersNumber { get; set; }

        public int PreviousNumber { get; set; }

        public int NextNumber { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            TargetRole = await _roleManager.FindByNameAsync(ChosenRole);
            TotalUsersNumber = (await _userManager.GetUsersInRoleAsync(ChosenRole)).Count;

            // create MediatR qury object
            var query = new ListFilteredUsersByRoleQuery { PageNumber = PageNumber, PageSize = PageSize, RoleId = TargetRole.Id };
            UsersInRole = await _mediator.Send(query);

            PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
            NextNumber = PageNumber + 1;
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveUserFromRoleAsync(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            IdentityResult result = await _userManager.RemoveFromRoleAsync(user, ChosenRole);

            if (result.Succeeded)
            {
                StatusMessage = "User removed from role successfully.";
                return RedirectToPage("UsersInRole", new { ChosenRole, PageNumber });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    StatusMessage = "Error - user has not been removed from role. Tryagain.";
                    return RedirectToPage("UsersInRole", new {ChosenRole, PageNumber });
                }
            }
            return Page();
        }
    }
}
