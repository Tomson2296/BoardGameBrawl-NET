#nullable disable
using BoardGameBrawl.App.Areas.Identity.Pages.Admin;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListUserProperties;
using BoardGameBrawl.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameBrawl.Areas.Identity.Pages.Account.Admin
{
    public class ViewUserModel : AdminPageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public ViewUserModel(UserManager<ApplicationUser> userManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public ViewUserDTO ViewUser { get; set; }  

        // get property names for ApplicationUser and save in IEnumerable object
        public IEnumerable<string> PropertyNames
            => typeof(ViewUserDTO).GetProperties()
                .Select(prop => prop.Name);

        // get value of the property 
        public string GetValue(string name)
            => typeof(ViewUserDTO).GetProperty(name).GetValue(ViewUser)?.ToString();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToPage("ManageUsers");
            }

            // Use MediatR to Send the Command - ListUserProperties
            var command = new ListUserPropertiesQuery { Id = user.Id };
            ViewUser = await _mediator.Send(command);

            if (ViewUser == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
