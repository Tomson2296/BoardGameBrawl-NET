using AutoMapper;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Player_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related
{
    [AutoMap(typeof(BoardgameModerator))]
    public class BoardgameModeratorDTO 
    {
        public Guid ModeratorId { get; set; }

        public string? ModeratorName { get; set; }

        public Guid BoardgameId { get; set; }

        public string? BoardgameName { get; set; }
    }
}
