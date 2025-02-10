using AutoMapper;
using BoardGameBrawl.Domain.Entities.Match_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Match_Related
{
    [AutoMap(typeof(MatchRule))]
    public class MatchRuleDTO
    {
        public Guid RuleId { get; set; } 

        public string? RuleDescription { get; set; }

        public bool RuleDecider { get; set; }

        public RuleType RuleType { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
