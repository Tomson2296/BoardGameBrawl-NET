using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Commands.DeleteGroupParticipant
{
    public class DeleteGroupParticipantCommand : IRequest<BaseCommandResponse>
    {
        public Guid GroupId { get; set; }

        public Guid PlayerId { get; set; }
    }
}
