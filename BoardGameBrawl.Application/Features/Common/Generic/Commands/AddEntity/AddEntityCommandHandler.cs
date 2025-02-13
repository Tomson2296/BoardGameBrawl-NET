using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Features.Player_Related.PlayerPreferences.Queries.GetAllBGPreferencesChosenByPlayers;
using BoardGameBrawl.Application.Responses;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategories;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Commands.AddEntity
{
    public abstract class AddEntityCommandHandler<TCommand, TEntityDTO, TEntity, TEntityValidator> : IRequestHandler<TCommand, BaseCommandResponse>
        where TCommand : IRequest<BaseCommandResponse>
        where TEntity : class
        where TEntityDTO : class
        where TEntityValidator : AbstractValidator<TEntityDTO>, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected AddEntityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
                var entityId = GetEntityId(entity);

                var repo = GetRepository(_unitOfWork);
                await repo.AddEntity(entity, cancellationToken);
                await _unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = entityId;
            }

            return response;
        }

        protected abstract TEntityDTO GetEntityDTOFromRequest(TCommand request);

        protected abstract TEntityValidator GetEntityValidator();


        // when validator requires additional repository

        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);

        protected abstract TEntityValidator GetValidatorRequiringRepo();

        protected abstract Guid GetEntityId(TEntity entity);

    }
}