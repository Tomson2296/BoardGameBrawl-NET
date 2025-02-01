﻿using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class Player : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ApplicationUserId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? BGGUsername { get; set; }

        public string? UserDescription { get; set; }

        public byte[]? UserAvatar { get; set; }

        public ICollection<GroupParticipant>? GroupParticipants { get; set; }

        public ICollection<PlayerRreference>? UserRatings { get; set; }
    }
}
