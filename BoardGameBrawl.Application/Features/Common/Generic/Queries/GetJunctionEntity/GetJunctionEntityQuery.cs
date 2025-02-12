using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Queries.GetJunctionEntity
{
    public abstract class GetJunctionEntityQuery<TEntityDTO> : IRequest<TEntityDTO>
        where TEntityDTO : class
    {
        public object[]? JunctionCompositeKeys { get; set; }
    }
}
