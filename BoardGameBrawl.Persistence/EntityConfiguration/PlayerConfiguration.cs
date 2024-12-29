using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<Player>
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
                .HasMaxLength(256);

            entity.Property(e => e.LastName)
                .HasMaxLength(256);

            entity.Property(e => e.BGGUsername)
                .HasMaxLength(256);

            entity.Property(e => e.UserDescription)
                .HasMaxLength(512);

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
