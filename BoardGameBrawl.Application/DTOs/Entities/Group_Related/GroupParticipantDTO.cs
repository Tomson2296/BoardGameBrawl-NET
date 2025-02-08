using AutoMapper;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Group_Related
{
    [AutoMap(typeof(GroupParticipant))]
    public class GroupParticipantDTO
    {
        public Guid GroupId { get; set; }

        public string? GroupName { get; set; }

        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
