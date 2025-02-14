using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetAllPlayerPreferences
{
    public class GetAllPlayerPreferencesQuery : IRequest<IList<PlayerPreferenceDTO>>
    {
        public Guid PlayerId { get; set; }
    }
}
