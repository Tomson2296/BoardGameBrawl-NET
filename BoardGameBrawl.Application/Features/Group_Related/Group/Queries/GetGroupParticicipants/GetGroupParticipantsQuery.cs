using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetGroupParticicipants
{
    public class GetGroupParticipantsQuery : IRequest<ICollection<NavPlayerDTO>>
    {
        public Guid GroupId { get; set; }
    }
}
