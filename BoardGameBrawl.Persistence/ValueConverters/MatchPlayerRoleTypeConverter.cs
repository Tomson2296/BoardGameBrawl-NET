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
    public class MatchPlayerRoleTypeConverter : ValueConverter<MatchPlayerRole, string>
    {
        public MatchPlayerRoleTypeConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<MatchPlayerRole>(v))
        { }
    }
}
