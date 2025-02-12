using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetAllGroupsByPlayer
{
    public class GetAllGroupsByPlayerQuery : IRequest<IList<NavGroupDTO>>
    {
        public Guid PlayerId { get; set; }
    }
}
