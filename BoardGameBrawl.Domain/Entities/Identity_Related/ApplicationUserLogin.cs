#nullable disable
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Domain.Entities;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser User { get; set; }
}
