using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Identity_Related
{
    internal class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> entity)
        {
            // Primary key
            entity.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            entity.HasIndex(r => r.NormalizedName)
                .HasDatabaseName("RoleNameIndex")
                .IsUnique();

            // A concurrency token for use with the optimistic concurrency checking
            entity.Property(r => r.ConcurrencyStamp)
                .IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            entity.Property(u => u.Name)
                .HasMaxLength(256);

            entity.Property(u => u.NormalizedName)
                .HasMaxLength(256);

            entity.Property(r => r.Description)
                .HasMaxLength(512);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            entity.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            entity.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();

            entity.ToTable("Roles");
        }
    }
}
