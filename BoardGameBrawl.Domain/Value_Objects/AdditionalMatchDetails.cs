using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Value_Objects
{
    public class AdditionalMatchDetails
    {
        public string? DetailName { get; set; }
        
        public IList<string>? Details { get; set; }  
    }
}
