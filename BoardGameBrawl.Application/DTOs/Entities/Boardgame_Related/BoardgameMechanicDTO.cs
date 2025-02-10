using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(BoardgameMechanic))]
    public class BoardgameMechanicDTO
    {
        public Guid Id { get; set; }

        public string? Mechanic { get; set; }
    }
}
