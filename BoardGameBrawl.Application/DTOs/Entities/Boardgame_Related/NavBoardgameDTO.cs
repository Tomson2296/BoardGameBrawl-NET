using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(Boardgame))]
    public class NavBoardgameDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int BGGId { get; set; }

        public short YearPublished { get; set; }

        public byte[]? Image { get; set; }
    }
}
