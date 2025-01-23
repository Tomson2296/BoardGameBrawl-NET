using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BoardGameBrawl.Identity.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    [MaxLength(256)]
    public string? FirstName { get; set; }

    [MaxLength(256)]
    public string? LastName { get; set; }

    [MaxLength(256)]
    public string? BGGUsername { get; set; }

    [MaxLength(512)]
    public string? UserDescription { get; set; }

    public DateOnly? UserCreatedDate { get; set; }

    public DateOnly? UserLastLogin { get; set; }

    public byte[]? UserAvatar { get; set; }

    public ICollection<ApplicationUserClaim>? UserClaims { get; set; }

    public ICollection<ApplicationUserLogin>? UserLogins { get; set; }

    public ICollection<ApplicationUserToken>? UserTokens { get; set; }

    public ICollection<ApplicationUserRole>? UserRoles { get; set; }
}
