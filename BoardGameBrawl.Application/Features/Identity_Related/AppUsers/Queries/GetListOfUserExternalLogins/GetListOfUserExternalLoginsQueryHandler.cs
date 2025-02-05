using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.GetListOfUserExternalLogins
{
    public class GetListOfUserExternalLoginsQueryHandler : IRequestHandler<GetListOfUserExternalLoginsQuery, IList<ApplicationUserLogin>>
    {
        private readonly IApplicationUserQueryService _applicationUserQueryService;

        public GetListOfUserExternalLoginsQueryHandler(IApplicationUserQueryService applicationUserQueryService)
        {
            _applicationUserQueryService = applicationUserQueryService;
        }

        public async Task<IList<ApplicationUserLogin>> Handle(GetListOfUserExternalLoginsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _applicationUserQueryService.GetExternalLoginByUserIdAsync(
                request.UserId,
                cancellationToken);
        }
    }
}
