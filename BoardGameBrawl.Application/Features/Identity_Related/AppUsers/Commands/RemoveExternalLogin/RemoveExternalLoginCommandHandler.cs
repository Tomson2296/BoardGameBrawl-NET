#nullable disable
using BoardGameBrawl.Application.Contracts.Entities.Identity_Related;
using BoardGameBrawl.Application.Exceptions;
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

        public async Task<BaseCommandResponse> Handle(RemoveExternalLoginCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = new BaseCommandResponse();

            try
            {
                var entityInDB = await _applicationUserQueryService.GetExternalLoginData(request.LoginProvider,
                   request.ProviderKey,
                   request.UserId,
                   cancellationToken);

                await _applicationUserCommandService.RemoveExternalLoginAsync(entityInDB, cancellationToken);

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = request.UserId;
                return response;
            }
            catch (NotFoundException ex)
            {
                response.Success = false;
                response.Message = "Removing Process Unsuccessful - " + ex.Message;
                response.Id = request.UserId;
                return response;
            }
        }
    }
}
