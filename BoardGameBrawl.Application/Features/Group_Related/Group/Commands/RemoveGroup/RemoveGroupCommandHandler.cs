using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using MediatR;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Commands.RemoveGroup
{
    public class RemoveGroupCommandHandler : IRequestHandler<RemoveGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveGroupCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var group = _mapper.Map<BoardGameBrawl.Domain.Entities.Group_Related.Group>(request.Id);

            var groupInDB = await _unitOfWork.GroupRepository.GetEntity(group.Id);

            if (groupInDB == null)
            {
                throw new NotFoundException(nameof(groupInDB), group.Id);
            }
            else
            {
                await _unitOfWork.GroupRepository.DeleteEntity(group);
                await _unitOfWork.CommitChangesAsync();
                return Unit.Value;
            }
        }
    }
}
