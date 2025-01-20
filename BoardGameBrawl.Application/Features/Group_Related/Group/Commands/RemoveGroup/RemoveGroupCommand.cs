using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Commands.RemoveGroup
{
    public class RemoveGroupCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
