using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Player_Related.Preference_Related
{
    public class CompositeBoardgamePreferencesByPlayers
    {
        public PlayerPreference? PlayerPreference { get; set; }
        
        public Player? Player { get; set; }
    }
}
