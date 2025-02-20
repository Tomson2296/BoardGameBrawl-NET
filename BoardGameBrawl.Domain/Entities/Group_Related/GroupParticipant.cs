﻿using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Domain.Entities.Group_Related
{
    public class GroupParticipant
    {
        public Guid? GroupId { get; set; }

        public Group? Group { get; set; }

        public required string GroupName { get; set; }

        public Guid? PlayerId { get; set; }

        public Player? Player { get; set; }

        public required string PlayerName { get; set; }
 
        public bool IsAdmin { get; set; }       
    }
}
