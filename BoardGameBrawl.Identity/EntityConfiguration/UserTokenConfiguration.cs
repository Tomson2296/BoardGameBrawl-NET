using BoardGameBrawl.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Identity.EntityConfiguration
{
    internal class UserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> entity)
        {
            entity.ToTable("UserTokens");
        }
    }
}
