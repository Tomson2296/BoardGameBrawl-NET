using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Queries.GetAllPlayersFavouringBG
{
    public class GetAllPlayersFavouringBGQuery : IRequest<IList<NavPlayerDTO>>
    {
        public Guid BoardgameId { get; set; }
    }
}
