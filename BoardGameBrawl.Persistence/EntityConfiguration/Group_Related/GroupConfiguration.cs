using BoardGameBrawl.Domain.Entities.Group_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Group_Related
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.GroupName)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasIndex(e => e.GroupName)
                .HasDatabaseName("GroupNameIndex")
                .IsUnique();

            entity.Property(e => e.GroupDescription)
                .HasMaxLength(2048);

            entity.Property(e => e.GroupMiniature)
               .HasColumnType("varbinary(max)")
               .IsRequired(false);

            entity.ToTable("Groups");
        }
    }
}
