using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Domain.Entities.Tournament_Related;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class Player : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ApplicationUserId { get; set; }

        public required string PlayerName { get; set; }

        public required string Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BGGUsername { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }


        // Entity relationship collections 

        public PlayerCollection? PlayerCollection { get; set; }

        public PlayerSchedule? PlayerSchedule { get; set; }


        public ICollection<PlayerFavouriteBG>? PlayerFavouriteBGs { get; set; }

        public ICollection<PlayerPreference>? PlayerPreferences { get; set; }

        public ICollection<PlayerRating>? PlayerEloRatings { get; set; } 


        public ICollection<BoardgameModerator>? BoardgameModerators { get; set; }   
        
        public ICollection<GroupParticipant>? GroupParticipants { get; set; }


        public ICollection<PlayerFriend>? Friendships { get; set; }  

        public ICollection<PlayerFriend>? FriendOfFriendships { get; set; } 

        
        public ICollection<MatchParticipant>? MatchesParticipating { get; set; }

        public ICollection<MatchResult>? MatchesWinning { get; set; }

        public ICollection<TournamentParticipant>? TournamentParticipating { get; set; }

        public ICollection<TournamentMatchParticipant>? TournamentMatchesParticipating { get; set; }
    }
}
