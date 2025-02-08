using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.GetPlayerCollection
{
    public class GetPlayerCollectionQuery : IRequest<PlayerCollectionDTO>
    {
        public Guid Id { get; set; }
    }
}
