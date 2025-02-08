using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerCollections.Queries.CheckIfPlayerCollectionExists
{
    public class CheckIfPlayerCollectionExistsQuery : IRequest<bool>
    {
        public Guid ApplicationUserId { get ; set; }    
    }
}
