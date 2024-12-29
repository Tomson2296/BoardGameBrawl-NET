using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class GroupParticipants 
    {
        public Guid? GroupId { get; set; }

        public Group? Group { get; set; }

        public Guid? PlayerId { get; set; }

        public Player? Player { get; set; }

        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }
    }
}
