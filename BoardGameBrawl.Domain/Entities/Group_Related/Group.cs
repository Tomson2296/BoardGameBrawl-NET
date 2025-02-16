using BoardGameBrawl.Domain.Common;

namespace BoardGameBrawl.Domain.Entities.Group_Related
{
    public class Group : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string GroupName { get; set; }

        public string? GroupDescription { get; set; }

        public byte[]? GroupMiniature { get; set; }

        public ICollection<GroupParticipant>? GroupParticipants { get; set; }
    }
}
