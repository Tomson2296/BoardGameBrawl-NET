using AutoMapper;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Match_Related
{
    [AutoMap(typeof(MatchRuleSet))]
    public class MatchRuleSetDTO
    {
        public Guid Id { get; set; }

        public Guid BoardgameId { get; set; }

        public VictoryConditions? VictoryConditions { get; set; }

        public AdditionalMatchDetails? AdditionalMatchDetails { get; set; }
    }
}
