using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Queries.CheckIfEntityExists
{
    public abstract class CheckIfEntityExistsQueryHandler<TCommand, TEntityDTO, TEntity> : IRequestHandler<TCommand, bool>
        where TCommand : IRequest<bool>
        where TEntityDTO : class
        where TEntity : class
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        protected CheckIfEntityExistsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var dto = GetEntityDTOFromRequest(request);

            var entity = _mapper.Map<TEntity>(dto);
            var entityId = GetEntityId(entity);
            
            var repo = GetRepository(_unitofWork);
            return await repo.Exists(entityId, cancellationToken);
        }

        protected abstract TEntityDTO GetEntityDTOFromRequest(TCommand command);
        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
        protected abstract Guid GetEntityId(TEntity entity);
    }
}
