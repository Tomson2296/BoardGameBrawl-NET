using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Commands.RemoveBoardgame
{
    public class RemoveBoardgameCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
