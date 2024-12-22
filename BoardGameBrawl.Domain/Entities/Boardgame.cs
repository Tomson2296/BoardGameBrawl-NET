using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class Boardgame : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Name { get; set; }

        public int BGGId { get; set; }
        
        public short YearPublished { get; set; }

        public byte MinPlayers { get; set; }
        
        public byte MaxPlayers { get; set; }

        public short PlayingTime { get; set; }

        public short MinimumPlayingTime { get; set; }

        public short MaximumPlayingTime { get; set; }

        public string? ThumbnailFilePath { get; set; }

        public string? ImageFilePath { get; set; }

        public string? Description { get; set; }

        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }


        public ICollection<BoardgameCategoryTag>? BoardgameCategoryTags { get; set; }

        public ICollection<BoardgameMechanicTag>? BoardgameMechanicTags { get; set; }

        public ICollection<MatchRule>? BoardgameRules { get; set; }

        public ICollection<UserRatings>? UserRatings { get; set; }

        public ICollection<Match>? Matches { get; set; }

        public ICollection<Tournament>? Tournaments { get; set; }

        public ICollection<TournamentMatch>? TournamentMatches { get; set; }
    }
}