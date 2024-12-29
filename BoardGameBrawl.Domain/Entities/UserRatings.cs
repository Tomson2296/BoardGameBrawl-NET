using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class UserRatings
    {
        public Guid? PlayerId { get; set; }

        public Player? Player { get; set; }

        public Guid? BoardgameId { get; set; }

        public Boardgame? Boardgame { get; set; }

        public short? Rating { get; set; }

        public DateTime? RatingDateTime { get; set; }


        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }
    }
}
