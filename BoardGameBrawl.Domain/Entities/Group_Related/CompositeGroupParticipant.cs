#nullable disable
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Group_Related
{
    public class CompositeGroupParticipant
    {
        public Player Player { get; set; }

        public GroupParticipant GroupParticipant { get; set; }
    }
}
