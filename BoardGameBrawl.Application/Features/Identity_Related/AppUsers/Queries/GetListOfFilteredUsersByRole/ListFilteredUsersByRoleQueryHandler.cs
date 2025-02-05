using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListUsersInRole
{
    public class ListFilteredUsersByRoleQueryHandler : IRequestHandler<ListFilteredUsersByRoleQuery, IList<NavUserDTO>>
    {
        private readonly IApplicationUserQueryService _applicationUserQueryService;

        public ListFilteredUsersByRoleQueryHandler(IApplicationUserQueryService applicationUserQueryService)
        {
            _applicationUserQueryService = applicationUserQueryService;
        }

        public async Task<IList<NavUserDTO>> Handle(ListFilteredUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _applicationUserQueryService.GetFilteredUsersByAppRoleAsync(
                request.PageSize,
                request.PageNumber,
                request.RoleId,
                cancellationToken);
        }
    }
}
