﻿using BoardGameBrawl.Domain.Common;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Domain.Entities.Player_Related
{
    public class PlayerFavouriteBG : BaseAuditableEntity
    {
        [ForeignKey(nameof(PlayerId))]
        public Player? Player { get; set; }

        public Guid PlayerId { get; set; }

        public required string PlayerName { get; set; }


        [ForeignKey(nameof(BoardgameId))]
        public Boardgame? Boardgame { get; set; }

        public Guid BoardgameId { get; set; }

        public required string BoardgameName { get; set; }
    }
}
