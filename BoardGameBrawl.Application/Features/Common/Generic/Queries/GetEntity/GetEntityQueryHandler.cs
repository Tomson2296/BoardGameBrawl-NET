using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Queries.GetEntity
{
    public abstract class GetEntityQueryHandler<TCommand, TEntityDTO, TEntity> : IRequestHandler<TCommand, TEntityDTO>
        where TCommand : IRequest<TEntityDTO>
        where TEntityDTO : class
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected GetEntityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TEntityDTO> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var entityId = GetIdFromRequest(request);
            var repo = GetRepository(_unitOfWork);
            var entity = await repo.GetEntity(entityId);
            return _mapper.Map<TEntityDTO>(entity);
        }

        protected abstract Guid GetIdFromRequest(TCommand request);
        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
    }
}
