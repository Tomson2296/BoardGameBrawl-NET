using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related
{
    public class CompositeBoardgamePreferencesByPlayersDTO
    {
        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public byte[]? UserAvatar { get; set; }

        public byte Rating { get; set; }
    }
}
