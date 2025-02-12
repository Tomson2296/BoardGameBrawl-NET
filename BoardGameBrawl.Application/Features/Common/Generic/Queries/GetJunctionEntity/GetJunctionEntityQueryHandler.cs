using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Queries.GetJunctionEntity
{
    public abstract class GetJunctionEntityQueryHandler<TCommand, TEntityDTO, TEntity> : IRequestHandler<TCommand, TEntityDTO>
        where TCommand : IRequest<TEntityDTO>
        where TEntityDTO : class
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected GetJunctionEntityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TEntityDTO> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entityIds = GetCompositeIdsFromRequest(request);
            var repo = GetRepository(_unitOfWork);
            var entity = await repo.GetEntity(entityIds, cancellationToken);
            return _mapper.Map<TEntityDTO>(entity);
        }

        protected abstract object[] GetCompositeIdsFromRequest(TCommand request);
        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
    }
}
