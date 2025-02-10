using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Commands.DeleteEntity
{
    public abstract class DeleteEntityCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
