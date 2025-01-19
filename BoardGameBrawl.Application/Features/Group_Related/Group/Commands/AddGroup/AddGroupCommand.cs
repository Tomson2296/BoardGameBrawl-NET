#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Commands.AddGroup
{
    public class AddGroupCommand : IRequest<BaseCommandResponse>
    {
        public GroupDTO GroupDTO { get; set; }
    }
}
