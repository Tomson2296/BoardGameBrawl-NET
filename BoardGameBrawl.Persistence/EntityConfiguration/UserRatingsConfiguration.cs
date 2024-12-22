using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration
{
    internal class UserRatingsConfiguration : IEntityTypeConfiguration<UserRatings>
    {
        public void Configure(EntityTypeBuilder<UserRatings> entity)
        {
            entity.HasKey(e => new { e.AppUserId, e.BoardgameId });

            entity.HasOne(e => e.User)
               .WithMany(u => u.UserRatings)
               .HasForeignKey(e => e.AppUserId);

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.UserRatings)
                .HasForeignKey(e => e.BoardgameId);

            entity.Property(e => e.Rating)
               .IsRequired();

            entity.Property(e => e.RatingDateTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("UserRatings");
        }
    }
}
