using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerFavouriteBGs.Commands.DeletePlayerFavouriteBG
{
    public class DeletePlayerFavouriteBGCommand : IRequest<BaseCommandResponse>
    {
        public Guid PlayerId { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
