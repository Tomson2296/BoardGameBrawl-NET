using BoardGameBrawl.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Match_Related
{
    public class MatchRule : BaseEntity
    {
        public Guid RuleId { get; set; } = Guid.NewGuid();

        public string? RuleDescription { get; set; }

        public bool RuleDecider { get; set; }

        public RuleType RuleType { get; set; }

        public Guid BoardgameId { get; set; }

        //public bool IsSoftDeleted { get; set; } = false;

        //public DateTime DeletedDate { get; set; }
    }
}
