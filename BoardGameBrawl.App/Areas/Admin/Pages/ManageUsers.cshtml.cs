#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListFilteredUsers;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.App.Areas.Admin.Pages
{
    public class ManageUsersModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public ManageUsersModel(UserManager<ApplicationUser> userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public ICollection<NavUserDTO> Users { get; set; }


        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }


        public int PageSize { get; set; } = 20;

        public int TotalUsersNumber { get; set; }

        public int PreviousNumber { get; set; }

        public int NextNumber { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            TotalUsersNumber = await _userManager.GetNumberOfUsersCountAsync();

            // Use MediatR to Send the Command - ListFilteredUsersQuery
            var command = new ListFilteredUsersQuery { Filter = Filter, PageNumber = PageNumber, PageSize = PageSize };
            Users = await _mediator.Send(command);
            
            PreviousNumber = (PageNumber - 1 < 1) ? 1 : PageNumber - 1;
            NextNumber = PageNumber + 1;
            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { Filter, PageNumber = 1 });
        }
    }
}
