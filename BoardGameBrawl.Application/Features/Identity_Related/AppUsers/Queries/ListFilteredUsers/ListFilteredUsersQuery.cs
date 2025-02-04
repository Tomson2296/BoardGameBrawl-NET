using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListFilteredUsers
{
    public class ListFilteredUsersQuery : IRequest<ICollection<NavUserDTO>>
    {
        public string? Filter { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
