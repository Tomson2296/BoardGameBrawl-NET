using BoardGameBrawl.Domain.Entities.Match_Related;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.ValueConverters
{
    internal class MatchRuleTypeConverter : ValueConverter<RuleType, string>
    {
        public MatchRuleTypeConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<RuleType>(v))
        { }
    }
}
