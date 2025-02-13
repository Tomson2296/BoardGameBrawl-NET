using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Group_Related
{
    public class CompositeGroupParticipantDTO
    {
        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public byte[]? UserAvatar { get; set; }

        public bool IsAdmin { get; set; }
    }
}
