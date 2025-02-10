using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.GetPlayerCollectionByPlayerId
{
    public class GetPlayerCollectionByPlayerIdQuery : IRequest<PlayerCollectionDTO?>
    {
        public Guid ApplicationUserId { get; set; }
    }
}
