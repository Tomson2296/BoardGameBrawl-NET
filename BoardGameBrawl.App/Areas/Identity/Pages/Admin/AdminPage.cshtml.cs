using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Empty AdminPage
// Abstract page model class for every Admin web page to inherit
// that applies default admin authorization filter 

namespace BoardGameBrawl.App.Areas.Identity.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public abstract class AdminPageModel : PageModel
    {
    }
}
