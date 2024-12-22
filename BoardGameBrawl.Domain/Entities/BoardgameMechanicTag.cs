using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class BoardgameMechanicTag 
    {
        public Guid? BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public int? MechanicId { get; set; }

        public BoardgameMechanic? BoardgameMechanic { get; set; }

        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }
    }
}