using BoardGameBrawl.Application.Features.Common.Generic.Queries.CheckIfJunctionEntityExists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.CheckIfUserIsParticipant
{
    public class CheckIfUserIsParticipantQuery : IRequest<bool>
    {
        public Guid GroupId { get; set; }

        public Guid PlayerId { get; set; }
    }
}
