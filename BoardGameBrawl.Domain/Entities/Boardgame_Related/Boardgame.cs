using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Common.BaseEntities;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Domain.Entities.Tournament_Related;

namespace BoardGameBrawl.Domain.Entities.Boardgame_Related
{
    public class Boardgame : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Name { get; set; }

        public int BGGId { get; set; }
        
        public short YearPublished { get; set; }

        public byte MinAge { get; set; }

        public byte MinPlayers { get; set; }
        
        public byte MaxPlayers { get; set; }

        public short PlayingTime { get; set; }

        public short MinimumPlayingTime { get; set; }

        public short MaximumPlayingTime { get; set; }

        public float AverageBGGWeight { get; set; }

        public float AverageRating { get; set; }

        public float BayesRating { get; set; }
        
        public int Owned { get; set; }

        public required byte[] Image { get; set; }
        
        public required string Description { get; set; }


        public MatchRuleSet? BoardgameRuleSet { get; set; }



        public ICollection<BoardgameDomainTag>? BoardgameDomainTags { get; set; }

        public ICollection<BoardgameCategoryTag>? BoardgameCategoryTags { get; set; }

        public ICollection<BoardgameMechanicTag>? BoardgameMechanicTags { get; set; }



        public ICollection<BoardgameModerator>? BoardgameModerators { get; set; }

        public ICollection<PlayerPreference>? PlayerPreferences { get; set; }

        public ICollection<PlayerFavouriteBG>? PlayerFavouriteBGs { get; set; }

        public ICollection<PlayerRating>? PlayerEloRatingsInGame { get; set; }



        public ICollection<BaseMatchEntity>? Matches { get; set; }
       
        public ICollection<Tournament>? Tournaments { get; set; }
    }
}