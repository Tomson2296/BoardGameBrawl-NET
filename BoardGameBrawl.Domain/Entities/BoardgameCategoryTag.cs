using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class BoardgameCategoryTag 
    {
        public Guid? BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public int? CategoryId { get; set; }

        public BoardgameCategory? BoardgameCategory { get; set; }

        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }
    }
}
