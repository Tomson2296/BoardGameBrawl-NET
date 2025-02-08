using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Group_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Group_Related
{
    [AutoMap(typeof(Group))] 
    public class NavGroupDTO : BaseAuditableEntityDTO
    {
        public string? GroupName { get; set; }

        public byte[]? GroupMiniature { get; set; }
    }
}
