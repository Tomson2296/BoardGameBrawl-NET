using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class BoardgameModerator : BaseAuditableEntity
    {
        public Guid ModeratorId { get; set; }

        public Player? Moderator { get; set; }

        public required string ModeratorName { get; set; }


        public Guid BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public required string BoardgameName { get; set; }
    }
}
