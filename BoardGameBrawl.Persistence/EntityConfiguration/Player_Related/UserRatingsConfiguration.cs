using BoardGameBrawl.Domain.Entities.Player_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Player_Related
{
    internal class UserRatingsConfiguration : IEntityTypeConfiguration<UserRatings>
    {
        public void Configure(EntityTypeBuilder<UserRatings> entity)
        {
            entity.HasKey(e => new { e.PlayerId, e.BoardgameId });

            entity.HasOne(e => e.Player)
               .WithMany(u => u.UserRatings)
               .HasForeignKey(e => e.PlayerId);

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.UserRatings)
                .HasForeignKey(e => e.BoardgameId);

            entity.Property(e => e.Rating)
               .IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("UserRatings");
        }
    }
}
