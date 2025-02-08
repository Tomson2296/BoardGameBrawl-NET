using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class PlayerFriendConfiguration : IEntityTypeConfiguration<PlayerFriend>
    {
        public void Configure(EntityTypeBuilder<PlayerFriend> entity)
        {
                // Composite primary key
                entity.HasKey(uf => new { uf.RequesterId, uf.AddresseeId });

                entity.Property(uf => uf.FriendshipDate)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("getdate()");

                entity.Property(uf => uf.Status)
                    .HasConversion<FriendshipStatusTypeConverter>()
                    .IsRequired();

                entity.Property(e => e.RequesterName)
                    .HasMaxLength(256)
                    .IsRequired();

                entity.Property(e => e.AddresseeName)
                    .HasMaxLength(256)
                    .IsRequired();

                // Configure relationships
                entity.HasOne(uf => uf.Requester)
                        .WithMany(u => u.Friendships)
                        .HasForeignKey(uf => uf.RequesterId)
                        .OnDelete(DeleteBehavior.Restrict);  

                entity.HasOne(uf => uf.Addressee)
                    .WithMany(u => u.FriendOfFriendships)
                    .HasForeignKey(uf => uf.AddresseeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.ToTable("PlayerFriends");
        }
    }
}
