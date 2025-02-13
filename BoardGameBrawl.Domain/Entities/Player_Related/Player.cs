using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Group_Related;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class Player : BaseEntity
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

        public ICollection<PlayerPreference>? PlayerRatings { get; set; }


        public ICollection<BoardgameModerator>? BoardgameModerators { get; set; }   
        
        public ICollection<GroupParticipant>? GroupParticipants { get; set; }


        public ICollection<PlayerFriend>? Friendships { get; set; }  

        public ICollection<PlayerFriend>? FriendOfFriendships { get; set; } 
    }
}
