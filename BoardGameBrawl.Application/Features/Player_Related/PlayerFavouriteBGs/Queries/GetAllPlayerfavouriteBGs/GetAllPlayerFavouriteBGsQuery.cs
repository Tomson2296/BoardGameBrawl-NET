using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetAllPlayerfavouriteBGs
{
    public class GetAllPlayerFavouriteBGsQuery : IRequest<IList<NavBoardgameDTO>>
    {
        public Guid PlayerId { get; set; }
    }
}
