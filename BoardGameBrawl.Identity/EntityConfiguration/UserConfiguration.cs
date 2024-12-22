using BoardGameBrawl.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Identity.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity.Property(e => e.UserCreatedDate)
                .HasColumnName("CreationDate")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            // Each User can have many UserClaims
            entity.HasMany(e => e.UserClaims)
                .WithOne(e => e.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            entity.HasMany(e => e.UserLogins)
                .WithOne(e => e.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            entity.HasMany(e => e.UserTokens)
                .WithOne(e => e.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            entity.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            // Ignore default IdentityUser properties related to phone number
            // and TwoFactor authentication 

            entity.Ignore(e => e.PhoneNumber);

            entity.Ignore(e => e.PhoneNumberConfirmed);

            entity.Ignore(e => e.TwoFactorEnabled);

            // Adding additional index to - if User has an account on boardgamegeek.com website

            entity.HasIndex(e => e.BGGUsername)
                .HasDatabaseName("BGGUsernameIndex")
                .IsUnique();
            
            entity.ToTable("Users");
        }
    }
}
