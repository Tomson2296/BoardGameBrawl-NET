#nullable disable
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Identity.Entities;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser User { get; set; }
}
