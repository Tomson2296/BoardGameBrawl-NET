using BoardGameBrawl.Domain.Entities.Match_Related;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

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
