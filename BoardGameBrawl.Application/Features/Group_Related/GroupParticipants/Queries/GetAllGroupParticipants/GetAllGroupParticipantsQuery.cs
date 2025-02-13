using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetAllGroupParticipants
{
    public class GetAllGroupParticipantsQuery : IRequest<IList<NavPlayerDTO>>
    {
        public Guid GroupId { get; set; }
    }
}
