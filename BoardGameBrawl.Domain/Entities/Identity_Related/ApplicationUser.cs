using Microsoft.AspNetCore.Identity;
namespace BoardGameBrawl.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public DateOnly? UserCreatedDate { get; set; }

    public DateOnly? UserLastLogin { get; set; }

    public bool IsPlayerCreated { get; set; } = false;

    public ICollection<ApplicationUserClaim>? UserClaims { get; set; }

    public ICollection<ApplicationUserLogin>? UserLogins { get; set; }

    public ICollection<ApplicationUserToken>? UserTokens { get; set; }

    public ICollection<ApplicationUserRole>? UserRoles { get; set; }
}
