﻿#nullable disable
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Commands.AddJunctionEntity
{
    public abstract class AddJunctionEntityCommand<TEntityDTO> : IRequest<BaseCommandResponse>
        where TEntityDTO : class
    {
        public TEntityDTO EntityDTO { get; set; }
    }
}
