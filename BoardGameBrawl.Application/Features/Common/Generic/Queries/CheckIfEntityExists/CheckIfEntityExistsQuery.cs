#nullable disable
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Queries.CheckIfEntityExists
{
    public abstract class CheckIfEntityExistsQuery<TEntityDTO> : IRequest<bool>
        where TEntityDTO : class
    {
        public TEntityDTO EntityDTO { get; set; }
    }
}
