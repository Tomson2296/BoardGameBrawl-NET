using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Tournament_Related;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
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

        public float BGGWeight { get; set; }

        public byte[]? Image { get; set; }
        
        public string? Description { get; set; }

        public ICollection<BoardgameCategoryTag>? BoardgameCategoryTags { get; set; }

        public ICollection<BoardgameMechanicTag>? BoardgameMechanicTags { get; set; }

        public ICollection<MatchRule>? BoardgameRules { get; set; }

        public ICollection<UserRatings>? UserRatings { get; set; }

        public ICollection<Match>? Matches { get; set; }

        public ICollection<Tournament>? Tournaments { get; set; }

        public ICollection<TournamentMatch>? TournamentMatches { get; set; }
    }
}