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
    internal class BoardgameDomainConfiguration : IEntityTypeConfiguration<BoardgameDomain>
    {
        public void Configure(EntityTypeBuilder<BoardgameDomain> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Domain)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasIndex(e => e.Domain)
                .HasDatabaseName("DomainIndex")
                .IsUnique();

            entity.ToTable("BoardgameDomains");
        }
    }
}
