using BoardGameBrawl.Domain.Entities.Tournament_Related;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.ValueConverters
{
    internal class TounrnamentUserRolesConverter : ValueConverter<TournamentUserRoles, string>
    {
        public TounrnamentUserRolesConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<TournamentUserRoles>(v))
        { }
    }
}
