using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetBatchOfGroups
{
    public class GetBatchOfGroupsQuery : IRequest<ICollection<GroupDTO>>
    {
        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
