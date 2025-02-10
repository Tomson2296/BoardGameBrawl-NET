using AutoMapper;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Group_Related
{
    [AutoMap(typeof(Group))]
    public class GroupDTO
    {
        public Guid Id { get; set; }

        public string? GroupName { get; set; }

        public string? GroupDescription { get; set; }

        public byte[]? GroupMiniature { get; set; }
    }
}
