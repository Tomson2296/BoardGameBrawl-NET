using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class GroupParticipants
    {
        public Guid? GroupId { get; set; }

        public Group? Group { get; set; }

        public Guid? PlayerId { get; set; }

        public Player? Player { get; set; }

    }
}
