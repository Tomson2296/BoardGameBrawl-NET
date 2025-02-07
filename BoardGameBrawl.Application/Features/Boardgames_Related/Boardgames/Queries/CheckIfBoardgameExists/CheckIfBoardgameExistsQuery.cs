using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.CheckIfBoardgameExists
{
    public class CheckIfBoardgameExistsQuery : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
