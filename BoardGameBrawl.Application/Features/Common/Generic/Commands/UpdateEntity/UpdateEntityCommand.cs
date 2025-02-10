#nullable disable
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Commands.UpdateEntity
{
    public abstract class UpdateEntityCommand<TEntityDTO> : IRequest<Unit>
    {
        public TEntityDTO EntityDTO { get; set; }
    }
}