#nullable disable
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Commands.AddEntity
{
    public abstract class AddEntityCommand<TEntityDTO> : IRequest<BaseCommandResponse>
        where TEntityDTO : class
    {
        public TEntityDTO EntityDTO { get; set; }
    }
}
