using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.ValueConverters
{
    internal class TournamentProgressTypeConverter : ValueConverter<TournnamentProgress, string>
    {
        public TournamentProgressTypeConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<TournnamentProgress>(v))
        { }
    }
}
