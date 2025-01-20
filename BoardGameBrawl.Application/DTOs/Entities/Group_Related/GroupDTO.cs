using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Group_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Group_Related
{
    [AutoMap(typeof(Group))]
    public class GroupDTO: BaseAuditableEntityDTO
    {
        public string? GroupName { get; set; }

        public string? GroupDescription { get; set; }

        public byte[]? GroupMiniature { get; set; }
    }
}
