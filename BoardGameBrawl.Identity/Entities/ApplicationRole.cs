#nullable disable
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BoardGameBrawl.Identity.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public ICollection<ApplicationUserRole> UserRoles { get; set; }

    public ICollection<ApplicationRoleClaim> RoleClaims { get; set; }

    [MaxLength(512)]
    public string Description { get; set; }
}
