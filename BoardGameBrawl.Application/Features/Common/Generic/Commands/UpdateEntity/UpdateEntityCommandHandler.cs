using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = BoardGameBrawl.Application.Exceptions.ValidationException;

namespace BoardGameBrawl.Application.Features.Common.Commands.UpdateEntity
{
    public abstract class UpdateEntityCommandHandler<TCommand, TEntityDTO, TEntity, TEntityValidator> : IRequestHandler<TCommand, Unit>
        where TCommand : IRequest<Unit>
        where TEntityDTO : class
        where TEntity : class
        where TEntityValidator : AbstractValidator<TEntityDTO>, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected UpdateEntityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var dto = GetEntityDTOFromRequest(request);
            var repo = GetRepository(_unitOfWork);

            var validator = GetValidatorRequiringRepo(repo);
            var validationResult = await validator.ValidateAsync(dto);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var entity = _mapper.Map<TEntity>(dto);
                var entityId = GetEntityId(entity);
                var entityInDB = await repo.GetEntity(entityId, cancellationToken);

                if (entityInDB == null)
                {
                    throw new NotFoundException(nameof(entityInDB), entityId);
                }
                else
                {
                    await repo.UpdateEntity(entity, cancellationToken);
                    await _unitOfWork.CommitChangesAsync();
                    return Unit.Value;
                }
            }

        }

        protected abstract TEntityDTO GetEntityDTOFromRequest(TCommand request);

        protected abstract TEntityValidator GetEntityValidator();

        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);

        protected abstract TEntityValidator GetValidatorRequiringRepo(IGenericRepository<TEntity> repository);

        protected abstract Guid GetEntityId(TEntity entity);
    }
}