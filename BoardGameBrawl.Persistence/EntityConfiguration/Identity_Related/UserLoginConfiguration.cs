using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Identity_Related
{
    internal class UserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> entity)
        {
            // Composite primary key consisting of the LoginProvider and the key to use
            // with that provider
            entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });

            // Limit the size of the composite key columns due to common DB restrictions
            entity.Property(l => l.LoginProvider)
                .HasMaxLength(450);

            entity.Property(l => l.ProviderKey)
                .HasMaxLength(450);

            entity.ToTable("UserLogins");
        }
    }
}
