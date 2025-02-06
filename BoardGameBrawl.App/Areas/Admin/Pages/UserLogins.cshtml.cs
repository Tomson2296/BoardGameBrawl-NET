#nullable disable

using BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListOfExternalUserLogins;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class UserLoginsModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public UserLoginsModel(UserManager<ApplicationUser> userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        public IList<ApplicationUserLogin> UserLogins { get; set; }

        public int LoginCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Create new query MediatR object
            var query = new ListOfAllExternalUserLoginsQuery { PageNumber = PageNumber, PageSize = 20 };
            UserLogins = await _mediator.Send(query);
            LoginCount = UserLogins.Count;
            
            return Page();
        }
    }
}
