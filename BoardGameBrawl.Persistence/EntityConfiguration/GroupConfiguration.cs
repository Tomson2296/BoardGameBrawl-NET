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
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.GroupName).HasMaxLength(256).IsRequired();
            entity.HasIndex(e => e.GroupName).HasDatabaseName("GroupNameIndex").IsUnique();

            entity.Property(e => e.GroupDescription).HasMaxLength(512);

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("Groups");
        }
    }
}
