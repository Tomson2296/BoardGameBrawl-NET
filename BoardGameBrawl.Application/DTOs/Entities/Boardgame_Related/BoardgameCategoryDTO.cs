using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(BoardgameCategory))]
    public class BoardgameCategoryDTO : BaseEntityDTO
    {
        public string? Category { get; set; }
    }
}
