using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Identity_Related
{
    internal class UserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> entity)
        {
            // Composite primary key consisting of the UserId, LoginProvider and Name
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            entity.Property(t => t.LoginProvider)
                .HasMaxLength(450);

            entity.Property(t => t.Name)
                .HasMaxLength(450);

            entity.ToTable("UserTokens");
        }
    }
}
