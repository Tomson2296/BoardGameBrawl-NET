using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroup
{
    public class GetGroupQuery : IRequest<GroupDTO>
    {
        public Guid Id { get; set; }
    }
}
