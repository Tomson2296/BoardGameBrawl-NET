using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using BoardGameBrawl.Application.Exceptions;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Commands.DeleteEntity
{
    public abstract class DeleteEntityCommandHandler<TCommand, TEntity> : IRequestHandler<TCommand, BaseCommandResponse>
        where TCommand : IRequest<BaseCommandResponse>
        where TEntity : class
    {
        private readonly IUnitOfWork unitOfWork;

        protected DeleteEntityCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var response = new BaseCommandResponse();
            var entityId = GetEntityId(request);
            var repo = GetRepository(unitOfWork);

            var entityInDB = await repo.GetEntity(entityId, cancellationToken);

            if (entityInDB == null)
            {
                return new BaseCommandResponse
                {
                    Success = false,
                    Message = "Deletion process unsuccessful",
                    Id = entityId
                };
            }
            else
            {
                await repo.DeleteEntity(entityInDB, cancellationToken);
                await unitOfWork.CommitChangesAsync();

                response.Success = true;
                response.Message = "Removing Process Successful";
                response.Id = Guid.NewGuid();
            }

            return response;
        }

        protected abstract Guid GetEntityId(TCommand request);

        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
    }
}
