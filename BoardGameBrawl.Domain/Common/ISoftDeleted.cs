using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Common
{
    public interface ISoftDeleted
    {
        public bool IsSoftDeleted { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
