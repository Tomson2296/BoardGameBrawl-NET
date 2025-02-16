using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class Match : BaseMatchEntity
    {
        public ICollection<MatchParticipant>? MatchParticipants { get; set; }
    }
}