#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Commands.RemoveExternalLogin
{
    public class RemoveExternalLoginCommandHandler : IRequestHandler<RemoveExternalLoginCommand, BaseCommandResponse>
    {
        private readonly IApplicationUserQueryService _applicationUserQueryService;
        private readonly IApplicationUserCommandService _applicationUserCommandService;

        public RemoveExternalLoginCommandHandler(IApplicationUserQueryService applicationUserQueryService,
            IApplicationUserCommandService applicationUserCommandService)
        {
            _applicationUserQueryService = applicationUserQueryService;
            _applicationUserCommandService = applicationUserCommandService;
        }

        public Task<BaseCommandResponse> Handle(RemoveExternalLoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
