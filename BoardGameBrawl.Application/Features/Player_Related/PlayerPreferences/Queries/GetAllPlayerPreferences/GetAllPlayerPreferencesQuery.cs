using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetAllPlayerPreferences
{
    public class GetAllPlayerPreferencesQuery : IRequest<IDictionary<Guid, byte>>
    {
        public Guid PlayerId { get; set; }
    }
}
