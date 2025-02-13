using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Validators.Group_Related.Groups;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var validator = new UpdateGroupValidator(_unitOfWork.GroupRepository);
            var validationResult = await validator.ValidateAsync(request.GroupDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var groupInDB = await _unitOfWork.GroupRepository.GetEntity(request.GroupDTO.Id);

                if (groupInDB == null)
                {
                    throw new NotFoundException(nameof(groupInDB), request.GroupDTO.Id);
                }
                else
                {
                    var group = _mapper.Map<BoardGameBrawl.Domain.Entities.Group_Related.Group>(request.GroupDTO);
                    await _unitOfWork.GroupRepository.UpdateEntity(group);
                    await _unitOfWork.CommitChangesAsync();
                    return Unit.Value;
                }
            }
        }
    }
}
