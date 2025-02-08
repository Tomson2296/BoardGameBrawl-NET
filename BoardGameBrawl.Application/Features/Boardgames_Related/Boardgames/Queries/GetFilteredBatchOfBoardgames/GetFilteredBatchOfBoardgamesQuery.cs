#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.Boardgames.Queries.GetFilteredBatchOfBoardgames
{
    public class GetFilteredBatchOfBoardgamesQuery : IRequest<IList<NavBoardgameDTO>>
    {
        public string Filter { get; set; }

        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
