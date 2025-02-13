using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.Features.Common.Generic.Commands.AddJunctionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Commands.AddGroupParticipant
{
    public class AddGroupParticipantCommand : AddJunctionEntityCommand<GroupParticipantDTO>
    {
    }
}
