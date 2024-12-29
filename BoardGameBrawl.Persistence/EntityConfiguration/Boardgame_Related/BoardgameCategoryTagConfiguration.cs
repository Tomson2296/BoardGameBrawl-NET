using BoardGameBrawl.Domain.Entities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameCategoryTagConfiguration : IEntityTypeConfiguration<BoardgameCategoryTag>
    {
        public void Configure(EntityTypeBuilder<BoardgameCategoryTag> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.CategoryId });

            entity.HasOne(e => e.Boardgame)
                .WithMany(b => b.BoardgameCategoryTags)
                .HasForeignKey(e => e.BoardgameId);

            entity.HasOne(e => e.BoardgameCategory)
                .WithMany(c => c.BoardgameCategoryTags)
                .HasForeignKey(e => e.CategoryId);

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("BoardgameCategoryTags");
        }
    }
}
