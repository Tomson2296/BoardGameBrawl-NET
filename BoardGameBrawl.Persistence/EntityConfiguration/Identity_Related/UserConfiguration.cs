using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Identity_Related
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> entity)
        {
            // Primary key
            entity.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            entity.HasIndex(u => u.NormalizedUserName)
                .HasDatabaseName("UserNameIndex")
                .IsUnique();

            entity.HasIndex(u => u.NormalizedEmail)
                .HasDatabaseName("EmailIndex")
                .IsUnique();

            // A concurrency token for use with the optimistic concurrency checking
            entity.Property(u => u.ConcurrencyStamp)
                .IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            entity.Property(u => u.UserName)
                .HasMaxLength(256);

            entity.Property(u => u.NormalizedUserName)
                .HasMaxLength(256);

            entity.Property(u => u.Email)
                .HasMaxLength(256);

            entity.Property(u => u.NormalizedEmail)
                .HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            entity.Property(e => e.UserCreatedDate)
                .HasColumnName("CreationDate")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

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
            // 2FA authentication and Lockout features

            entity.Ignore(e => e.PhoneNumber);

            entity.Ignore(e => e.PhoneNumberConfirmed);

            entity.Ignore(e => e.TwoFactorEnabled);

            entity.Ignore(e => e.AccessFailedCount);

            entity.Ignore(e => e.LockoutEnabled);

            entity.Ignore(e => e.LockoutEnd);
            
            entity.ToTable("Users");
        }
    }
}
