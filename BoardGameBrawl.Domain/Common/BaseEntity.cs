using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Common
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        [MaxLength(256)]
        public string? CreatedBy { get; set; }
        

        public DateTime LastModifiedDate { get; set; }
        
        [MaxLength(256)]
        public string? LastModifiedBy { get; set; }
    }
}
