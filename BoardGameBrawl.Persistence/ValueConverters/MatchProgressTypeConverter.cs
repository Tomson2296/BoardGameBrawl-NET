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
    internal class MatchProgressTypeConverter : ValueConverter<MatchProgress, string>
    {
        public MatchProgressTypeConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<MatchProgress>(v))
        { }
    }
}
