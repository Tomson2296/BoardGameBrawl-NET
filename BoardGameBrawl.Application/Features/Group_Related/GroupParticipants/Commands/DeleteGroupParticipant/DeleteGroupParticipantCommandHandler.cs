using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.GroupParticipants.Commands.DeleteGroupParticipant
{
    public class DeleteGroupParticipantCommandHandler : IRequestHandler<DeleteGroupParticipantCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupParticipantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteGroupParticipantCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var groupParticipantInDB = await _unitOfWork.GroupParticipantRepository.GetGroupParticipantAsync(request.GroupId,
                request.PlayerId, cancellationToken);

            if (groupParticipantInDB == null)
            {
                response.Success = false;
                response.Message = "Removing Process Unsuccessful - Player not found";
                response.Id = Guid.NewGuid();
                return response;
            }
            else
            {
                await _unitOfWork.GroupParticipantRepository.DeleteEntity(groupParticipantInDB, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = Guid.NewGuid();
            }
            return response;
        }
    }
}
