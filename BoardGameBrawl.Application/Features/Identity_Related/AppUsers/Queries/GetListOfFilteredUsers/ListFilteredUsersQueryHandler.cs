using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListFilteredUsers
{
    public class ListFilteredUsersQueryHandler : IRequestHandler<ListFilteredUsersQuery, ICollection<NavUserDTO>>
    {
        private readonly IApplicationUserQueryService _userQueryService;

        public ListFilteredUsersQueryHandler(IApplicationUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public async Task<ICollection<NavUserDTO>> Handle(
            ListFilteredUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await _userQueryService.GetFilteredUsersByUsernameAsync(
                request.PageSize,
                request.PageNumber,
                request.Filter,
                cancellationToken
            );
        }
    }
}
