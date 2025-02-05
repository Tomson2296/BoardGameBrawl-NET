using BoardGameBrawl.Application.Responses;
using MediatR;

namespace BoardGameBrawl.Application.Features.Identity_Related.AppUsers.Commands.RemoveExternalLogin
{
    public class RemoveExternalLoginCommand : IRequest<BaseCommandResponse>
    {
        public string? LoginProvider { get; set; }

        public string? ProviderKey { get; set; }

        public Guid UserId { get; set; }
    }
}
