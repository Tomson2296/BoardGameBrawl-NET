using AutoMapper;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(BoardgameCategoryTag))]
    public class BoardgameCategoryTagDTO
    {
        public Guid BoardgameId { get; set; }

        public string? BoardgameName { get; set; }

        public Guid CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
