#nullable disable
using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class Match : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public MatchProgress MatchProgress { get; set; }

        public DateTime MatchDate_Created { get; set; }

        public DateTime MatchDate_Started { get; set; }

        public DateTime MatchDate_Ended { get; set; }

        public int NumberOfPlayers { get; set; }

        public Dictionary<string, MatchUserRoles> Participants { get; set; } 

        public Guid? BoardgameId { get; set; }

        
        //public MatchResult MatchResult { get; set; }
    }

    public enum MatchProgress
    {
        Upcoming,
        Started,
        Finished
    }

    public enum MatchUserRoles
    {
        Player,
        Host
    }
}
