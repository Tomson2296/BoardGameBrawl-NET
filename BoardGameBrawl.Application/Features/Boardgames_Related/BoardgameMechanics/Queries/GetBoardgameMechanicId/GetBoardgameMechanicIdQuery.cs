#nullable disable
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameMechanics.Queries.GetBoardgameMechanicId
{
    public class GetBoardgameMechanicIdQuery : IRequest<Guid>
    {
        public string MechanicName { get; set; }
    }
}
