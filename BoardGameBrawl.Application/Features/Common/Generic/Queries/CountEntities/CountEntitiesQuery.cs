using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Queries.CountEntities
{
    public abstract class CountEntitiesQuery : IRequest<int>
    {

    }
}
