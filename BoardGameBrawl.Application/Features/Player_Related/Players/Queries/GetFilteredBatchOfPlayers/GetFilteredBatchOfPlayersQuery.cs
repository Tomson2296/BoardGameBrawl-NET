#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetFilteredBatchOfPlayers
{
    public class GetFilteredBatchOfPlayersQuery : IRequest<IList<NavPlayerDTO>>
    {
        public string Filter { get; set; }

        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
