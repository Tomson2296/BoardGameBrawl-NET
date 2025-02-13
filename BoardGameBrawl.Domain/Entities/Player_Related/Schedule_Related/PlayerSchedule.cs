using BoardGameBrawl.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related
{
    public class PlayerSchedule : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(PlayerId))]
        public Player? Player { get; set; }

        public Guid PlayerId { get; set; }

        public ICollection<DailyAvailability>? DailyAvailabilities { get; set; }
    }
}