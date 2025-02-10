using AutoMapper;
using BoardGameBrawl.Application.DTOs.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Player_Related
{
    [AutoMap(typeof(PlayerFavouriteBG))]
    public class PlayerFavouriteBGDTO 
    {
        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public Guid BoardgameId { get; set; }

        public string? BoardgameName { get; set; }
    }
}
