using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListUsersInRole
{
    public class ListFilteredUsersByRoleQuery : IRequest<IList<NavUserDTO>>
    {
        public Guid RoleId { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
