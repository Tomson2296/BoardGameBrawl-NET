using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Responses;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Commands.AddJunctionEntity
{
    public abstract class AddJunctionEntityCommandHandler<TCommand, TEntityDTO, TEntity, TEntityValidator> : IRequestHandler<TCommand, BaseCommandResponse>
        where TCommand : IRequest<BaseCommandResponse>
        where TEntityDTO : class
        where TEntity : class
        where TEntityValidator : AbstractValidator<TEntityDTO>, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected AddJunctionEntityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = new BaseCommandResponse();
            var dto = GetEntityDTOFromRequest(request);

            var validator = GetEntityValidator();
            var validationResult = await validator.ValidateAsync(dto, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Creation Failed",
                    Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList()
                };
            }
            else
            {
                var entity = _mapper.Map<TEntity>(dto);
                var repo = GetRepository(_unitOfWork);
                await repo.AddEntity(entity, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }

        protected abstract TEntityDTO GetEntityDTOFromRequest(TCommand request);

        protected abstract TEntityValidator GetEntityValidator();

        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
    }
}
