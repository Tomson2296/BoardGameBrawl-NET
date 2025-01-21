using AutoMapper;
using BoardGameBrawl.Domain.Entities.Player_Related;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(PlayerRreference))]
    public class PlayerPreferenceDTO
    {
        public Guid PlayerId { get; set; }

        public Guid BoardgameId { get; set; }

        public byte Rating { get; set; }
    }
}
