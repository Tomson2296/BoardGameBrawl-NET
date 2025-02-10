#nullable disable
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Queries.CheckIfJunctionEntityExists
{
    public abstract class CheckIfJunctionEntityExistsQuery<TEntityDTO> : IRequest<bool>
        where TEntityDTO : class
    {
        TEntityDTO EntityDTO { get; set; }
    }
}
