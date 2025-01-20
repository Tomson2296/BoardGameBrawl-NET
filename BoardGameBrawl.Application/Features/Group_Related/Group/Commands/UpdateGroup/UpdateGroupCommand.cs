#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest<Unit>
    {
        public GroupDTO GroupDTO { get; set; }
    }
}
