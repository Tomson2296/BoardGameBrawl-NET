using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.CheckIfPlayerPreferenceExists
{
    public class CheckIfPlayerPreferenceExistsQuery : IRequest<bool>
    {
        public Guid PlayerId { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
