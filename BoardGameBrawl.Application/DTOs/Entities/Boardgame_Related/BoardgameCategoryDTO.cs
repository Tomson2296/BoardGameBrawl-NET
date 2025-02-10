using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(BoardgameCategory))]
    public class BoardgameCategoryDTO
    {
        public Guid Id { get; set; }

        public string? Category { get; set; }
    }
}
