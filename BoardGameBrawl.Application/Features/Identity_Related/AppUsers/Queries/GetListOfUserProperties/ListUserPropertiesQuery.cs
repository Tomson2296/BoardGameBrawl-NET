using BoardGameBrawl.Application.DTOs.Entities.Identity_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Queries.ListUserProperties
{
    public class ListUserPropertiesQuery : IRequest<ViewUserDTO>
    {
        public Guid Id { get; set; }
    }
}
