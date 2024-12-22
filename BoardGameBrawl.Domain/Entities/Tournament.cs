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
    public class Tournament : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string TournamentName { get; set; }

        public TournnamentProgress TournnamentProgress { get; set; }

        public DateTime TournamentDate_Created { get; set; }

        public DateTime TournamentDate_Started { get; set; }

        public DateTime TournamentDate_Ended { get; set; }

        public string Description { get; set; }

        public short MaxNumberOfPlayers { get; set; }

        public Guid BoardgameId { get; set; }

        public Dictionary<string, TournamentUserRoles> TournamentParticipants { get; set; }

        public ICollection<TournamentMatch> TournamentMatches { get; set; }


        //public bool IsSoftDeleted { get; set; } = false;
        
        //public DateTime DeletedDate { get; set; }
    }

    public enum TournnamentProgress
    {
        Upcoming,
        Started,
        Finished
    }

    public enum TournamentUserRoles
    {
        Player, 
        Host
    }
}
