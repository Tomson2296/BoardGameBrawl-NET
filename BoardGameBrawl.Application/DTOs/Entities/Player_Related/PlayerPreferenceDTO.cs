using AutoMapper;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(PlayerPreference))]
    public class PlayerPreferenceDTO 
    {
        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public Guid BoardgameId { get; set; }

        public string? BoardgameName { get; set; }

        public byte Rating { get; set; }
    }
}
