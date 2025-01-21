using AutoMapper;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Group_Related
{
    [AutoMap(typeof(GroupParticipant))]
    public class GroupParticipantDTO
    {
        public Guid GroupId { get; set; }

        public Guid PlayerId { get; set; }

        public bool IsAdmin { get; set; }
    }
}
