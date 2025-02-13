using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Queries.GetGroupAdminStatus
{
    public class GetGroupAdminStatusQuery : IRequest<bool>
    {
        public Guid GroupId { get; set; }

        public Guid PlayerId { get; set; }
    }
}
