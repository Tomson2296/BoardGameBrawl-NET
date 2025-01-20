using BoardGameBrawl.Domain.Entities.Tournament_Related;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

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
