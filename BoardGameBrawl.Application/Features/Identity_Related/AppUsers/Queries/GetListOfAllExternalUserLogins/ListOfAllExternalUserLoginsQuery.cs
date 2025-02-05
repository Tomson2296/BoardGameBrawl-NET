using BoardGameBrawl.Domain.Entities;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListOfExternalUserLogins
{
    public class ListOfAllExternalUserLoginsQuery : IRequest<IList<ApplicationUserLogin>>
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
