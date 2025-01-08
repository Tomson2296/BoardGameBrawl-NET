using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Commands.AddUser
{
    public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, BaseCommandResponse>
    {
        public Task<BaseCommandResponse> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
