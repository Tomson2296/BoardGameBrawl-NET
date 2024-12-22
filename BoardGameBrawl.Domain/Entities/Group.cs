using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities
{
    public class Group : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? GroupName { get; set; }

        public string? GroupDescription { get; set; }

        public byte[]? GroupMiniature { get; set; }


        //public bool IsSoftDeleted { get; set; } = false;
        
        //public DateTime DeletedDate { get; set; }
        
        public ICollection<GroupParticipants>? GroupParticipants { get; set; }
    }
}
