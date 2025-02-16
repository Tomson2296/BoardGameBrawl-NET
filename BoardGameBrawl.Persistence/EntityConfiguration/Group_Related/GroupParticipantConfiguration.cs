using BoardGameBrawl.Domain.Entities.Group_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Group_Related
{
    internal class GroupParticipantConfiguration : IEntityTypeConfiguration<GroupParticipant>
    {
        public void Configure(EntityTypeBuilder<GroupParticipant> entity)
        {
            entity.HasKey(e => new { e.GroupId, e.PlayerId });

            entity.HasOne(e => e.Group)
               .WithMany(g => g.GroupParticipants)
               .HasForeignKey(e => e.GroupId);

            entity.HasOne(e => e.Player)
                .WithMany(u => u.GroupParticipants)
                .HasForeignKey(e => e.PlayerId);

            entity.Property(e => e.GroupName)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.PlayerName)
                .HasMaxLength(256)
                .IsRequired();

            entity.Property(e => e.IsAdmin)
                .IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("GroupParticipants");
        }
    }
}
