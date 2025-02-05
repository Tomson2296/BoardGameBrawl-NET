using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListUserProperties
{
    public class ListUserPropertiesQueryHandler : IRequestHandler<ListUserPropertiesQuery, ViewUserDTO>
    {
        private readonly IApplicationUserQueryService _userQueryService;

        public ListUserPropertiesQueryHandler(IApplicationUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public async Task<ViewUserDTO> Handle(ListUserPropertiesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _userQueryService.GetUserPropertiesAsync(
                request.Id,
                cancellationToken
            );
        }
    }
}
