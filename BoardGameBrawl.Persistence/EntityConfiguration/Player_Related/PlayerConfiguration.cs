using BoardGameBrawl.Domain.Entities.Player_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.UserName)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.FirstName)
                .HasMaxLength(256)
                .IsRequired(false);

            entity.Property(e => e.LastName)
                .HasMaxLength(256)
                .IsRequired(false);

            entity.Property(e => e.BGGUsername)
                .HasMaxLength(256)
                .IsRequired(false);

            entity.Property(e => e.UserDescription)
                .HasMaxLength(2048)
                .IsRequired(false);

            entity.Property(e => e.UserAvatar)
               .HasColumnType("varbinary(max)")
               .IsRequired(false);

            // configure indexes

            entity.HasIndex(e => e.UserName)
                .HasDatabaseName("UserNameIndex")
                .IsUnique();

            entity.HasIndex(e => e.Email)
               .HasDatabaseName("UserEmailIndex")
               .IsUnique();

            entity.HasIndex(e => e.BGGUsername)
               .HasDatabaseName("BGGUsernameIndex")
               .IsUnique();

            entity.ToTable("Players");
        }
    }
}
