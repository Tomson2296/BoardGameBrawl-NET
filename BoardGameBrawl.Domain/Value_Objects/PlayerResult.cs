using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Value_Objects
{
    public class PlayerResult
    {
        public string? PlayerUsername { get; set; }
        public int Score { get; set; }
    }
}
