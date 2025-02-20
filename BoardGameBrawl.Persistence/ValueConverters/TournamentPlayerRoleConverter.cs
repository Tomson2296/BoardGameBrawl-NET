﻿using BoardGameBrawl.Domain.Entities.Tournament_Related;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace BoardGameBrawl.Persistence.ValueConverters
{
    internal class TournamentPlayerRoleConverter : ValueConverter<TournamentPlayerRole, string>
    {
        public TournamentPlayerRoleConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<TournamentPlayerRole>(v))
        { }
    }
}
