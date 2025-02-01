#nullable disable
using Microsoft.AspNetCore.Identity;
namespace BoardGameBrawl.Domain.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public ICollection<ApplicationUserRole> UserRoles { get; set; }

    public ICollection<ApplicationRoleClaim> RoleClaims { get; set; }

    public string Description { get; set; }
}
