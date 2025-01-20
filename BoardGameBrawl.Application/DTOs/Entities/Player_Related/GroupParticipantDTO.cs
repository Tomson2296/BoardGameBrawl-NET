using AutoMapper;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(GroupParticipant))]
    public class GroupParticipantDTO
    {
        public Guid? GroupId { get; set; }

        public Guid? PlayerId { get; set; }

        public bool IsAdmin { get; set; }
    }
}
