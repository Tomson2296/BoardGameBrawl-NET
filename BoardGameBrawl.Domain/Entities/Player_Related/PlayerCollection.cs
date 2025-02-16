using BoardGameBrawl.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class PlayerCollection : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(PlayerId))]
        public Player? Player { get; set; }

        public Guid PlayerId { get; set; }

        public required string PlayerName { get; set; }    

        public IList<int>? BoardgameCollection { get; set; }

        public bool IsCollectionCreated { get; set; }
    }
}
