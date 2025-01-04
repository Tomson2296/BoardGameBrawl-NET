using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Domain.Entities.Group_Related
{
    public class Group : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? GroupName { get; set; }

        public string? GroupDescription { get; set; }

        public byte[]? GroupMiniature { get; set; }


        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }

        public ICollection<GroupParticipants>? GroupParticipants { get; set; }
    }
}
