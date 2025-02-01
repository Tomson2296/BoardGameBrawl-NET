#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoardGameBrawl.App.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserStore<ApplicationUser> _userStore;

        public IndexModel(UserManager<ApplicationUser> userManager,
            IApplicationUserStore<ApplicationUser> userStore)
        {
            _userManager = userManager;
            _userStore = userStore;
        }

        public string Username { get; set; }

        public string SuccessMessage { get; set; }

        public bool IfProfileCreated { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Username = user.UserName;
            SuccessMessage = TempData["StatusMessage"] as string;
            IfProfileCreated = await _userManager.CheckIfUserHasCreatedPlayerAccountAsync(_userStore, user);
            return Page();
        }
    }
}
