#nullable disable

using Microsoft.AspNetCore.Identity;
namespace BoardGameBrawl.Domain.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser User { get; set; }
}
