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
    internal class BoardgameMechanicConfiguration : IEntityTypeConfiguration<BoardgameMechanic>
    {
        public void Configure(EntityTypeBuilder<BoardgameMechanic> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Mechanic).HasMaxLength(256).IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("BoardgameMechanics");
        }
    }
}
