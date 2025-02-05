using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Domain.Entities;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListOfExternalUserLogins
{
    public class ListOfAllExternalUserLoginsQueryHandler : IRequestHandler<ListOfAllExternalUserLoginsQuery, IList<ApplicationUserLogin>>
    {
        private readonly IApplicationUserQueryService _applicationUserQueryService;

        public ListOfAllExternalUserLoginsQueryHandler(IApplicationUserQueryService applicationUserQueryService)
        {
            _applicationUserQueryService = applicationUserQueryService;
        }

        public async Task<IList<ApplicationUserLogin>> Handle(ListOfAllExternalUserLoginsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _applicationUserQueryService.GetListOfAllExternalLoginsAsync(
                request.PageSize,
                request.PageNumber,
                cancellationToken
            );
        }
    }
}
