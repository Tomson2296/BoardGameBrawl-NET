using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related
{
    public class CompositePlayerBoardgamePreferencesDTO
    {
        public int BGGId { get; set; }

        public string? Boardgame_Name { get; set; }

        public byte[]? Boardgame_Image { get; set; }

        public byte Rating { get; set; }
    }
}
