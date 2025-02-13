using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Group_Related.Groups;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Commands.AddGroup
{
    public class AddGroupCommandHandler : IRequestHandler<AddGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(AddGroupCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = new BaseCommandResponse();
            var validator = new AddGroupValidator(_unitOfWork.GroupRepository);
            var validationResult = await validator.ValidateAsync(request.GroupDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var groupObj = _mapper.Map<BoardGameBrawl.Domain.Entities.Group_Related.Group>(request.GroupDTO);

                await _unitOfWork.GroupRepository.AddEntity(groupObj);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = groupObj.Id;
            }

            return response;
        }
    }
}
