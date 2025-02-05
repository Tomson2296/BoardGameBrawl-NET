using BoardGameBrawl.Domain.Entities;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.GetListOfUserExternalLogins
{
    public class GetListOfUserExternalLoginsQuery : IRequest<IList<ApplicationUserLogin>>
    {
        public Guid UserId { get; set; }
    }
}
