using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Value_Objects
{
    public class VictoryConditions
    {
        public required string WinCondition { get; set; }  

        public bool? ConditionSatisfied { get; set; }
    }
}
