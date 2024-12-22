#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class TournamentMatch
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public MatchProgress MatchProgress { get; set; }

        public DateTime MatchDate_Created { get; set; }

        public DateTime MatchDate_Started { get; set; }

        public DateTime MatchDate_Ended { get; set; }

        public int NumberOfPlayers { get; set; }

        public Dictionary<string, MatchUserRoles> Participants { get; set; }

        public Guid? BoardgameId { get; set; }
        
        public Guid? TournamentId { get; set; }

        public short MatchNumber { get; set; }
    }
}
