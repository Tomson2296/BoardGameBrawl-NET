using BoardGameBrawl.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Identity.EntityConfiguration
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> entity)
        {
            entity.ToTable("UserLogins");
        }
    }
}
