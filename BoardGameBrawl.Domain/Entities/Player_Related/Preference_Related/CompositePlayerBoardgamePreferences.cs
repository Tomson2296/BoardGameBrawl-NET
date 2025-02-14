using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related
{
    public class CompositePlayerBoardgamePreferences
    {
        public PlayerPreference? PlayerPreference { get; set; }

        public Boardgame? Boardgame { get; set; }
    }
}
