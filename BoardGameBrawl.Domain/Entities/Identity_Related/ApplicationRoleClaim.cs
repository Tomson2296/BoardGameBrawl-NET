#nullable disable
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Domain.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationRole Role { get; set; }
}
