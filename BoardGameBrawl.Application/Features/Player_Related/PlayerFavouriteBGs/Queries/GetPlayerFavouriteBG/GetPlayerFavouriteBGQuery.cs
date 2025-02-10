using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetPlayerFavouriteBG
{
    public class GetPlayerFavouriteBGQuery : IRequest<PlayerFavouriteBGDTO>
    {
        public Guid PlayerId { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
