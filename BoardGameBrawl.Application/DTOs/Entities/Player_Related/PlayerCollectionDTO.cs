using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(PlayerCollection))]
    public class PlayerCollectionDTO : BaseAuditableEntityDTO
    {
        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public IList<int>? BoardgameCollection { get; set; }

        public bool IsCollectionCreated { get; set; }
    }
}
