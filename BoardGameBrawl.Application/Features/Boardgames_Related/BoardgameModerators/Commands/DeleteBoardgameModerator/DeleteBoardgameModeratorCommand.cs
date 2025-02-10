using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameModerators.Commands.DeleteBoardgameModerator
{
    public class DeleteBoardgameModeratorCommand : IRequest<BaseCommandResponse>
    {
        public Guid ModeratorId { get; set; }

        public Guid BoardgameId { get; set; }
    }
}
