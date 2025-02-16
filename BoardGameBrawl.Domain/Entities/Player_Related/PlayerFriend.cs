using BoardGameBrawl.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class PlayerFriend : BaseAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        [ForeignKey(nameof(RequesterId))]
        public Player? Requester { get; set; }

        public Guid RequesterId { get; set; }

        public required string RequesterName { get; set; }


        [ForeignKey(nameof(AddresseeId))]
        public Player? Addressee { get; set; }

        public Guid AddresseeId { get; set; }

        public required string AddresseeName { get; set; }


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