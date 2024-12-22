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
    internal class BoardgameMechanicTagConfigutaion : IEntityTypeConfiguration<BoardgameMechanicTag>
    {
        public void Configure(EntityTypeBuilder<BoardgameMechanicTag> entity)
        {
            entity.HasKey(e => new { e.BoardgameId, e.MechanicId });

            entity.HasOne(e => e.Boardgame)
               .WithMany(b => b.BoardgameMechanicTags)
               .HasForeignKey(e => e.BoardgameId);

            entity.HasOne(e => e.BoardgameMechanic)
                .WithMany(m => m.BoardgameMechanicTags)
                .HasForeignKey(e => e.MechanicId);

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("BoardgameMechanicTags");
        }
    }
}
