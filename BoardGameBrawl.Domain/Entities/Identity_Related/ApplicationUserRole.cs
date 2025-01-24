#nullable disable
using Microsoft.AspNetCore.Identity;

namespace BoardGameBrawl.Domain.Entities
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }

}