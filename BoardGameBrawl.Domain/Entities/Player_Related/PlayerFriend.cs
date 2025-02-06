using BoardGameBrawl.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class PlayerFriend : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(RequesterId))]
        public Player? Requester { get; set; }

        public Guid RequesterId { get; set; }


        [ForeignKey(nameof(AddresseeId))]
        public Player? Addressee { get; set; }

        public Guid AddresseeId { get; set; }


        public DateTime FriendshipDate { get; set; }

        public FriendshipStatus Status { get; set; }
    }
}

public enum FriendshipStatus
{
    Pending,
    Accepted,
    Declined
}