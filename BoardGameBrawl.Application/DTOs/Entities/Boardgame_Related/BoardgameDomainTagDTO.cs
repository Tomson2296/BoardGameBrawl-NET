using AutoMapper;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(BoardgameDomainTag))]
    public class BoardgameDomainTagDTO
    {
        public Guid BoardgameId { get; set; }

        public string? BoardgameName { get; set; }

        public Guid DomainId { get; set; }

        public string? DomainName { get; set; }
    }
}
